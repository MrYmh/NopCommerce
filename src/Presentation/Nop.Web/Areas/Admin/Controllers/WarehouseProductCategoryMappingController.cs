
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Core.Caching;
using Nop.Core.Domain.Warehouses;
using Nop.Services.ExportImport;
using Nop.Services.Localization;
using Nop.Services.Logging;
using Nop.Services.Messages;
using Nop.Services.Security;
using Nop.Services.Warehouses;
using Nop.Services.Warehouses.Interface;
using Nop.Web.Areas.Admin.Factories.WarehouseFactories;
using Nop.Web.Areas.Admin.Infrastructure.Mapper.Extensions;
using Nop.Web.Areas.Admin.Models.Warehouses;
using Nop.Web.Framework.Mvc.Filters;

namespace Nop.Web.Areas.Admin.Controllers
{
    public class WarehouseProductCategoryMappingController : BaseAdminController
    {
        #region Fields

        private readonly ICustomerActivityService _customerActivityService;
        private readonly IExportManager _exportManager;
        private readonly IImportManager _importManager;
        private readonly ILocalizationService _localizationService;
        private readonly INotificationService _notificationService;
        private readonly IPermissionService _permissionService;
        private readonly IStaticCacheManager _staticCacheManager;
        private readonly IWorkContext _workContext;
        private readonly IWarehouseProductCategoryMappingModelFactory _warehouseProductCategoryMappingModelFactory;
        private readonly IWarehouseProductCategoryMappingService _warehouseProductCategoryMappingService;

        #endregion

        #region Ctor

        public WarehouseProductCategoryMappingController(ICustomerActivityService customerActivityService,
            IExportManager exportManager,
            IImportManager importManager,
            ILocalizationService localizationService,
            INotificationService notificationService,
            IPermissionService permissionService,
            IStaticCacheManager staticCacheManager,
            IWorkContext workContext,
            IWarehouseProductCategoryMappingModelFactory warehouseProductCategoryMappingModelFactory,
            IWarehouseProductCategoryMappingService warehouseProductCategoryMappingService)
        {
            _customerActivityService = customerActivityService;
            _exportManager = exportManager;
            _importManager = importManager;
            _localizationService = localizationService;
            _notificationService = notificationService;
            _permissionService = permissionService;
            _staticCacheManager = staticCacheManager;
            _workContext = workContext;
            _warehouseProductCategoryMappingModelFactory = warehouseProductCategoryMappingModelFactory;
            _warehouseProductCategoryMappingService = warehouseProductCategoryMappingService;
        }

        #endregion

        #region Utilities

        #endregion

        #region List

        //public IActionResult Index()
        //{
        //    return RedirectToAction("List");
        //}

        public async Task<IActionResult> List(int warehouseId)
        {
            if (warehouseId <= 0)
                return AccessDeniedView();

            //TODO: ADD LOGIC TO VALIDATE IF THE USER IS ALLOWED TO ENTER THIS SPECIFIC WAREHOUSE
            //var currentUser = await _workContext.GetCurrentCustomerAsync();
            //if (!IsUserAllowedToAccessWarehouse(warehouseId, currentUser.Id))
            //    return AccessDeniedView();

            //TODO: IF NOT ALLOWED TO ENTER THIS WAREHOUSE RETURN AccessDeniedView()

            // validate the user permission
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
                return AccessDeniedView();

            //prepare search model
            var searchModel = new WarehouseProductCategoryMappingSearchModel() { WarehouseId = warehouseId };


            //prepare model
            var model = _warehouseProductCategoryMappingModelFactory.PrepareWarehouseProductCategoryMappingSearchModelAsync(searchModel);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> List(WarehouseProductCategoryMappingSearchModel searchModel, int warehouseId)
        {
            if (warehouseId <= 0)
                return AccessDeniedView();

            //TODO: ADD LOGIC TO VALIDATE IF THE USER IS ALLOWED TO ENTER THIS SPECIFIC WAREHOUSE
            //var currentUser = await _workContext.GetCurrentCustomerAsync();
            //if (!IsUserAllowedToAccessWarehouse(warehouseId, currentUser.Id))
            //    return AccessDeniedView();

            //TODO: IF NOT ALLOWED TO ENTER THIS WAREHOUSE RETURN AccessDeniedView()
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
                return await AccessDeniedDataTablesJson();

            //prepare model
            var model = await _warehouseProductCategoryMappingModelFactory.PrepareWarehouseProductCategoryMappingListModelAsync(searchModel);

            return Json(model);
        }

        #endregion

        #region Create / Edit / Delete

        public async Task<IActionResult> Create(int warehouseId)
        {
            if (warehouseId <= 0)
                return AccessDeniedView();

            //TODO: ADD LOGIC TO VALIDATE IF THE USER IS ALLOWED TO ENTER THIS SPECIFIC WAREHOUSE
            //var currentUser = await _workContext.GetCurrentCustomerAsync();
            //if (!IsUserAllowedToAccessWarehouse(warehouseId, currentUser.Id))
            //    return AccessDeniedView();

            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
                return AccessDeniedView();

            var model = new WarehouseProductCategoryMappingModel() { WarehouseId = warehouseId };

            //prepare model
            var preparedModel = await _warehouseProductCategoryMappingModelFactory.PrepareWarehouseProductCategoryMappingModelAsync(model, null);

            return View(preparedModel);
        }

        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        public async Task<IActionResult> Create(WarehouseProductCategoryMappingModel model, int warehouseId)
        {
            if (warehouseId <= 0)
                return AccessDeniedView();

            //TODO: ADD LOGIC TO VALIDATE IF THE USER IS ALLOWED TO ENTER THIS SPECIFIC WAREHOUSE
            var currentUser = await _workContext.GetCurrentCustomerAsync();
            //if (!IsUserAllowedToAccessWarehouse(warehouseId, currentUser.Id))
            //    return AccessDeniedView();

            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
                return AccessDeniedView();

            if (ModelState.IsValid)
            {
                //add multiple product categories
                if (model.SelectedProductCategoriesIds.Any())
                {
                    var mappedWarehouseProductCategories = new List<WarehouseProductCategoryMapping>();
                    foreach (var selectedProductCategoryId in model.SelectedProductCategoriesIds)
                    {
                        mappedWarehouseProductCategories.Add(new WarehouseProductCategoryMapping()
                        {
                            WarehouseId = warehouseId,
                            WarehouseCategoryMappingId = model.WarehouseCategoryMappingId,
                            ProductCategoryId = selectedProductCategoryId,
                            CreatedOnUtc = DateTime.UtcNow,
                            CreatedBy = currentUser.Id
                        });
                    }
                    await _warehouseProductCategoryMappingService.InsertWarehouseProductCategoryMappingAsync(mappedWarehouseProductCategories);

                    foreach (var warehouseProductCategoryMapping in mappedWarehouseProductCategories)
                    {
                        //activity log
                        await _customerActivityService.InsertActivityAsync("AddNewWarehouseProductCategoryMapping",
                            string.Format(await _localizationService.GetResourceAsync("ActivityLog.AddNewWarehouseProductCategoryMapping"), warehouseProductCategoryMapping.Id), warehouseProductCategoryMapping);
                    }
                }
                else
                {
                    return RedirectToAction("List", "WarehouseProductCategoryMapping", new { warehouseId = warehouseId });
                }


                _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Warehouses.WarehouseProductCategoryMapping.Added"));

                return RedirectToAction("List", "WarehouseProductCategoryMapping", new { warehouseId = warehouseId });
            }

            //prepare model
            model = await _warehouseProductCategoryMappingModelFactory.PrepareWarehouseProductCategoryMappingModelAsync(model, null);

            //if we got this far, something failed, redisplay form
            return View(model);
        }

        public async Task<IActionResult> Edit(int id, int warehouseId)
        {
            if (warehouseId <= 0)
                return AccessDeniedView();

            //TODO: ADD LOGIC TO VALIDATE IF THE USER IS ALLOWED TO ENTER THIS SPECIFIC WAREHOUSE
            //var currentUser = await _workContext.GetCurrentCustomerAsync();
            //if (!IsUserAllowedToAccessWarehouse(warehouseId, currentUser.Id))
            //    return AccessDeniedView();

            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
                return AccessDeniedView();

            //try to get a warehouse product category mapping with the specified id
            var warehouseProductCategoryMapping = await _warehouseProductCategoryMappingService.GetWarehouseProductCategoryMappingByIdAsync(id);
            if (warehouseProductCategoryMapping is null || warehouseProductCategoryMapping.Deleted)
                return RedirectToAction("List", "WarehouseProductCategoryMapping", new { warehouseId = warehouseId });

            //prepare model
            var model = await _warehouseProductCategoryMappingModelFactory.PrepareWarehouseProductCategoryMappingModelAsync(null, warehouseProductCategoryMapping, true);
            model.IsEditMode = true;
            return View(model);
        }

        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        public async Task<IActionResult> Edit(WarehouseProductCategoryMappingModel model, int warehouseId)
        {
            if (warehouseId <= 0)
                return AccessDeniedView();

            //TODO: ADD LOGIC TO VALIDATE IF THE USER IS ALLOWED TO ENTER THIS SPECIFIC WAREHOUSE
            var currentUser = await _workContext.GetCurrentCustomerAsync();
            //if (!IsUserAllowedToAccessWarehouse(warehouseId, currentUser.Id))
            //    return AccessDeniedView();

            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
                return AccessDeniedView();

            //try to get a warehouse product category mapping with the specified id
            var warehouseProductCategoryMapping = await _warehouseProductCategoryMappingService.GetWarehouseProductCategoryMappingByIdAsync(model.Id);
            if (warehouseProductCategoryMapping is null || warehouseProductCategoryMapping.Deleted)
                return RedirectToAction("List", "WarehouseProductCategoryMapping", new { warehouseId = warehouseId });

            if (ModelState.IsValid)
            {
                warehouseProductCategoryMapping.WarehouseCategoryMappingId = model.WarehouseCategoryMappingId;
                warehouseProductCategoryMapping.ProductCategoryId = model.SelectedProductCategoriesIds.FirstOrDefault();
                warehouseProductCategoryMapping.UpdatedOnUtc = DateTime.UtcNow;
                warehouseProductCategoryMapping.UpdatedBy = currentUser.Id;

                await _warehouseProductCategoryMappingService.UpdateWarehouseProductCategoryMappingAsync(warehouseProductCategoryMapping);

                //activity log
                await _customerActivityService.InsertActivityAsync("EditWarehouseProductCategoryMapping",
                    string.Format(await _localizationService.GetResourceAsync("ActivityLog.EditWarehouseProductCategoryMapping"), warehouseProductCategoryMapping.Id), warehouseProductCategoryMapping);

                _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Warehouses.WarehouseProductCategoryMapping.Updated"));

                return RedirectToAction("List", "WarehouseProductCategoryMapping", new { warehouseId = warehouseId });
            }

            //prepare model
            model = await _warehouseProductCategoryMappingModelFactory.PrepareWarehouseProductCategoryMappingModelAsync(model, warehouseProductCategoryMapping);

            //if we got this far, something failed, redisplay form
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, int warehouseId)
        {
            //TODO: ADD LOGIC TO VALIDATE IF THE USER IS ALLOWED TO ENTER THIS SPECIFIC WAREHOUSE
            //var currentUser = await _workContext.GetCurrentCustomerAsync();
            //if (!IsUserAllowedToAccessWarehouse(warehouseId, currentUser.Id))
            //    return AccessDeniedView();

            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
                return AccessDeniedView();

            //try to get a warehouse product category mapping with the specified id
            var warehouseProductCategoryMapping = await _warehouseProductCategoryMappingService.GetWarehouseProductCategoryMappingByIdAsync(id);

            if (warehouseProductCategoryMapping is null)
                return RedirectToAction("List", "WarehouseProductCategoryMapping", new { warehouseId = warehouseId });

            await _warehouseProductCategoryMappingService.DeleteWarehouseProductCategoryMappingAsync(warehouseProductCategoryMapping);

            //activity log
            await _customerActivityService.InsertActivityAsync("DeleteWarehouseProductCategoryMapping",
                string.Format(await _localizationService.GetResourceAsync("ActivityLog.DeleteWarehouseProductCategoryMapping"), warehouseProductCategoryMapping.Id), warehouseProductCategoryMapping);

            _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Warehouses.WarehouseProductCategoryMapping.Deleted"));

            return RedirectToAction("List", "WarehouseProductCategoryMapping", new { warehouseId = warehouseId });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteSelected(ICollection<int> selectedIds, int warehouseId)
        {
            //TODO: ADD LOGIC TO VALIDATE IF THE USER IS ALLOWED TO ENTER THIS SPECIFIC WAREHOUSE
            //var currentUser = await _workContext.GetCurrentCustomerAsync();
            //if (!IsUserAllowedToAccessWarehouse(warehouseId, currentUser.Id))
            //    return AccessDeniedView();

            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
                return AccessDeniedView();

            if (selectedIds is null || selectedIds.Count == 0)
                return NoContent();

            await _warehouseProductCategoryMappingService.DeleteWarehouseProductCategoryMappingAsync(await _warehouseProductCategoryMappingService.GetWarehouseProductCategoryMappingByIdsAsync(selectedIds.ToArray()));

            return Json(new { Result = true });
        }

        #endregion

    }

}
