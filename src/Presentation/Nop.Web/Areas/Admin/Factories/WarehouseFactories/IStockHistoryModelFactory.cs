
using System.Threading.Tasks;
using Nop.Core.Domain.Warehouses;
using Nop.Web.Areas.Admin.Models.Warehouses;

namespace Nop.Web.Areas.Admin.Factories.WarehouseFactories
{
    /// <summary>
    /// Represents the stock history model factory
    /// </summary>
    public interface IStockHistoryModelFactory
    {

        /// <summary>
        /// Prepare stock history search model
        /// </summary>
        /// <param name="searchModel">stock history search model</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the stock history search model
        /// </returns>
        StockHistorySearchModel PrepareStockHistorySearchModelAsync(StockHistorySearchModel searchModel);

        /// <summary>
        /// Prepare paged stock history list model
        /// </summary>
        /// <param name="searchModel">stock history search model</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the stock history list model
        /// </returns>
        Task<StockHistoryListModel> PrepareStockHistoryListModelAsync(StockHistorySearchModel searchModel);

        /// <summary>
        /// Prepare stock history model
        /// </summary>
        /// <param name="model">stock history model</param>
        /// <param name="stockHistory">StockHistory</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the stock history model
        /// </returns>
        Task<StockHistoryModel> PrepareStockHistoryModelAsync(StockHistoryModel model, StockHistory stockHistory);

    }

}
