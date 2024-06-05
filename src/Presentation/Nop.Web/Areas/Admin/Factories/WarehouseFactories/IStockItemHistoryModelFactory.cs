
using System.Threading.Tasks;
using Nop.Core.Domain.Warehouses;
using Nop.Web.Areas.Admin.Models.Warehouses;

namespace Nop.Web.Areas.Admin.Factories.WarehouseFactories
{
    /// <summary>
    /// Represents the stock item history model factory
    /// </summary>
    public interface IStockItemHistoryModelFactory
    {

        /// <summary>
        /// Prepare stock item history search model
        /// </summary>
        /// <param name="searchModel">stock item history search model</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the stock item history search model
        /// </returns>
        StockItemHistorySearchModel PrepareStockItemHistorySearchModelAsync(StockItemHistorySearchModel searchModel);

        /// <summary>
        /// Prepare paged stock item history list model
        /// </summary>
        /// <param name="searchModel">stock item history search model</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the stock item history list model
        /// </returns>
        Task<StockItemHistoryListModel> PrepareStockItemHistoryListModelAsync(StockItemHistorySearchModel searchModel);

        /// <summary>
        /// Prepare stock item history model
        /// </summary>
        /// <param name="model">stock item history model</param>
        /// <param name="stockItemHistory">StockItemHistory</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the stock item history model
        /// </returns>
        Task<StockItemHistoryModel> PrepareStockItemHistoryModelAsync(StockItemHistoryModel model, StockItemHistory stockItemHistory);

    }

}
