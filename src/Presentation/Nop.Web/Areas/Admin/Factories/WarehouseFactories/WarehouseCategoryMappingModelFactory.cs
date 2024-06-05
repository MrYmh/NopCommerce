using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Core.Domain.Directory;
using Nop.Core.Domain.Warehouses;
using Nop.Services.Directory;
using Nop.Services.Shipping;
using Nop.Services.Warehouses;
using Nop.Services.Warehouses.Interface;
using Nop.Web.Areas.Admin.Infrastructure.Mapper.Extensions;
using Nop.Web.Areas.Admin.Models.Shipping;
using Nop.Web.Areas.Admin.Models.Warehouses;
using Nop.Web.Framework.Models.Extensions;

namespace Nop.Web.Areas.Admin.Factories.WarehouseFactories
{
    /// <summary>
    /// Represents the warehouse category mapping model factory implementation
    /// </summary>
    public class WarehouseCategoryMappingModelFactory : IWarehouseCategoryMappingModelFactory
    {
        #region Fields

        private readonly CurrencySettings _currencySettings;
        private readonly ICurrencyService _currencyService;
        private readonly IWarehouseCategoryService _warehouseCategoryService;
        private readonly IShippingService _shippingService;
        private readonly IWarehouseCategoryMappingService _warehouseCategoryMappingService;

        #endregion

        #region Ctor

        public WarehouseCategoryMappingModelFactory(CurrencySettings currencySettings,
            ICurrencyService currencyService,
            IWarehouseCategoryService warehouseCategoryService,
            IShippingService shippingService,
            IWarehouseCategoryMappingService warehouseCategoryMappingService)
        {
            _currencySettings = currencySettings;
            _currencyService = currencyService;
            _shippingService = shippingService;
            _warehouseCategoryService = warehouseCategoryService;
            _warehouseCategoryMappingService = warehouseCategoryMappingService;
        }

        #endregion

        #region Utilities

        public async Task PrepareWarehouseCategoriesAsync(IList<SelectListItem> items, int warehouseId)
        {

            var mappedWarehouseCategories = await _warehouseCategoryMappingService.GetAllWarehouseCategoryMappingAsync(warehouseId);
            var categories = await _warehouseCategoryService.GetAvailableWarehouseCategoriesForMappingAsync(mappedWarehouseCategories.Select(x => x.WarehouseCategoryId).ToArray());
            foreach (var category in categories)
            {
                items.Add(new SelectListItem()
                {
                    Text = category.Name,
                    Value = category.Id.ToString()
                });
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Prepare mapped warehouse category search model
        /// </summary>
        /// <param name="searchModel">Warehouse Category search model</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the mapped warehouse category search model
        /// </returns>
        public WarehouseCategoryMappingSearchModel PrepareWarehouseCategoryMappingSearchModelAsync(WarehouseCategoryMappingSearchModel searchModel)
        {
            if (searchModel == null)
                throw new ArgumentNullException(nameof(searchModel));

            //prepare page parameters
            searchModel.SetGridPageSize();

            return searchModel;
        }

        /// <summary>
        /// Prepare paged mapped Warehouse category list model
        /// </summary>
        /// <param name="searchModel">Warehouse category search model</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the mapped warehouse category list model
        /// </returns>
        public async Task<WarehouseCategoryMappingListModel> PrepareWarehouseCategoryMappingListModelAsync(WarehouseCategoryMappingSearchModel searchModel)
        {
            if (searchModel == null)
                throw new ArgumentNullException(nameof(searchModel));

            //get mapped categories
            var mappedWarehouseCategories = await _warehouseCategoryMappingService.GetAllWarehouseCategoryMappingAsync(
                warehouseId: searchModel.WarehouseId,
                categoryName: searchModel.SearchWarehouseCategoryName,
                pageIndex: searchModel.Page - 1,
                pageSize: searchModel.PageSize
                );

            //prepare grid model
            var model = await new WarehouseCategoryMappingListModel().PrepareToGridAsync(searchModel, mappedWarehouseCategories, () =>
            {
                return mappedWarehouseCategories.SelectAwait(async mappedWarehouseCategory =>
                {
                    //fill in model values from the entity
                    var mappedWarehouseCategoryModel = mappedWarehouseCategory.ToModel<WarehouseCategoryMappingModel>();

                    //fill in additional values (not existing in the entity)
                    var warehouseCategory = await _warehouseCategoryService.GetWarehouseCategoryByIdAsync(mappedWarehouseCategory.WarehouseCategoryId);
                    var warehouse = await _shippingService.GetWarehouseByIdAsync(mappedWarehouseCategory.WarehouseId);
                    mappedWarehouseCategoryModel.WarehouseCategoryModel = warehouseCategory.ToModel<WarehouseCategoryModel>();
                    mappedWarehouseCategoryModel.WarehouseModel = warehouse.ToModel<WarehouseModel>();
                    mappedWarehouseCategoryModel.Name = warehouseCategory.Name;
                    mappedWarehouseCategoryModel.Description = warehouseCategory.Description;
                    
                    return mappedWarehouseCategoryModel;
                });

            });

            return model;
        }

        /// <summary>
        /// Prepare mapped warehouse category model
        /// </summary>
        /// <param name="model">Warehouse category model</param>
        /// <param name="category">Warehouse category</param>
        /// <param name="excludeProperties">Whether to exclude populating of some properties of model</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the mapped warehouse category model
        /// </returns>
        public async Task<WarehouseCategoryMappingModel> PrepareWarehouseCategoryMappingModelAsync(WarehouseCategoryMappingModel model, WarehouseCategoryMapping mappedWarehouseCategory)
        {
            if (mappedWarehouseCategory != null)
            {
                //fill in model values from the entity
                if (model is null)
                {
                    model = mappedWarehouseCategory.ToModel<WarehouseCategoryMappingModel>();
                }
            }

            //prepare available warehouse categories
            await PrepareWarehouseCategoriesAsync(model.AvailableWarehouseCategories, model.WarehouseId);

            return model;
        }


        #endregion
    }



}

