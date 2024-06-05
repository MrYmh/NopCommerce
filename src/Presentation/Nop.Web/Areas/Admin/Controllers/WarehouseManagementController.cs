
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
    public class WarehouseManagmentController : BaseAdminController
    {
        #region Fields

        //private readonly ICustomerActivityService _customerActivityService;
        //private readonly IExportManager _exportManager;
        //private readonly IImportManager _importManager;
        //private readonly ILocalizationService _localizationService;
        //private readonly INotificationService _notificationService;
        //private readonly IPermissionService _permissionService;
        //private readonly IStaticCacheManager _staticCacheManager;
        //private readonly IWorkContext _workContext;
        //private readonly IWarehouseProductCombinationModelFactory _warehouseProductCombinationModelFactory;
        //private readonly IWarehouseProductCombinationService _warehouseProductCombinationService;

        #endregion

        #region Ctor

        public WarehouseManagmentController(
            //ICustomerActivityService customerActivityService,
            //IExportManager exportManager,
            //IImportManager importManager,
            //ILocalizationService localizationService,
            //INotificationService notificationService,
            //IPermissionService permissionService,
            //IStaticCacheManager staticCacheManager,
            //IWorkContext workContext,
            //IWarehouseProductCombinationModelFactory warehouseProductCombinationModelFactory,
            //IWarehouseProductCombinationService warehouseProductCombinationService
            )
        {
            //_customerActivityService = customerActivityService;
            //_exportManager = exportManager;
            //_importManager = importManager;
            //_localizationService = localizationService;
            //_notificationService = notificationService;
            //_permissionService = permissionService;
            //_staticCacheManager = staticCacheManager;
            //_workContext = workContext;
            //_warehouseProductCombinationModelFactory = warehouseProductCombinationModelFactory;
            //_warehouseProductCombinationService = warehouseProductCombinationService;
        }

        #endregion

        #region Utilities

        #endregion

        #region List

        public IActionResult Index()
        {
            return RedirectToAction("List");
        }

        [HttpGet("Warehouse/{id}")]
        public async Task<IActionResult> List(int id)
        {
            //if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
            //    return AccessDeniedView();
            var x = id;
            //prepare model
            //var model = _warehouseProductCombinationModelFactory.PrepareWarehouseProductCombinationSearchModelAsync(new WarehouseProductCombinationSearchModel());

            return View(x);
        }

        [HttpGet]
        public async Task<IActionResult> WarehouseSetup(int warehouseId)
        {
            //if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
            //    return AccessDeniedView();
            var id = warehouseId;
            //prepare model
            //var model = _warehouseProductCombinationModelFactory.PrepareWarehouseProductCombinationSearchModelAsync(new WarehouseProductCombinationSearchModel());

            return View(id);
        }

        [HttpGet]
        public async Task<IActionResult> StockOperations(int warehouseId)
        {
            //if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
            //    return AccessDeniedView();
            var id = warehouseId;
            //prepare model
            //var model = _warehouseProductCombinationModelFactory.PrepareWarehouseProductCombinationSearchModelAsync(new WarehouseProductCombinationSearchModel());

            return View(id);
        }


        #endregion







    }

}
