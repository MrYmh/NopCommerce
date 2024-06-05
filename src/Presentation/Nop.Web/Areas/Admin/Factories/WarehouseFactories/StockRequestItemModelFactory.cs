
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
    /// Represents the stock request item model factory implementation
    /// </summary>
    public class StockRequestItemModelFactory : IStockRequestItemModelFactory
    {

        #region Fields

        private readonly IStockRequestItemService _stockRequestItemService;

        #endregion

        #region Ctor

        public StockRequestItemModelFactory(IStockRequestItemService stockRequestItemService)
        {
            _stockRequestItemService = stockRequestItemService;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Prepare stock request item search model
        /// </summary>
        /// <param name="searchModel">stock request item search model</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the stock request item search model
        /// </returns>
        public StockRequestItemSearchModel PrepareStockRequestItemSearchModelAsync(StockRequestItemSearchModel searchModel)
        {
            if (searchModel == null)
                throw new ArgumentNullException(nameof(searchModel));

            //prepare page parameters
            searchModel.SetGridPageSize();

            return searchModel;
        }

        /// <summary>
        /// Prepare paged stock request item list model
        /// </summary>
        /// <param name="searchModel">stock request item search model</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the stock request item list model
        /// </returns>
        public async Task<StockRequestItemListModel> PrepareStockRequestItemListModelAsync(StockRequestItemSearchModel searchModel)
        {
            if (searchModel == null)
                throw new ArgumentNullException(nameof(searchModel));

            //get categories
            var stockRequestItem = await _stockRequestItemService.GetAllStockRequestItemsAsync(
                stockRequestId: searchModel.StockRequestId,
                pageIndex: searchModel.Page - 1,
                pageSize: searchModel.PageSize
                );

            //prepare grid model
            var model = await new StockRequestItemListModel().PrepareToGridAsync(searchModel, stockRequestItem, () =>
            {
                return stockRequestItem.SelectAwait(async stockRequestItem =>
                {
                    //fill in model values from the entity
                    var stockRequestItemModel = stockRequestItem.ToModel<StockRequestItemModel>();

                    return stockRequestItemModel;
                });
            });

            return model;
        }

        /// <summary>
        /// Prepare stock request item model
        /// </summary>
        /// <param name="model">stock request item model</param>
        /// <param name="stockRequestItem">StockRequestItem</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the stock request item model
        /// </returns>
        public async Task<StockRequestItemModel> PrepareStockRequestItemModelAsync(StockRequestItemModel model, StockRequestItem stockRequestItem)
        {

            if (stockRequestItem != null)
            {
                //fill in model values from the entity
                if (model == null)
                {
                    model = stockRequestItem.ToModel<StockRequestItemModel>();
                }
            }


            //prepare model fields

            return model;
        }

        #endregion

    }

}
