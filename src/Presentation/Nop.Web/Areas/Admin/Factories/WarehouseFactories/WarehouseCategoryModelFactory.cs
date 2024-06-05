using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Directory;
using Nop.Core.Domain.Discounts;
using Nop.Core.Domain.Warehouses;
using Nop.Services.Catalog;
using Nop.Services.Directory;
using Nop.Services.Discounts;
using Nop.Services.Localization;
using Nop.Services.Seo;
using Nop.Services.Warehouses.Interface;
using Nop.Web.Areas.Admin.Infrastructure.Mapper.Extensions;
using Nop.Web.Areas.Admin.Models.Catalog;
using Nop.Web.Areas.Admin.Models.Warehouses;
using Nop.Web.Framework.Extensions;
using Nop.Web.Framework.Factories;
using Nop.Web.Framework.Models.Extensions;

namespace Nop.Web.Areas.Admin.Factories.WarehouseFactories
{
    /// <summary>
    /// Represents the warehouse category model factory implementation
    /// </summary>
    public class WarehouseCategoryModelFactory : IWarehouseCategoryModelFactory
    {
        #region Fields

        private readonly CurrencySettings _currencySettings;
        private readonly ICurrencyService _currencyService;
        private readonly IWarehouseCategoryService _warehouseCategoryService;

        #endregion

        #region Ctor

        public WarehouseCategoryModelFactory(CurrencySettings currencySettings,
            ICurrencyService currencyService,
            IWarehouseCategoryService warehouseCategoryService)
        {
            _currencySettings = currencySettings;
            _currencyService = currencyService;
            _warehouseCategoryService = warehouseCategoryService;
        }

        #endregion

        #region Utilities

        public async Task PrepareWarehouseCategoriesAsync(IList<SelectListItem> items)
        {
            var categories = await _warehouseCategoryService.GetAllWarehouseCategoriesAsync();

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
        /// Prepare warehouse category search model
        /// </summary>
        /// <param name="searchModel">Warehouse Category search model</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the warehouse category search model
        /// </returns>
        public WarehouseCategorySearchModel PrepareWarehouseCategorySearchModelAsync(WarehouseCategorySearchModel searchModel)
        {
            if (searchModel == null)
                throw new ArgumentNullException(nameof(searchModel));

            //prepare page parameters
            searchModel.SetGridPageSize();

            return searchModel;
        }

        /// <summary>
        /// Prepare paged Warehouse category list model
        /// </summary>
        /// <param name="searchModel">Warehouse category search model</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the warehouse category list model
        /// </returns>
        public async Task<WarehouseCategoryListModel> PrepareWarehouseCategoryListModelAsync(WarehouseCategorySearchModel searchModel)
        {
            if (searchModel == null)
                throw new ArgumentNullException(nameof(searchModel));

            //get categories
            var warehouseCategories = await _warehouseCategoryService.GetAllWarehouseCategoriesAsync(
                categoryName: searchModel.SearchWarehouseCategoryName,
                pageIndex: searchModel.Page - 1,
                pageSize: searchModel.PageSize
                );

            //prepare grid model
            var model = await new WarehouseCategoryListModel().PrepareToGridAsync(searchModel, warehouseCategories, () =>
            {
                return warehouseCategories.SelectAwait(async warehouseCategory =>
                {
                    //fill in model values from the entity
                    return warehouseCategory.ToModel<WarehouseCategoryModel>();
                });
            });

            return model;
        }

        public async Task<WarehouseCategoryModel> PrepareWarehouseCategoryModelAsync(WarehouseCategoryModel model, WarehouseCategory warehouseCategory)
        {

            if (warehouseCategory != null)
            {
                //fill in model values from the entity
                if (model == null)
                {
                    model = warehouseCategory.ToModel<WarehouseCategoryModel>();
                }
            }

            //prepare available warehouse categories
            await PrepareWarehouseCategoriesAsync(model.AvailableWarehouseCategories);

            return model;
        }

        #endregion
    }



}

