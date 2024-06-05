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
using Nop.Services.Warehouses.Interface;
using Nop.Web.Areas.Admin.Factories.WarehouseFactories;
using Nop.Web.Areas.Admin.Infrastructure.Mapper.Extensions;
using Nop.Web.Areas.Admin.Models.Warehouses;
using Nop.Web.Framework.Mvc.Filters;

namespace Nop.Web.Areas.Admin.Controllers
{
    public class WarehouseCategoryController : BaseAdminController
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
        private readonly IWarehouseCategoryModelFactory _warehouseCategoryModelFactory;
        private readonly IWarehouseCategoryService _warehouseCategoryService;

        #endregion

        #region Ctor

        public WarehouseCategoryController(ICustomerActivityService customerActivityService,
            IExportManager exportManager,
            IImportManager importManager,
            ILocalizationService localizationService,
            INotificationService notificationService,
            IPermissionService permissionService,
            IStaticCacheManager staticCacheManager,
            IWorkContext workContext,
            IWarehouseCategoryModelFactory warehouseCategoryModelFactory,
            IWarehouseCategoryService warehouseCategoryService)
        {
            _customerActivityService = customerActivityService;
            _exportManager = exportManager;
            _importManager = importManager;
            _localizationService = localizationService;
            _notificationService = notificationService;
            _permissionService = permissionService;
            _staticCacheManager = staticCacheManager;
            _workContext = workContext;
            _warehouseCategoryModelFactory = warehouseCategoryModelFactory;
            _warehouseCategoryService = warehouseCategoryService;
        }

        #endregion

        #region Utilities

        #endregion

        #region List

        public IActionResult Index()
        {
            return RedirectToAction("List");
        }

        public async Task<IActionResult> List()
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
                return AccessDeniedView();

            //prepare model
            var model = _warehouseCategoryModelFactory.PrepareWarehouseCategorySearchModelAsync(new WarehouseCategorySearchModel());

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> List(WarehouseCategorySearchModel searchModel)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
                return await AccessDeniedDataTablesJson();

            //prepare model
            var model = await _warehouseCategoryModelFactory.PrepareWarehouseCategoryListModelAsync(searchModel);

            return Json(model);
        }

        #endregion

        #region Create / Edit / Delete

        public async Task<IActionResult> Create()
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
                return AccessDeniedView();

            //prepare model
            var model = await _warehouseCategoryModelFactory.PrepareWarehouseCategoryModelAsync(new WarehouseCategoryModel(), null);

            return View(model);
        }

        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        public async Task<IActionResult> Create(WarehouseCategoryModel model)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
                return AccessDeniedView();

            if (ModelState.IsValid)
            {
                var warehouseCategory = model.ToEntity<WarehouseCategory>();
                warehouseCategory.CreatedOnUtc = DateTime.UtcNow;
                var currentUser = await _workContext.GetCurrentCustomerAsync();
                warehouseCategory.CreatedBy = currentUser.Id;
                await _warehouseCategoryService.InsertWarehouseCategoryAsync(warehouseCategory);

                //activity log
                await _customerActivityService.InsertActivityAsync("AddNewWarehouseCategory",
                    string.Format(await _localizationService.GetResourceAsync("ActivityLog.AddNewWarehouseCategory"), warehouseCategory.Id), warehouseCategory);

                _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Warehouses.WarehouseCategory.Added"));

                return RedirectToAction("List");
            }

            //prepare model
            model = await _warehouseCategoryModelFactory.PrepareWarehouseCategoryModelAsync(model, null);

            //if we got this far, something failed, redisplay form
            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
                return AccessDeniedView();

            //try to get a category with the specified id
            var warehouseCategory = await _warehouseCategoryService.GetWarehouseCategoryByIdAsync(id);
            if (warehouseCategory == null || warehouseCategory.Deleted)
                return RedirectToAction("List");

            //prepare model
            var model = await _warehouseCategoryModelFactory.PrepareWarehouseCategoryModelAsync(null, warehouseCategory);

            return View(model);
        }

        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        public async Task<IActionResult> Edit(WarehouseCategoryModel model)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
                return AccessDeniedView();

            //try to get a warehouse category with the specified id
            var warehouseCategory = await _warehouseCategoryService.GetWarehouseCategoryByIdAsync(model.Id);
            if (warehouseCategory == null || warehouseCategory.Deleted)
                return RedirectToAction("List");

            if (ModelState.IsValid)
            {
                warehouseCategory = model.ToEntity(warehouseCategory);
                warehouseCategory.UpdatedOnUtc = DateTime.UtcNow;
                var currentUser = await _workContext.GetCurrentCustomerAsync();
                warehouseCategory.UpdatedBy = currentUser.Id;

                await _warehouseCategoryService.UpdateWarehouseCategoryAsync(warehouseCategory);

                //activity log
                await _customerActivityService.InsertActivityAsync("EditWarehouseCategory",
                    string.Format(await _localizationService.GetResourceAsync("ActivityLog.EditWarehouseCategory"), warehouseCategory.Id), warehouseCategory);

                _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Warehouses.WarehouseCategory.Updated"));

                return RedirectToAction("List");
            }

            //prepare model
            model = await _warehouseCategoryModelFactory.PrepareWarehouseCategoryModelAsync(model, warehouseCategory);

            //if we got this far, something failed, redisplay form
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
                return AccessDeniedView();

            //try to get a category with the specified id
            var warehouseCategory = await _warehouseCategoryService.GetWarehouseCategoryByIdAsync(id);

            if (warehouseCategory is null || warehouseCategory.IsSystem)
                return RedirectToAction("List");

            await _warehouseCategoryService.DeleteWarehouseCategoryAsync(warehouseCategory);

            //activity log
            await _customerActivityService.InsertActivityAsync("DeleteWarehouseCategory",
                string.Format(await _localizationService.GetResourceAsync("ActivityLog.DeleteWarehouseCategory"), warehouseCategory.Id), warehouseCategory);

            _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Warehouses.WarehouseCategory.Deleted"));

            return RedirectToAction("List");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteSelected(ICollection<int> selectedIds)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
                return AccessDeniedView();

            if (selectedIds == null || selectedIds.Count == 0)
                return NoContent();

            var warehouseCategories = await _warehouseCategoryService.GetWarehouseCategoriesByIdsAsync(selectedIds.ToArray());
            warehouseCategories = warehouseCategories.Where(x => !x.IsSystem).ToList();

            await _warehouseCategoryService.DeleteWarehouseCategoryAsync(warehouseCategories);

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