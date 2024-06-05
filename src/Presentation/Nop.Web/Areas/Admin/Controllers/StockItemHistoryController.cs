
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
    public class StockItemHistoryController : BaseAdminController
    {
        #region Fields

        private readonly ILocalizationService _localizationService;
        private readonly IPermissionService _permissionService;
        private readonly IWorkContext _workContext;
        private readonly IStockItemHistoryModelFactory _stockItemHistoryModelFactory;

        #endregion

        #region Ctor

        public StockItemHistoryController(ILocalizationService localizationService,
            IPermissionService permissionService,
            IWorkContext workContext,
            IStockItemHistoryModelFactory stockItemHistoryModelFactory,
            IStockItemHistoryService stockItemHistoryService)
        {
            _localizationService = localizationService;
            _permissionService = permissionService;
            _workContext = workContext;
            _stockItemHistoryModelFactory = stockItemHistoryModelFactory;
        }

        #endregion

        #region Utilities

        #endregion

        #region List

        public IActionResult Index()
        {
            return RedirectToAction("List");
        }

        public async Task<IActionResult> List(int warehouseId, int stockHistoryId)
        {
            if (warehouseId <= 0)
                return AccessDeniedView();

            //TODO: ADD LOGIC TO VALIDATE IF THE USER IS ALLOWED TO ENTER THIS SPECIFIC WAREHOUSE
            //var currentUser = await _workContext.GetCurrentCustomerAsync();
            //if (!IsUserAllowedToAccessWarehouse(warehouseId, currentUser.Id))
            //    return AccessDeniedView();

            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
                return AccessDeniedView();

            var searchModel = new StockItemHistorySearchModel() { StockHistoryId = stockHistoryId };

            //prepare model
            var model = _stockItemHistoryModelFactory.PrepareStockItemHistorySearchModelAsync(searchModel);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> List(StockItemHistorySearchModel searchModel, int warehouseId)
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
            var model = await _stockItemHistoryModelFactory.PrepareStockItemHistoryListModelAsync(searchModel);

            return Json(model);
        }

        #endregion

    }

}
