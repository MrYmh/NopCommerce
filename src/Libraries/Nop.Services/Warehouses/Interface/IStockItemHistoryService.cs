using System.Collections.Generic;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Core.Domain.Warehouses;

namespace Nop.Services.Warehouses.Interface
{
    /// <summary>
    /// Stock Item History Service Interface
    /// </summary>
    public interface IStockItemHistoryService
    {

        /// <summary>
        /// Delete Stock Item History
        /// </summary>
        /// <param name="stockItemHistory">stockItemHistory</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task DeleteStockItemHistoryAsync(StockItemHistory stockItemHistory);

        /// <summary>
        /// Delete a list of Stock Items History
        /// </summary>
        /// <param name="stockItemHistories">stockItemHistories</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task DeleteStockItemHistoryAsync(IList<StockItemHistory> stockItemsHistory);

        /// <summary>
        /// Gets all Stock Items History
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the Stock Items History
        /// </returns>
        Task<IList<StockItemHistory>> GetAllStockItemsHistoryAsync(int stockHistoryId);

        /// <summary>
        /// Gets Stock Item History by identifier
        /// </summary>
        /// <param name="stockItemHistoryId">stockItemHistory identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the Stock Items History
        /// </returns>
        Task<StockItemHistory> GetStockItemHistoryByIdAsync(int stockItemHistoryId);

        /// <summary>
        /// Gets all stock items History
        /// </summary>
        /// <param name="stockHistoryId">Stock History Id</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the stock items History
        /// </returns>
        Task<IPagedList<StockItemHistory>> GetAllStockItemsHistoryAsync(int stockHistoryId, int pageIndex = 0, int pageSize = int.MaxValue);

        /// <summary>
        /// Get stock item history by identifiers
        /// </summary>
        /// <param name="stockItemHistoryIds">stock item history identifiers</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the stock item history that retrieved by identifiers
        /// </returns>
        Task<IList<StockItemHistory>> GetStockItemHistoryByIdsAsync(int[] stockItemHistoryIds);

        /// <summary>
        /// Inserts a Stock Item History
        /// </summary>
        /// <param name="stockItemHistory">>stockItemHistory</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task InsertStockItemHistoryAsync(StockItemHistory stockItemHistory);

        /// <summary>
        /// Insert Stock Item Histories
        /// </summary>
        /// <param name="stockItemHistories">>stockItemHistories</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task InsertStockItemHistoryAsync(IList<StockItemHistory> stockItemHistories);

        /// <summary>
        /// Updates a Stock Item History
        /// </summary>
        /// <param name="stockItemHistory">>stockItemHistory</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task UpdateStockItemHistoryAsync(StockItemHistory stockItemHistory);

        /// <summary>
        /// Update Stock Items History
        /// </summary>
        /// <param name="stockItemsHistory">>stockItemsHistory</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task UpdateStockItemHistoryAsync(IList<StockItemHistory> stockItemsHistory);

        //Task<IList<StockItemHistory>> GetCategoriesByIdsAsync(int[] StockItemHistoryIds);
    }
}