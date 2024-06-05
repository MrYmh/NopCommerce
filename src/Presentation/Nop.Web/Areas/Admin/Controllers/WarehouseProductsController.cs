using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Warehouses;
using Nop.Services.Catalog;
using Nop.Services.Localization;
using Nop.Services.Logging;
using Nop.Services.Messages;
using Nop.Services.Security;
using Nop.Services.Warehouses;
using Nop.Services.Warehouses.Interface;
using Nop.Web.Areas.Admin.Factories.WarehouseFactories;
using Nop.Web.Areas.Admin.Infrastructure.Mapper.Extensions;
using Nop.Web.Areas.Admin.Models.Warehouses;

namespace Nop.Web.Areas.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseProductsController : ControllerBase
    {
        private readonly IWarehouseProductService _warehouseProductService;
       // private readonly IWarehouseProductCombinationService _warehouseProductCombinationService;
        private readonly IWarehouseProductCategoryMappingService _warehouseProductCategoryMappingService;
        private readonly IProductService _productService;
        private readonly IWorkContext _workContext;
        private readonly IPermissionService _permissionService;
        private readonly IAcceptStockRequestService _acceptStockRequestService;
        private readonly IStockRequestService _stockRequestService;
        private readonly IStockRequestItemService _stockRequestItemService;
        private readonly ICustomerActivityService _customerActivityService;
        private readonly ILocalizationService _localizationService;
        private readonly IStockHistoryService _stockHistoryService;
        private readonly INotificationService _notificationService;
        private readonly IStockItemHistoryService _stockItemHistoryService;
        private readonly IWarehouseItemService _warehouseItemService;
        private readonly IProductAttributeService _productAttributeService;
        private readonly IProductAttributeParser _productAttributeParser;
        private readonly IWarehouseProductCombinationService _warehouseProductCombinationService;
        private readonly IStockHistoryModelFactory _stockHistoryModelFactory;

        private readonly IStockItemHistoryMappingService _stockItemHistoryMappingService;


        public WarehouseProductsController(
            IWarehouseProductService wps , 
            IWarehouseProductCategoryMappingService wpcms,
            IProductService ps,
            IWorkContext workContext,
        IPermissionService permissionService,
        IAcceptStockRequestService acceptStockRequestService,
        IStockRequestService stockRequestService,
        IStockRequestItemService stockRequestItemService,
        ICustomerActivityService customerActivityService,
        ILocalizationService localizationService,
        IStockHistoryService stockHistoryService,
        INotificationService notificationService,
        IStockItemHistoryService stockItemHistoryService,
        IWarehouseItemService warehouseItemService,
        IWarehouseProductCombinationService warehouseProductCombinationService,
        IProductAttributeService productAttributeService,
        IProductAttributeParser productAttributeParser,
        IStockItemHistoryMappingService stockItemHistoryMappingService,
        IStockHistoryModelFactory stockHistoryModelFactory)

        {
            _warehouseProductService = wps;
            _warehouseProductCategoryMappingService = wpcms;
            _productService = ps;
            _workContext = workContext;
            _permissionService = permissionService;
            _acceptStockRequestService = acceptStockRequestService;
            _stockRequestService = stockRequestService;
            _stockRequestItemService = stockRequestItemService;
            _customerActivityService = customerActivityService;
            _localizationService = localizationService;
            _stockHistoryService = stockHistoryService;
            _notificationService = notificationService;
            _stockItemHistoryService = stockItemHistoryService;
            _warehouseItemService = warehouseItemService;
            _warehouseProductCombinationService = warehouseProductCombinationService;
            _productAttributeService = productAttributeService;
            _productAttributeParser = productAttributeParser;
            _stockItemHistoryMappingService = stockItemHistoryMappingService;
            _stockHistoryModelFactory = stockHistoryModelFactory;
        }


        private async Task<IList<WarehouseProductCombination>> PrepareWarehouseProductCombinations(IList<ProductAttributeCombination> productAttributeCombinations, WarehouseProduct warehouseProduct, Customer currentUser)
        {
            return await productAttributeCombinations.SelectAwait(async x => new WarehouseProductCombination
            {
                WarehouseId = warehouseProduct.WarehouseId,
                WarehouseProductId = warehouseProduct.Id,
                CombinationId = x.Id,
                AttributesXml = await _productAttributeParser.ConvertAttributesToString(x.AttributesXml),
                TotalQuantity = 0,
                Sku = x.Sku,
                Available = false, //just added to the warehouse system but not available yet.
                CreatedOnUtc = DateTime.UtcNow,
                CreatedBy = currentUser.Id
            }).ToListAsync();
        }

        private async Task PrepareAndInsertReceivedStockItemsHistory(StockHistory stockHistory, IList<StockItemHistoryModel> stockItems, int currentUserId)
        {
            try
            {
                if (stockItems.Any())
                {
                    var stockItemHistoriesForBulkInsert = new List<StockItemHistory>();
                    foreach (var stockItem in stockItems)
                    {
                        stockItem.StockHistoryId = stockHistory.Id;
                        stockItem.CreatedOnUtc = DateTime.UtcNow;
                        stockItem.CreatedBy = currentUserId;
                        stockItemHistoriesForBulkInsert.Add(stockItem.ToEntity<StockItemHistory>());
                    }

                    //to be removed 
                    var exx = stockItemHistoriesForBulkInsert;
                    //Console.WriteLine(exx);
                    await _stockItemHistoryService.InsertStockItemHistoryAsync(stockItemHistoriesForBulkInsert);

                    //Warehouse Items
                    await PrepareAndInsertWarehouseItems(stockItemHistoriesForBulkInsert, stockHistory.WarehouseId);
                    foreach (var stockItemHistory in stockItemHistoriesForBulkInsert)
                    {
                        //activity log
                        await _customerActivityService.InsertActivityAsync("AddNewStockItemHistory",
                            string.Format(await _localizationService.GetResourceAsync("ActivityLog.AddNewStockItemHistory"), stockItemHistory.Id), stockItemHistory);
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        private List<WarehouseItem> PrepareWarehouseItemsForCreation(StockItemHistory stockItemHistory, int warehouseId)
        {
            if (stockItemHistory.StockQuantity <= 0)
                return null;

            return Enumerable.Range(0, stockItemHistory.StockQuantity).Select(_ => new WarehouseItem
            {
                WarehouseId = warehouseId,
                WarehouseProductCombinationId = stockItemHistory.WarehouseProductCombinationId,
                Sku = stockItemHistory.Sku,
                ItemStatus = (int)ItemStatus.Received,
                Received = true,
                HasExpirationDate = stockItemHistory.HasExpirationDate,
                ExpirationDate = stockItemHistory.ExpirationDate,
                CreatedOnUtc = DateTime.UtcNow,
                CreatedBy = stockItemHistory.CreatedBy

            }).ToList();
        }

        private List<WarehouseItem> PrepareWarehouseItemsForCreation(StockItemHistory stockItemHistory, int warehouseId, int quantity)
        {
            if (quantity <= 0)
                return null;

            return Enumerable.Range(0, quantity).Select(_ => new WarehouseItem
            {
                WarehouseId = warehouseId,
                WarehouseProductCombinationId = stockItemHistory.WarehouseProductCombinationId,
                Sku = stockItemHistory.Sku,
                ItemStatus = (int)ItemStatus.Received,
                Received = true,
                HasExpirationDate = stockItemHistory.HasExpirationDate,
                ExpirationDate = stockItemHistory.ExpirationDate,
                CreatedOnUtc = DateTime.UtcNow,
                CreatedBy = stockItemHistory.CreatedBy

            }).ToList();
        }

        private async Task PrepareAndInsertWarehouseItems(IEnumerable<StockItemHistory> stockItemHistory, int warehouseId)
        {
            try
            {
                //adding warehouse items
                var warehouseItems = new List<WarehouseItem>();
                foreach (var stockItem in stockItemHistory)
                {
                    var preparedWarehouseItems = PrepareWarehouseItemsForCreation(stockItem, warehouseId);
                    if (preparedWarehouseItems != null)
                        warehouseItems.AddRange(preparedWarehouseItems);
                }

                if (warehouseItems is null || !warehouseItems.Any())
                    return;

                await _warehouseItemService.InsertWarehouseItemAsync(warehouseItems);
                //updating warehouse items barcodes
                foreach (var warehouseItem in warehouseItems)
                {
                    warehouseItem.Barcode = $"{warehouseItem.WarehouseId}-{Base36Converter.DecimalToBase36(warehouseItem.Id)}-{warehouseItem.WarehouseProductCombinationId}";
                    warehouseItem.UpdatedOnUtc = DateTime.UtcNow;
                    warehouseItem.UpdatedBy = warehouseItem.CreatedBy;
                }
                await _warehouseItemService.UpdateWarehouseItemAsync(warehouseItems);

                //adding stock item history mapping records
                var mappedItemsGroups = warehouseItems.GroupBy(x => x.WarehouseProductCombinationId);
                var mappedStockItemHistories = new List<StockItemHistoryMapping>();
                foreach (var group in mappedItemsGroups)
                {
                    var stockItemHistoryId = stockItemHistory.FirstOrDefault(x => x.WarehouseProductCombinationId == group.Key).Id;
                    mappedStockItemHistories.AddRange(group.Select(x => new StockItemHistoryMapping
                    {
                        StockItemHistoryId = stockItemHistoryId,
                        WarehouseItemId = x.Id,
                        ProcessType = StockProcess.Receiving,
                        CreatedOnUtc = DateTime.UtcNow
                    }));
                }
                await _stockItemHistoryMappingService.InsertStockItemHistoryMappingAsync(mappedStockItemHistories);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private async Task CreateReceivedStock(StockHistoryModel model, Customer currentUser)
        {
            //Stock History
            model.CreatedOnUtc = DateTime.UtcNow;
            model.CreatedBy = currentUser.Id;
            var stockHistory = model.ToEntity<StockHistory>();
            await _stockHistoryService.InsertStockHistoryAsync(stockHistory);

            //Stock Items History
            await PrepareAndInsertReceivedStockItemsHistory(stockHistory, model.StockItems, currentUser.Id);

            //activity log
            await _customerActivityService.InsertActivityAsync("AddNewStockHistory",
                string.Format(await _localizationService.GetResourceAsync("ActivityLog.AddNewStockHistory"), stockHistory.Id), stockHistory);

            _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Warehouses.StockHistory.Added"));
        }

        private async Task CreateReturnedToVendorStock(StockHistoryModel model, Customer currentUser)
        {
            try
            {
                //Stock History
                model.CreatedOnUtc = DateTime.UtcNow;
                model.CreatedBy = currentUser.Id;
                var stockHistory = model.ToEntity<StockHistory>();
                await _stockHistoryService.InsertStockHistoryAsync(stockHistory);

                //Stock Items History
                await PrepareAndInsertReturnedStockItemsHistory(stockHistory, model.StockItems, currentUser.Id);

                //activity log
                await _customerActivityService.InsertActivityAsync("AddNewReturnedStockHistory",
                    string.Format(await _localizationService.GetResourceAsync("ActivityLog.AddNewReturnedStockHistory"), stockHistory.Id), stockHistory);

                _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Warehouses.StockHistory.Added"));
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private async Task PrepareAndInsertReturnedStockRequestItems(StockRequest stockRequest, IList<StockRequestItemModel> stockRequestItems, int currentUserId)
        {
            if (stockRequestItems.Any())
            {
                var stockRequestItemsForBulkInsert = new List<StockRequestItem>();
                foreach (var requestItem in stockRequestItems)
                {
                    requestItem.StockRequestId = stockRequest.Id;
                    requestItem.CreatedOnUtc = DateTime.UtcNow;
                    requestItem.CreatedBy = currentUserId;
                    var stockRequestItem = requestItem.ToEntity<StockRequestItem>();
                    stockRequestItemsForBulkInsert.Add(stockRequestItem);
                }
                await _stockRequestItemService.InsertStockRequestItemAsync(stockRequestItemsForBulkInsert);
                foreach (var stockRequestItem in stockRequestItemsForBulkInsert)
                {
                    //activity log
                    await _customerActivityService.InsertActivityAsync("AddNewStockRequestItem",
                        string.Format(await _localizationService.GetResourceAsync("ActivityLog.AddNewStockRequestItem"), stockRequestItem.Id), stockRequestItem);
                }
            }
        }

        private async Task PrepareAndInsertReceivedStockRequestItems(StockRequest stockRequest, IList<StockRequestItemModel> stockRequestItems, int currentUserId)
        {
            try
            {
                if (stockRequestItems.Any())
                {
                    var stockRequestItemsForBulkInsert = new List<StockRequestItem>();
                    foreach (var stockRequestItem in stockRequestItems)
                    {
                        stockRequestItem.StockRequestId = stockRequest.Id;
                        stockRequestItem.CreatedOnUtc = DateTime.UtcNow;
                        stockRequestItem.CreatedBy = currentUserId;
                        stockRequestItemsForBulkInsert.Add(stockRequestItem.ToEntity<StockRequestItem>());
                    }
                    await _stockRequestItemService.InsertStockRequestItemAsync(stockRequestItemsForBulkInsert);

                    foreach (var stockRequestItem in stockRequestItemsForBulkInsert)
                    {
                        //activity log
                        await _customerActivityService.InsertActivityAsync("AddNewStockRequestItem",
                            string.Format(await _localizationService.GetResourceAsync("ActivityLog.AddNewStockRequestItem"), stockRequestItem.Id), stockRequestItem);
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        private async Task PrepareAndInsertReturnedStockItemsHistory(StockHistory stockHistory, IList<StockItemHistoryModel> stockItems, int currentUserId)
        {
            if (stockItems.Any())
            {
                var stockItemHistoriesForBulkInsert = new List<StockItemHistory>();
                foreach (var stockItem in stockItems)
                {
                    stockItem.StockHistoryId = stockHistory.Id;
                    stockItem.CreatedOnUtc = DateTime.UtcNow;
                    stockItem.CreatedBy = currentUserId;
                    var stockItemHistory = stockItem.ToEntity<StockItemHistory>();
                    stockItemHistoriesForBulkInsert.Add(stockItemHistory);
                }
                await _stockItemHistoryService.InsertStockItemHistoryAsync(stockItemHistoriesForBulkInsert);
                foreach (var stockItemHistory in stockItemHistoriesForBulkInsert)
                {
                    //activity log
                    await _customerActivityService.InsertActivityAsync("AddNewReturnedStockItemHistory",
                        string.Format(await _localizationService.GetResourceAsync("ActivityLog.AddNewReturnedStockItemHistory"), stockItemHistory.Id), stockItemHistory);
                }
            }
        }

        private void RefreshWarehouseProductData(WarehouseProduct warehouseProduct, Product product)
        {
            warehouseProduct.Name = product.Name;
            warehouseProduct.Sku = product.Sku;
            warehouseProduct.FullDescription = product.FullDescription;
            warehouseProduct.ShortDescription = product.ShortDescription;
            warehouseProduct.UpdatedOnUtc = DateTime.UtcNow;
        }
        private async Task PrepareAndInsertWarehouseItems(StockItemHistory stockItemHistory, int warehouseId, int quantity)
        {
            var warehouseItems = PrepareWarehouseItemsForCreation(stockItemHistory, warehouseId, quantity);
            if (warehouseItems is null)
                return;


            await _warehouseItemService.InsertWarehouseItemAsync(warehouseItems);
            foreach (var warehouseItem in warehouseItems)
            {
                warehouseItem.Barcode = $"{warehouseItem.WarehouseId}-{Base36Converter.DecimalToBase36(warehouseItem.Id)}-{warehouseItem.WarehouseProductCombinationId}";
                warehouseItem.UpdatedOnUtc = DateTime.UtcNow;
                warehouseItem.UpdatedBy = warehouseItem.CreatedBy;
            }
            await _warehouseItemService.UpdateWarehouseItemAsync(warehouseItems);

            //adding stock item history mapping records
            var mappedStockItemHistories = warehouseItems.Select(x => new StockItemHistoryMapping
            {
                StockItemHistoryId = stockItemHistory.Id,
                WarehouseItemId = x.Id,
                ProcessType = StockProcess.Receiving,
                CreatedOnUtc = DateTime.UtcNow
            }).ToList();
            await _stockItemHistoryMappingService.InsertStockItemHistoryMappingAsync(mappedStockItemHistories);
        }


        [HttpGet("GetProductsByCategoryMappingId")]
        public async Task<List<WarehouseProductDto>> GetProductsByCategoryMappingId([FromQuery]int warehouseCategoryMappingId)
        {
            try
            {
                //get product categories mapped to this warehouse category
                var mappedWarehouseProductCategories = await _warehouseProductCategoryMappingService.GetWarehouseProductCategoryMappingByWarehouseCategoryMappingIdAsync(warehouseCategoryMappingId);

                var productCategoriesIds = mappedWarehouseProductCategories.Select(x => x.ProductCategoryId);
                if (productCategoriesIds is null || !productCategoriesIds.Any())
                    return null;

                //get all products related to the retrieved product categories
                var products = await _productService.GetProductsByCategoryIdsAsync(productCategoriesIds);
                if (products is null || !products.Any())
                    return null;

                var warehouseProductCategoryMappingIds = mappedWarehouseProductCategories.Select(x => x.Id);

                //get mapped products to the warehouse
                var mappedProductsIds = await _warehouseProductService.GetProductsIdsByWarehouseProductCategoryMappingIdsAsync(warehouseProductCategoryMappingIds);

                //remove all mapped products from the final products' list
                var filteredProducts = products.Where(x => !mappedProductsIds.Contains(x.Id));

                return filteredProducts.Select(x => x.ToModel<WarehouseProductDto>()).ToList();
            }
            catch (System.Exception ex)
            {

                throw;
            }
        }


        [HttpPost("CreateAcceptStockRequest")]
        public async Task<IActionResult> CreateAcceptStockRequest([FromBody] AcceptStockRequestModel model, int warehouseId)
        {

            var currentUser = await _workContext.GetCurrentCustomerAsync();

            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
                return StatusCode(403, new { message = "Access Denied" });

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var acceptStockRequest = model.ToEntity<AcceptStockRequest>();
            acceptStockRequest.CreatedOnUtc = DateTime.UtcNow;
            acceptStockRequest.UpdatedOnUtc = DateTime.UtcNow;
            acceptStockRequest.CreatedBy = currentUser.Id;

            if (model.Accepted)
            {
                var stockRequest = await _stockRequestService.GetStockRequestByIdAsync(model.StockRequestId);
                var stockHistoryModel = stockRequest.ToModel<StockHistoryModel>();
                stockHistoryModel.StockItems = new List<StockItemHistoryModel>();

                var requestItems = await _stockRequestItemService.GetAllStockRequestItemsAsync(model.StockRequestId);
                foreach (var item in requestItems)
                {
                    stockHistoryModel.StockItems.Add(item.ToModel<StockItemHistoryModel>());
                }

                switch (model.RequestType)
                {
                    case StockProcess.Receiving:
                        await CreateReceivedStock(stockHistoryModel, currentUser);
                        break;
                    case StockProcess.ReturnedToVendor:
                        await CreateReturnedToVendorStock(stockHistoryModel, currentUser);
                        break;
                }
            }

            await _acceptStockRequestService.InsertAcceptStockRequestAsync(acceptStockRequest);

            await _customerActivityService.InsertActivityAsync("AddNewAcceptStockRequest",
                string.Format(await _localizationService.GetResourceAsync("ActivityLog.AddNewAcceptStockRequest"), acceptStockRequest.Id), acceptStockRequest);

            return Ok(new { message = "Accept stock request processed successfully", id = acceptStockRequest.Id });
        }

        [HttpPost("UpdateWarehouseProductCombinations")]
        public async Task<IActionResult> UpdateWarehouseProductCombinations([FromQuery]int warehouseProductId, [FromQuery]int warehouseId)
        {
            if (warehouseId <= 0)
                return BadRequest();

            //TODO: ADD LOGIC TO VALIDATE IF THE USER IS ALLOWED TO ENTER THIS SPECIFIC WAREHOUSE
            var currentUser = await _workContext.GetCurrentCustomerAsync();
            //if (!IsUserAllowedToAccessWarehouse(warehouseId, currentUser.Id))
            //    return AccessDeniedView();

            //refresh product
            var warehouseProduct = await _warehouseProductService.GetWarehouseProductByIdAsync(warehouseProductId);
            var nopProduct = await _productService.GetProductByIdAsync(warehouseProduct.ProductId);
            RefreshWarehouseProductData(warehouseProduct, nopProduct);
            warehouseProduct.UpdatedBy = currentUser.Id;
            await _warehouseProductService.UpdateWarehouseProductAsync(warehouseProduct);

            var warehouseProductCombinations = await _warehouseProductCombinationService.GetWarehouseProductCombinationsByWarehouseProductIdAsync(warehouseProductId);
            var warehouseProductCombinationsIds = warehouseProductCombinations.Select(x => x.CombinationId);

            //system data
            var productAttributeCombinations = await _productAttributeService.GetAllProductAttributeCombinationsAsync(warehouseProduct.ProductId);

            var warehouseProductCombinationsToBeInserted = productAttributeCombinations.Where(x => !warehouseProductCombinationsIds.Contains(x.Id)).ToList();

            //the combinations in the system are more than the warehouse combinations.
            if (warehouseProductCombinationsToBeInserted.Any())
            {
                var preparedWarehouseProductCombinations = await PrepareWarehouseProductCombinations(warehouseProductCombinationsToBeInserted, warehouseProduct, currentUser);

                await _warehouseProductCombinationService.InsertWarehouseProductCombinationAsync(preparedWarehouseProductCombinations);

                _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Warehouses.WarehouseProductCombination.Added"));

                //activity log
                foreach (var warehouseProductCombination in preparedWarehouseProductCombinations)
                {
                    await _customerActivityService.InsertActivityAsync("AddNewWarehouseProductCombination",
                        string.Format(await _localizationService.GetResourceAsync("ActivityLog.AddNewWarehouseProductCombination"), warehouseProductCombination.Id), warehouseProductCombination);
                }
                return Ok();
            }
            //the combinations in the system and warehouse are the same.
            else
            {
                await RefreshWarehouseProductCombinationsData(warehouseProductCombinations, productAttributeCombinations);
                await _warehouseProductCombinationService.UpdateWarehouseProductCombinationAsync(warehouseProductCombinations);
                _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Warehouses.WarehouseProductCombination.UpToDate"));
                return Ok();
            }
            /* NOT IMPLEMENTED YET (Reason: not needed)
             * 3- the warehouse combinations are more than the combinations in the system.
             * Warn the user, there is a combination has been deleted from the system but we have it in the warehouse system.
             */
        }

        private async Task RefreshWarehouseProductCombinationsData(IEnumerable<WarehouseProductCombination> warehouseProductCombinations, IEnumerable<ProductAttributeCombination> productAttributeCombinations)
        {
            foreach (var warehouseProductCombination in warehouseProductCombinations)
            {
                var productAttributeCombination = productAttributeCombinations.FirstOrDefault(x => x.Id == warehouseProductCombination.CombinationId);
                if (productAttributeCombination != null)
                {
                    warehouseProductCombination.AttributesXml = await _productAttributeParser.ConvertAttributesToString(productAttributeCombination.AttributesXml);
                    warehouseProductCombination.Sku = productAttributeCombination.Sku;
                }
            }
        }


        [HttpGet("GetWarehouseProductCombination")]
        public async Task<ActionResult<StockItemHistoryModel>> GetWarehouseProductCombination(int warehouseId, string sku)
        {

            try
            {
                if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
                    throw new Exception("Not Allowed.");

                var response = new StockItemHistoryModel();

                var warehouseProductCombination = await _warehouseProductCombinationService.GetWarehouseProductCombinationBySkuAsync(warehouseId, sku);
                if (warehouseProductCombination != null)
                {
                    var warehouseProduct = await _warehouseProductService.GetWarehouseProductByIdAsync(warehouseProductCombination.WarehouseProductId);
                    if (warehouseProduct != null)
                    {
                        var result = warehouseProductCombination.ToModel<WarehouseProductCombinationModel>();
                        result.WarehouseProduct = warehouseProduct.ToModel<WarehouseProductModel>();

                        var product = await _productService.GetProductByIdAsync(warehouseProduct.ProductId);



                        if (result != null && product != null)
                        {
                            response.WarehouseId = warehouseId;
                            response.Sku = result.Sku;
                            response.AttributesXml = result.AttributesXml;
                            response.WarehouseProductCombinationId = warehouseProductCombination.Id;
                            response.ProductName = result.WarehouseProduct.Name;
                            response.UnitPrice = product.Price;
                            response.Tax = 0;
                            response.Discount = 0;
                            response.Profit = 0;
                            response.StockQuantity = 0;
                        }
                        else
                        {
                            response.WarehouseId = warehouseId;
                            response.Sku = "";
                            response.AttributesXml = "";
                            //response.WarehouseProductCombinationId = null;
                            response.ProductName = "";
                            //response.UnitPrice = null;
                            //response.Tax = ;
                           // response.Discount = 0;
                            //response.Profit = 0;
                            //response.StockQuantity = 0;
                        }
                    }



                }


                return response;
            }
            catch (Exception ex)
            {

                throw;
            }
        }



        [HttpPost("CreateReceivingRecord")]
        public async Task<IActionResult> CreateReceivingRecord([FromBody] StockHistoryModel model, int warehouseId)
        {
            try
            {
                var currentUser = await _workContext.GetCurrentCustomerAsync();

                if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
                    return StatusCode(403, new { message = "Access Denied" });

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                model.CreatedOnUtc = DateTime.UtcNow;
                model.CreatedBy = currentUser.Id;
                model.WarehouseId = warehouseId;
                model.TypeOfProcess = StockProcess.Receiving;
                var stockHistory = model.ToEntity<StockHistory>();
                stockHistory.TypeOfProcess = (int)StockProcess.Receiving;
                await _stockHistoryService.InsertStockHistoryAsync(stockHistory);

                await PrepareAndInsertReceivedStockItemsHistory(stockHistory, model.StockItems, currentUser.Id);

                await _customerActivityService.InsertActivityAsync("AddNewStockHistory",
                    string.Format(await _localizationService.GetResourceAsync("ActivityLog.AddNewStockHistory"), stockHistory.Id), stockHistory);

                _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Warehouses.StockHistory.Added"));
                return Ok();
            }
            catch (Exception ex)
            {

                throw;
            }
        }




        [HttpPost("UpdateReceivingRecord")]
        public async Task<IActionResult> UpdateReceivingRecord([FromBody] StockHistoryModel model, int warehouseId)
        {
            try
            {
                //TODO: ADD LOGIC TO VALIDATE IF THE USER IS ALLOWED TO ENTER THIS SPECIFIC WAREHOUSE
                var currentUser = await _workContext.GetCurrentCustomerAsync();
                //if (!IsUserAllowedToAccessWarehouse(warehouseId, currentUser.Id))
                //    return AccessDeniedView();
                model.UpdatedOnUtc = DateTime.UtcNow;
                model.UpdatedBy = currentUser.Id;
                model.WarehouseId = warehouseId;
                model.TypeOfProcess = StockProcess.Receiving;
                if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
                    return StatusCode(403, new { message = "Access Denied" });

                //try to get a warehouse product with the specified id
                var stockHistory = await _stockHistoryService.GetStockHistoryByIdAsync(model.Id);
                if (stockHistory is null || stockHistory.Deleted)
                    return BadRequest();

                //in case of trying to change the process type
                if ((int)model.TypeOfProcess != stockHistory.TypeOfProcess)
                {
                    _notificationService.ErrorNotification(await _localizationService.GetResourceAsync("Admin.Warehouses.WarehouseProduct.NotUpdatedTypeOfProcess"));
                    return BadRequest();
                }

                if (ModelState.IsValid)
                {
                    var retrievedStockItemsHistory = await _stockItemHistoryService.GetAllStockItemsHistoryAsync(stockHistory.Id);

                    //in case of removing product combinations.
                    var stockItemsIds = model.StockItems.Where(x => x.Id != 0).Select(x => x.Id).ToList();
                    var removedStockItemsHistory = retrievedStockItemsHistory.Where(x => !stockItemsIds.Contains(x.Id)).ToList();
                    if (removedStockItemsHistory.Any())
                    {
                        foreach (var stockItemHistory in removedStockItemsHistory)
                        {
                            var mappedStockItems = await _stockItemHistoryMappingService.GetStockItemHistoryMappingByStockItemHistoryIdAsync(stockItemHistory.Id);
                            var warehouseItemsIds = mappedStockItems.Select(x => x.WarehouseItemId);
                            var warehouseItems = await _warehouseItemService.GetWarehouseItemByIdsAsync(warehouseItemsIds.ToArray());
                            foreach (var warehouseItem in warehouseItems)
                            {
                                if (warehouseItem.ItemStatus != (int)ItemStatus.Received)
                                {
                                    _notificationService.ErrorNotification(await _localizationService.GetResourceAsync("Admin.Warehouses.WarehouseProduct.NotUpdatedItemStatusNotReceived"));
                                    return BadRequest();
                                    
                                }
                            }
                        }
                        await _stockItemHistoryService.DeleteStockItemHistoryAsync(removedStockItemsHistory);
                    }

                    //in case of adding new product combinations.
                    var newStockItems = model.StockItems.Where(x => x.Id == 0).ToList();
                    if (newStockItems.Any())
                        await PrepareAndInsertReceivedStockItemsHistory(stockHistory, newStockItems, currentUser.Id);

                    //in case of editing product combinations quantities
                    var editableStockItems = model.StockItems.Where(x => x.Id != 0).ToList();
                    bool isDeleted = true;
                    foreach (var stockItem in editableStockItems)
                    {
                        var retrievedStockItemHistory = retrievedStockItemsHistory.FirstOrDefault(x => x.Id == stockItem.Id);
                        if (stockItem.StockQuantity == retrievedStockItemHistory.StockQuantity)
                        {
                            stockItem.StockHistoryId = model.Id;
                            continue;
                        }
                        else if (stockItem.StockQuantity > retrievedStockItemHistory.StockQuantity)
                        {
                            var addedQuantity = stockItem.StockQuantity - retrievedStockItemHistory.StockQuantity;
                            await PrepareAndInsertWarehouseItems(retrievedStockItemHistory, warehouseId, addedQuantity);
                        }
                        else
                        {
                            var deletedQuantity = retrievedStockItemHistory.StockQuantity - stockItem.StockQuantity;
                            var deletableWarehouseItems = await _warehouseItemService.GetReceivedWarehouseItemsByStockItemHistoryIdAsync(warehouseId, stockItem.Id);
                            if (deletedQuantity <= deletableWarehouseItems.Count)
                            {
                                 isDeleted = await _warehouseItemService.DeleteWarehouseItemAsync(deletableWarehouseItems.Take(deletedQuantity).ToList());
                            }
                        }

                        stockItem.StockHistoryId = model.Id;
                    }

                    if (isDeleted)
                    {
                        //update stock items history
                        var updatableStockItemsHistory = new List<StockItemHistory>();
                        foreach (var editableStockItem in editableStockItems)
                        {
                            updatableStockItemsHistory.Add(editableStockItem.ToEntity<StockItemHistory>());
                        }

                        await _stockItemHistoryService.UpdateStockItemHistoryAsync(updatableStockItemsHistory);

                        //update stock history
                        var updatableStockHistory = model.ToEntity<StockHistory>();
                        await _stockHistoryService.UpdateStockHistoryAsync(updatableStockHistory);

                        //activity log
                        await _customerActivityService.InsertActivityAsync("EditStockHistory",
                            string.Format(await _localizationService.GetResourceAsync("ActivityLog.EditStockHistory"), updatableStockHistory.Id), updatableStockHistory);

                        _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Warehouses.StockHistory.Updated"));

                        return Ok();
                    }
                    
                }

                //prepare model
                model = await _stockHistoryModelFactory.PrepareStockHistoryModelAsync(model, stockHistory);

                //if we got this far, something failed, redisplay form
                return Ok();
            }
            catch (Exception ex)
            {

                throw;
            }
        }




        [HttpPost("CreateReturningToVendorRecord")]
        public async Task<IActionResult> CreateReturningToVendorRecord([FromBody] StockHistoryModel model, [FromQuery] int warehouseId)
        {
            if (warehouseId <= 0)
                return StatusCode(403); // Forbidden access

            // TODO: Add logic to validate if the user is allowed to enter this specific warehouse
            var currentUser = await _workContext.GetCurrentCustomerAsync();
            // if (!IsUserAllowedToAccessWarehouse(warehouseId, currentUser.Id))
            //     return StatusCode(403); // Forbidden access


            model.CreatedOnUtc = DateTime.UtcNow;
            model.CreatedBy = currentUser.Id;
            model.WarehouseId = warehouseId;
            model.TypeOfProcess = StockProcess.ReturnedToVendor;

            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
                return StatusCode(403); // Forbidden access

            if (ModelState.IsValid)
            {
                //model.WarehouseId = warehouseId;
                await CreateReturnedToVendorStock(model, currentUser);

                // Normally we might return a 201 Created status code, possibly including the URI to the newly created resource
                // However, if redirecting to another action is required in an MVC context, in an API context,
                // we would return a successful response code with any appropriate message or resource location.
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }


            //model = await _stockHistoryModelFactory.PrepareStockHistoryModelAsync(model, null);
            // If we got this far, something failed, return a 400 Bad Request with the model state errors
            
        }



        [HttpPost("UpdateReturningToVendorRecord")]
        public async Task<IActionResult> UpdateReturningToVendorRecord([FromBody] StockHistoryModel model, [FromQuery] int warehouseId)
        {
            if (warehouseId <= 0)
                return StatusCode(403); // Forbidden access

            //TODO: Add logic to validate if the user is allowed to enter this specific warehouse
            var currentUser = await _workContext.GetCurrentCustomerAsync();
            //if (!IsUserAllowedToAccessWarehouse(warehouseId, currentUser.Id))
            //    return StatusCode(403); // Forbidden access

            model.UpdatedOnUtc = DateTime.UtcNow;
            model.UpdatedBy = currentUser.Id;
            model.WarehouseId = warehouseId;
            model.TypeOfProcess = StockProcess.ReturnedToVendor;

            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
                return StatusCode(403); // Forbidden access

            var stockHistory = await _stockHistoryService.GetStockHistoryByIdAsync(model.Id);
            if (stockHistory == null || stockHistory.Deleted)
                return NotFound("Stock history not found or has been deleted.");

            if ((int)model.TypeOfProcess != stockHistory.TypeOfProcess)
            {
                return BadRequest("Cannot update the type of process.");
            }

            if (ModelState.IsValid)
            {
                var retrievedStockItemsHistory = await _stockItemHistoryService.GetAllStockItemsHistoryAsync(stockHistory.Id);
                var stockItemsIds = model.StockItems.Where(x => x.Id != 0).Select(x => x.Id).ToList();
                var removedStockItemsHistory = retrievedStockItemsHistory.Where(x => !stockItemsIds.Contains(x.Id)).ToList();

                if (removedStockItemsHistory.Any())
                {
                    foreach (var stockItemHistory in removedStockItemsHistory)
                    {
                        var mappedWarehouseItems = await _stockItemHistoryMappingService.GetStockItemHistoryMappingByStockItemHistoryIdAsync(stockItemHistory.Id);
                        if (mappedWarehouseItems != null && mappedWarehouseItems.Any())
                        {
                            return BadRequest("Cannot delete combination that has items mapped.");
                        }
                    }
                    await _stockItemHistoryService.DeleteStockItemHistoryAsync(removedStockItemsHistory);
                }

                var newStockItems = model.StockItems.Where(x => x.Id == 0).ToList();
                if (newStockItems.Any())
                    await PrepareAndInsertReturnedStockItemsHistory(stockHistory, newStockItems, currentUser.Id);

                var updatableStockHistory = model.ToEntity<StockHistory>();
                await _stockHistoryService.UpdateStockHistoryAsync(updatableStockHistory);

                var updatableStockItemsHistory = model.StockItems
                    .Where(x => x.Id != 0)
                    .Select(x => x.ToEntity<StockItemHistory>())
                    .ToList();

                foreach (var item in updatableStockItemsHistory)
                {
                    item.StockHistoryId = updatableStockHistory.Id;
                }

                await _stockItemHistoryService.UpdateStockItemHistoryAsync(updatableStockItemsHistory);

                _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Warehouses.StockHistory.Updated"));
                return Ok();
            }

            // Return model with errors if ModelState is not valid
            return BadRequest(ModelState);
        }

        [HttpPost("CreateStockReceivingRequest")]
        public async Task<IActionResult> CreateStockReceivingRequestRecord([FromBody] StockRequestModel model, int warehouseId)
        {
            var currentUser = await _workContext.GetCurrentCustomerAsync();

            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
                return StatusCode(StatusCodes.Status403Forbidden, "Access denied");


            model.CreatedOnUtc = DateTime.UtcNow;
            model.CreatedBy = currentUser.Id;
            model.WarehouseId = warehouseId;
            model.TypeOfProcess = StockProcess.Receiving;

            if (ModelState.IsValid)
            {
               
                var stockRequest = model.ToEntity<StockRequest>();
                await _stockRequestService.InsertStockRequestAsync(stockRequest);

                await PrepareAndInsertReceivedStockRequestItems(stockRequest, model.StockRequestItems, currentUser.Id);

                await _customerActivityService.InsertActivityAsync("AddNewStockRequest",
                    string.Format(await _localizationService.GetResourceAsync("ActivityLog.AddNewStockRequest"), stockRequest.Id), stockRequest);

                return Ok();
            }
            else
            {
                // If the model state is invalid, send a bad request status with the validation errors
                return BadRequest();
            }
        }


        [HttpPost("UpdateStockReceivingRequest")]
        public async Task<IActionResult> UpdateStockReceivingRequestRecord([FromBody] StockRequestModel model, int warehouseId)
        {
            var currentUser = await _workContext.GetCurrentCustomerAsync();

            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
                return StatusCode(StatusCodes.Status403Forbidden, "Access denied");

            model.UpdatedOnUtc = DateTime.UtcNow;
            model.UpdatedBy = currentUser.Id;
            model.WarehouseId = warehouseId;
            model.TypeOfProcess = StockProcess.Receiving;

            var stockRequest = await _stockRequestService.GetStockRequestByIdAsync(model.Id);
            if (stockRequest is null || stockRequest.Deleted)
                return NotFound();

            if ((int)model.TypeOfProcess != stockRequest.TypeOfProcess)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                foreach(var stockItemRequest in model.StockRequestItems)
                {
                    stockItemRequest.StockRequestId = model.Id;
                }

                var retrievedStockRequestItems = await _stockRequestItemService.GetAllStockRequestItemsAsync(stockRequest.Id);

                var stockRequestItemsIds = model.StockRequestItems.Where(x => x.Id != 0).Select(x => x.Id).ToList();
                var removedStockRequestItems = retrievedStockRequestItems.Where(x => !stockRequestItemsIds.Contains(x.Id)).ToList();
                if (removedStockRequestItems.Any())
                {
                    
                    await _stockRequestItemService.DeleteStockRequestItemAsync(removedStockRequestItems);
                }

                var newStockRequestItems = model.StockRequestItems.Where(x => x.Id == 0).ToList();
                if (newStockRequestItems.Any())
                {
                    
                    await PrepareAndInsertReceivedStockRequestItems(stockRequest, newStockRequestItems, currentUser.Id);

                }

                var editableStockRequestItems = model.StockRequestItems.Where(x => x.Id != 0).ToList();

               

                var updatableStockRequest = model.ToEntity<StockRequest>();

                //to enable the reviewing process again
                if (updatableStockRequest.Reviewed)
                {
                    updatableStockRequest.Reviewed = false;
                }

                await _stockRequestService.UpdateStockRequestAsync(updatableStockRequest);

                var updatableStockRequestItems = editableStockRequestItems.Select(x => x.ToEntity<StockRequestItem>()).ToList();
                //foreach (var stockItemRequest in updatableStockRequestItems)
                //{
                //    stockItemRequest.StockRequestId = model.Id;
                //}
                await _stockRequestItemService.UpdateStockRequestItemAsync(updatableStockRequestItems);

                await _customerActivityService.InsertActivityAsync("EditStockRequest",
                    string.Format(await _localizationService.GetResourceAsync("ActivityLog.EditStockRequest"), updatableStockRequest.Id), updatableStockRequest);

                return Ok();
            }
            else
            {
                // If the model state is invalid, send a bad request status with the validation errors
                return BadRequest();
            }
        }


        [HttpPost("CreateReturningToVendorRequest")]
        public async Task<IActionResult> CreateReturningToVendorRequestRecord([FromBody] StockRequestModel model, int warehouseId)
        {
            var currentUser = await _workContext.GetCurrentCustomerAsync();

            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
                return StatusCode(StatusCodes.Status403Forbidden, "Access denied");

            model.CreatedOnUtc = DateTime.UtcNow;
            model.CreatedBy = currentUser.Id;
            model.WarehouseId = warehouseId;
            model.TypeOfProcess = StockProcess.ReturnedToVendor;

            if (ModelState.IsValid)
            {
                
                var stockRequest = model.ToEntity<StockRequest>();
                stockRequest.Reviewed = false;
                await _stockRequestService.InsertStockRequestAsync(stockRequest);

                await PrepareAndInsertReturnedStockRequestItems(stockRequest, model.StockRequestItems, currentUser.Id);

                await _customerActivityService.InsertActivityAsync("AddNewStockRequest",
                    string.Format(await _localizationService.GetResourceAsync("ActivityLog.AddNewStockRequest"), stockRequest.Id), stockRequest);

                return Ok(new { Message = await _localizationService.GetResourceAsync("Admin.Warehouses.StockRequest.Added"), StockRequestId = stockRequest.Id });
            }
            else
            {
                // If the model state is invalid, send a bad request status with the validation errors
                return BadRequest(ModelState);
            }
        }


        [HttpPost("UpdateReturningToVendorRequest")]
        public async Task<IActionResult> UpdateReturningToVendorRequestRecord([FromBody] StockRequestModel model, int warehouseId)
        {
            var currentUser = await _workContext.GetCurrentCustomerAsync();

            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
                return StatusCode(StatusCodes.Status403Forbidden, "Access denied");

            model.UpdatedOnUtc = DateTime.UtcNow;
            model.UpdatedBy = currentUser.Id;
            model.WarehouseId = warehouseId;
            model.TypeOfProcess = StockProcess.ReturnedToVendor;

            var stockRequest = await _stockRequestService.GetStockRequestByIdAsync(model.Id);
            if (stockRequest is null || stockRequest.Deleted)
                return NotFound("Stock request not found or has been deleted");

            if ((int)model.TypeOfProcess != stockRequest.TypeOfProcess)
            {
                return BadRequest(new { Message = await _localizationService.GetResourceAsync("Admin.Warehouses.WarehouseProduct.NotUpdatedTypeOfProcess") });
            }

            if (ModelState.IsValid)
            {
                foreach (var stockItemRequest in model.StockRequestItems)
                {
                    stockItemRequest.StockRequestId = model.Id;
                }
                var retrievedStockRequestItems = await _stockRequestItemService.GetAllStockRequestItemsAsync(stockRequest.Id);

                var stockItemsIds = model.StockRequestItems.Where(x => x.Id != 0).Select(x => x.Id).ToList();
                var removedStockRequestItems = retrievedStockRequestItems.Where(x => !stockItemsIds.Contains(x.Id)).ToList();
                if (removedStockRequestItems.Any())
                {
                    await _stockRequestItemService.DeleteStockRequestItemAsync(removedStockRequestItems);
                }

                var newStockItems = model.StockRequestItems.Where(x => x.Id == 0).ToList();
                if (newStockItems.Any())
                    await PrepareAndInsertReturnedStockRequestItems(stockRequest, newStockItems, currentUser.Id);

                var editableStockRequestItems = model.StockRequestItems.Where(x => x.Id != 0).ToList();
                var updatableStockRequest = model.ToEntity<StockRequest>();

                //to enable the reviewing process again
                if (updatableStockRequest.Reviewed)
                {
                    updatableStockRequest.Reviewed = false;
                }

                await _stockRequestService.UpdateStockRequestAsync(updatableStockRequest);

                var updatableStockRequestItems = editableStockRequestItems.Select(x => x.ToEntity<StockRequestItem>()).ToList();
                await _stockRequestItemService.UpdateStockRequestItemAsync(updatableStockRequestItems);

                await _customerActivityService.InsertActivityAsync("EditStockRequest",
                    string.Format(await _localizationService.GetResourceAsync("ActivityLog.EditStockRequest"), updatableStockRequest.Id), updatableStockRequest);

                return Ok(new { Message = await _localizationService.GetResourceAsync("Admin.Warehouses.StockRequest.Updated"), StockRequestId = updatableStockRequest.Id });
            }
            else
            {
                // If the model state is invalid, send a bad request status with the validation errors
                return BadRequest(ModelState);
            }
        }


        


    }
}
