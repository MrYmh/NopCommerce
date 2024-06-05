
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.EMMA;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Mvc;
using Nito.AsyncEx.Synchronous;
using Nop.Core;
using Nop.Core.Caching;
using Nop.Core.Domain.Warehouses;
using Nop.Services.ExportImport;
using Nop.Services.Localization;
using Nop.Services.Logging;
using Nop.Services.Messages;
using Nop.Services.Security;
using Nop.Services.Warehouses.Interface;
using Nop.Web.Areas.Admin.Factories.WarehouseFactories;
using Nop.Web.Areas.Admin.Infrastructure.Mapper.Extensions;
using Nop.Web.Areas.Admin.Models.Warehouses;
using Nop.Web.Framework.Mvc.Filters;

namespace Nop.Web.Areas.Admin.Controllers
{
    public class WarehouseCategoryMappingController : BaseAdminController
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
        private readonly IWarehouseCategoryMappingModelFactory _warehouseCategoryMappingModelFactory;
        private readonly IWarehouseCategoryMappingService _warehouseCategoryMappingService;

        #endregion

        #region Ctor

        public WarehouseCategoryMappingController(ICustomerActivityService customerActivityService,
            IExportManager exportManager,
            IImportManager importManager,
            ILocalizationService localizationService,
            INotificationService notificationService,
            IPermissionService permissionService,
            IStaticCacheManager staticCacheManager,
            IWorkContext workContext,
            IWarehouseCategoryMappingModelFactory warehouseCategoryMappingModelFactory,
            IWarehouseCategoryMappingService warehouseCategoryMappingService)
        {
            _customerActivityService = customerActivityService;
            _exportManager = exportManager;
            _importManager = importManager;
            _localizationService = localizationService;
            _notificationService = notificationService;
            _permissionService = permissionService;
            _staticCacheManager = staticCacheManager;
            _workContext = workContext;
            _warehouseCategoryMappingModelFactory = warehouseCategoryMappingModelFactory;
            _warehouseCategoryMappingService = warehouseCategoryMappingService;
        }

        #endregion

        #region Utilities

        #endregion

        #region List

        public IActionResult Index(int warehouseId)
        {
            return RedirectToAction("List");
        }

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
            var searchModel = new WarehouseCategoryMappingSearchModel() { WarehouseId = warehouseId };

            //prepare model
            var model = _warehouseCategoryMappingModelFactory.PrepareWarehouseCategoryMappingSearchModelAsync(searchModel);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> List(WarehouseCategoryMappingSearchModel searchModel, int warehouseId)
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

            //searchModel.WarehouseId = warehouseId;

            //prepare model
            var model = await _warehouseCategoryMappingModelFactory.PrepareWarehouseCategoryMappingListModelAsync(searchModel);

            return Json(model);
        }

        #endregion

        #region Create / Edit / Delete

        public async Task<IActionResult> Create(int warehouseId)
        {
            if (warehouseId <= 0)
            {
                return AccessDeniedView();
            }
            //TODO: ADD LOGIC TO VALIDATE IF THE USER IS ALLOWED TO ENTER THIS SPECIFIC WAREHOUSE
            //var currentUser = await _workContext.GetCurrentCustomerAsync();
            //if (!IsUserAllowedToAccessWarehouse(warehouseId, currentUser.Id))
            //    return AccessDeniedView();


            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
                return AccessDeniedView();

            var model = new WarehouseCategoryMappingModel() { WarehouseId = warehouseId };

            //prepare model
            var preparedModel = await _warehouseCategoryMappingModelFactory.PrepareWarehouseCategoryMappingModelAsync(model, null);

            return View(preparedModel);
        }

        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        public async Task<IActionResult> Create(WarehouseCategoryMappingModel model, int warehouseId)
        {
            if (warehouseId <= 0)
                return AccessDeniedView();

            var currentUser = await _workContext.GetCurrentCustomerAsync();
            //TODO: ADD LOGIC TO VALIDATE IF THE USER IS ALLOWED TO ENTER THIS SPECIFIC WAREHOUSE
            //var currentUser = await _workContext.GetCurrentCustomerAsync();
            //if (!IsUserAllowedToAccessWarehouse(warehouseId, currentUser.Id))
            //    return AccessDeniedView();

            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
                return AccessDeniedView();

            if (ModelState.IsValid)
            {
                //posting many warehouse categories at once
                if (model.SelectedWarehouseCategoriesIds.Any())
                {
                    var mappedWarehouseCategories = new List<WarehouseCategoryMapping>();
                    foreach (var selectedWarehouseCategoryId in model.SelectedWarehouseCategoriesIds)
                    {
                        mappedWarehouseCategories.Add(new WarehouseCategoryMapping()
                        {
                            CreatedOnUtc = DateTime.UtcNow,
                            CreatedBy = currentUser.Id,
                            WarehouseCategoryId = selectedWarehouseCategoryId,
                            WarehouseId = model.WarehouseId
                        });
                    }

                    await _warehouseCategoryMappingService.InsertWarehouseCategoryMappingAsync(mappedWarehouseCategories);

                    foreach (var mappedWarehouseCategory in mappedWarehouseCategories)
                    {
                        //activity log
                        await _customerActivityService.InsertActivityAsync("AddNewWarehouseCategoryMapping",
                            string.Format(await _localizationService.GetResourceAsync("ActivityLog.AddNewWarehouseCategoryMapping"), mappedWarehouseCategory.Id), mappedWarehouseCategory);
                    }
                }
                else
                {
                    return RedirectToAction("List", "WarehouseCategoryMapping", new { warehouseId = model.WarehouseId });
                }

                _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Warehouses.WarehouseCategoryMapping.Added"));
                return RedirectToAction("List", "WarehouseCategoryMapping", new { warehouseId = model.WarehouseId });

            }

            //prepare model
            model = await _warehouseCategoryMappingModelFactory.PrepareWarehouseCategoryMappingModelAsync(model, null);

            //if we got this far, something failed, redisplay form
            return View(model);
        }

        public async Task<IActionResult> Edit(int id, int warehouseId)
        {
            
            return AccessDeniedView();
            //TODO: ADD LOGIC TO VALIDATE IF THE USER IS ALLOWED TO ENTER THIS SPECIFIC WAREHOUSE
            //var currentUser = await _workContext.GetCurrentCustomerAsync();
            //if (!IsUserAllowedToAccessWarehouse(warehouseId, currentUser.Id))
            //    return AccessDeniedView();

            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
                return AccessDeniedView();

            //try to get a warehouse category mapping with the specified id
            var warehouseCategoryMapping = await _warehouseCategoryMappingService.GetWarehouseCategoryMappingByIdAsync(id);
            if (warehouseCategoryMapping is null || warehouseCategoryMapping.Deleted)
                return RedirectToAction("List");

            //prepare model
            var model = await _warehouseCategoryMappingModelFactory.PrepareWarehouseCategoryMappingModelAsync(null, warehouseCategoryMapping);

            return View(model);
        }

        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        public async Task<IActionResult> Edit(WarehouseCategoryMappingModel model, int warehouseId)
        {
            return AccessDeniedView();
            var currentUser = await _workContext.GetCurrentCustomerAsync();
            //TODO: ADD LOGIC TO VALIDATE IF THE USER IS ALLOWED TO ENTER THIS SPECIFIC WAREHOUSE
            //var currentUser = await _workContext.GetCurrentCustomerAsync();
            //if (!IsUserAllowedToAccessWarehouse(warehouseId, currentUser.Id))
            //    return AccessDeniedView();

            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
                return AccessDeniedView();

            //try to get a warehouse category mapping with the specified id
            var warehouseCategoryMapping = await _warehouseCategoryMappingService.GetWarehouseCategoryMappingByIdAsync(model.Id);
            if (warehouseCategoryMapping is null || warehouseCategoryMapping.Deleted)
                return RedirectToAction("List");

            if (ModelState.IsValid)
            {
                warehouseCategoryMapping = model.ToEntity(warehouseCategoryMapping);
                warehouseCategoryMapping.UpdatedOnUtc = DateTime.UtcNow;
                warehouseCategoryMapping.UpdatedBy = currentUser.Id;

                await _warehouseCategoryMappingService.UpdateWarehouseCategoryMappingAsync(warehouseCategoryMapping);

                //activity log
                await _customerActivityService.InsertActivityAsync("EditWarehouseCategoryMapping",
                    string.Format(await _localizationService.GetResourceAsync("ActivityLog.EditWarehouseCategoryMapping"), warehouseCategoryMapping.Id), warehouseCategoryMapping);

                _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Warehouses.WarehouseCategoryMapping.Updated"));

                return RedirectToAction("List");
            }

            //prepare model
            model = await _warehouseCategoryMappingModelFactory.PrepareWarehouseCategoryMappingModelAsync(model, warehouseCategoryMapping);

            //if we got this far, something failed, redisplay form
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, int warehouseId)
        {
            var currentUser = await _workContext.GetCurrentCustomerAsync();
            //TODO: ADD LOGIC TO VALIDATE IF THE USER IS ALLOWED TO ENTER THIS SPECIFIC WAREHOUSE
            //var currentUser = await _workContext.GetCurrentCustomerAsync();
            //if (!IsUserAllowedToAccessWarehouse(warehouseId, currentUser.Id))
            //    return AccessDeniedView();

            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
                return AccessDeniedView();

            //try to get a warehouse category mapping with the specified id
            var warehouseCategoryMapping = await _warehouseCategoryMappingService.GetWarehouseCategoryMappingByIdAsync(id);

            if (warehouseCategoryMapping?.IsSystem == true)
            {
                _notificationService.ErrorNotification(await _localizationService.GetResourceAsync("Admin.Warehouses.WarehouseCategoryMapping.CannotDeletedSystemMapping"));
                return RedirectToAction("List");
            }


            await _warehouseCategoryMappingService.DeleteWarehouseCategoryMappingAsync(warehouseCategoryMapping);


            //activity log
            await _customerActivityService.InsertActivityAsync("DeleteWarehouseCategoryMapping",
                string.Format(await _localizationService.GetResourceAsync("ActivityLog.DeleteWarehouseCategoryMapping"), warehouseCategoryMapping.Id), warehouseCategoryMapping);

            _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Warehouses.WarehouseCategoryMapping.Deleted"));

            return RedirectToAction("List");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteSelected(ICollection<int> selectedIds, int warehouseId)
        {
            var currentUser = await _workContext.GetCurrentCustomerAsync();
            //TODO: ADD LOGIC TO VALIDATE IF THE USER IS ALLOWED TO ENTER THIS SPECIFIC WAREHOUSE
            //var currentUser = await _workContext.GetCurrentCustomerAsync();
            //if (!IsUserAllowedToAccessWarehouse(warehouseId, currentUser.Id))
            //    return AccessDeniedView();

            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
                return AccessDeniedView();

            if (selectedIds is null || selectedIds.Count == 0)
                return NoContent();

            var mappedWarehouseCategories = await _warehouseCategoryMappingService.GetWarehouseCategoryMappingByIdsAsync(selectedIds.ToArray());

            var deletableNonSystemMappedCategories = mappedWarehouseCategories.Where(x => x.IsSystem != true).ToArray();
            await _warehouseCategoryMappingService.DeleteWarehouseCategoryMappingAsync(deletableNonSystemMappedCategories);

            foreach (var mappedWarehouseCategory in mappedWarehouseCategories)
            {
                //activity log
                await _customerActivityService.InsertActivityAsync("DeleteWarehouseCategoryMapping",
                    string.Format(await _localizationService.GetResourceAsync("ActivityLog.DeleteWarehouseCategoryMapping"), mappedWarehouseCategory.Id), mappedWarehouseCategory);
            }

            return Json(new { Result = true });
        }

        #endregion

        #region Export / Import

        //public virtual async Task<IActionResult> ExportXml()
        //{
        //    if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
        //        return AccessDeniedView();

        //    try
        //    {
        //        var xml = await _exportManager.ExportCategoriesToXmlAsync();

        //        return File(Encoding.UTF8.GetBytes(xml), "application/xml", "categories.xml");
        //    }
        //    catch (Exception exc)
        //    {
        //        await _notificationService.ErrorNotificationAsync(exc);
        //        return RedirectToAction("List");
        //    }
        //}

        //public virtual async Task<IActionResult> ExportXlsx()
        //{
        //    if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
        //        return AccessDeniedView();

        //    try
        //    {
        //        var bytes = await _exportManager
        //            .ExportCategoriesToXlsxAsync((await _categoryService.GetAllCategoriesAsync(showHidden: true)).ToList());

        //        return File(bytes, MimeTypes.TextXlsx, "categories.xlsx");
        //    }
        //    catch (Exception exc)
        //    {
        //        await _notificationService.ErrorNotificationAsync(exc);
        //        return RedirectToAction("List");
        //    }
        //}

        //[HttpPost]
        //public virtual async Task<IActionResult> ImportFromXlsx(IFormFile importexcelfile)
        //{
        //    if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
        //        return AccessDeniedView();

        //    //a vendor cannot import categories
        //    if (await _workContext.GetCurrentVendorAsync() != null)
        //        return AccessDeniedView();

        //    try
        //    {
        //        if (importexcelfile != null && importexcelfile.Length > 0)
        //        {
        //            await _importManager.ImportCategoriesFromXlsxAsync(importexcelfile.OpenReadStream());
        //        }
        //        else
        //        {
        //            _notificationService.ErrorNotification(await _localizationService.GetResourceAsync("Admin.Common.UploadFile"));
        //            return RedirectToAction("List");
        //        }

        //        _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Catalog.Categories.Imported"));

        //        return RedirectToAction("List");
        //    }
        //    catch (Exception exc)
        //    {
        //        await _notificationService.ErrorNotificationAsync(exc);
        //        return RedirectToAction("List");
        //    }
        //}

        #endregion

    }

}
