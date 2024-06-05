using System.Collections.Generic;
using System.Threading.Tasks;
using Nop.Core.Domain.Warehouses;

namespace Nop.Services.Warehouses.Interface
{
    /// <summary>
    /// Stock item history mapping service interface.
    /// </summary>
    public interface IStockItemHistoryMappingService
    {

        /// <summary>
        /// Delete stock item history mapping.
        /// </summary>
        /// <param name="mappedStockItemHistory">mappedStockItemHistory</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task DeleteStockItemHistoryMappingAsync(StockItemHistoryMapping mappedStockItemHistory);

        /// <summary>
        /// Delete a list of stock item history mapping.
        /// </summary>
        /// <param name="mappedStockItemHistories">mappedStockItemHistories</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task DeleteStockItemHistoryMappingAsync(IList<StockItemHistoryMapping> mappedStockItemHistories);

        /// <summary>
        /// Gets all stock item history mapping by warehouse item identifier.
        /// </summary>
        /// <param name="warehouseItemId">warehouseItemId</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains a list of Stock Item History Mapping
        /// </returns>
        Task<IList<StockItemHistoryMapping>> GetAllStockItemHistoryMappingByWarehouseItemIdAsync(int warehouseItemId);

        /// <summary>
        /// Gets stock item history mapping by stock item history identifier.
        /// </summary>
        /// <param name="stockItemHistoryId">stock item history identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the Stock Items History Mapping
        /// </returns>
        Task<IList<StockItemHistoryMapping>> GetStockItemHistoryMappingByStockItemHistoryIdAsync(int stockItemHistoryId);

        /// <summary>
        /// Get stock item history mapping by identifiers
        /// </summary>
        /// <param name="stockItemHistoryIds">stock item history identifiers</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the stock item history that retrieved by identifiers
        /// </returns>
        Task<IList<StockItemHistoryMapping>> GetStockItemHistoryMappingByIdsAsync(int[] mappedStockItemHistoryIds);

        /// <summary>
        /// Inserts a stock item history mapping
        /// </summary>
        /// <param name="stockItemHistory">>stockItemHistory</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task InsertStockItemHistoryMappingAsync(StockItemHistoryMapping mappedStockItemHistory);

        /// <summary>
        /// Insert stock item history mapping
        /// </summary>
        /// <param name="mappedStockItemHistory">>mappedStockItemHistory</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task InsertStockItemHistoryMappingAsync(IList<StockItemHistoryMapping> mappedStockItemHistory);

        /// <summary>
        /// Updates a stock item history mapping
        /// </summary>
        /// <param name="mappedStockItemHistory">>mappedStockItemHistory</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task UpdateStockItemHistoryMappingAsync(StockItemHistoryMapping mappedStockItemHistory);

        /// <summary>
        /// Update stock item history mapping
        /// </summary>
        /// <param name="mappedStockItemHistory">>mappedStockItemHistory</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task UpdateStockItemHistoryMappingAsync(IList<StockItemHistoryMapping> mappedStockItemHistory);

    }
}