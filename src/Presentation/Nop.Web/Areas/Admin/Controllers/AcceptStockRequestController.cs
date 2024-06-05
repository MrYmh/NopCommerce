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
    public class AcceptStockRequestController : BaseAdminController
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
        private readonly IAcceptStockRequestModelFactory _acceptStockRequestModelFactory;
        private readonly IAcceptStockRequestService _acceptStockRequestService;

        #endregion

        #region Ctor

        public AcceptStockRequestController(ICustomerActivityService customerActivityService,
            IExportManager exportManager,
            IImportManager importManager,
            ILocalizationService localizationService,
            INotificationService notificationService,
            IPermissionService permissionService,
            IStaticCacheManager staticCacheManager,
            IWorkContext workContext,
            IAcceptStockRequestModelFactory acceptStockRequestModelFactory,
            IAcceptStockRequestService acceptStockRequestService)
        {
            _customerActivityService = customerActivityService;
            _exportManager = exportManager;
            _importManager = importManager;
            _localizationService = localizationService;
            _notificationService = notificationService;
            _permissionService = permissionService;
            _staticCacheManager = staticCacheManager;
            _workContext = workContext;
            _acceptStockRequestModelFactory = acceptStockRequestModelFactory;
            _acceptStockRequestService = acceptStockRequestService;
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
            //TODO: ADD LOGIC TO VALIDATE IF THE USER IS ALLOWED TO ENTER THIS SPECIFIC WAREHOUSE
            //var currentUser = await _workContext.GetCurrentCustomerAsync();
            //if (!IsUserAllowedToAccessWarehouse(warehouseId, currentUser.Id))
            //    return AccessDeniedView();

            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
                return AccessDeniedView();
            var searchModel = new AcceptStockRequestSearchModel() { WarehouseId = warehouseId };

            //prepare model
            var model = _acceptStockRequestModelFactory.PrepareAcceptStockRequestSearchModelAsync(searchModel);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> List(AcceptStockRequestSearchModel searchModel, int warehouseId)
        {
            //TODO: ADD LOGIC TO VALIDATE IF THE USER IS ALLOWED TO ENTER THIS SPECIFIC WAREHOUSE
            //var currentUser = await _workContext.GetCurrentCustomerAsync();
            //if (!IsUserAllowedToAccessWarehouse(warehouseId, currentUser.Id))
            //    return AccessDeniedView();

            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
                return await AccessDeniedDataTablesJson();

            //prepare model
            var model = await _acceptStockRequestModelFactory.PrepareAcceptStockRequestListModelAsync(searchModel);

            return Json(model);
        }

        #endregion

        #region Create / Edit / Delete

        public async Task<IActionResult> Create(int warehouseId, int stockRequestId)
        {
            //TODO: ADD LOGIC TO VALIDATE IF THE USER IS ALLOWED TO ENTER THIS SPECIFIC WAREHOUSE
            //var currentUser = await _workContext.GetCurrentCustomerAsync();
            //if (!IsUserAllowedToAccessWarehouse(warehouseId, currentUser.Id))
            //    return AccessDeniedView();

            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
                return AccessDeniedView();
            var preparedModel = new AcceptStockRequestModel() { WarehouseId = warehouseId, StockRequestId = stockRequestId };
            //prepare model
            var model = await _acceptStockRequestModelFactory.PrepareAcceptStockRequestModelAsync(preparedModel, null);

            return View(model);
        }

        

        //public async Task<IActionResult> Edit(int id)
        //{
        //    if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
        //        return AccessDeniedView();

        //    //try to get a accept stock request with the specified id
        //    var acceptStockRequest = await _acceptStockRequestService.GetAcceptStockRequestByIdAsync(id);
        //    if (acceptStockRequest is null || acceptStockRequest.Deleted)
        //        return RedirectToAction("List");

        //    //prepare model
        //    var model = await _acceptStockRequestModelFactory.PrepareAcceptStockRequestModelAsync(null, acceptStockRequest);

        //    return View(model);
        //}

        //[HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        //public async Task<IActionResult> Edit(AcceptStockRequestModel model)
        //{
        //    if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
        //        return AccessDeniedView();

        //    //try to get a accept stock request with the specified id
        //    var acceptStockRequest = await _acceptStockRequestService.GetAcceptStockRequestByIdAsync(model.Id);
        //    if (acceptStockRequest is null || acceptStockRequest.Deleted)
        //        return RedirectToAction("List");

        //    if (ModelState.IsValid)
        //    {
        //        acceptStockRequest = model.ToEntity(acceptStockRequest);
        //        acceptStockRequest.UpdatedOnUtc = DateTime.UtcNow;
        //        var currentUser = await _workContext.GetCurrentCustomerAsync();
        //        acceptStockRequest.UpdatedBy = currentUser.Id;

        //        await _acceptStockRequestService.UpdateAcceptStockRequestAsync(acceptStockRequest);

        //        //activity log
        //        await _customerActivityService.InsertActivityAsync("EditAcceptStockRequest",
        //            string.Format(await _localizationService.GetResourceAsync("ActivityLog.EditAcceptStockRequest"), acceptStockRequest.Id), acceptStockRequest);

        //        _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Warehouses.AcceptStockRequest.Updated"));

        //        return RedirectToAction("List");
        //    }

        //    //prepare model
        //    model = await _acceptStockRequestModelFactory.PrepareAcceptStockRequestModelAsync(model, acceptStockRequest);

        //    //if we got this far, something failed, redisplay form
        //    return View(model);
        //}

        //[HttpPost]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
        //        return AccessDeniedView();

        //    //try to get a accept stock request with the specified id
        //    var acceptStockRequest = await _acceptStockRequestService.GetAcceptStockRequestByIdAsync(id);

        //    if (acceptStockRequest is null)
        //        return RedirectToAction("List");

        //    await _acceptStockRequestService.DeleteAcceptStockRequestAsync(acceptStockRequest);

        //    var currentUser = await _workContext.GetCurrentCustomerAsync();

        //    //activity log
        //    await _customerActivityService.InsertActivityAsync("DeleteAcceptStockRequest",
        //        string.Format(await _localizationService.GetResourceAsync("ActivityLog.DeleteAcceptStockRequest"), acceptStockRequest.Id), acceptStockRequest);

        //    _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Warehouses.AcceptStockRequest.Deleted"));

        //    return RedirectToAction("List");
        //}

        //[HttpPost]
        //public async Task<IActionResult> DeleteSelected(ICollection<int> selectedIds)
        //{
        //    if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
        //        return AccessDeniedView();

        //    if (selectedIds is null || selectedIds.Count == 0)
        //        return NoContent();

        //    await _acceptStockRequestService.DeleteAcceptStockRequestAsync(await _acceptStockRequestService.GetAcceptStockRequestByIdsAsync(selectedIds.ToArray()));

        //    return Json(new { Result = true });
        //}

        #endregion

    }

}
