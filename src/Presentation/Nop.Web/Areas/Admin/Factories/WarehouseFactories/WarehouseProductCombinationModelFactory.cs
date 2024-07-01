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
    /// Represents the warehouse product combination model factory implementation
    /// </summary>
    public class WarehouseProductCombinationModelFactory : IWarehouseProductCombinationModelFactory
    {

        #region Fields

        private readonly IWarehouseProductCombinationService _warehouseProductCombinationService;

        #endregion

        #region Ctor

        public WarehouseProductCombinationModelFactory(IWarehouseProductCombinationService warehouseProductCombinationService)
        {
            _warehouseProductCombinationService = warehouseProductCombinationService;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Prepare warehouse product combination search model
        /// </summary>
        /// <param name="searchModel">warehouse product combination search model</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the warehouse product combination search model
        /// </returns>
        public WarehouseProductCombinationSearchModel PrepareWarehouseProductCombinationSearchModelAsync(WarehouseProductCombinationSearchModel searchModel)
        {
            try
            {
                if (searchModel == null)
                    throw new ArgumentNullException(nameof(searchModel));

                //prepare page parameters
                searchModel.SetGridPageSize();

                return searchModel;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        ///// <summary>
        ///// Prepare paged warehouse unprinted serials list model
        ///// </summary>
        ///// <param name="searchModel">warehouse unprinted serials search model</param>
        ///// <returns>
        ///// A task that represents the asynchronous operation
        ///// The task result contains the warehouse unprinted serials list model
        ///// </returns>
        //public async Task<WarehouseProductCombinationListModel> PrepareUnPrintedSerialsListModelAsync(WarehouseProductCombinationSearchModel searchModel)
        //{
        //    try
        //    {
        //        if (searchModel == null)
        //            throw new ArgumentNullException(nameof(searchModel));

        //        //get categories
        //        var warehouseItems = await _warehouseProductCombinationService.GetAllUnPrintedSerialsAsync(
        //            warehouseId: searchModel.WarehouseId,
        //            pageIndex: searchModel.Page - 1,
        //            pageSize: searchModel.PageSize
        //            );



        //        //prepare grid model
        //        //var model = await new WarehouseItemListModel().PrepareToGridAsync(searchModel, warehouseItems, () =>
        //        //{
        //        //    return warehouseItems.SelectAwait(async warehouseProductCombination =>
        //        //    {
        //        //        //fill in model values from the entity
        //        //        var warehouseProductCombinationModel = warehouseProductCombination.ToModel<WarehouseProductCombinationModel>();

        //        //        return warehouseProductCombinationModel;
        //        //    });
        //        //});

        //        return model;
        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }
        //}


        /// <summary>
        /// Prepare paged warehouse product combination list model
        /// </summary>
        /// <param name="searchModel">warehouse product combination search model</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the warehouse product combination list model
        /// </returns>
        public async Task<WarehouseProductCombinationListModel> PrepareWarehouseProductCombinationListModelAsync(WarehouseProductCombinationSearchModel searchModel)
        {
            try
            {
                if (searchModel == null)
                    throw new ArgumentNullException(nameof(searchModel));

                //get categories
                var warehouseProductCombination = await _warehouseProductCombinationService.GetAllWarehouseProductCombinationsAsync(
                    warehouseId: searchModel.WarehouseId,
                    sku: searchModel.Sku,
                    pageIndex: searchModel.Page - 1,
                    pageSize: searchModel.PageSize
                    );

                //prepare grid model
                var model = await new WarehouseProductCombinationListModel().PrepareToGridAsync(searchModel, warehouseProductCombination, () =>
                {
                    return warehouseProductCombination.SelectAwait(async warehouseProductCombination =>
                    {
                        //fill in model values from the entity
                        var warehouseProductCombinationModel = warehouseProductCombination.ToModel<WarehouseProductCombinationModel>();

                        return warehouseProductCombinationModel;
                    });
                });

                return model;
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        /// <summary>
        /// Prepare warehouse product combination model
        /// </summary>
        /// <param name="model">warehouse product combination model</param>
        /// <param name="warehouseProductCombination">WarehouseProductCombination</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the warehouse product combination model
        /// </returns>
        public Task<WarehouseProductCombinationModel> PrepareWarehouseProductCombinationModelAsync(WarehouseProductCombinationModel model, WarehouseProductCombination warehouseProductCombination)
        {

            if (warehouseProductCombination != null)
            {
                //fill in model values from the entity
                if (model == null)
                {
                    model = warehouseProductCombination.ToModel<WarehouseProductCombinationModel>();
                }
            }

            //prepare model fields

            return Task.FromResult(model);
        }

        #endregion

    }

}
