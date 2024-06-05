
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
    public class StockHistoryController : BaseAdminController
    {
        #region Fields

        private readonly ILocalizationService _localizationService;
        private readonly IPermissionService _permissionService;
        private readonly IWorkContext _workContext;
        private readonly IStockHistoryModelFactory _stockHistoryModelFactory;

        #endregion

        #region Ctor

        public StockHistoryController(ILocalizationService localizationService,
            IPermissionService permissionService,
            IWorkContext workContext,
            IStockHistoryModelFactory stockHistoryModelFactory)
        {
            _localizationService = localizationService;
            _permissionService = permissionService;
            _workContext = workContext;
            _stockHistoryModelFactory = stockHistoryModelFactory;
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

            var searchModel = new StockHistorySearchModel() { WarehouseId = warehouseId };
            //prepare model
            var model = _stockHistoryModelFactory.PrepareStockHistorySearchModelAsync(searchModel);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> List(StockHistorySearchModel searchModel, int warehouseId)
        {
            if (warehouseId <= 0)
                return AccessDeniedView();

            //prepare saerch model values
            IEnumerable<int> vendorIds = null; 

           

            //TODO: ADD LOGIC TO VALIDATE IF THE USER IS ALLOWED TO ENTER THIS SPECIFIC WAREHOUSE
            //var currentUser = await _workContext.GetCurrentCustomerAsync();
            //if (!IsUserAllowedToAccessWarehouse(warehouseId, currentUser.Id))
            //    return AccessDeniedView();

            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
                return await AccessDeniedDataTablesJson();

            //prepare model
            var model = await _stockHistoryModelFactory.PrepareStockHistoryListModelAsync(searchModel);

            return Json(model);
        }

        #endregion

    }

}
