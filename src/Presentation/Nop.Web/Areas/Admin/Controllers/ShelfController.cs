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
    public class ShelfController : BaseAdminController
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
        private readonly IShelfModelFactory _shelfModelFactory;
        private readonly IShelfService _shelfService;

        #endregion

        #region Ctor

        public ShelfController(ICustomerActivityService customerActivityService,
            IExportManager exportManager,
            IImportManager importManager,
            ILocalizationService localizationService,
            INotificationService notificationService,
            IPermissionService permissionService,
            IStaticCacheManager staticCacheManager,
            IWorkContext workContext,
            IShelfModelFactory shelfModelFactory,
            IShelfService shelfService)
        {
            _customerActivityService = customerActivityService;
            _exportManager = exportManager;
            _importManager = importManager;
            _localizationService = localizationService;
            _notificationService = notificationService;
            _permissionService = permissionService;
            _staticCacheManager = staticCacheManager;
            _workContext = workContext;
            _shelfModelFactory = shelfModelFactory;
            _shelfService = shelfService;
        }

        #endregion

        #region Utilities

        #endregion

        #region List

        public IActionResult Index()
        {
            return RedirectToAction("List");
        }

        public async Task<IActionResult> List(int warehouseId, int standId)
        {
            //TODO: ADD LOGIC TO VALIDATE IF THE USER IS ALLOWED TO ENTER THIS SPECIFIC WAREHOUSE
            //var currentUser = await _workContext.GetCurrentCustomerAsync();
            //if (!IsUserAllowedToAccessWarehouse(warehouseId, currentUser.Id))
            //    return AccessDeniedView();

            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
                return AccessDeniedView();

            var searchModel = new ShelfSearchModel()
            {
                WarehouseId = warehouseId,
                StandId = standId
            };

            //prepare model
            var model = _shelfModelFactory.PrepareShelfSearchModelAsync(searchModel);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> List(ShelfSearchModel searchModel, int warehouseId)
        {
            //TODO: ADD LOGIC TO VALIDATE IF THE USER IS ALLOWED TO ENTER THIS SPECIFIC WAREHOUSE
            //var currentUser = await _workContext.GetCurrentCustomerAsync();
            //if (!IsUserAllowedToAccessWarehouse(warehouseId, currentUser.Id))
            //    return AccessDeniedView();

            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
                return await AccessDeniedDataTablesJson();

            //prepare model
            var model = await _shelfModelFactory.PrepareShelfListModelAsync(searchModel);

            return Json(model);
        }
        #endregion
        public async Task<IActionResult> Edit(int id, int warehouseId)
        {
            //TODO: ADD LOGIC TO VALIDATE IF THE USER IS ALLOWED TO ENTER THIS SPECIFIC WAREHOUSE
            //var currentUser = await _workContext.GetCurrentCustomerAsync();
            //if (!IsUserAllowedToAccessWarehouse(warehouseId, currentUser.Id))
            //    return AccessDeniedView();

            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
                return AccessDeniedView();

            //try to get a warehouse stand with the specified id
            var shelf = await _shelfService.GetShelfByIdAsync(id);
            if (shelf is null || shelf.Deleted)
                return RedirectToAction("List", "Shelf", new { warehouseId = warehouseId });

            //prepare model
            var model = await _shelfModelFactory.PrepareShelfModelAsync(null, shelf);

            return View(model);
        }

        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        public async Task<IActionResult> Edit(ShelfModel model, int warehouseId)
        {
            var currentUser = await _workContext.GetCurrentCustomerAsync();
            //TODO: ADD LOGIC TO VALIDATE IF THE USER IS ALLOWED TO ENTER THIS SPECIFIC WAREHOUSE
            //var currentUser = await _workContext.GetCurrentCustomerAsync();
            //if (!IsUserAllowedToAccessWarehouse(warehouseId, currentUser.Id))
            //    return AccessDeniedView();

            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
                return AccessDeniedView();

            //try to get a warehouse stand with the specified id
            var shelf = await _shelfService.GetShelfByIdAsync(model.Id);
            if (shelf is null || shelf.Deleted)
                return RedirectToAction("List", "Shelf", new { warehouseId = warehouseId });

            if (ModelState.IsValid)
            {

                //any change to the activation status of the stand
                if ((shelf.Active && !model.Active) || (!shelf.Active && model.Active))
                {
                    var updatableShelf = await _shelfService.GetShelfByIdAsync(shelf.Id);
                    updatableShelf.Active = model.Active;
                    updatableShelf.UpdatedBy = currentUser.Id;
                    updatableShelf.UpdatedOnUtc = DateTime.UtcNow;
                    await _shelfService.UpdateShelfAsync(updatableShelf);
                }
                
                _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Warehouses.Shelf.Updated"));
                return RedirectToAction("List", "Shelf", new { warehouseId = warehouseId });
            }

            //prepare model
            model = await _shelfModelFactory.PrepareShelfModelAsync(model, shelf);

            //if we got this far, something failed, redisplay form
            return View(model);
        }
    }
}
