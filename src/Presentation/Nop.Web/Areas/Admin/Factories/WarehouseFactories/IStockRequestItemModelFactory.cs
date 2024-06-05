
using System.Threading.Tasks;
using Nop.Core.Domain.Warehouses;
using Nop.Web.Areas.Admin.Models.Warehouses;

namespace Nop.Web.Areas.Admin.Factories.WarehouseFactories
{
    /// <summary>
    /// Represents the stock request item model factory
    /// </summary>
    public interface IStockRequestItemModelFactory
    {

        /// <summary>
        /// Prepare stock request item search model
        /// </summary>
        /// <param name="searchModel">stock request item search model</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the stock request item search model
        /// </returns>
        StockRequestItemSearchModel PrepareStockRequestItemSearchModelAsync(StockRequestItemSearchModel searchModel);

        /// <summary>
        /// Prepare paged stock request item list model
        /// </summary>
        /// <param name="searchModel">stock request item search model</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the stock request item list model
        /// </returns>
        Task<StockRequestItemListModel> PrepareStockRequestItemListModelAsync(StockRequestItemSearchModel searchModel);

        /// <summary>
        /// Prepare stock request item model
        /// </summary>
        /// <param name="model">stock request item model</param>
        /// <param name="stockRequestItem">StockRequestItem</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the stock request item model
        /// </returns>
        Task<StockRequestItemModel> PrepareStockRequestItemModelAsync(StockRequestItemModel model, StockRequestItem stockRequestItem);

    }

}
