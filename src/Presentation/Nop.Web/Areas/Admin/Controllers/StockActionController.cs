using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Nop.Core;
using Nop.Core.Domain.Warehouses;
using Nop.Services.Catalog;
using Nop.Services.Common;
using Nop.Services.Localization;
using Nop.Services.Logging;
using Nop.Services.Messages;
using Nop.Services.Security;
using Nop.Services.Warehouses.Interface;
using Nop.Web.Areas.Admin.Factories.WarehouseFactories;
using Nop.Web.Areas.Admin.Models;
using Nop.Web.Areas.Admin.Models.Dtos;

namespace Nop.Web.Areas.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockActionController : ControllerBase
    {
        #region Fields

        private readonly IWorkContext _workContext;
        private readonly ICustomerActivityService _customerActivityService;
        private readonly ILocalizationService _localizationService;
        private readonly INotificationService _notificationService;
        private readonly IPermissionService _permissionService;
        private readonly IWarehouseProductService _warehouseProductService;
        private readonly IStockHistoryService _stockHistoryService;
        private readonly IStockRequestService _stockRequestService;
        private readonly IStockRequestItemService _stockRequestItemService;
        private readonly IWarehouseItemService _warehouseItemService;
        private readonly IAcceptStockRequestService _acceptStockRequestService;
        private readonly IStockItemHistoryService _stockItemHistoryService;
        private readonly IWarehouseProductCombinationService _warehouseProductCombinationService;
        private readonly IShelfService _shelfService;
        private readonly IProductService _productService;
        private readonly IShelfItemMappingService _shelfItemMappingService;
        private readonly IStockItemHistoryMappingService _stockItemHistoryMappingService;
        private readonly IWarehouseProductModelFactory _warehouseProductModelFactory;
        private readonly IStockHistoryModelFactory _stockHistoryModelFactory;
        private readonly IStockRequestModelFactory _stockRequestModelFactory;
        private readonly IAcceptStockRequestModelFactory _acceptStockRequestModelFactory;
        private readonly IPdfService _pdfService;


        #endregion

        #region Ctor

        public StockActionController(IWorkContext workContext,
            ICustomerActivityService customerActivityService,
            ILocalizationService localizationService,
            INotificationService notificationService,
            IPermissionService permissionService,
            IWarehouseProductService warehouseProductService,
            ICategoryService categoryService,
            IProductAttributeService productAttributeService,
            IStockRequestService stockRequestService,
            IStockRequestItemService stockRequestItemService,
            IWarehouseProductCombinationService warehouseProductCombinationService,
            IStockHistoryService stockHistoryService,
            IStockItemHistoryService stockItemHistoryService,
            IWarehouseItemService warehouseItemService,
            IAcceptStockRequestService acceptStockRequestService,
            IShelfService shelfService,
            IProductService productService,
            IPdfService pdfService,
            IShelfItemMappingService shelfItemMappingService,
            IStockItemHistoryMappingService stockItemHistoryMappingService,
            IWarehouseProductModelFactory warehouseProductModelFactory,
            IStockHistoryModelFactory stockHistoryModelFactory,
            IStockRequestModelFactory stockRequestModelFactory,
            IAcceptStockRequestModelFactory acceptStockRequestModelFactory)
        {
            _customerActivityService = customerActivityService;
            _localizationService = localizationService;
            _notificationService = notificationService;
            _permissionService = permissionService;
            _workContext = workContext;
            _warehouseProductModelFactory = warehouseProductModelFactory;
            _warehouseProductService = warehouseProductService;
            _warehouseProductCombinationService = warehouseProductCombinationService;
            _stockHistoryModelFactory = stockHistoryModelFactory;
            _stockHistoryService = stockHistoryService;
            _stockRequestService = stockRequestService;
            _stockRequestItemService = stockRequestItemService;
            _acceptStockRequestService = acceptStockRequestService;
            _shelfService = shelfService;
            _productService = productService;
            _pdfService = pdfService;
            _shelfItemMappingService = shelfItemMappingService;
            _stockItemHistoryMappingService = stockItemHistoryMappingService;
            _stockItemHistoryService = stockItemHistoryService;
            _warehouseItemService = warehouseItemService;
            _stockRequestModelFactory = stockRequestModelFactory;
            _acceptStockRequestModelFactory = acceptStockRequestModelFactory;
        }

        #endregion

        #region Utilities

        //Map items to shelf
        private async Task<IList<ShelfItemMapping>> ItemsMappedBefore(IList<WarehouseItem> items)
        {
            var itemsIds = items.Select(x => x.Id);
            var mappedShelfItems = await _shelfItemMappingService.GetShelfItemMappingByItemsIdsAsync(itemsIds);
            if (mappedShelfItems is null || !mappedShelfItems.Any())
                return null;
            return mappedShelfItems;
        }

        private async Task<ActionResult<BaseResponse>> ErrorBaseResponse(string localizationKey)
        {
            _notificationService.ErrorNotification(await _localizationService.GetResourceAsync(localizationKey));
            return new BaseResponse { Success = false };
        }

        private bool IsBarcodeAlreadyDamagedOrInvalidBefore(IEnumerable<WarehouseItem> warehouseItems)
        {
            foreach (var item in warehouseItems)
            {
                if (item.Damaged || item.Ordered || item.Deleted)
                    return true;
            }
            return false;
        }

        private bool IsItemValidForLinkingToShelf(WarehouseItem warehouseItem)
        {
            //the item must be scanned and not damaged or ordered to be linked.
            if (warehouseItem.Scanned && !warehouseItem.ReturnedToVendor && !warehouseItem.Ordered  && !warehouseItem.Deleted)
                return true;
            
            return false;
        }

        private void MarkItemsAsScanned(IEnumerable<WarehouseItem> warehouseItems)
        {
            foreach (var item in warehouseItems)
            {
                item.Scanned = true;
                item.ItemStatus = (int)ItemStatus.Scanned;
                item.UpdatedOnUtc = DateTime.UtcNow;
            }
        }

        private async Task IncrementWarehouseProductCombinationStockQuantity(IList<WarehouseItem> warehouseItems)
        {
            // Key: WarehouseProductCombinationId, Value: count of received items related to this combination.

            var itemsCounter = new Dictionary<int, int>();
            foreach (var warehouseItem in warehouseItems)
            {
                //increment the counter
                if (itemsCounter.ContainsKey(warehouseItem.WarehouseProductCombinationId))
                {
                    itemsCounter[warehouseItem.WarehouseProductCombinationId] += 1;
                }
                else
                {
                    itemsCounter[warehouseItem.WarehouseProductCombinationId] = 1;
                }
            }

            //get the product combinations to modify the quantities
            var warehouseProductCombinations = await _warehouseProductCombinationService.GetWarehouseProductCombinationByIdsAsync(itemsCounter.Keys.ToArray());
            foreach (var warehouseProductCombination in warehouseProductCombinations)
            {
                //adding the received quantities to the available quantity
                warehouseProductCombination.TotalQuantity += itemsCounter[warehouseProductCombination.Id];
                warehouseProductCombination.Available = true;
            }

            //updating the database
            await _warehouseItemService.UpdateWarehouseItemAsync(warehouseItems);
            await _warehouseProductCombinationService.UpdateWarehouseProductCombinationAsync(warehouseProductCombinations);
        }

        // If the result is false, change the borders of the scanned barcode to red and disable scanning button
        // If the result is true and all scanned barcodes return true from this method enable scanning button and change borders to green
        public async Task<bool> AreReceivedBarcodeValid(IEnumerable<WarehouseItem> warehouseItems)
        {
            foreach (var item in warehouseItems)
            {
                if (item is null || item.Deleted)
                {
                    _notificationService.ErrorNotification(await _localizationService.GetResourceAsync("Admin.Warehouses.Barcode.InValid"));
                    return false;
                }

                if (IsBarcodeAlreadyScannedBefore(item))
                {
                    _notificationService.ErrorNotification(await _localizationService.GetResourceAsync("Admin.Warehouses.Barcode.ItemScannedBefore"));
                    return false;
                }
            }
            
            return true;
        }

        private bool IsBarcodeAlreadyScannedBefore(WarehouseItem warehouseItem)
        {
            if (warehouseItem.Scanned)
                return true;
            return false;
        }

        #endregion
       
        #region APIs

        [HttpPost("ScanReturnedToVendorItems")]
        public async Task<ActionResult<BaseResponse>> ScanReturnedToVendorItems([FromQuery] int stockItemHistoryId, [FromBody] List<string> barcodes)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
                throw new Exception("Not Allowed.");

            //get all items using their barcodes.
            var warehouseItems = await _warehouseItemService.GetWarehouseItemsByBarcodesAsync(barcodes);
            if (warehouseItems is null || !warehouseItems.Any() || barcodes.Count != warehouseItems.Count)
                return await ErrorBaseResponse("Admin.Warehouses.ScanDamaged.NotValidItemsToScan");

            //entered quantity
            var itemsCountToBeReturned = warehouseItems.Count;
            //get allowed quantity to be returned.
            var stockItemHistory = await _stockItemHistoryService.GetStockItemHistoryByIdAsync(stockItemHistoryId);

            //get the product combination to modify the quantities
            var warehouseProductCombination = await _warehouseProductCombinationService.GetWarehouseProductCombinationByIdAsync(stockItemHistory.WarehouseProductCombinationId);

            if (warehouseItems.Any(x => x.WarehouseProductCombinationId != warehouseProductCombination.Id))
                return await ErrorBaseResponse("Admin.Warehouses.ScanDamaged.NotValidItemsToScan");

            //get quantity already returned.
            var mappedStockItemHistory = await _stockItemHistoryMappingService.GetStockItemHistoryMappingByStockItemHistoryIdAsync(stockItemHistoryId);
            var alreadyReturnedItemsCount = mappedStockItemHistory?.Count ?? 0;
            // stock quantity      =           returned        +    entered
            var returnableQuantity = alreadyReturnedItemsCount + itemsCountToBeReturned;

            if (stockItemHistory.StockQuantity < returnableQuantity)
            {
                _notificationService.ErrorNotification(string.Format(await _localizationService.GetResourceAsync("Admin.Warehouses.ScanReturnedToVendor.YouTryToReturnQuantityMoreThanAllowed"), stockItemHistory.StockQuantity, alreadyReturnedItemsCount, (stockItemHistory.StockQuantity - alreadyReturnedItemsCount)));
                return new BaseResponse { Success = false };
            }

            //Subtracting the returned to vendor quantity from the available quantity
            warehouseProductCombination.TotalQuantity -= itemsCountToBeReturned;
            if (warehouseProductCombination.TotalQuantity < 0)
                return await ErrorBaseResponse("Admin.Warehouses.ScanReturnedToVendor.ImpossibleToHaveNegativeQuantity");

            //Adding the returned to vendor quantity to its quantity field
            warehouseProductCombination.ReturnedToVendorQuantity += itemsCountToBeReturned;

            //linking items to the stock item history
            var mappedStockItemHistoryForBulkInsertion = warehouseItems.Select(x => new StockItemHistoryMapping
            {
                StockItemHistoryId = stockItemHistoryId,
                WarehouseItemId = x.Id,
                ProcessType = StockProcess.ReturnedToVendor,
                CreatedOnUtc = DateTime.UtcNow
            }).ToList();

            //updating the database
            await _warehouseItemService.UpdateWarehouseItemAsync(warehouseItems);
            await _stockItemHistoryMappingService.InsertStockItemHistoryMappingAsync(mappedStockItemHistoryForBulkInsertion);
            await _warehouseProductCombinationService.UpdateWarehouseProductCombinationAsync(warehouseProductCombination);

            return new BaseResponse() { Success = true };
        }

        [HttpPost("ScanReceivedItems")]
        public async Task<ActionResult<BaseResponse>> ScanReceivedItems([FromBody] List<string> itemsBarcodes)
        {
            //get warehouse item
            var warehouseItems = await _warehouseItemService.GetWarehouseItemsByBarcodesAsync(itemsBarcodes);

            if (warehouseItems is null || !warehouseItems.Any())
                return await ErrorBaseResponse("Admin.Warehouses.Barcode.SomethingWrongInBarcodes");

            var areReceivedBarcodeValid = await AreReceivedBarcodeValid(warehouseItems);
            if (!areReceivedBarcodeValid)
                return new BaseResponse { Success = false };

            //scanning the items
            MarkItemsAsScanned(warehouseItems);

            //incrementing the quantity of the combination
            await IncrementWarehouseProductCombinationStockQuantity(warehouseItems);
            _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Warehouses.Barcode.ScanSuccess"));
            return new BaseResponse { Success = true };
        }

        [HttpPost("MapItemToShelf")]
        public async Task<ActionResult<BaseResponse>> MapItemToShelf([FromQuery] string shelfBarcode, [FromBody] List<string> itemsBarcodes)
        {
            //get shelf
            var shelf = await _shelfService.GetShelfByBarcodeAsync(shelfBarcode);
            if (shelf is null || shelf.Deleted)
                return await ErrorBaseResponse("Admin.Warehouses.MapItemToShelf.shelfNotFound");

            if (!shelf.Active)
                return await ErrorBaseResponse("Admin.Warehouses.MapItemToShelf.shelfInactive");

            //get warehouse items
            var items = await _warehouseItemService.GetWarehouseItemsByBarcodesAsync(itemsBarcodes);
            if (items is null || !items.Any())
                return await ErrorBaseResponse("Admin.Warehouses.MapItemToShelf.itemsNotFound");

            var currentUser = await _workContext.GetCurrentCustomerAsync();

            //the item must be scanned and not damaged or ordered to be linked.
            foreach (var item in items)
            {
                if (!IsItemValidForLinkingToShelf(item))
                    return await ErrorBaseResponse("Admin.Warehouses.MapItemToShelf.ItemNotReadyToLink");

                item.MappedToShelf = true;
                item.UpdatedBy = currentUser.Id;
                item.UpdatedOnUtc = DateTime.UtcNow;
            }
            

            //check if the items are linked to a shelf already (if linked delete the existing map)
            var deletableMappings = await ItemsMappedBefore(items);
            if (deletableMappings != null && deletableMappings.Any())
            {
                foreach (var item in deletableMappings)
                {
                    item.UpdatedOnUtc = DateTime.UtcNow;
                    item.UpdatedBy = currentUser.Id;
                }
                await _shelfItemMappingService.DeleteShelfItemMappingAsync(deletableMappings);
            }

            //map items to a shelf
            var shelfItemMappingsForBulkInsertion = items.Select(x => new ShelfItemMapping
            {
                ShelfId = shelf.Id,
                ItemId = x.Id,
                CreatedOnUtc = DateTime.UtcNow,
                UpdatedOnUtc = DateTime.UtcNow,
                CreatedBy = currentUser.Id,
                UpdatedBy = currentUser.Id
            }).ToList();
            await _shelfItemMappingService.InsertShelfItemMappingAsync(shelfItemMappingsForBulkInsertion);
            await _warehouseItemService.UpdateWarehouseItemAsync(items);

            _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Warehouses.Barcode.ScanSuccess"));
            return new BaseResponse { Success = true };
        }

        [HttpPost("ScanDamagedItems")]
        public async Task<ActionResult<BaseResponse>> ScanDamagedItems([FromBody] List<string> barcodes)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
                throw new Exception("Not Allowed.");

            //get all items using their barcodes.
            var warehouseItems = await _warehouseItemService.GetWarehouseItemsByBarcodesAsync(barcodes);
            if (warehouseItems == null || !warehouseItems.Any())
                return await ErrorBaseResponse("Admin.Warehouses.ScanDamaged.NotValidItemsToScan");

            if (IsBarcodeAlreadyDamagedOrInvalidBefore(warehouseItems))
                return await ErrorBaseResponse(await _localizationService.GetResourceAsync("Admin.Warehouses.Barcode.NotValidItemsToScan"));

            // Key: WarehouseProductCombinationId, Value: int[2] count of damaged items related to this combination.
            /*
             * We have two cases:
             * case 1: [0]
             * the items have not been scanned in our system, so we will not subtract them from the available quantity
             * case 2: [1]
             * the items have been scanned in our system, so we will subtract them from the available quantity
             * 
             * notice that: in both of cases we will add it to the damaged quantity
             */
            var damagedItemsCounter = new Dictionary<int, int[]>();
            foreach (var warehouseItem in warehouseItems)
            {
                warehouseItem.Damaged = true;
                warehouseItem.ItemStatus = (int)ItemStatus.Damaged;

                //increment the counter
                if (damagedItemsCounter.ContainsKey(warehouseItem.WarehouseProductCombinationId))
                {
                    if (warehouseItem.Scanned)
                    {
                        //for damaged quantiity
                        damagedItemsCounter[warehouseItem.WarehouseProductCombinationId][0] += 1;
                        //for total quantity
                        damagedItemsCounter[warehouseItem.WarehouseProductCombinationId][1] += 1;
                    }
                    else
                    {
                        //for damaged quantiity
                        damagedItemsCounter[warehouseItem.WarehouseProductCombinationId][0] += 1;
                    }
                }
                else
                {
                    damagedItemsCounter[warehouseItem.WarehouseProductCombinationId] = new int[2];
                    if (warehouseItem.Scanned)
                    {
                        //for damaged quantiity
                        damagedItemsCounter[warehouseItem.WarehouseProductCombinationId][0] = 1;
                        //for total quantity
                        damagedItemsCounter[warehouseItem.WarehouseProductCombinationId][1] = 1;
                    }
                    else
                    {
                        //for damaged quantiity
                        damagedItemsCounter[warehouseItem.WarehouseProductCombinationId][0] = 1;
                        //for total quantity
                        damagedItemsCounter[warehouseItem.WarehouseProductCombinationId][1] = 0;
                    }
                }
            }

            //get the product combinations to modify the quantities
            var warehouseProductCombinations = await _warehouseProductCombinationService.GetWarehouseProductCombinationByIdsAsync(damagedItemsCounter.Keys.ToArray());
            foreach (var warehouseProductCombination in warehouseProductCombinations)
            {
                //Subtracting the damaged quantity from the available quantity
                warehouseProductCombination.TotalQuantity -= damagedItemsCounter[warehouseProductCombination.Id][1];
                if (warehouseProductCombination.TotalQuantity < 0)
                    return await ErrorBaseResponse("Admin.Warehouses.ScanDamaged.ImpossibleToHaveNegativeQuantity");
                //Adding the damaged quantity to its total quantity
                warehouseProductCombination.DamagedQuantity += damagedItemsCounter[warehouseProductCombination.Id][0];
            }

            //updating the database
            await _warehouseItemService.UpdateWarehouseItemAsync(warehouseItems);
            await _warehouseProductCombinationService.UpdateWarehouseProductCombinationAsync(warehouseProductCombinations);
            _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Warehouses.Barcode.ScanSuccess"));
            return new BaseResponse() { Success = true };
        }


        [HttpPost("GetUnprintedBarcodes")]
        public async Task<dynamic> GetUnprintedBarcodes([FromQuery] int warehouseId, [FromQuery] string sku, [FromQuery] int quantity)
        {
            var warehouseItems = await _warehouseItemService.GetUnPrintedWarehouseItemsBarcodesAsync(warehouseId, sku, quantity);

            if (!warehouseItems.Any())
                return NotFound();

            var combination = await _warehouseProductCombinationService.GetWarehouseProductCombinationByIdAsync(warehouseItems.FirstOrDefault().WarehouseProductCombinationId);
            var warehouseProduct = await _warehouseProductService.GetWarehouseProductByIdAsync(combination.WarehouseProductId);
            //change item status to printed
            foreach (var item in warehouseItems)
            {
                item.Printed = true;
                item.ItemStatus = (int)ItemStatus.Printed;
                item.UpdatedOnUtc = DateTime.UtcNow;
            }

            byte[] pdfBytes = _pdfService.GenerateBarcodePdf(warehouseItems, warehouseProduct.Name, combination.AttributesXml);

            if (pdfBytes == null || pdfBytes.Length == 0)
                return NotFound("PDF could not be generated.");

            await _warehouseItemService.UpdateWarehouseItemAsync(warehouseItems);
            return File(pdfBytes, "application/pdf", $"barcodes_{sku}_{quantity}_{DateTime.Now.Ticks}.pdf");
        }

        #endregion



    }
}
