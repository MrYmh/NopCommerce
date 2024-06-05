using System.Collections.Generic;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Core.Domain.Warehouses;

namespace Nop.Services.Warehouses.Interface
{
    /// <summary>
    /// Accept Stock Request service interface
    /// </summary>
    public interface IAcceptStockRequestService
    {
        /// <summary>
        /// Delete accept Stock Request
        /// </summary>
        /// <param name="acceptStockRequest">AcceptStockRequest</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task DeleteAcceptStockRequestAsync(AcceptStockRequest acceptStockRequest);

        /// <summary>
        /// Delete a list of accept Stock Requests
        /// </summary>
        /// <param name="acceptStockRequests">acceptStockRequests</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task DeleteAcceptStockRequestAsync(IList<AcceptStockRequest> acceptStockRequests);

        /// <summary>
        /// Gets all accept Stock Requests
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the accept Stock Requests
        /// </returns>
        Task<IList<AcceptStockRequest>> GetAllAcceptStockRequestsAsync();

        /// <summary>
        /// Gets accept Stock Request
        /// </summary>
        /// <param name="stockRequestId">stockRequestId</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains a accept Stock Request
        /// </returns>
        Task<AcceptStockRequest> GetAllAcceptStockRequestByStockRequestIdAsync(int stockRequestId);

        /// <summary>
        /// Gets all accepted Stock Requests
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the accepted Stock Requests
        /// </returns>
        Task<IList<AcceptStockRequest>> GetAllAcceptedStockRequestsAsync();

        /// <summary>
        /// Gets all rejected Stock Requests
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the rejected Stock Requests
        /// </returns>
        Task<IList<AcceptStockRequest>> GetAllRejectedStockRequestsAsync();

        /// <summary>
        /// Gets accept Stock Request by identifier
        /// </summary>
        /// <param name="acceptStockRequestId">acceptStockRequest identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the accept Stock Request
        /// </returns>
        Task<AcceptStockRequest> GetAcceptStockRequestByIdAsync(int acceptStockRequestId);

        /// <summary>
        /// Gets all Accept Stock Requests
        /// </summary>
        /// <param name="warehouseId">warehouse id</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the accept stock request
        /// </returns>
        Task<IPagedList<AcceptStockRequest>> GetAllAcceptStockRequestAsync(int warehouseId, string processType = null, string accepted = null , string requestId = null , int pageIndex = 0, int pageSize = int.MaxValue);

        /// <summary>
        /// Get accept stock request by identifiers
        /// </summary>
        /// <param name="acceptStockRequestIds">accept stock request identifiers</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the accept stock request that retrieved by identifiers
        /// </returns>
        Task<IList<AcceptStockRequest>> GetAcceptStockRequestByIdsAsync(int[] acceptStockRequestIds);

        /// <summary>
        /// Inserts a accept Stock Request
        /// </summary>
        /// <param name="acceptStockRequest">>acceptStockRequest</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task InsertAcceptStockRequestAsync(AcceptStockRequest acceptStockRequest);

        /// <summary>
        /// Updates the accept Stock Request 
        /// </summary>
        /// <param name="acceptStockRequest">>acceptStockRequest</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task UpdateAcceptStockRequestAsync(AcceptStockRequest acceptStockRequest);

    }
}