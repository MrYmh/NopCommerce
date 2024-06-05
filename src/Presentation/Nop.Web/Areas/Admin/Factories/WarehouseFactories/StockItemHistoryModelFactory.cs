
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
    /// Represents the stock item history model factory implementation
    /// </summary>
    public class StockItemHistoryModelFactory : IStockItemHistoryModelFactory
    {

        #region Fields

        private readonly IStockHistoryService _stockHistoryService;
        private readonly IStockItemHistoryService _stockItemHistoryService;
        private readonly IWarehouseProductService _warehouseProductService;
        private readonly IWarehouseProductCombinationService _warehouseProductCombinationService;

        #endregion

        #region Ctor

        public StockItemHistoryModelFactory(IStockHistoryService stockHistoryService, 
            IStockItemHistoryService stockItemHistoryService, 
            IWarehouseProductService warehouseProductService, 
            IWarehouseProductCombinationService warehouseProductCombinationService)
        {
            _stockHistoryService = stockHistoryService;
            _stockItemHistoryService = stockItemHistoryService;
            _warehouseProductService = warehouseProductService;
            _warehouseProductCombinationService = warehouseProductCombinationService;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Prepare stock item history search model
        /// </summary>
        /// <param name="searchModel">stock item history search model</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the stock item history search model
        /// </returns>
        public StockItemHistorySearchModel PrepareStockItemHistorySearchModelAsync(StockItemHistorySearchModel searchModel)
        {
            if (searchModel == null)
                throw new ArgumentNullException(nameof(searchModel));

            //prepare page parameters
            searchModel.SetGridPageSize();

            return searchModel;
        }

        /// <summary>
        /// Prepare paged stock item history list model
        /// </summary>
        /// <param name="searchModel">stock item history search model</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the stock item history list model
        /// </returns>
        public async Task<StockItemHistoryListModel> PrepareStockItemHistoryListModelAsync(StockItemHistorySearchModel searchModel)
        {
            if (searchModel == null)
                throw new ArgumentNullException(nameof(searchModel));

            //get stock Items History
            var stockItemHistory = await _stockItemHistoryService.GetAllStockItemsHistoryAsync(
                stockHistoryId: searchModel.StockHistoryId,
                pageIndex: searchModel.Page - 1,
                pageSize: searchModel.PageSize
                );

            //prepare grid model
            var model = await new StockItemHistoryListModel().PrepareToGridAsync(searchModel, stockItemHistory, () =>
            {
                return stockItemHistory.SelectAwait(async stockItemHistory =>
                {
                    //fill in model values from the entity
                    var stockItemHistoryModel = stockItemHistory.ToModel<StockItemHistoryModel>();

                    var warehouseProductCombination = await _warehouseProductCombinationService.GetWarehouseProductCombinationByIdAsync(stockItemHistoryModel.WarehouseProductCombinationId);
                    stockItemHistoryModel.WarehouseProductCombination = warehouseProductCombination?.ToModel<WarehouseProductCombinationModel>();

                    if (warehouseProductCombination != null)
                    {
                        var warehouseProduct = await _warehouseProductService.GetWarehouseProductByIdAsync(warehouseProductCombination.WarehouseProductId);
                        stockItemHistoryModel.WarehouseProduct = warehouseProduct?.ToModel<WarehouseProductModel>();
                    }

                    return stockItemHistoryModel;
                });
            });

            return model;
        }

        /// <summary>
        /// Prepare stock item history model
        /// </summary>
        /// <param name="model">stock item history model</param>
        /// <param name="stockItemHistory">StockItemHistory</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the stock item history model
        /// </returns>
        public Task<StockItemHistoryModel> PrepareStockItemHistoryModelAsync(StockItemHistoryModel model, StockItemHistory stockItemHistory)
        {

            if (stockItemHistory != null)
            {
                //fill in model values from the entity
                if (model == null)
                {
                    model = stockItemHistory.ToModel<StockItemHistoryModel>();
                }
            }


            //prepare model fields

            return Task.FromResult(model);
        }

        #endregion

    }

}
