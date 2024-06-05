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
    /// Represents the warehouse stand model factory implementation
    /// </summary>
    public class WarehouseStandModelFactory : IWarehouseStandModelFactory
    {

        #region Fields

        private readonly IWarehouseStandService _warehouseStandService;
        private readonly IShelfService _shelfService;

        #endregion

        #region Ctor

        public WarehouseStandModelFactory(IWarehouseStandService warehouseStandService, IShelfService shelfService)
        {
            _warehouseStandService = warehouseStandService;
            _shelfService = shelfService;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Prepare warehouse stand search model
        /// </summary>
        /// <param name="searchModel">warehouse stand search model</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the warehouse stand search model
        /// </returns>
        public WarehouseStandSearchModel PrepareWarehouseStandSearchModelAsync(WarehouseStandSearchModel searchModel)
        {
            if (searchModel == null)
                throw new ArgumentNullException(nameof(searchModel));

            //prepare page parameters
            searchModel.SetGridPageSize();

            return searchModel;
        }

        /// <summary>
        /// Prepare paged warehouse stand list model
        /// </summary>
        /// <param name="searchModel">warehouse stand search model</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the warehouse stand list model
        /// </returns>
        public async Task<WarehouseStandListModel> PrepareWarehouseStandListModelAsync(WarehouseStandSearchModel searchModel)
        {
            if (searchModel == null)
                throw new ArgumentNullException(nameof(searchModel));

            //get stands
            var warehouseStands = await _warehouseStandService.GetAllWarehouseStandsAsync(
                warehouseId: searchModel.WarehouseId,
                materialType: searchModel.SearchMaterialType,
                pageIndex: searchModel.Page - 1,
                pageSize: searchModel.PageSize
                );

            //prepare grid model
            var model = await new WarehouseStandListModel().PrepareToGridAsync(searchModel, warehouseStands, () =>
            {
                return warehouseStands.SelectAwait(async warehouseStand =>
                {
                    //fill in model values from the entity
                    var warehouseStandModel = warehouseStand.ToModel<WarehouseStandModel>();
                    return warehouseStandModel;
                });
            });

            return model;
        }

        /// <summary>
        /// Prepare warehouse stand model
        /// </summary>
        /// <param name="model">warehouse stand model</param>
        /// <param name="warehouseStand">WarehouseStand</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the warehouse stand model
        /// </returns>
        public WarehouseStandModel PrepareWarehouseStandModelAsync(WarehouseStandModel model, WarehouseStand warehouseStand)
        {

            if (warehouseStand != null)
            {
                //fill in model values from the entity
                if (model == null)
                {
                    model = warehouseStand.ToModel<WarehouseStandModel>();
                }
            }


            //prepare model fields

            return model;
        }

        #endregion

    }

}
