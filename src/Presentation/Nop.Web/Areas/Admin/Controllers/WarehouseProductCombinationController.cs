
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Core.Caching;
using Nop.Core.Domain.Catalog;
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
using Nop.Web.Areas.Admin.Models.Catalog;
using Nop.Web.Areas.Admin.Models.Warehouses;
using Nop.Web.Framework.Mvc.Filters;

namespace Nop.Web.Areas.Admin.Controllers
{
    public class WarehouseProductCombinationController : BaseAdminController
    {
        #region Fields

        private readonly ICustomerActivityService _customerActivityService;
        private readonly IExportManager _exportManager;
        private readonly IImportManager _importManager;
        private readonly ILocalizationService _localizationService;
        private readonly INotificationService _notificationService;
        private readonly IWarehouseProductCombinationService _warehouseProductCombinationService;
        private readonly IPermissionService _permissionService;
        private readonly IStaticCacheManager _staticCacheManager;
        private readonly IWorkContext _workContext;
        private readonly IWarehouseProductCombinationModelFactory _warehouseProductCombinationModelFactory;
        private readonly IWarehouseStandModelFactory _warehouseStandModelFactory;

        #endregion

        #region Ctor

        public WarehouseProductCombinationController(ICustomerActivityService customerActivityService,
            IExportManager exportManager,
            IImportManager importManager,
            ILocalizationService localizationService,
            INotificationService notificationService,
            IPermissionService permissionService,
            IStaticCacheManager staticCacheManager,
            IWarehouseStandModelFactory warehouseStandModelFactory,
            IWorkContext workContext,
            IWarehouseProductCombinationModelFactory warehouseProductCombinationModelFactory,
            IWarehouseProductCombinationService warehouseProductCombinationService)
        {
            _customerActivityService = customerActivityService;
            _exportManager = exportManager;
            _importManager = importManager;
            _localizationService = localizationService;
            _notificationService = notificationService;
            _permissionService = permissionService;
            _staticCacheManager = staticCacheManager;
            _warehouseStandModelFactory = warehouseStandModelFactory;
            _workContext = workContext;
            _warehouseProductCombinationModelFactory = warehouseProductCombinationModelFactory;
            _warehouseProductCombinationService = warehouseProductCombinationService;
        }

        #endregion

        #region Utilities

        #endregion

        #region List

        public IActionResult Index()
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

            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
                return AccessDeniedView();

            //prepare search model
            var searchModel = new WarehouseProductCombinationSearchModel() { WarehouseId = warehouseId };

            //prepare model
            var model = _warehouseProductCombinationModelFactory.PrepareWarehouseProductCombinationSearchModelAsync(searchModel);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> List(WarehouseProductCombinationSearchModel searchModel, int warehouseId)
        {
            if (warehouseId <= 0)
                return AccessDeniedView();

            //TODO: ADD LOGIC TO VALIDATE IF THE USER IS ALLOWED TO ENTER THIS SPECIFIC WAREHOUSE
            //var currentUser = await _workContext.GetCurrentCustomerAsync();
            //if (!IsUserAllowedToAccessWarehouse(warehouseId, currentUser.Id))
            //    return AccessDeniedView();

            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
                return await AccessDeniedDataTablesJson();

            //prepare model
            var model = await _warehouseProductCombinationModelFactory.PrepareWarehouseProductCombinationListModelAsync(searchModel);

            return Json(model);
        }

        #endregion

        #region UnPrinted Serials

        public async Task<IActionResult> UnPrintedSerials(int warehouseId)
        {
            if (warehouseId <= 0)
                return AccessDeniedView();

            //TODO: ADD LOGIC TO VALIDATE IF THE USER IS ALLOWED TO ENTER THIS SPECIFIC WAREHOUSE
            //var currentUser = await _workContext.GetCurrentCustomerAsync();
            //if (!IsUserAllowedToAccessWarehouse(warehouseId, currentUser.Id))
            //    return AccessDeniedView();

            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
                return AccessDeniedView();
            var searchModel = new WarehouseStandSearchModel() { WarehouseId = warehouseId };

            //prepare model
            var model = _warehouseStandModelFactory.PrepareWarehouseStandSearchModelAsync(searchModel);

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> UnPrintedSerialsGroup(int warehouseId)
        {
            if (warehouseId <= 0)
                return AccessDeniedView();

            //TODO: ADD LOGIC TO VALIDATE IF THE USER IS ALLOWED TO ENTER THIS SPECIFIC WAREHOUSE
            //var currentUser = await _workContext.GetCurrentCustomerAsync();
            //if (!IsUserAllowedToAccessWarehouse(warehouseId, currentUser.Id))
            //    return AccessDeniedView();

            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
                return AccessDeniedView();
            var groupedItems = await _warehouseProductCombinationService.GetAllUnPrintedSerialsAsync(warehouseId);
            var viewModel = new WarehouseItemViewModel
            {
                WarehouseId = warehouseId,
                Groups = groupedItems,
                SelectedItems = new List<WarehouseItem>()
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UnPrintedSerialsItems(int warehouseId, string selectedSku)
        {
            if (warehouseId <= 0)
                return AccessDeniedView();

            //TODO: ADD LOGIC TO VALIDATE IF THE USER IS ALLOWED TO ENTER THIS SPECIFIC WAREHOUSE
            //var currentUser = await _workContext.GetCurrentCustomerAsync();
            //if (!IsUserAllowedToAccessWarehouse(warehouseId, currentUser.Id))
            //    return AccessDeniedView();

            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
                return AccessDeniedView();
            var groupedItems = await _warehouseProductCombinationService.GetAllUnPrintedSerialsAsync(warehouseId);
            var selectedItems = groupedItems.FirstOrDefault(g => g.Sku == selectedSku)?.Items ?? new List<WarehouseItem>();
            var viewModel = new WarehouseItemViewModel
            {
                WarehouseId = warehouseId,
                Groups = groupedItems,
                SelectedItems = selectedItems
            };

            return View(viewModel);
        }




       
        #endregion

        #region Create / Edit / Delete

        public async Task<IActionResult> Edit(int id, int warehouseId)
        {
            return AccessDeniedView();
            if (warehouseId <= 0)
                return AccessDeniedView();

            //TODO: ADD LOGIC TO VALIDATE IF THE USER IS ALLOWED TO ENTER THIS SPECIFIC WAREHOUSE
            //var currentUser = await _workContext.GetCurrentCustomerAsync();
            //if (!IsUserAllowedToAccessWarehouse(warehouseId, currentUser.Id))
            //    return AccessDeniedView();

            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
                return AccessDeniedView();

            //try to get a warehouse product combination with the specified id
            var warehouseProductCombination = await _warehouseProductCombinationService.GetWarehouseProductCombinationByIdAsync(id);
            if (warehouseProductCombination is null || warehouseProductCombination.Deleted)
                return RedirectToAction("List", "WarehouseProductCombination", new { warehouseId = warehouseId });

            //prepare model
            var model = await _warehouseProductCombinationModelFactory.PrepareWarehouseProductCombinationModelAsync(null, warehouseProductCombination);

            return View(model);
        }

        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        public async Task<IActionResult> Edit(WarehouseProductCombinationModel model, int warehouseId)
        {
            return AccessDeniedView();
            if (warehouseId <= 0)
                return AccessDeniedView();

            //TODO: ADD LOGIC TO VALIDATE IF THE USER IS ALLOWED TO ENTER THIS SPECIFIC WAREHOUSE
            var currentUser = await _workContext.GetCurrentCustomerAsync();
            //if (!IsUserAllowedToAccessWarehouse(warehouseId, currentUser.Id))
            //    return AccessDeniedView();

            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
                return AccessDeniedView();

            //try to get a warehouse product combination with the specified id
            var warehouseProductCombination = await _warehouseProductCombinationService.GetWarehouseProductCombinationByIdAsync(model.Id);
            if (warehouseProductCombination is null || warehouseProductCombination.Deleted)
                return RedirectToAction("List", "WarehouseProductCombination", new { warehouseId = model.WarehouseId });

            if (ModelState.IsValid)
            {
                warehouseProductCombination = model.ToEntity(warehouseProductCombination);
                warehouseProductCombination.UpdatedOnUtc = DateTime.UtcNow;
                warehouseProductCombination.UpdatedBy = currentUser.Id;

                await _warehouseProductCombinationService.UpdateWarehouseProductCombinationAsync(warehouseProductCombination);

                //activity log
                await _customerActivityService.InsertActivityAsync("EditWarehouseProductCombination",
                    string.Format(await _localizationService.GetResourceAsync("ActivityLog.EditWarehouseProductCombination"), warehouseProductCombination.Id), warehouseProductCombination);

                _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Warehouses.WarehouseProductCombination.Updated"));

                return RedirectToAction("List" , "WarehouseProductCombination", new { warehouseId = model.WarehouseId });
            }

            //prepare model
            model = await _warehouseProductCombinationModelFactory.PrepareWarehouseProductCombinationModelAsync(model, warehouseProductCombination);

            //if we got this far, something failed, redisplay form
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, int warehouseId)
        {
            return AccessDeniedView();
            //TODO: ADD LOGIC TO VALIDATE IF THE USER IS ALLOWED TO ENTER THIS SPECIFIC WAREHOUSE
            //var currentUser = await _workContext.GetCurrentCustomerAsync();
            //if (!IsUserAllowedToAccessWarehouse(warehouseId, currentUser.Id))
            //    return AccessDeniedView();

            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
                return AccessDeniedView();

            //try to get a warehouse product combination with the specified id
            var warehouseProductCombination = await _warehouseProductCombinationService.GetWarehouseProductCombinationByIdAsync(id);

            if (warehouseProductCombination is null)
                return RedirectToAction("List");

            await _warehouseProductCombinationService.DeleteWarehouseProductCombinationAsync(warehouseProductCombination);

            //activity log
            await _customerActivityService.InsertActivityAsync("DeleteWarehouseProductCombination",
                string.Format(await _localizationService.GetResourceAsync("ActivityLog.DeleteWarehouseProductCombination"), warehouseProductCombination.Id), warehouseProductCombination);

            _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Warehouses.WarehouseProductCombination.Deleted"));

            return RedirectToAction("List");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteSelected(ICollection<int> selectedIds, int warehouseId)
        {
            return AccessDeniedView();
            //TODO: ADD LOGIC TO VALIDATE IF THE USER IS ALLOWED TO ENTER THIS SPECIFIC WAREHOUSE
            //var currentUser = await _workContext.GetCurrentCustomerAsync();
            //if (!IsUserAllowedToAccessWarehouse(warehouseId, currentUser.Id))
            //    return AccessDeniedView();

            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
                return AccessDeniedView();

            if (selectedIds is null || selectedIds.Count == 0)
                return NoContent();

            var warehouseProductCombinationsForDeletion = await _warehouseProductCombinationService.GetWarehouseProductCombinationByIdsAsync(selectedIds.ToArray());
            await _warehouseProductCombinationService.DeleteWarehouseProductCombinationAsync(warehouseProductCombinationsForDeletion);
            
            //activity log
            foreach (var warehouseProductCombination in warehouseProductCombinationsForDeletion)
            {
                await _customerActivityService.InsertActivityAsync("DeleteWarehouseProductCombination",
                    string.Format(await _localizationService.GetResourceAsync("ActivityLog.DeleteWarehouseProductCombination"), warehouseProductCombination.Id), warehouseProductCombination);
            }
            return Json(new { Result = true });
        }

        #endregion

    }

}
