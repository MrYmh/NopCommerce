
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.VariantTypes;
using Microsoft.AspNetCore.Mvc;
using Nito.AsyncEx.Synchronous;
using Nop.Core;
using Nop.Core.Caching;
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
using Nop.Web.Areas.Admin.Models;
using Nop.Web.Areas.Admin.Models.Warehouses;
using Nop.Web.Framework.Mvc.Filters;

namespace Nop.Web.Areas.Admin.Controllers
{
    public class StockController : BaseAdminController
    {
        

        #region Fields

        private readonly IWorkContext _workContext;
        private readonly IStaticCacheManager _staticCacheManager;
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


        #endregion

        #region Ctor

        public StockController(IWorkContext workContext,
            IStaticCacheManager staticCacheManager,
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
            _staticCacheManager = staticCacheManager;
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
            _shelfItemMappingService = shelfItemMappingService;
            _stockItemHistoryMappingService = stockItemHistoryMappingService;
            _stockItemHistoryService = stockItemHistoryService;
            _warehouseItemService = warehouseItemService;
            _stockRequestModelFactory = stockRequestModelFactory;
            _acceptStockRequestModelFactory = acceptStockRequestModelFactory;
        }

        #endregion

        #region Utilities
        

        private async Task PrepareStockRequest(AcceptStockRequestModel model, int stockRequestId)
        {
            var request = await _stockRequestService.GetStockRequestByIdAsync(stockRequestId);
            if (request != null)
            {
                model.StockRequest = request.ToModel<StockRequestModel>();
            }
        }

        private async Task PrepareStockRequestItems(IList<StockRequestItemModel> items, int stockRequestId)
        {
            var requestItems = await _stockRequestItemService.GetAllStockRequestItemsAsync(stockRequestId);
            if (requestItems.Any())
            {
                //var addedItems = new List<StockRequestItemModel>();
                foreach (var item in requestItems)
                {
                    items.Add(item.ToModel<StockRequestItemModel>());
                }
                //items = addedItems;
            }
        }

        private async Task CreateReturnedToVendorStock(StockHistoryModel model, Customer currentUser)
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
        private async Task PrepareAndInsertReceivedStockItemsHistory(StockHistory stockHistory, IList<StockItemHistoryModel> stockItems, int currentUserId)
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

        private async Task PrepareAndInsertWarehouseItems(IEnumerable<StockItemHistory> stockItemHistory, int warehouseId)
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

        // insert stock items without items because they will be mapped from existing items that will be returned to new ones
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

        

        

        private async Task<ActionResult<BaseResponse>> ErrorBaseResponse(string localizationKey)
        {
            _notificationService.ErrorNotification(await _localizationService.GetResourceAsync(localizationKey));
            return new BaseResponse { Success = false };
        }

        private bool IsBarcodeAlreadyOrdered(WarehouseItem warehouseItem)
        {
            if (warehouseItem.Ordered)
                return true;
            return false;
        }

        private bool IsBarcodeAlreadyReturnedToVendorBefore(WarehouseItem warehouseItem)
        {
            if (warehouseItem.ReturnedToVendor)
                return true;
            return false;
        }

        //request
        private async Task PrepareAndInsertReceivedStockRequestItems(StockRequest stockRequest, IList<StockRequestItemModel> stockRequestItems, int currentUserId)
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

        #endregion

        #region Product API



        //substituted by jquery code to improve the performance.
        //[HttpGet("GetWarehouseProductCombination/{warehouseId}/{sku}")]
        //public async Task<ActionResult<List<StockItemHistory>>> CheckEnteredStockItemHistory(List<StockItemHistory> existingStockItems, StockItemHistory addedStockItem)
        //{
        //    if(existingStockItems.Any(x => x.WarehouseProductCombinationId == addedStockItem.WarehouseProductCombinationId))
        //    {
        //        var existingStockItem = existingStockItems.FirstOrDefault(x => x.WarehouseProductCombinationId == addedStockItem.WarehouseProductCombinationId);
        //        //if the added item is identical to an existing item in the list just add its quantity without creating another list item.
        //        if (!AreStockItemsIdentical(existingStockItem, addedStockItem))
        //        {
        //            _notificationService.WarningNotification(await _localizationService.GetResourceAsync("Admin.Warehouses.Stock.AddedItemCausesConflict"));
        //        }

        //        var indexOfExistingStockItem = existingStockItems.IndexOf(existingStockItem);

        //            existingStockItems[indexOfExistingStockItem].StockQuantity += addedStockItem.StockQuantity;

        //    }
        //    else
        //    {
        //        existingStockItems.Add(addedStockItem);
        //    }
        //    return existingStockItems;
        //}
        //private bool AreStockItemsIdentical(StockItemHistory existingStockItem, StockItemHistory addedStockItem)
        //{
        //    return existingStockItem.UnitPrice == addedStockItem.UnitPrice &&
        //        existingStockItem.Tax == addedStockItem.Tax &&
        //        existingStockItem.Discount == addedStockItem.Discount &&
        //        existingStockItem.Profit == addedStockItem.Profit;
        //}

        #endregion

        #region Stock Processes

        public async Task<IActionResult> CreateStockProcess(int warehouseId)
        {
            if (warehouseId <= 0)
                return AccessDeniedView();

            //TODO: ADD LOGIC TO VALIDATE IF THE USER IS ALLOWED TO ENTER THIS SPECIFIC WAREHOUSE
            //var currentUser = await _workContext.GetCurrentCustomerAsync();
            //if (!IsUserAllowedToAccessWarehouse(warehouseId, currentUser.Id))
            //    return AccessDeniedView();

            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
                return AccessDeniedView();

            var model = new StockHistoryModel()
            {
                WarehouseId = warehouseId,
                //TypeOfProcess = StockProcess.Receiving
            };

            //prepare model
            var preparedModel = await _stockHistoryModelFactory.PrepareStockHistoryModelAsync(model, null);

            return View(preparedModel);
        }

        #region Receiving Stock

        public async Task<IActionResult> CreateReceivingRecord(int warehouseId)
        {
            if (warehouseId <= 0)
                return AccessDeniedView();

            //TODO: ADD LOGIC TO VALIDATE IF THE USER IS ALLOWED TO ENTER THIS SPECIFIC WAREHOUSE
            //var currentUser = await _workContext.GetCurrentCustomerAsync();
            //if (!IsUserAllowedToAccessWarehouse(warehouseId, currentUser.Id))
            //    return AccessDeniedView();

            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
                return AccessDeniedView();

            var model = new StockHistoryModel()
            {
                WarehouseId = warehouseId,
                TypeOfProcess = StockProcess.Receiving
            };

            //prepare model
            var preparedModel = await _stockHistoryModelFactory.PrepareStockHistoryModelAsync(model, null);

            return View(preparedModel);
        }

        public async Task<IActionResult> UpdateReceivingRecord(int id, int warehouseId)
        {
            if (warehouseId <= 0)
                return AccessDeniedView();

            //TODO: ADD LOGIC TO VALIDATE IF THE USER IS ALLOWED TO ENTER THIS SPECIFIC WAREHOUSE
            var currentUser = await _workContext.GetCurrentCustomerAsync();
            //if (!IsUserAllowedToAccessWarehouse(warehouseId, currentUser.Id))
            //    return AccessDeniedView();

            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
                return AccessDeniedView();

            //try to get a warehouse product with the specified id
            var stockHistory = await _stockHistoryService.GetStockHistoryByIdAsync(id);
            if (stockHistory is null || stockHistory.Deleted)
                return RedirectToAction("List", "StockHistory", new { warehouseId = warehouseId });

            //prepare model
            var model = await _stockHistoryModelFactory.PrepareStockHistoryModelAsync(null, stockHistory);

            return View(model);
        }

        

        #endregion

        #region Returning Stock To Vendor

        public async Task<IActionResult> CreateReturningToVendorRecord(int warehouseId)
        {
            if (warehouseId <= 0)
                return AccessDeniedView();

            //TODO: ADD LOGIC TO VALIDATE IF THE USER IS ALLOWED TO ENTER THIS SPECIFIC WAREHOUSE
            //var currentUser = await _workContext.GetCurrentCustomerAsync();
            //if (!IsUserAllowedToAccessWarehouse(warehouseId, currentUser.Id))
            //    return AccessDeniedView();

            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
                return AccessDeniedView();

            var model = new StockHistoryModel()
            {
                WarehouseId = warehouseId,
                TypeOfProcess = StockProcess.ReturnedToVendor
            };

            //prepare model
            var preparedModel = await _stockHistoryModelFactory.PrepareStockHistoryModelAsync(model, null);

            return View(preparedModel);
        }

        //[HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        //public async Task<IActionResult> CreateReturningToVendorRecord(StockHistoryModel model, int warehouseId)
        //{
        //    if (warehouseId <= 0)
        //        return AccessDeniedView();

        //    //TODO: ADD LOGIC TO VALIDATE IF THE USER IS ALLOWED TO ENTER THIS SPECIFIC WAREHOUSE
        //    var currentUser = await _workContext.GetCurrentCustomerAsync();
        //    //if (!IsUserAllowedToAccessWarehouse(warehouseId, currentUser.Id))
        //    //    return AccessDeniedView();

        //    if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
        //        return AccessDeniedView();

        //    if (ModelState.IsValid)
        //    {
        //        await CreateReturnedToVendorStock(model, currentUser);

        //        //edit it to be redirect to scanning returned items page
        //        return RedirectToAction("List");
        //    }

        //    //prepare model
        //    model = await _stockHistoryModelFactory.PrepareStockHistoryModelAsync(model, null);

        //    //if we got this far, something failed, redisplay form
        //    return View(model);
        //}

        public async Task<IActionResult> UpdateReturningToVendorRecord(int id, int warehouseId)
        {
            if (warehouseId <= 0)
                return AccessDeniedView();

            //TODO: ADD LOGIC TO VALIDATE IF THE USER IS ALLOWED TO ENTER THIS SPECIFIC WAREHOUSE
            var currentUser = await _workContext.GetCurrentCustomerAsync();
            //if (!IsUserAllowedToAccessWarehouse(warehouseId, currentUser.Id))
            //    return AccessDeniedView();

            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
                return AccessDeniedView();

            //try to get a warehouse product with the specified id
            var stockHistory = await _stockHistoryService.GetStockHistoryByIdAsync(id);
            if (stockHistory is null || stockHistory.Deleted)
                return RedirectToAction("List", "StockHistory");

            //prepare model
            var model = await _stockHistoryModelFactory.PrepareStockHistoryModelAsync(null, stockHistory);

            return View(model);
        }

        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        public async Task<IActionResult> UpdateReturningToVendorRecord(StockHistoryModel model, int warehouseId)
        {
            if (warehouseId <= 0)
                return AccessDeniedView();

            //TODO: ADD LOGIC TO VALIDATE IF THE USER IS ALLOWED TO ENTER THIS SPECIFIC WAREHOUSE
            var currentUser = await _workContext.GetCurrentCustomerAsync();
            //if (!IsUserAllowedToAccessWarehouse(warehouseId, currentUser.Id))
            //    return AccessDeniedView();

            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
                return AccessDeniedView();

            //try to get a warehouse product with the specified id
            var stockHistory = await _stockHistoryService.GetStockHistoryByIdAsync(model.Id);
            if (stockHistory is null || stockHistory.Deleted)
                return RedirectToAction("List", "StockHistory");

            //in case of trying to change the process type
            if ((int)model.TypeOfProcess != stockHistory.TypeOfProcess)
            {
                _notificationService.ErrorNotification(await _localizationService.GetResourceAsync("Admin.Warehouses.WarehouseProduct.NotUpdatedTypeOfProcess"));
                return RedirectToAction("List", "StockHistory");
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
                        var mappedWarehouseItems = await _stockItemHistoryMappingService.GetStockItemHistoryMappingByStockItemHistoryIdAsync(stockItemHistory.Id);
                        if (mappedWarehouseItems != null || mappedWarehouseItems.Any())
                        {
                            _notificationService.ErrorNotification(await _localizationService.GetResourceAsync("Admin.Warehouses.WarehouseProduct.TryToDeleteCombinationHasItemsMapped"));
                            return RedirectToAction("List", "StockHistory");
                        }


                    }
                    await _stockItemHistoryService.DeleteStockItemHistoryAsync(removedStockItemsHistory);
                }

                //in case of adding new product combinations.
                var newStockItems = model.StockItems.Where(x => x.Id == 0).ToList();
                if (newStockItems.Any())
                    await PrepareAndInsertReturnedStockItemsHistory(stockHistory, newStockItems, currentUser.Id);

                //in case of editing product combinations quantities
                var editableStockItems = model.StockItems.Where(x => x.Id != 0).ToList();
                foreach (var stockItem in editableStockItems)
                {
                    var retrievedStockItemHistory = retrievedStockItemsHistory.FirstOrDefault(x => x.Id == stockItem.Id);
                    if (stockItem.StockQuantity < retrievedStockItemHistory.StockQuantity)
                    {
                        var deletedQuantity = retrievedStockItemHistory.StockQuantity - stockItem.StockQuantity;
                        //get items that already scanned to be returned if any.
                        var mappedWarehouseItems = await _stockItemHistoryMappingService.GetStockItemHistoryMappingByStockItemHistoryIdAsync(stockItem.Id);
                        if (mappedWarehouseItems != null || mappedWarehouseItems.Any())
                        {
                            //count of unscanned items that could be reduced.
                            var remainingItemsCount = retrievedStockItemHistory.StockQuantity - mappedWarehouseItems.Count;
                            if (remainingItemsCount < deletedQuantity)
                            {
                                _notificationService.ErrorNotification(await _localizationService.GetResourceAsync("Admin.Warehouses.WarehouseProduct.CannotReduceItemQuantity"));
                                return RedirectToAction("List", "StockHistory");
                            }
                        }
                    }
                    else
                    {
                        continue;
                    }

                }
                //update stock history
                var updatableStockHistory = model.ToEntity<StockHistory>();
                await _stockHistoryService.UpdateStockHistoryAsync(updatableStockHistory);
                //update stock items history
                var updatableStockItemsHistory = new List<StockItemHistory>();
                foreach (var editableStockItem in editableStockItems)
                {
                    updatableStockItemsHistory.Add(editableStockItem.ToEntity<StockItemHistory>());
                }
                await _stockItemHistoryService.UpdateStockItemHistoryAsync(updatableStockItemsHistory);

                //activity log
                await _customerActivityService.InsertActivityAsync("EditStockHistory",
                    string.Format(await _localizationService.GetResourceAsync("ActivityLog.EditStockHistory"), updatableStockHistory.Id), updatableStockHistory);

                _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Warehouses.StockHistory.Updated"));

                return RedirectToAction("List");
            }

            //prepare model
            model = await _stockHistoryModelFactory.PrepareStockHistoryModelAsync(model, stockHistory);

            //if we got this far, something failed, redisplay form
            return View(model);
        }

        #endregion

        #region Damaging Stock

        [HttpGet]
        public async Task<ActionResult> DamageStock(int warehouseId)
        {
            return View(warehouseId);
        }

        //[HttpPost("CheckDamagedBarcodeValidity/{warehouseId}")]
        //public async Task<ActionResult<bool>> CheckDamagedBarcodeValidity(int warehouseId, string itemBarcode)
        //{
        //    var warehouseItem = await _warehouseItemService.GetWarehouseItemByBarcodeAsync(itemBarcode);
        //    if (warehouseItem is null)
        //    {
        //        _notificationService.ErrorNotification(string.Format(await _localizationService.GetResourceAsync("Admin.Warehouses.Barcode.InValid"), itemBarcode));
        //        return false;
        //    }


        //    return true;
        //}

        #endregion

        #endregion

        #region Stock Requests

        public async Task<IActionResult> CreateStockRequestRecord(int warehouseId)
        {


            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
                return AccessDeniedView();

            var model = new StockRequestModel()
            {
                WarehouseId = warehouseId,
                //TypeOfProcess = StockProcess.Receiving
            };

            //prepare model
            var preparedModel = await _stockRequestModelFactory.PrepareStockRequestModelAsync(model, null);

            return View(preparedModel);
        }

        #region Stock Receiving Request

        public async Task<IActionResult> CreateStockReceivingRequestRecord(int warehouseId)
        {
            

            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
                return AccessDeniedView();

            var model = new StockRequestModel()
            {
                WarehouseId = warehouseId,
                TypeOfProcess = StockProcess.Receiving
            };

            //prepare model
            var preparedModel = await _stockRequestModelFactory.PrepareStockRequestModelAsync(model, null);

            return View(preparedModel);
        }
        
        public async Task<IActionResult> UpdateStockReceivingRequestRecord(int id, int warehouseId)
        {
            //TODO: ADD LOGIC TO VALIDATE IF THE USER IS ALLOWED TO ENTER THIS SPECIFIC WAREHOUSE
            var currentUser = await _workContext.GetCurrentCustomerAsync();
            //if (!IsUserAllowedToAccessWarehouse(warehouseId, currentUser.Id))
            //    return AccessDeniedView();

            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
                return AccessDeniedView();

            var acceptRequest = await _acceptStockRequestService.GetAllAcceptStockRequestByStockRequestIdAsync(id);
            if (acceptRequest != null)
            {
                _notificationService.ErrorNotification(await _localizationService.GetResourceAsync("Admin.Warehouses.StockRequest.ActionTakenInThisRequest"));
                return RedirectToAction("List", "StockRequest", new { warehouseId = warehouseId });
            }


            var stockRequest = await _stockRequestService.GetStockRequestByIdAsync(id);
            if (stockRequest is null || stockRequest.Deleted)
                return RedirectToAction("List", "StockRequest", new { warehouseId = warehouseId });

            //prepare model
            var model = await _stockRequestModelFactory.PrepareStockRequestModelAsync(null, stockRequest);

            return View(model);
        }

        



        #endregion

        #region Stock Returning To Vendor Request

        public async Task<IActionResult> CreateReturningToVendorRequestRecord(int warehouseId)
        {
            //TODO: ADD LOGIC TO VALIDATE IF THE USER IS ALLOWED TO ENTER THIS SPECIFIC WAREHOUSE
            //var currentUser = await _workContext.GetCurrentCustomerAsync();
            //if (!IsUserAllowedToAccessWarehouse(warehouseId, currentUser.Id))
            //    return AccessDeniedView();

            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
                return AccessDeniedView();

            var model = new StockRequestModel()
            {
                WarehouseId = warehouseId,
                TypeOfProcess = StockProcess.ReturnedToVendor
            };

            //prepare model
            var preparedModel = await _stockRequestModelFactory.PrepareStockRequestModelAsync(model, null);

            return View(preparedModel);
        }

        //[HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        //public async Task<IActionResult> CreateReturningToVendorRequestRecord(StockRequestModel model, int warehouseId)
        //{
        //    //TODO: ADD LOGIC TO VALIDATE IF THE USER IS ALLOWED TO ENTER THIS SPECIFIC WAREHOUSE
        //    var currentUser = await _workContext.GetCurrentCustomerAsync();
        //    //if (!IsUserAllowedToAccessWarehouse(warehouseId, currentUser.Id))
        //    //    return AccessDeniedView();

        //    if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
        //        return AccessDeniedView();

        //    if (ModelState.IsValid)
        //    {

        //        //Stock Request
        //        model.CreatedOnUtc = DateTime.UtcNow;
        //        model.CreatedBy = currentUser.Id;
        //        var stockRequest = model.ToEntity<StockRequest>();
        //        await _stockRequestService.InsertStockRequestAsync(stockRequest);

        //        //Stock Request Items
        //        await PrepareAndInsertReturnedStockRequestItems(stockRequest, model.StockRequestItems, currentUser.Id);

        //        //activity log
        //        await _customerActivityService.InsertActivityAsync("AddNewStockRequest",
        //            string.Format(await _localizationService.GetResourceAsync("ActivityLog.AddNewStockRequest"), stockRequest.Id), stockRequest);

        //        _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Warehouses.StockRequest.Added"));


        //        //edit it to be redirect to scanning returned items page
        //        return RedirectToAction("List", "StockRequest");
        //    }

        //    //prepare model
        //    model = await _stockRequestModelFactory.PrepareStockRequestModelAsync(model, null);

        //    //if we got this far, something failed, redisplay form
        //    return View(model);
        //}

        public async Task<IActionResult> UpdateReturningToVendorRequestRecord(int id, int warehouseId)
        {
            //TODO: ADD LOGIC TO VALIDATE IF THE USER IS ALLOWED TO ENTER THIS SPECIFIC WAREHOUSE
            var currentUser = await _workContext.GetCurrentCustomerAsync();
            //if (!IsUserAllowedToAccessWarehouse(warehouseId, currentUser.Id))
            //    return AccessDeniedView();

            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
                return AccessDeniedView();

            var acceptRequest = await _acceptStockRequestService.GetAllAcceptStockRequestByStockRequestIdAsync(id);
            if (acceptRequest != null)
            {
                _notificationService.ErrorNotification(await _localizationService.GetResourceAsync("Admin.Warehouses.StockRequest.ActionTakenInThisRequest"));
                return RedirectToAction("List", "StockRequest", new { warehouseId = warehouseId });
            }

            //try to get a warehouse product with the specified id
            var stockRequest = await _stockRequestService.GetStockRequestByIdAsync(id);
            if (stockRequest is null || stockRequest.Deleted)
                return RedirectToAction("List", "StockRequest", new { warehouseId = warehouseId });

            //prepare model
            var model = await _stockRequestModelFactory.PrepareStockRequestModelAsync(null, stockRequest);

            return View(model);
        }

        //[HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        //public async Task<IActionResult> UpdateReturningToVendorRequestRecord(StockRequestModel model, int warehouseId)
        //{
        //    //TODO: ADD LOGIC TO VALIDATE IF THE USER IS ALLOWED TO ENTER THIS SPECIFIC WAREHOUSE
        //    var currentUser = await _workContext.GetCurrentCustomerAsync();
        //    //if (!IsUserAllowedToAccessWarehouse(warehouseId, currentUser.Id))
        //    //    return AccessDeniedView();

        //    if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
        //        return AccessDeniedView();

        //    //try to get a warehouse product with the specified id
        //    var stockRequest = await _stockRequestService.GetStockRequestByIdAsync(model.Id);
        //    if (stockRequest is null || stockRequest.Deleted)
        //        return RedirectToAction("List", "StockRequest");

        //    //in case of trying to change the process type
        //    if (model.TypeOfProcess != stockRequest.TypeOfProcess)
        //    {
        //        _notificationService.ErrorNotification(await _localizationService.GetResourceAsync("Admin.Warehouses.WarehouseProduct.NotUpdatedTypeOfProcess"));
        //        return RedirectToAction("List", "StockRequest");
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        var retrievedStockRequestItems = await _stockRequestItemService.GetAllStockRequestItemsAsync(stockRequest.Id);

        //        //in case of removing product combinations.
        //        var stockItemsIds = model.StockRequestItems.Where(x => x.Id != 0).Select(x => x.Id).ToList();
        //        var removedStockRequestItems = retrievedStockRequestItems.Where(x => !stockItemsIds.Contains(x.Id)).ToList();
        //        if (removedStockRequestItems.Any())
        //        {
        //            await _stockRequestItemService.DeleteStockRequestItemAsync(removedStockRequestItems);
        //        }

        //        //in case of adding new product combinations.
        //        var newStockItems = model.StockRequestItems.Where(x => x.Id == 0).ToList();
        //        if (newStockItems.Any())
        //            await PrepareAndInsertReturnedStockRequestItems(stockRequest, newStockItems, currentUser.Id);

        //        //in case of editing product combinations quantities
        //        var editableStockRequestItems = model.StockRequestItems.Where(x => x.Id != 0).ToList();

        //        //update stock request
        //        var updatableStockRequest = model.ToEntity<StockRequest>();
        //        await _stockRequestService.UpdateStockRequestAsync(updatableStockRequest);
        //        //update stock request items
        //        var updatableStockRequestItems = new List<StockRequestItem>();
        //        foreach (var editableStockRequestItem in editableStockRequestItems)
        //        {
        //            updatableStockRequestItems.Add(editableStockRequestItem.ToEntity<StockRequestItem>());
        //        }
        //        await _stockRequestItemService.UpdateStockRequestItemAsync(updatableStockRequestItems);

        //        //activity log
        //        await _customerActivityService.InsertActivityAsync("EditStockRequest",
        //            string.Format(await _localizationService.GetResourceAsync("ActivityLog.EditStockRequest"), updatableStockRequest.Id), updatableStockRequest);

        //        _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Warehouses.StockRequest.Updated"));

        //        return RedirectToAction("List", "StockRequest");
        //    }

        //    //prepare model
        //    model = await _stockRequestModelFactory.PrepareStockRequestModelAsync(model, stockRequest);

        //    //if we got this far, something failed, redisplay form
        //    return View(model);
        //}

        #endregion

        #region Accept Request

        public async Task<IActionResult> CreateAcceptStockRequest(int id, int warehouseId)
        {
            //TODO: ADD LOGIC TO VALIDATE IF THE USER IS ALLOWED TO ENTER THIS SPECIFIC WAREHOUSE
            var currentUser = await _workContext.GetCurrentCustomerAsync();
            //if (!IsUserAllowedToAccessWarehouse(warehouseId, currentUser.Id))
            //    return AccessDeniedView();

            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
                return AccessDeniedView();




            var stockRequest = await _stockRequestService.GetStockRequestByIdAsync(id);
            if (stockRequest is null || stockRequest.Deleted)
                return RedirectToAction("List", "StockRequest");

            var acceptStockRequestModel = new AcceptStockRequestModel
            {
                RequestorId = stockRequest.CreatedBy,
                ActionTakenBy = currentUser.Id,
                StockRequestId = id,
                WarehouseId = warehouseId,
                //RequestType = stockRequest.TypeOfProcess,
                

            };

            //prepare model
            var model = await _acceptStockRequestModelFactory.PrepareAcceptStockRequestModelAsync(acceptStockRequestModel, null);

            return View(model);
        }

        //take action accept or reject if accept the logic of creation for the receiving or returning to the vendor will be executed.
        [HttpPost]
        public async Task<IActionResult> CreateAcceptStockRequest(AcceptStockRequestModel model, int warehouseId)
        {
            //TODO: ADD LOGIC TO VALIDATE IF THE USER IS ALLOWED TO ENTER THIS SPECIFIC WAREHOUSE
            var currentUser = await _workContext.GetCurrentCustomerAsync();
            //if (!IsUserAllowedToAccessWarehouse(warehouseId, currentUser.Id))
            //    return AccessDeniedView();

            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
                return AccessDeniedView();

            if (ModelState.IsValid)
            {
                model.Id = 0;
                //await PrepareStockRequest(model, model.StockRequestId);
                //await PrepareStockRequestItems(model.StockRequestItems, model.StockRequestId);
                var acceptStockRequest = model.ToEntity<AcceptStockRequest>();
                acceptStockRequest.CreatedOnUtc = DateTime.UtcNow;
                acceptStockRequest.UpdatedOnUtc = DateTime.UtcNow;
                acceptStockRequest.CreatedBy = currentUser.Id;

                var stockRequest = await _stockRequestService.GetStockRequestByIdAsync(model.StockRequestId);

                if (model.Accepted)
                {
                    try
                    {
                        var stockHistoryModel = stockRequest.ToModel<StockHistoryModel>();

                        stockHistoryModel.StockItems = new List<StockItemHistoryModel>();
                        var requestItems = await _stockRequestItemService.GetAllStockRequestItemsAsync(model.StockRequestId);
                        foreach (var item in requestItems)
                        {
                            stockHistoryModel.StockItems.Add(item.ToModel<StockItemHistoryModel>());
                        }
                        model.RequestType = stockHistoryModel.TypeOfProcess;
                        switch (model.RequestType)
                        {
                            case StockProcess.Receiving:
                                await CreateReceivedStock(stockHistoryModel, currentUser);
                                break;
                            case StockProcess.ReturnedToVendor:
                                await CreateReturnedToVendorStock(stockHistoryModel, currentUser);
                                break;
                            default:
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }

                stockRequest.Reviewed = true;
                await _stockRequestService.UpdateStockRequestAsync(stockRequest);

                await _acceptStockRequestService.InsertAcceptStockRequestAsync(acceptStockRequest);

                //activity log
                await _customerActivityService.InsertActivityAsync("AddNewAcceptStockRequest",
                    string.Format(await _localizationService.GetResourceAsync("ActivityLog.AddNewAcceptStockRequest"), acceptStockRequest.Id), acceptStockRequest);

                _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Warehouses.AcceptStockRequest.Added"));

                return RedirectToAction("List" , "StockRequest", new { warehouseId = model.WarehouseId });
            }

            //prepare model
            model = await _acceptStockRequestModelFactory.PrepareAcceptStockRequestModelAsync(model, null);

            //if we got this far, something failed, redisplay form
            return View(model);
        }
        //display the list of the requests that need to be handeled and give the user the ability to search using the piriority and taken action

        #endregion

        #endregion

        #region Barcodes

        [HttpGet]
        public async Task<ActionResult> ScanBarcode(int warehouseId)
        {
            return View(warehouseId);
        }

        #region Receiving Stock Barcode APIs

        [HttpGet]
        public async Task<ActionResult> ScanReceivedItems(int warehouseId)
        {
            return View(warehouseId);
        }

        #endregion

        #region Returning Stock To Vendor Barcode APIs

        [HttpGet]
        public async Task<ActionResult> ScanReturnedToVendorItems(int warehouseId)
        {
            return View(warehouseId);
        }


        

        

        #endregion

        #region Map items to shelf

        //Admin/Stock/MapItemToShelf
        [HttpGet]
        public async Task<ActionResult> MapItemToShelf(int warehouseId)
        {
            return View(warehouseId);
        }

        [HttpGet]
        public async Task<ActionResult> PrintBarcodes(int warehouseId)
        {
            return View(warehouseId);
        }


        #endregion



        #endregion












    }

} 

