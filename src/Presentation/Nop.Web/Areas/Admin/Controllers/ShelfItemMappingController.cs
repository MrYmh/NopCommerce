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
    public class ShelfItemMappingController : BaseAdminController
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
        private readonly IShelfItemMappingModelFactory _shelfItemMappingModelFactory;
        private readonly IShelfItemMappingService _shelfItemMappingService;

        #endregion

        #region Ctor

        public ShelfItemMappingController(ICustomerActivityService customerActivityService,
            IExportManager exportManager,
            IImportManager importManager,
            ILocalizationService localizationService,
            INotificationService notificationService,
            IPermissionService permissionService,
            IStaticCacheManager staticCacheManager,
            IWorkContext workContext,
            IShelfItemMappingModelFactory shelfItemMappingModelFactory,
            IShelfItemMappingService shelfItemMappingService)
        {
            _customerActivityService = customerActivityService;
            _exportManager = exportManager;
            _importManager = importManager;
            _localizationService = localizationService;
            _notificationService = notificationService;
            _permissionService = permissionService;
            _staticCacheManager = staticCacheManager;
            _workContext = workContext;
            _shelfItemMappingModelFactory = shelfItemMappingModelFactory;
            _shelfItemMappingService = shelfItemMappingService;
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
            var model = _shelfItemMappingModelFactory.PrepareShelfItemMappingSearchModelAsync(new ShelfItemMappingSearchModel());

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> List(ShelfItemMappingSearchModel searchModel)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
                return await AccessDeniedDataTablesJson();

            //prepare model
            var model = await _shelfItemMappingModelFactory.PrepareShelfItemMappingListModelAsync(searchModel);

            return Json(model);
        }

        #endregion

        #region Create / Edit / Delete

        public async Task<IActionResult> Create()
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
                return AccessDeniedView();

            //prepare model
            var model = await _shelfItemMappingModelFactory.PrepareShelfItemMappingModelAsync(new ShelfItemMappingModel(), null);

            return View(model);
        }

        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        public async Task<IActionResult> Create(ShelfItemMappingModel model)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
                return AccessDeniedView();

            if (ModelState.IsValid)
            {
                var shelfItemMapping = model.ToEntity<ShelfItemMapping>();
                shelfItemMapping.CreatedOnUtc = DateTime.UtcNow;
                shelfItemMapping.UpdatedOnUtc = DateTime.UtcNow;
                var currentUser = await _workContext.GetCurrentCustomerAsync();
                shelfItemMapping.CreatedBy = currentUser.Id;
                await _shelfItemMappingService.InsertShelfItemMappingAsync(shelfItemMapping);

                //activity log
                await _customerActivityService.InsertActivityAsync("AddNewShelfItemMapping",
                    string.Format(await _localizationService.GetResourceAsync("ActivityLog.AddNewShelfItemMapping"), shelfItemMapping.Id), shelfItemMapping);

                _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Warehouses.ShelfItemMapping.Added"));

                return RedirectToAction("List");
            }

            //prepare model
            model = await _shelfItemMappingModelFactory.PrepareShelfItemMappingModelAsync(model, null);

            //if we got this far, something failed, redisplay form
            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
                return AccessDeniedView();

            //try to get a shelf item mapping with the specified id
            var shelfItemMapping = await _shelfItemMappingService.GetShelfItemMappingByIdAsync(id);
            if (shelfItemMapping is null || shelfItemMapping.Deleted)
                return RedirectToAction("List");

            //prepare model
            var model = await _shelfItemMappingModelFactory.PrepareShelfItemMappingModelAsync(null, shelfItemMapping);

            return View(model);
        }

        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        public async Task<IActionResult> Edit(ShelfItemMappingModel model)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
                return AccessDeniedView();

            //try to get a shelf item mapping with the specified id
            var shelfItemMapping = await _shelfItemMappingService.GetShelfItemMappingByIdAsync(model.Id);
            if (shelfItemMapping is null || shelfItemMapping.Deleted)
                return RedirectToAction("List");

            if (ModelState.IsValid)
            {
                shelfItemMapping = model.ToEntity(shelfItemMapping);
                shelfItemMapping.UpdatedOnUtc = DateTime.UtcNow;
                var currentUser = await _workContext.GetCurrentCustomerAsync();
                shelfItemMapping.UpdatedBy = currentUser.Id;

                await _shelfItemMappingService.UpdateShelfItemMappingAsync(shelfItemMapping);

                //activity log
                await _customerActivityService.InsertActivityAsync("EditShelfItemMapping",
                    string.Format(await _localizationService.GetResourceAsync("ActivityLog.EditShelfItemMapping"), shelfItemMapping.Id), shelfItemMapping);

                _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Warehouses.ShelfItemMapping.Updated"));

                return RedirectToAction("List");
            }

            //prepare model
            model = await _shelfItemMappingModelFactory.PrepareShelfItemMappingModelAsync(model, shelfItemMapping);

            //if we got this far, something failed, redisplay form
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
                return AccessDeniedView();

            //try to get a shelf item mapping with the specified id
            var shelfItemMapping = await _shelfItemMappingService.GetShelfItemMappingByIdAsync(id);

            if (shelfItemMapping is null)
                return RedirectToAction("List");

            await _shelfItemMappingService.DeleteShelfItemMappingAsync(shelfItemMapping);

            var currentUser = await _workContext.GetCurrentCustomerAsync();

            //activity log
            await _customerActivityService.InsertActivityAsync("DeleteShelfItemMapping",
                string.Format(await _localizationService.GetResourceAsync("ActivityLog.DeleteShelfItemMapping"), shelfItemMapping.Id), shelfItemMapping);

            _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Warehouses.ShelfItemMapping.Deleted"));

            return RedirectToAction("List");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteSelected(ICollection<int> selectedIds)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
                return AccessDeniedView();

            if (selectedIds is null || selectedIds.Count == 0)
                return NoContent();

            await _shelfItemMappingService.DeleteShelfItemMappingAsync(await _shelfItemMappingService.GetShelfItemMappingByIdsAsync(selectedIds.ToArray()));

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
