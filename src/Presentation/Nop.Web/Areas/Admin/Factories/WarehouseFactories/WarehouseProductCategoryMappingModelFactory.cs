using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Core.Domain.Warehouses;
using Nop.Services.Catalog;
using Nop.Services.Warehouses;
using Nop.Services.Warehouses.Interface;
using Nop.Web.Areas.Admin.Infrastructure.Mapper.Extensions;
using Nop.Web.Areas.Admin.Models.Warehouses;
using Nop.Web.Framework.Models.Extensions;

namespace Nop.Web.Areas.Admin.Factories.WarehouseFactories
{
    /// <summary>
    /// Represents the warehouse product category mapping model factory implementation
    /// </summary>
    public class WarehouseProductCategoryMappingModelFactory : IWarehouseProductCategoryMappingModelFactory
    {

        #region Fields

        private readonly IWarehouseProductCategoryMappingService _warehouseProductCategoryMappingService;
        private readonly IWarehouseCategoryMappingService _warehouseCategoryMappingService;
        private readonly IWarehouseCategoryService _warehouseCategoryService;
        private readonly ICategoryService _categoryService;

        #endregion

        #region Ctor

        public WarehouseProductCategoryMappingModelFactory(IWarehouseProductCategoryMappingService warehouseProductCategoryMappingService, 
            IWarehouseCategoryMappingService warehouseCategoryMappingService,
            IWarehouseCategoryService warehouseCategoryService,
            ICategoryService categoryService)
        {
            _warehouseProductCategoryMappingService = warehouseProductCategoryMappingService;
            _warehouseCategoryMappingService = warehouseCategoryMappingService;
            _warehouseCategoryService = warehouseCategoryService;
            _categoryService = categoryService;
        }

        #endregion

        #region Utilities

        protected async Task PrepareWarehouseCategoriesAsync(IList<SelectListItem> items, int warehouseId)
        {
            var mappedWarehouseCategories = await _warehouseCategoryMappingService.GetAllWarehouseCategoryMappingAsync(warehouseId);
            var categories = await _warehouseCategoryService.GetWarehouseCategoriesByIdsAsync(mappedWarehouseCategories.Select(x => x.WarehouseCategoryId).ToArray());
            foreach (var category in categories)
            {
                items.Add(new SelectListItem()
                {
                    Text = category.Name,
                    // warehouse category mapping id
                    Value = mappedWarehouseCategories.FirstOrDefault(x => x.WarehouseCategoryId == category.Id).Id.ToString()
                });
            }
        }

        protected async Task PrepareProductsCategoriesAsync(IList<SelectListItem> items, WarehouseProductCategoryMappingModel model, bool isEditMode)
        {
            //get mapped warehouse categories
            var mappedWarehouseCategories = await _warehouseCategoryMappingService.GetAllWarehouseCategoryMappingAsync(model.WarehouseId);
            var warehouseCategoryMappingIds = mappedWarehouseCategories.Select(x => x.Id).ToArray();
            var mappedProductCategories = await _warehouseProductCategoryMappingService.GetWarehouseProductCategoryMappingByWarehouseCategoryMappingIdAsync(warehouseCategoryMappingIds);
            // mapped product categories ids
            var productCategoriesIds = mappedProductCategories.Select(x => x.ProductCategoryId).ToList();

            //to be added into the selection list
            if (isEditMode)
            {
                productCategoriesIds.Remove(model.ProductCategoryId);
            }

            //all distinct product categories
            var categories = await _categoryService.GetAllCategoriesAsync();
            categories = categories.DistinctBy(x => x.Name).ToList();

            //clear used categories from the list
            var filteredCategories = categories.Where(x => !productCategoriesIds.Contains(x.Id));
            foreach (var category in filteredCategories)
            {
                items.Add(new SelectListItem()
                {
                    Text = category.Name,
                    Value = category.Id.ToString()
                });
            }
        }

        protected async Task<string> PrepareWarehouseCategoryNameAsync(int warehouseCategoryMappingId)
        {
            var mappedWarehouseCategory = await _warehouseCategoryMappingService.GetWarehouseCategoryMappingByIdAsync(warehouseCategoryMappingId);
            var warehouseCategory = await _warehouseCategoryService.GetWarehouseCategoryByIdAsync(mappedWarehouseCategory.WarehouseCategoryId);
            return warehouseCategory.Name;
        }

        protected async Task<string> PrepareProductCategoryNameAsync(int productCategoryId)
        {
            var productCategory = await _categoryService.GetCategoryByIdAsync(productCategoryId);
            return productCategory.Name;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Prepare warehouse product category mapping search model
        /// </summary>
        /// <param name="searchModel">warehouse product category mapping search model</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the warehouse product category mapping search model
        /// </returns>
        public WarehouseProductCategoryMappingSearchModel PrepareWarehouseProductCategoryMappingSearchModelAsync(WarehouseProductCategoryMappingSearchModel searchModel)
        {
            if (searchModel == null)
                throw new ArgumentNullException(nameof(searchModel));

            //prepare page parameters
            searchModel.SetGridPageSize();

            return searchModel;
        }

        /// <summary>
        /// Prepare paged warehouse product category mapping list model
        /// </summary>
        /// <param name="searchModel">warehouse product category mapping search model</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the warehouse product category mapping list model
        /// </returns>
        public async Task<WarehouseProductCategoryMappingListModel> PrepareWarehouseProductCategoryMappingListModelAsync(WarehouseProductCategoryMappingSearchModel searchModel)
        {
            if (searchModel == null)
                throw new ArgumentNullException(nameof(searchModel));

            var warehouseProductCategoryMapping = await _warehouseProductCategoryMappingService.GetAllWarehouseProductCategoryMappingAsync(
                warehouseId: searchModel.WarehouseId,
                productCategory: searchModel.SearchProductCategoryName,
                pageIndex: searchModel.Page - 1,
                pageSize: searchModel.PageSize
                );

            //prepare grid model
            var model = await new WarehouseProductCategoryMappingListModel().PrepareToGridAsync(searchModel, warehouseProductCategoryMapping, () =>
            {
                return warehouseProductCategoryMapping.SelectAwait(async warehouseProductCategoryMapping =>
                {
                    //fill in model values from the entity
                    var warehouseProductCategoryMappingModel = warehouseProductCategoryMapping.ToModel<WarehouseProductCategoryMappingModel>();
                    warehouseProductCategoryMappingModel.WarehouseCategoryName = await PrepareWarehouseCategoryNameAsync(warehouseProductCategoryMappingModel.WarehouseCategoryMappingId);
                    warehouseProductCategoryMappingModel.ProductCategoryName = await PrepareProductCategoryNameAsync(warehouseProductCategoryMappingModel.ProductCategoryId);
                    return warehouseProductCategoryMappingModel;
                });
            });

            return model;
        }

        /// <summary>
        /// Prepare warehouse product category mapping model
        /// </summary>
        /// <param name="model">warehouse product category mapping model</param>
        /// <param name="warehouseProductCategoryMapping">WarehouseProductCategoryMapping</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the warehouse product category mapping model
        /// </returns>
        public async Task<WarehouseProductCategoryMappingModel> PrepareWarehouseProductCategoryMappingModelAsync(WarehouseProductCategoryMappingModel model, WarehouseProductCategoryMapping warehouseProductCategoryMapping, bool isEditMode = false)
        {

            if (warehouseProductCategoryMapping != null)
            {
                //fill in model values from the entity
                if (model == null)
                {
                    model = warehouseProductCategoryMapping.ToModel<WarehouseProductCategoryMappingModel>();
                    var mappedWarehouseCategory = await _warehouseCategoryMappingService.GetWarehouseCategoryMappingByIdAsync(warehouseProductCategoryMapping.WarehouseCategoryMappingId);
                    model.WarehouseId = mappedWarehouseCategory.WarehouseId;
                }
            }


            //prepare model fields
            await PrepareWarehouseCategoriesAsync(model.AvailableMappedWarehouseCategories, model.WarehouseId);
            await PrepareProductsCategoriesAsync(model.AvailableProductCategories, model, isEditMode);

            return model;
        }

        #endregion

    }

}
