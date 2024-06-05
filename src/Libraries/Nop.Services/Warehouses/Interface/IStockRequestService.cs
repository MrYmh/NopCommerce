using System.Collections.Generic;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Core.Domain.Warehouses;

namespace Nop.Services.Warehouses.Interface
{
    /// <summary>
    /// Stock Request Service Interface
    /// </summary>
    public interface IStockRequestService
    {
        /// <summary>
        /// Delete Stock Request
        /// </summary>
        /// <param name="stockRequest">stockRequest</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task DeleteStockRequestAsync(StockRequest stockRequest);

        /// <summary>
        /// Delete a list of Stock Requests
        /// </summary>
        /// <param name="stockRequests">stockRequests</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task DeleteStockRequestAsync(IList<StockRequest> stockRequests);

        /// <summary>
        /// Gets all Stock Requests
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the Stock Requests
        /// </returns>
        Task<IList<StockRequest>> GetAllStockRequestsAsync();

        /// <summary>
        /// Gets Stock Requests by identifier
        /// </summary>
        /// <param name="stockRequestId">stockRequest identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the Stock Requests
        /// </returns>
        Task<StockRequest> GetStockRequestByIdAsync(int stockRequestId);

        /// <summary>
        /// Gets all stock requests
        /// </summary>
        /// <param name="warehouseId">Warehouse Id</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the stock requests
        /// </returns>
        Task<IPagedList<StockRequest>> GetAllStockRequestsAsync(int warehouseId, int typeOfProcess = 0, int stockRequestId = 0, IEnumerable<int> vendorIds = null, int pageIndex = 0, int pageSize = int.MaxValue);

        /// <summary>
        /// Get stock request by identifiers
        /// </summary>
        /// <param name="stockRequestIds">stock request identifiers</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the stock request that retrieved by identifiers
        /// </returns>
        Task<IList<StockRequest>> GetStockRequestByIdsAsync(int[] stockRequestIds);

        /// <summary>
        /// Inserts a Stock Request
        /// </summary>
        /// <param name="stockRequest">>stockRequest</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task InsertStockRequestAsync(StockRequest stockRequest);

        /// <summary>
        /// Updates a Stock Request
        /// </summary>
        /// <param name="stockRequest">>stockRequest</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task UpdateStockRequestAsync(StockRequest stockRequest);

        //Task<IList<StockRequest>> GetCategoriesByIdsAsync(int[] StockRequestIds);
    }
}