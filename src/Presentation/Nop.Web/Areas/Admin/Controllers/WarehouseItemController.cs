
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
    public class WarehouseItemController : BaseAdminController
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
        private readonly IWarehouseItemModelFactory _warehouseItemModelFactory;
        private readonly IWarehouseItemService _warehouseItemService;

        #endregion

        #region Ctor

        public WarehouseItemController(ICustomerActivityService customerActivityService,
            IExportManager exportManager,
            IImportManager importManager,
            ILocalizationService localizationService,
            INotificationService notificationService,
            IPermissionService permissionService,
            IStaticCacheManager staticCacheManager,
            IWorkContext workContext,
            IWarehouseItemModelFactory warehouseItemModelFactory,
            IWarehouseItemService warehouseItemService)
        {
            _customerActivityService = customerActivityService;
            _exportManager = exportManager;
            _importManager = importManager;
            _localizationService = localizationService;
            _notificationService = notificationService;
            _permissionService = permissionService;
            _staticCacheManager = staticCacheManager;
            _workContext = workContext;
            _warehouseItemModelFactory = warehouseItemModelFactory;
            _warehouseItemService = warehouseItemService;
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

            return AccessDeniedView();

            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
                return AccessDeniedView();

            //prepare model
            var model = _warehouseItemModelFactory.PrepareWarehouseItemSearchModelAsync(new WarehouseItemSearchModel());

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> List(WarehouseItemSearchModel searchModel)
        {
            return AccessDeniedView();
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
                return await AccessDeniedDataTablesJson();

            //prepare model
            var model = await _warehouseItemModelFactory.PrepareWarehouseItemListModelAsync(searchModel);

            return Json(model);
        }

        #endregion

        #region Create / Edit / Delete

        public async Task<IActionResult> Create()
        {
            return AccessDeniedView();
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
                return AccessDeniedView();

            //prepare model
            var model = await _warehouseItemModelFactory.PrepareWarehouseItemModelAsync(new WarehouseItemModel(), null);

            return View(model);
        }

        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        public async Task<IActionResult> Create(WarehouseItemModel model)
        {
            return AccessDeniedView();
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
                return AccessDeniedView();

            if (ModelState.IsValid)
            {
                var warehouseItem = model.ToEntity<WarehouseItem>();
                warehouseItem.CreatedOnUtc = DateTime.UtcNow;
                warehouseItem.UpdatedOnUtc = DateTime.UtcNow;
                var currentUser = await _workContext.GetCurrentCustomerAsync();
                warehouseItem.CreatedBy = currentUser.Id;
                await _warehouseItemService.InsertWarehouseItemAsync(warehouseItem);

                //activity log
                await _customerActivityService.InsertActivityAsync("AddNewWarehouseItem",
                    string.Format(await _localizationService.GetResourceAsync("ActivityLog.AddNewWarehouseItem"), warehouseItem.Id), warehouseItem);

                _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Warehouses.WarehouseItem.Added"));

                return RedirectToAction("List");
            }

            //prepare model
            model = await _warehouseItemModelFactory.PrepareWarehouseItemModelAsync(model, null);

            //if we got this far, something failed, redisplay form
            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            return AccessDeniedView();
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
                return AccessDeniedView();

            //try to get a warehouse item with the specified id
            var warehouseItem = await _warehouseItemService.GetWarehouseItemByIdAsync(id);
            if (warehouseItem is null || warehouseItem.Deleted)
                return RedirectToAction("List");

            //prepare model
            var model = await _warehouseItemModelFactory.PrepareWarehouseItemModelAsync(null, warehouseItem);

            return View(model);
        }

        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        public async Task<IActionResult> Edit(WarehouseItemModel model)
        {
            return AccessDeniedView();
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
                return AccessDeniedView();

            //try to get a warehouse item with the specified id
            var warehouseItem = await _warehouseItemService.GetWarehouseItemByIdAsync(model.Id);
            if (warehouseItem is null || warehouseItem.Deleted)
                return RedirectToAction("List");

            if (ModelState.IsValid)
            {
                warehouseItem = model.ToEntity(warehouseItem);
                warehouseItem.UpdatedOnUtc = DateTime.UtcNow;
                var currentUser = await _workContext.GetCurrentCustomerAsync();
                warehouseItem.UpdatedBy = currentUser.Id;

                await _warehouseItemService.UpdateWarehouseItemAsync(warehouseItem);

                //activity log
                await _customerActivityService.InsertActivityAsync("EditWarehouseItem",
                    string.Format(await _localizationService.GetResourceAsync("ActivityLog.EditWarehouseItem"), warehouseItem.Id), warehouseItem);

                _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Warehouses.WarehouseItem.Updated"));

                return RedirectToAction("List");
            }

            //prepare model
            model = await _warehouseItemModelFactory.PrepareWarehouseItemModelAsync(model, warehouseItem);

            //if we got this far, something failed, redisplay form
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            return AccessDeniedView();
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
                return AccessDeniedView();

            //try to get a warehouse item with the specified id
            var warehouseItem = await _warehouseItemService.GetWarehouseItemByIdAsync(id);

            if (warehouseItem is null)
                return RedirectToAction("List");

            await _warehouseItemService.DeleteWarehouseItemAsync(warehouseItem);

            var currentUser = await _workContext.GetCurrentCustomerAsync();

            //activity log
            await _customerActivityService.InsertActivityAsync("DeleteWarehouseItem",
                string.Format(await _localizationService.GetResourceAsync("ActivityLog.DeleteWarehouseItem"), warehouseItem.Id), warehouseItem);

            _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Warehouses.WarehouseItem.Deleted"));

            return RedirectToAction("List");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteSelected(ICollection<int> selectedIds)
        {
            return AccessDeniedView();
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
                return AccessDeniedView();

            if (selectedIds is null || selectedIds.Count == 0)
                return NoContent();

            await _warehouseItemService.DeleteWarehouseItemAsync(await _warehouseItemService.GetWarehouseItemByIdsAsync(selectedIds.ToArray()));

            return Json(new { Result = true });
        }

        #endregion

      

    }

}
