using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Core.Domain.Warehouses;
using Nop.Services.Warehouses.Interface;
using Nop.Web.Areas.Admin.Infrastructure.Mapper.Extensions;
using Nop.Web.Areas.Admin.Models.Warehouses;
using Nop.Web.Framework.Models.Extensions;


namespace Nop.Web.Areas.Admin.Factories.WarehouseFactories
{
    /// <summary>
    /// Represents the warehouse product model factory implementation
    /// </summary>
    public class WarehouseProductModelFactory : IWarehouseProductModelFactory
    {

        #region Fields

        private readonly IWarehouseProductService _warehouseProductService;
        private readonly IWarehouseCategoryMappingService _warehouseCategoryMappingService;
        private readonly IWarehouseProductCategoryMappingService _warehouseProductCategoryMappingService;
        private readonly IWarehouseCategoryService _warehouseCategoryService;

        #endregion

        #region Ctor

        public WarehouseProductModelFactory(IWarehouseProductService warehouseProductService,
            IWarehouseCategoryMappingService warehouseCategoryMappingService,
            IWarehouseProductCategoryMappingService warehouseProductCategoryMappingService,
            IWarehouseCategoryService warehouseCategoryService)
        {
            _warehouseProductService = warehouseProductService;
            _warehouseCategoryMappingService = warehouseCategoryMappingService;
            _warehouseProductCategoryMappingService = warehouseProductCategoryMappingService;
            _warehouseCategoryService = warehouseCategoryService;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Prepare warehouse product search model
        /// </summary>
        /// <param name="searchModel">warehouse product search model</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the warehouse product search model
        /// </returns>
        public WarehouseProductSearchModel PrepareWarehouseProductSearchModelAsync(WarehouseProductSearchModel searchModel)
        {
            if (searchModel == null)
                throw new ArgumentNullException(nameof(searchModel));

            //prepare page parameters
            searchModel.SetGridPageSize();

            return searchModel;
        }

        /// <summary>
        /// Prepare paged warehouse product list model
        /// </summary>
        /// <param name="searchModel">warehouse product search model</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the warehouse product list model
        /// </returns>
        public async Task<WarehouseProductListModel> PrepareWarehouseProductListModelAsync(WarehouseProductSearchModel searchModel)
        {
            if (searchModel == null)
                throw new ArgumentNullException(nameof(searchModel));

            //get warehouse product
            var warehouseProduct = await _warehouseProductService.GetAllWarehouseProductsAsync(
                warehouseId: searchModel.WarehouseId,
                productName: searchModel.Name,
                sku: searchModel.Sku,
                pageIndex: searchModel.Page - 1,
                pageSize: searchModel.PageSize
                );

            //prepare grid model
            var model = await new WarehouseProductListModel().PrepareToGridAsync(searchModel, warehouseProduct, () =>
            {
                return warehouseProduct.SelectAwait(async warehouseProduct =>
                {
                    //fill in model values from the entity
                    var warehouseProductModel = warehouseProduct.ToModel<WarehouseProductModel>();
                    // validate if neccessary appending the combinations data...
                    return warehouseProductModel;
                });
            });

            return model;
        }

        /// <summary>
        /// Prepare warehouse product model
        /// </summary>
        /// <param name="model">warehouse product model</param>
        /// <param name="warehouseProduct">WarehouseProduct</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the warehouse product model
        /// </returns>
        public async Task<WarehouseProductModel> PrepareWarehouseProductModelAsync(WarehouseProductModel model, WarehouseProduct warehouseProduct)
        {

            if (warehouseProduct != null)
            {
                //fill in model values from the entity
                if (model == null)
                {
                    model = warehouseProduct.ToModel<WarehouseProductModel>();
                }
            }

            //prepare model fields
            await PrepareAvailableWarehouseProductCategoryMappingIdentifiers(model.AvailableWarehouseProductCategoryMappingIds, model.WarehouseId);

            return model;
        }

        private async Task PrepareAvailableWarehouseProductCategoryMappingIdentifiers(IList<SelectListItem> items, int warehouseId)
        {
            /*
             * availableWarehouseProductCategoryMappingId refers to 
             * a specific product category from the system that has been linked to warehouse's category 
             * which linked to a specific warehouse.
             * availableWarehouseProductCategoryMappingId =>
             *                                              WarehouseCategoryMappingId,
             *                                              ProductCategoryId ## both of them are WarehouseProductCategoryMappingId
             *                                              =>
             *                                                  WarehouseId,
             *                                                  WarehouseCategoryId ## both of them are WarehouseCategoryMappingId
             */

            //get WarehouseCategoryMapping related to the warehouse
            var mappedWarehouseCategories = await _warehouseCategoryMappingService.GetAllWarehouseCategoryMappingAsync(warehouseId);
            var mappedWarehouseCategoriesIds = mappedWarehouseCategories.Select(x => x.Id).ToArray();

            var warehouseCategoriesIds = mappedWarehouseCategories.Select(x => x.WarehouseCategoryId).ToArray();
            var warehouseCategories = await _warehouseCategoryService.GetWarehouseCategoriesByIdsAsync(warehouseCategoriesIds);



            //get WarehouseProductCategoryMapping related to the warehouse
            //var mappedWarehouseProductCategories = await _warehouseProductCategoryMappingService.GetWarehouseProductCategoryMappingByWarehouseCategoryMappingIdAsync(mappedWarehouseCategoriesIds);
            //var mappedWarehouseProductCategoriesIds = mappedWarehouseProductCategories.Select(x => x.Id);

            //var warehouseCategoryMappingIds = mappedWarehouseProductCategories.Select(x => x.WarehouseCategoryMappingId).Distinct().ToArray();
            //var warehouseCategories = await _warehouseCategoryService.GetWarehouseCategoriesByIdsAsync(warehouseCategoryMappingIds);
            //get availableMappedWarehouseProductCategories
            foreach (var warehouseCategory in warehouseCategories)
            {
                items.Add(new SelectListItem()
                {
                    // warehouse category name
                    Text = warehouseCategory.Name,
                    //mapping id
                    Value = mappedWarehouseCategories.FirstOrDefault(x => x.WarehouseCategoryId == warehouseCategory.Id).Id.ToString()
                });
            }
        }

        #endregion

    }

}
