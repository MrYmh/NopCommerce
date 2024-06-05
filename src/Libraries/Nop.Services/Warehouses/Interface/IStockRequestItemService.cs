using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Core.Domain.Warehouses;

namespace Nop.Services.Warehouses.Interface
{
    /// <summary>
    /// Stock Request Item Service Interface
    /// </summary>
    public interface IStockRequestItemService
    {
        /// <summary>
        /// Delete Stock Request Item
        /// </summary>
        /// <param name="stockRequestItem">stockRequestItem</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task DeleteStockRequestItemAsync(StockRequestItem stockRequestItem);

        /// <summary>
        /// Delete a list of Stock Request Items
        /// </summary>
        /// <param name="stockRequestItems">stockRequestItems</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task DeleteStockRequestItemAsync(IList<StockRequestItem> stockRequestItems);

        /// <summary>
        /// Gets all Stock Request Items
        /// </summary>
        /// <param name="stockRequestId">stockRequestId</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the Stock Request Items
        /// </returns>
        Task<IList<StockRequestItem>> GetAllStockRequestItemsAsync(int stockRequestId);

        /// <summary>
        /// Gets Stock Request Item by identifier
        /// </summary>
        /// <param name="stockRequestItemId">stockRequestItem identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the Stock Request Item
        /// </returns>
        Task<StockRequestItem> GetStockRequestItemByIdAsync(int stockRequestItemId);

        /// <summary>
        /// Gets all stock request items
        /// </summary>
        /// <param name="stockRequestId">Stock Request Id</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the stock request items
        /// </returns>
        Task<IPagedList<StockRequestItem>> GetAllStockRequestItemsAsync(int stockRequestId, int pageIndex = 0, int pageSize = int.MaxValue);

        /// <summary>
        /// Get stock request item by identifiers
        /// </summary>
        /// <param name="stockRequestItemIds">stock request item identifiers</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the stock request item that retrieved by identifiers
        /// </returns>
        Task<IList<StockRequestItem>> GetStockRequestItemByIdsAsync(int[] stockRequestItemIds);

        /// <summary>
        /// Inserts a Stock Request Item
        /// </summary>
        /// <param name="stockRequestItem">>stockRequestItem</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task InsertStockRequestItemAsync(StockRequestItem stockRequestItem);

        /// <summary>
        /// Insert Stock Request Items
        /// </summary>
        /// <param name="stockRequestItems">>stockRequestItems</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task InsertStockRequestItemAsync(IList<StockRequestItem> stockRequestItems);

        /// <summary>
        /// Updates the Stock Request Item 
        /// </summary>
        /// <param name="stockRequestItem">>stockRequestItem</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task UpdateStockRequestItemAsync(StockRequestItem stockRequestItem);

        /// <summary>
        /// Updates the Stock Request Items
        /// </summary>
        /// <param name="stockRequestItems">>stockRequestItems</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task UpdateStockRequestItemAsync(IList<StockRequestItem> stockRequestItems);


    }
}