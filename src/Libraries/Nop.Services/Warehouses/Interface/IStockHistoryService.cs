using System.Collections.Generic;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Core.Domain.Warehouses;

namespace Nop.Services.Warehouses.Interface
{
    /// <summary>
    /// Stock History Service Interface
    /// </summary>
    public interface IStockHistoryService
    {

        /// <summary>
        /// Delete Stock History
        /// </summary>
        /// <param name="stockHistory">stockHistory</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task DeleteStockHistoryAsync(StockHistory stockHistory);

        /// <summary>
        /// Delete a list of Stock Histories
        /// </summary>
        /// <param name="stockHistories">stockHistories</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task DeleteStockHistoryAsync(IList<StockHistory> stockHistories);

        /// <summary>
        /// Gets all Stock Histories
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the Stock Histories
        /// </returns>
        Task<IList<StockHistory>> GetAllStockHistoriesAsync();

        /// <summary>
        /// Gets Stock History by identifier
        /// </summary>
        /// <param name="stockHistoryId">stockHistory identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the Stock History
        /// </returns>
        Task<StockHistory> GetStockHistoryByIdAsync(int stockHistoryId);

        /// <summary>
        /// Gets all stock items History
        /// </summary>
        /// <param name="warehouseId">Warehouse Id</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the stock items History
        /// </returns>
        Task<IPagedList<StockHistory>> GetAllStockHistoryAsync(int warehouseId, int typeOfProcess = 0, int stockRequestId = 0, IEnumerable<int> vendorIds = null, int pageIndex = 0, int pageSize = int.MaxValue);

        /// <summary>
        /// Get stock history by identifiers
        /// </summary>
        /// <param name="stockHistoryIds">stock history identifiers</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the stock history that retrieved by identifiers
        /// </returns>
        Task<IList<StockHistory>> GetStockHistoryByIdsAsync(int[] stockHistoryIds);

        /// <summary>
        /// Inserts a Stock History
        /// </summary>
        /// <param name="stockHistory">>stockHistory</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task InsertStockHistoryAsync(StockHistory stockHistory);

        /// <summary>
        /// Updates a Stock History 
        /// </summary>
        /// <param name="stockHistory">>stockHistory</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task UpdateStockHistoryAsync(StockHistory stockHistory);

        //Task<IList<StockHistory>> GetCategoriesByIdsAsync(int[] stockHistoryIds);
    }
}