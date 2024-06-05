
using System;
using System.Linq;
using System.Threading.Tasks;
using Nop.Core.Domain.Warehouses;
using Nop.Services.Warehouses;
using Nop.Services.Warehouses.Interface;
using Nop.Web.Areas.Admin.Infrastructure.Mapper.Extensions;
using Nop.Web.Areas.Admin.Models.Warehouses;
using Nop.Web.Framework.Models.Extensions;

namespace Nop.Web.Areas.Admin.Factories.WarehouseFactories
{
    /// <summary>
    /// Represents the shelf item mapping model factory implementation
    /// </summary>
    public class ShelfItemMappingModelFactory : IShelfItemMappingModelFactory
    {

        #region Fields

        private readonly IShelfItemMappingService _shelfItemMappingService;

        #endregion

        #region Ctor

        public ShelfItemMappingModelFactory(IShelfItemMappingService shelfItemMappingService)
        {
            _shelfItemMappingService = shelfItemMappingService;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Prepare shelf item mapping search model
        /// </summary>
        /// <param name="searchModel">shelf item mapping search model</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the shelf item mapping search model
        /// </returns>
        public ShelfItemMappingSearchModel PrepareShelfItemMappingSearchModelAsync(ShelfItemMappingSearchModel searchModel)
        {
            if (searchModel == null)
                throw new ArgumentNullException(nameof(searchModel));

            //prepare page parameters
            searchModel.SetGridPageSize();

            return searchModel;
        }

        /// <summary>
        /// Prepare paged shelf item mapping list model
        /// </summary>
        /// <param name="searchModel">shelf item mapping search model</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the shelf item mapping list model
        /// </returns>
        public async Task<ShelfItemMappingListModel> PrepareShelfItemMappingListModelAsync(ShelfItemMappingSearchModel searchModel)
        {
            if (searchModel == null)
                throw new ArgumentNullException(nameof(searchModel));

            //get categories
            var shelfItemMapping = await _shelfItemMappingService.GetAllShelfItemMappingAsync(
                pageIndex: searchModel.Page - 1,
                pageSize: searchModel.PageSize
                );

            //prepare grid model
            var model = await new ShelfItemMappingListModel().PrepareToGridAsync(searchModel, shelfItemMapping, () =>
            {
                return shelfItemMapping.SelectAwait(async shelfItemMapping =>
                {
                    //fill in model values from the entity
                    var shelfItemMappingModel = shelfItemMapping.ToModel<ShelfItemMappingModel>();

                    return shelfItemMappingModel;
                });
            });

            return model;
        }

        /// <summary>
        /// Prepare shelf item mapping model
        /// </summary>
        /// <param name="model">shelf item mapping model</param>
        /// <param name="shelfItemMapping">ShelfItemMapping</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the shelf item mapping model
        /// </returns>
        public async Task<ShelfItemMappingModel> PrepareShelfItemMappingModelAsync(ShelfItemMappingModel model, ShelfItemMapping shelfItemMapping)
        {

            if (shelfItemMapping != null)
            {
                //fill in model values from the entity
                if (model == null)
                {
                    model = shelfItemMapping.ToModel<ShelfItemMappingModel>();
                }
            }


            //prepare model fields

            return model;
        }

        #endregion

    }

}
