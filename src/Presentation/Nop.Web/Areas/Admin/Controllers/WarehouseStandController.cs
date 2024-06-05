
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
    public class WarehouseStandController : BaseAdminController
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
        private readonly IWarehouseStandModelFactory _warehouseStandModelFactory;
        private readonly IWarehouseStandService _warehouseStandService;
        private readonly IShelfService _shelfService;

        #endregion

        #region Ctor

        public WarehouseStandController(ICustomerActivityService customerActivityService,
            IExportManager exportManager,
            IImportManager importManager,
            ILocalizationService localizationService,
            INotificationService notificationService,
            IPermissionService permissionService,
            IStaticCacheManager staticCacheManager,
            IWorkContext workContext,
            IWarehouseStandModelFactory warehouseStandModelFactory,
            IWarehouseStandService warehouseStandService,
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
            _warehouseStandModelFactory = warehouseStandModelFactory;
            _warehouseStandService = warehouseStandService;
            _shelfService = shelfService;
        }

        #endregion

        #region Utilities

        private async Task InsertShelves(WarehouseStand entity, WarehouseStandModel model, int noOfShelves)
        {
            var currentUser = await _workContext.GetCurrentCustomerAsync();
            var shelves = Enumerable.Range(0, noOfShelves).Select(_ => new Shelf
            {
                StandId = entity.Id,
                Active = model.Active,
                WarehouseId = entity.WarehouseId,
                CreatedOnUtc = DateTime.UtcNow,
                CreatedBy = currentUser.Id
            }).ToList();
            await _shelfService.InsertShelfAsync(shelves);

            foreach (var shelf in shelves)
            {
                shelf.Barcode = $"{entity.WarehouseId}-SH{shelf.Id}-S{entity.Id}";
                shelf.UpdatedOnUtc = DateTime.UtcNow;
                shelf.UpdatedBy = currentUser.Id;
            }
            await _shelfService.UpdateShelfAsync(shelves);

            foreach (var shelf in shelves)
            {
                //activity log
                await _customerActivityService.InsertActivityAsync("AddNewShelf",
                    string.Format(await _localizationService.GetResourceAsync("ActivityLog.AddNewShelf"), shelf.Id), shelf);
            }
        }

        #endregion

        #region List

        public IActionResult Index()
        {
            return RedirectToAction("List");
        }

        public async Task<IActionResult> List(int warehouseId)
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

            //prepare search model
            var searchModel = new WarehouseStandSearchModel() { WarehouseId = warehouseId };

            //prepare model
            var model = _warehouseStandModelFactory.PrepareWarehouseStandSearchModelAsync(searchModel);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> List(WarehouseStandSearchModel searchModel, int warehouseId)
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
                return await AccessDeniedDataTablesJson();

            //prepare model
            var model = await _warehouseStandModelFactory.PrepareWarehouseStandListModelAsync(searchModel);

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

            var model = new WarehouseStandModel() { WarehouseId = warehouseId };

            //prepare model
            var preparedModel = _warehouseStandModelFactory.PrepareWarehouseStandModelAsync(model, null);
            preparedModel.Active = true;

            return View(preparedModel);
        }

        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        public async Task<IActionResult> Create(WarehouseStandModel model, int warehouseId)
        {
            if (warehouseId <= 0)
            {
                return AccessDeniedView();
            }
            var currentUser = await _workContext.GetCurrentCustomerAsync();
            //TODO: ADD LOGIC TO VALIDATE IF THE USER IS ALLOWED TO ENTER THIS SPECIFIC WAREHOUSE
            //var currentUser = await _workContext.GetCurrentCustomerAsync();
            //if (!IsUserAllowedToAccessWarehouse(warehouseId, currentUser.Id))
            //    return AccessDeniedView();

            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
                return AccessDeniedView();

            if (ModelState.IsValid)
            {
                var warehouseStands = Enumerable.Range(0, model.NoOfStands).Select(_ => new WarehouseStand
                {
                    WarehouseId = model.WarehouseId,
                    MaterialType = model.MaterialType,
                    Description = model.Description,
                    NoOfShelves = model.NoOfShelves,
                    Active = model.Active,
                    CreatedOnUtc = DateTime.UtcNow,
                    CreatedBy = currentUser.Id
                }).ToList();

                await _warehouseStandService.InsertWarehouseStandAsync(warehouseStands);
                foreach (var warehouseStand in warehouseStands)
                {
                    //activity log
                    await _customerActivityService.InsertActivityAsync("AddNewWarehouseStand",
                        string.Format(await _localizationService.GetResourceAsync("ActivityLog.AddNewWarehouseStand"), warehouseStand.Id), warehouseStand);
                }

                foreach (var warehouseStand in warehouseStands)
                {
                    await InsertShelves(warehouseStand, model, model.NoOfShelves);
                }
                
                _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Warehouses.WarehouseStand.Added"));

                return RedirectToAction("List" , "WarehouseStand", new { warehouseId = model.WarehouseId });
            }

            //prepare model
            model = _warehouseStandModelFactory.PrepareWarehouseStandModelAsync(model, null);

            //if we got this far, something failed, redisplay form
            return View(model);
        }

        public async Task<IActionResult> Edit(int id, int warehouseId)
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

            //try to get a warehouse stand with the specified id
            var warehouseStand = await _warehouseStandService.GetWarehouseStandByIdAsync(id);
            if (warehouseStand is null || warehouseStand.Deleted)
                return RedirectToAction("List", "WarehouseStand", new { warehouseId = warehouseId });

            //prepare model
            var model = _warehouseStandModelFactory.PrepareWarehouseStandModelAsync(null, warehouseStand);
            model.IsEditMode = true;

            return View(model);
        }

        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        public async Task<IActionResult> Edit(WarehouseStandModel model, int warehouseId)
        {
            if (warehouseId <= 0)
            {
                return AccessDeniedView();
            }
            var currentUser = await _workContext.GetCurrentCustomerAsync();
            //TODO: ADD LOGIC TO VALIDATE IF THE USER IS ALLOWED TO ENTER THIS SPECIFIC WAREHOUSE
            //var currentUser = await _workContext.GetCurrentCustomerAsync();
            //if (!IsUserAllowedToAccessWarehouse(warehouseId, currentUser.Id))
            //    return AccessDeniedView();

            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
                return AccessDeniedView();

            //try to get a warehouse stand with the specified id
            var warehouseStand = await _warehouseStandService.GetWarehouseStandByIdAsync(model.Id);
            if (warehouseStand is null || warehouseStand.Deleted)
                return RedirectToAction("List", "WarehouseStand", new { warehouseId = warehouseId });

            if (ModelState.IsValid)
            {
                #region Updating shelves

                //any change to the number of shelves
                //the incoming model has low number of shelves, delete the excess
                if (model.NoOfShelves <= warehouseStand.NoOfShelves)
                {
                    var noOfRetrievedShelves = warehouseStand.NoOfShelves - model.NoOfShelves;
                    var shelves = await _shelfService.GetShelvesSubsetForStandAsync(warehouseStand.Id, noOfRetrievedShelves);
                    await _shelfService.DeleteShelfAsync(shelves);
                }
                //the incoming model has more shelves, add the difference
                else if (model.NoOfShelves >= warehouseStand.NoOfShelves)
                {
                    var noOfAddedShelves = model.NoOfShelves - warehouseStand.NoOfShelves;
                    var shelf = await _shelfService.GetShelvesSubsetForStandAsync(warehouseStand.Id, 1);
                    await InsertShelves(warehouseStand, model, noOfAddedShelves);
                }

                //any change to the activation status of the stand
                if ((warehouseStand.Active && !model.Active) || (!warehouseStand.Active && model.Active))
                {
                    var shelves = await _shelfService.GetStandShelvesAsync(warehouseStand.Id);
                    foreach (var shelf in shelves)
                    {
                        shelf.Active = model.Active;
                    }
                    await _shelfService.UpdateShelfAsync(shelves);
                }

                #endregion

                #region Updating Stand
                model.CreatedBy = warehouseStand.CreatedBy;
                warehouseStand = model.ToEntity(warehouseStand);
                warehouseStand.UpdatedOnUtc = DateTime.UtcNow;
                warehouseStand.UpdatedBy = currentUser.Id;
                await _warehouseStandService.UpdateWarehouseStandAsync(warehouseStand);

                //activity log
                await _customerActivityService.InsertActivityAsync("EditWarehouseStand",
                    string.Format(await _localizationService.GetResourceAsync("ActivityLog.EditWarehouseStand"), warehouseStand.Id), warehouseStand);

                _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Warehouses.WarehouseStand.Updated"));

                #endregion

                return RedirectToAction("List", "WarehouseStand", new { warehouseId = warehouseId });
            }

            //prepare model
            model = _warehouseStandModelFactory.PrepareWarehouseStandModelAsync(model, warehouseStand);

            //if we got this far, something failed, redisplay form
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, int warehouseId)
        {
            if (warehouseId <= 0)
            {
                return AccessDeniedView();
            }
            var currentUser = await _workContext.GetCurrentCustomerAsync();
            //TODO: ADD LOGIC TO VALIDATE IF THE USER IS ALLOWED TO ENTER THIS SPECIFIC WAREHOUSE
            //var currentUser = await _workContext.GetCurrentCustomerAsync();
            //if (!IsUserAllowedToAccessWarehouse(warehouseId, currentUser.Id))
            //    return AccessDeniedView();

            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
                return AccessDeniedView();

            //try to get a warehouse stand with the specified id
            var warehouseStand = await _warehouseStandService.GetWarehouseStandByIdAsync(id);

            if (warehouseStand is null)
                return RedirectToAction("List", "WarehouseStand", new { warehouseId = warehouseId });

            await _warehouseStandService.DeleteWarehouseStandAsync(warehouseStand);

            var shelves = await _shelfService.GetStandShelvesAsync(warehouseStand.Id);
            await _shelfService.DeleteShelfAsync(shelves);


            //activity log
            await _customerActivityService.InsertActivityAsync("DeleteWarehouseStand",
                string.Format(await _localizationService.GetResourceAsync("ActivityLog.DeleteWarehouseStand"), warehouseStand.Id), warehouseStand);

            _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Warehouses.WarehouseStand.Deleted"));

            return RedirectToAction("List", "WarehouseStand", new { warehouseId = warehouseId });
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

            var stands = await _warehouseStandService.GetWarehouseStandByIdsAsync(selectedIds.ToArray());
            var shelvesForDeletion = await _shelfService.GetShelvesByStandsIdsAsync(selectedIds.ToArray());
            
            await _shelfService.DeleteShelfAsync(shelvesForDeletion);
            await _warehouseStandService.DeleteWarehouseStandAsync(stands);
            foreach (var stand in stands)
            {
                //activity log
                await _customerActivityService.InsertActivityAsync("DeleteWarehouseStand",
                    string.Format(await _localizationService.GetResourceAsync("ActivityLog.DeleteWarehouseStand"), stand.Id), stand);
            }

            return Json(new { Result = true });
        }

        #endregion

    }

}
