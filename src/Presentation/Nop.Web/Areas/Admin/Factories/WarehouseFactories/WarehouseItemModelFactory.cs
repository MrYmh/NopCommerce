using System;
using System.Linq;
using System.Threading.Tasks;
using Nop.Core.Domain.Warehouses;
using Nop.Services.Warehouses.Interface;
using Nop.Web.Areas.Admin.Infrastructure.Mapper.Extensions;
using Nop.Web.Areas.Admin.Models.Warehouses;
using Nop.Web.Framework.Models.Extensions;

namespace Nop.Web.Areas.Admin.Factories.WarehouseFactories
{
    /// <summary>
    /// Represents the warehouse item model factory implementation
    /// </summary>
    public class WarehouseItemModelFactory : IWarehouseItemModelFactory
    {

        #region Fields

        private readonly IWarehouseItemService _warehouseItemService;

        #endregion

        #region Ctor

        public WarehouseItemModelFactory(IWarehouseItemService warehouseItemService)
        {
            _warehouseItemService = warehouseItemService;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Prepare warehouse item search model
        /// </summary>
        /// <param name="searchModel">warehouse item search model</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the warehouse item search model
        /// </returns>
        public WarehouseItemSearchModel PrepareWarehouseItemSearchModelAsync(WarehouseItemSearchModel searchModel)
        {
            if (searchModel == null)
                throw new ArgumentNullException(nameof(searchModel));

            //prepare page parameters
            searchModel.SetGridPageSize();

            return searchModel;
        }

        /// <summary>
        /// Prepare paged warehouse item list model
        /// </summary>
        /// <param name = "searchModel" > warehouse item search model</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the warehouse item list model
        /// </returns>
        public async Task<WarehouseItemListModel> PrepareWarehouseItemListModelAsync(WarehouseItemSearchModel searchModel)
        {
            if (searchModel == null)
                throw new ArgumentNullException(nameof(searchModel));

            //get categories
            var warehouseItem = await _warehouseItemService.GetAllWarehouseItemsAsync(
                warehouseId: searchModel.WarehouseId,
                pageIndex: searchModel.Page - 1,
                pageSize: searchModel.PageSize
                );

            //prepare grid model
            var model = await new WarehouseItemListModel().PrepareToGridAsync(searchModel, warehouseItem, () =>
            {
                return warehouseItem.SelectAwait(async warehouseItem =>
                {
                    //fill in model values from the entity
                    var warehouseItemModel = warehouseItem.ToModel<WarehouseItemModel>();

                    return warehouseItemModel;
                });
            });

            return model;
        }

        /// <summary>
        /// Prepare warehouse item model
        /// </summary>
        /// <param name="model">warehouse item model</param>
        /// <param name="warehouseItem">WarehouseItem</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the warehouse item model
        /// </returns>
        public async Task<WarehouseItemModel> PrepareWarehouseItemModelAsync(WarehouseItemModel model, WarehouseItem warehouseItem)
        {

            if (warehouseItem != null)
            {
                //fill in model values from the entity
                if (model == null)
                {
                    model = warehouseItem.ToModel<WarehouseItemModel>();
                }
            }


            //prepare model fields

            return model;
        }

        

        #endregion

    }

}
