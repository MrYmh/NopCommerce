using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using DocumentFormat.OpenXml.EMMA;
using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Core.Caching;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Warehouses;
using Nop.Services.Catalog;
using Nop.Services.Localization;
using Nop.Services.Logging;
using Nop.Services.Messages;
using Nop.Services.Security;
using Nop.Services.Warehouses.Interface;
using Nop.Web.Areas.Admin.Factories.WarehouseFactories;
using Nop.Web.Areas.Admin.Infrastructure.Mapper.Extensions;
using Nop.Web.Areas.Admin.Models.Warehouses;
using Nop.Web.Framework.Mvc.Filters;
using Org.BouncyCastle.Asn1.Cms;

namespace Nop.Web.Areas.Admin.Controllers
{
    public class WarehouseProductController : BaseAdminController
    {
        #region Fields

        private readonly ICustomerActivityService _customerActivityService;
        private readonly ILocalizationService _localizationService;
        private readonly INotificationService _notificationService;
        private readonly IPermissionService _permissionService;
        private readonly IStaticCacheManager _staticCacheManager;
        private readonly IWorkContext _workContext;
        private readonly IWarehouseProductModelFactory _warehouseProductModelFactory;
        private readonly IWarehouseProductService _warehouseProductService;
        private readonly ICategoryService _categoryService;
        private readonly IWarehouseProductCategoryMappingService _warehouseProductCategoryMappingService;
        private readonly IProductAttributeService _productAttributeService;
        private readonly IWarehouseProductCombinationService _warehouseProductCombinationService;
        private readonly IProductAttributeParser _productAttributeParser;

        #endregion

        #region Ctor

        public WarehouseProductController(ICustomerActivityService customerActivityService,
            ILocalizationService localizationService,
            INotificationService notificationService,
            IPermissionService permissionService,
            IStaticCacheManager staticCacheManager,
            IWorkContext workContext,
            IWarehouseProductModelFactory warehouseProductModelFactory,
            IWarehouseProductService warehouseProductService,
            ICategoryService categoryService,
            IWarehouseProductCategoryMappingService warehouseProductCategoryMappingService,
            IProductAttributeService productAttributeService,
            IWarehouseProductCombinationService warehouseProductCombinationService,
            IProductAttributeParser productAttributeParser)
        {
            _customerActivityService = customerActivityService;
            _localizationService = localizationService;
            _notificationService = notificationService;
            _permissionService = permissionService;
            _staticCacheManager = staticCacheManager;
            _workContext = workContext;
            _warehouseProductModelFactory = warehouseProductModelFactory;
            _warehouseProductService = warehouseProductService;
            _categoryService = categoryService;
            _productAttributeService = productAttributeService;
            _warehouseProductCategoryMappingService = warehouseProductCategoryMappingService;
            _warehouseProductCombinationService = warehouseProductCombinationService;
            _productAttributeParser = productAttributeParser;
        }

        #endregion

        #region Utilities
        private async Task<IList<WarehouseProductCombination>> PrepareWarehouseProductCombinations(IList<ProductAttributeCombination> productAttributeCombinations, WarehouseProduct warehouseProduct, Customer currentUser)
        {
            return await productAttributeCombinations.SelectAwait(async x => new WarehouseProductCombination
            {
                WarehouseId = warehouseProduct.WarehouseId,
                WarehouseProductId = warehouseProduct.Id,
                CombinationId = x.Id,
                AttributesXml = await _productAttributeParser.ConvertAttributesToString(x.AttributesXml),
                TotalQuantity = 0,
                Sku = x.Sku,
                Available = false, //just added to the warehouse system but not available yet.
                CreatedOnUtc = DateTime.UtcNow,
                CreatedBy = currentUser.Id
            }).ToListAsync();
        }
        
        private async Task<bool> IsProductCategoryMappedAsync(WarehouseProductModel model)
        {
            try
            {
                var mappedWarehouseProductCategory = await _warehouseProductCategoryMappingService.GetWarehouseProductCategoryMappingByWarehouseCategoryMappingIdAsync(model.WarehouseCategoryMappingId);
                var productCategories = await _categoryService.GetProductCategoriesByProductIdAsync(model.ProductId, true);
                var productCategoriesIds = productCategories.Select(x => x.CategoryId).ToList();
                //if any of product categories in the system linked to a warehouse category
                if (mappedWarehouseProductCategory.Any(x => productCategoriesIds.Contains(x.ProductCategoryId)))
                    return true;
                    
                return false;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private async Task PrepareWarehouseProductCategoryMappingForProduct(WarehouseProduct warehouseProduct, int warehouseCategoryMapping)
        {
            //get warehouse product category mapping entities related to specific warehouse category
            var mappedWarehouseProductCategories = await _warehouseProductCategoryMappingService.GetWarehouseProductCategoryMappingByWarehouseCategoryMappingIdAsync(warehouseCategoryMapping);
            
            //get categories related to the product in nop system
            var productCategories = await _categoryService.GetProductCategoriesByProductIdAsync(warehouseProduct.ProductId, true);
            var productCategoriesIds = productCategories.Select(x => x.CategoryId);
            //get the warehouse product category mapping linked to nop product category
            var mappedWarehouseProductCategory = mappedWarehouseProductCategories.FirstOrDefault(x => productCategoriesIds.Contains(x.ProductCategoryId));

            warehouseProduct.WarehouseProductCategoryMappingId = mappedWarehouseProductCategory.Id;
        }

        
        #endregion

        #region List

        //public IActionResult Index()
        //{
        //    return RedirectToAction("List");
        //}

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
            var searchModel = new WarehouseProductSearchModel() { WarehouseId = warehouseId };

            //prepare model
            var model = _warehouseProductModelFactory.PrepareWarehouseProductSearchModelAsync(searchModel);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> List(WarehouseProductSearchModel searchModel, int warehouseId)
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
            var model = await _warehouseProductModelFactory.PrepareWarehouseProductListModelAsync(searchModel);

            return Json(model);
        }

        #endregion

        #region Create / Edit / Delete

        public async Task<IActionResult> Create(int warehouseId)
        {
            if (warehouseId <= 0)
                return AccessDeniedView();

            //TODO: ADD LOGIC TO VALIDATE IF THE USER IS ALLOWED TO ENTER THIS SPECIFIC WAREHOUSE
            //var currentUser = await _workContext.GetCurrentCustomerAsync();
            //if (!IsUserAllowedToAccessWarehouse(warehouseId, currentUser.Id))
            //    return AccessDeniedView();

            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
                return AccessDeniedView();

            var model = new WarehouseProductModel() { WarehouseId = warehouseId };

            //prepare model
            var preparedModel = await _warehouseProductModelFactory.PrepareWarehouseProductModelAsync(model, null);

            return View(preparedModel);
        }

        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        public async Task<IActionResult> Create(WarehouseProductModel model, int warehouseId)
        {
            if (warehouseId <= 0)
                return AccessDeniedView();

            //TODO: ADD LOGIC TO VALIDATE IF THE USER IS ALLOWED TO ENTER THIS SPECIFIC WAREHOUSE
            var currentUser = await _workContext.GetCurrentCustomerAsync();
            //if (!IsUserAllowedToAccessWarehouse(warehouseId, currentUser.Id))
            //    return AccessDeniedView();

            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
                return AccessDeniedView();

            //turn it into fluent validation if possible
            //if any of product categories in the system linked to a warehouse category
            if (! await IsProductCategoryMappedAsync(model))
            {
                //prepare model
                model = await _warehouseProductModelFactory.PrepareWarehouseProductModelAsync(model, null);

                _notificationService.ErrorNotification(await _localizationService.GetResourceAsync("Admin.Warehouses.WarehouseProduct.ProductCategoryNotMapped"));
                //if we got this far, something failed, redisplay form
                return View(model);
            }

            if (ModelState.IsValid)
            {
                var warehouseProduct = model.ToEntity<WarehouseProduct>();
                warehouseProduct.CreatedOnUtc = DateTime.UtcNow;
                warehouseProduct.CreatedBy = currentUser.Id;
                await PrepareWarehouseProductCategoryMappingForProduct(warehouseProduct, model.WarehouseCategoryMappingId);
                await _warehouseProductService.InsertWarehouseProductAsync(warehouseProduct);

                //activity log
                await _customerActivityService.InsertActivityAsync("AddNewWarehouseProduct",
                    string.Format(await _localizationService.GetResourceAsync("ActivityLog.AddNewWarehouseProduct"), warehouseProduct.Id), warehouseProduct);

                var productAttributeCombinations = await _productAttributeService.GetAllProductAttributeCombinationsAsync(model.ProductId);
                if (productAttributeCombinations != null && productAttributeCombinations.Any())
                {
                    var warehouseProductCombinations = await PrepareWarehouseProductCombinations(productAttributeCombinations, warehouseProduct, currentUser);
                    await _warehouseProductCombinationService.InsertWarehouseProductCombinationAsync(warehouseProductCombinations);

                    //activity log
                    foreach (var warehouseProductCombination in warehouseProductCombinations)
                    {
                        await _customerActivityService.InsertActivityAsync("AddNewWarehouseProductCombination",
                            string.Format(await _localizationService.GetResourceAsync("ActivityLog.AddNewWarehouseProductCombination"), warehouseProductCombination.Id), warehouseProductCombination);
                    }
                }

                _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Warehouses.WarehouseProduct.Added"));

                return RedirectToAction("List", "WarehouseProduct", new { warehouseId = model.WarehouseId });
            }

            //prepare model
            model = await _warehouseProductModelFactory.PrepareWarehouseProductModelAsync(model, null);

            //if we got this far, something failed, redisplay form
            return View(model);
        }

        

        public async Task<IActionResult> Edit(int id, int warehouseId)
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

            //try to get a warehouse product with the specified id
            var warehouseProduct = await _warehouseProductService.GetWarehouseProductByIdAsync(id);
            if (warehouseProduct is null || warehouseProduct.Deleted)
                return RedirectToAction("List", "WarehouseProduct", new { warehouseId = warehouseId });

            //prepare model
            var model = await _warehouseProductModelFactory.PrepareWarehouseProductModelAsync(null, warehouseProduct);

            return View(model);
        }

        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        public async Task<IActionResult> Edit(WarehouseProductModel model, int warehouseId)
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

            //try to get a warehouse product with the specified id
            var warehouseProduct = await _warehouseProductService.GetWarehouseProductByIdAsync(model.Id);
            if (warehouseProduct is null || warehouseProduct.Deleted)
                return RedirectToAction("List", "WarehouseProduct", new { warehouseId = warehouseId });

            //if any of product categories in the system linked to a warehouse category
            if (!await IsProductCategoryMappedAsync(model))
            {
                //prepare model
                model = await _warehouseProductModelFactory.PrepareWarehouseProductModelAsync(model, warehouseProduct);

                _notificationService.ErrorNotification(await _localizationService.GetResourceAsync("Admin.Warehouses.WarehouseProduct.ProductCategoryNotMapped"));
                //if we got this far, something failed, redisplay form
                return View(model);
            }

            if (ModelState.IsValid)
            {
                warehouseProduct = model.ToEntity(warehouseProduct);
                warehouseProduct.UpdatedOnUtc = DateTime.UtcNow;
                warehouseProduct.UpdatedBy = currentUser.Id;

                await _warehouseProductService.UpdateWarehouseProductAsync(warehouseProduct);

                //activity log
                await _customerActivityService.InsertActivityAsync("EditWarehouseProduct",
                    string.Format(await _localizationService.GetResourceAsync("ActivityLog.EditWarehouseProduct"), warehouseProduct.Id), warehouseProduct);

                _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Warehouses.WarehouseProduct.Updated"));

                return RedirectToAction("List", "WarehouseProduct", new { warehouseId = warehouseId });
            }

            //prepare model
            model = await _warehouseProductModelFactory.PrepareWarehouseProductModelAsync(model, warehouseProduct);

            //if we got this far, something failed, redisplay form
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, int warehouseId)
        {
            return AccessDeniedView();

            //TODO: ADD LOGIC TO VALIDATE IF THE USER IS ALLOWED TO ENTER THIS SPECIFIC WAREHOUSE
            var currentUser = await _workContext.GetCurrentCustomerAsync();
            //if (!IsUserAllowedToAccessWarehouse(warehouseId, currentUser.Id))
            //    return AccessDeniedView();

            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
                return AccessDeniedView();

            //try to get a warehouse product with the specified id
            var warehouseProduct = await _warehouseProductService.GetWarehouseProductByIdAsync(id);

            if (warehouseProduct is null)
                return RedirectToAction("List", "WarehouseProduct", new { warehouseId = warehouseId });

            var warehouseProductCombinations = await _warehouseProductCombinationService.GetWarehouseProductCombinationsByWarehouseProductIdAsync(warehouseProduct.Id);

            await _warehouseProductCombinationService.DeleteWarehouseProductCombinationAsync(warehouseProductCombinations);
            await _warehouseProductService.DeleteWarehouseProductAsync(warehouseProduct);

            //activity log
            await _customerActivityService.InsertActivityAsync("DeleteWarehouseProduct",
                string.Format(await _localizationService.GetResourceAsync("ActivityLog.DeleteWarehouseProduct"), warehouseProduct.Id), warehouseProduct);
            foreach (var warehouseProductCombination in warehouseProductCombinations)
            {
                await _customerActivityService.InsertActivityAsync("DeleteWarehouseProductCombination",
                    string.Format(await _localizationService.GetResourceAsync("ActivityLog.DeleteWarehouseProductCombination"), warehouseProductCombination.Id), warehouseProductCombination);
            }

            _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Warehouses.WarehouseProduct.Deleted"));

            return RedirectToAction("List", "WarehouseProduct", new { warehouseId = warehouseId });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteSelected(ICollection<int> selectedIds, int warehouseId)
        {
            //TODO: ADD LOGIC TO VALIDATE IF THE USER IS ALLOWED TO ENTER THIS SPECIFIC WAREHOUSE
            //var currentUser = await _workContext.GetCurrentCustomerAsync();
            //if (!IsUserAllowedToAccessWarehouse(warehouseId, currentUser.Id))
            //    return AccessDeniedView();

            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
                return AccessDeniedView();

            if (selectedIds is null || selectedIds.Count == 0)
                return NoContent();

            var warehouseProducts = await _warehouseProductService.GetWarehouseProductByIdsAsync(selectedIds.ToArray());
            var warehouseProductCombinationsForDeletion = await _warehouseProductCombinationService.GetWarehouseProductCombinationsByWarehouseProductIdAsync(
                warehouseProducts.Select(x => x.Id).ToArray());

            if(warehouseProductCombinationsForDeletion != null && warehouseProductCombinationsForDeletion.Any())
            {
                foreach (var productCombination in warehouseProductCombinationsForDeletion)
                {
                    if (productCombination.TotalQuantity > 0 || productCombination.DamagedQuantity > 0 || productCombination.ReturnedToVendorQuantity > 0)
                    {
                        return Json(new { Result = false });
                    }
                }
                await _warehouseProductCombinationService.DeleteWarehouseProductCombinationAsync(warehouseProductCombinationsForDeletion);
            }
            await _warehouseProductService.DeleteWarehouseProductAsync(warehouseProducts);

            //activity log
            foreach (var warehouseProduct in warehouseProducts)
            {
                await _customerActivityService.InsertActivityAsync("DeleteWarehouseProduct",
                string.Format(await _localizationService.GetResourceAsync("ActivityLog.DeleteWarehouseProduct"), warehouseProduct.Id), warehouseProduct);
                foreach (var warehouseProductCombination in warehouseProductCombinationsForDeletion.Where(x => x.WarehouseProductId == warehouseProduct.Id))
                {
                    await _customerActivityService.InsertActivityAsync("DeleteWarehouseProductCombination",
                        string.Format(await _localizationService.GetResourceAsync("ActivityLog.DeleteWarehouseProductCombination"), warehouseProductCombination.Id), warehouseProductCombination);
                }
            }
            return Json(new { Result = true });
        }

        #endregion

    }

}
