
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
    public class StockRequestController : BaseAdminController
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
        private readonly IStockRequestModelFactory _stockRequestModelFactory;
        private readonly IStockRequestService _stockRequestService;

        #endregion

        #region Ctor

        public StockRequestController(ICustomerActivityService customerActivityService,
            IExportManager exportManager,
            IImportManager importManager,
            ILocalizationService localizationService,
            INotificationService notificationService,
            IPermissionService permissionService,
            IStaticCacheManager staticCacheManager,
            IWorkContext workContext,
            IStockRequestModelFactory stockRequestModelFactory,
            IStockRequestService stockRequestService)
        {
            _customerActivityService = customerActivityService;
            _exportManager = exportManager;
            _importManager = importManager;
            _localizationService = localizationService;
            _notificationService = notificationService;
            _permissionService = permissionService;
            _staticCacheManager = staticCacheManager;
            _workContext = workContext;
            _stockRequestModelFactory = stockRequestModelFactory;
            _stockRequestService = stockRequestService;
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
            var searchModel = new StockRequestSearchModel() { WarehouseId = warehouseId };

            //prepare model
            var model = _stockRequestModelFactory.PrepareStockRequestSearchModelAsync(searchModel);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> List(StockRequestSearchModel searchModel, int warehouseId)
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
            var model = await _stockRequestModelFactory.PrepareStockRequestListModelAsync(searchModel);

            return Json(model);
        }

        #endregion

        #region Delete

        

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
                return AccessDeniedView();

            //try to get a stock request with the specified id
            var stockRequest = await _stockRequestService.GetStockRequestByIdAsync(id);

            if (stockRequest is null)
                return RedirectToAction("List");

            await _stockRequestService.DeleteStockRequestAsync(stockRequest);

            var currentUser = await _workContext.GetCurrentCustomerAsync();

            //activity log
            await _customerActivityService.InsertActivityAsync("DeleteStockRequest",
                string.Format(await _localizationService.GetResourceAsync("ActivityLog.DeleteStockRequest"), stockRequest.Id), stockRequest);

            _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Warehouses.StockRequest.Deleted"));

            return RedirectToAction("List");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteSelected(ICollection<int> selectedIds)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
                return AccessDeniedView();

            if (selectedIds is null || selectedIds.Count == 0)
                return NoContent();

            await _stockRequestService.DeleteStockRequestAsync(await _stockRequestService.GetStockRequestByIdsAsync(selectedIds.ToArray()));

            return Json(new { Result = true });
        }

        #endregion
        
    }

}
