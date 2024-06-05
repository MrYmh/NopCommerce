using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Core.Caching;
using Nop.Core.Domain.Warehouses;
using Nop.Data;
using Nop.Services.Localization;
using Nop.Services.Warehouses.Interface;

namespace Nop.Services.Warehouses
{
    /// <summary>
    /// AcceptStockRequest service
    /// </summary>
    public class AcceptStockRequestService : IAcceptStockRequestService
    {
        #region Fields

        private readonly ILocalizationService _localizationService;

        private readonly IRepository<AcceptStockRequest> _acceptStockRequestRepository;

        private readonly IStaticCacheManager _staticCacheManager;

        #endregion

        #region Ctor

        public AcceptStockRequestService(
            
            ILocalizationService localizationService,
            IRepository<AcceptStockRequest> acceptStockRequestRepository,
            IStaticCacheManager staticCacheManager
            )
        {
           
            _localizationService = localizationService;
            _acceptStockRequestRepository = acceptStockRequestRepository;
            _staticCacheManager = staticCacheManager;
            
        }

        #endregion

        #region Methods

        /// <summary>
        /// Delete accept Stock Request
        /// </summary>
        /// <param name="acceptStockRequest">AcceptStockRequest</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task DeleteAcceptStockRequestAsync(AcceptStockRequest acceptStockRequest)
        {
            if (acceptStockRequest is null)
                throw new ArgumentNullException(nameof(acceptStockRequest));

            await _acceptStockRequestRepository.DeleteAsync(acceptStockRequest);
        }

        /// <summary>
        /// Delete a list of accept Stock Requests
        /// </summary>
        /// <param name="acceptStockRequests">acceptStockRequests</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task DeleteAcceptStockRequestAsync(IList<AcceptStockRequest> acceptStockRequests)
        {
            if (acceptStockRequests is null)
                throw new ArgumentNullException(nameof(acceptStockRequests));

            await _acceptStockRequestRepository.DeleteAsync(acceptStockRequests);
        }

        /// <summary>
        /// Gets accept Stock Request by identifier
        /// </summary>
        /// <param name="acceptStockRequestId">acceptStockRequest identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the accept Stock Request
        /// </returns>
        public async Task<AcceptStockRequest> GetAcceptStockRequestByIdAsync(int acceptStockRequestId)
        {
            return await _acceptStockRequestRepository.GetByIdAsync(acceptStockRequestId);
        }

        /// <summary>
        /// Get all accept Stock Requests
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the accept Stock Requests
        /// </returns>
        public async Task<IList<AcceptStockRequest>> GetAllAcceptStockRequestsAsync()
        {
            return await _acceptStockRequestRepository.GetAllAsync(query => query.Where(x => x.Deleted != true));
        }

        /// <summary>
        /// Gets accept Stock Request
        /// </summary>
        /// <param name="stockRequestId">stockRequestId</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains a accept Stock Request
        /// </returns>
        public async Task<AcceptStockRequest> GetAllAcceptStockRequestByStockRequestIdAsync(int stockRequestId)
        {
            try
            {
                var request = await _acceptStockRequestRepository.GetAllAsync(query => query.Where(x => x.Deleted != true && x.StockRequestId == stockRequestId));

                return request.FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Get all accepted Stock Requests
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the accepted Stock Requests
        /// </returns>
        public async Task<IList<AcceptStockRequest>> GetAllAcceptedStockRequestsAsync()
        {
            return await _acceptStockRequestRepository.GetAllAsync(query => query.Where(x => x.Deleted != true && x.Accepted == true));
        }

        /// <summary>
        /// Gets all rejected Stock Requests
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the rejected Stock Requests
        /// </returns>
        public async Task<IList<AcceptStockRequest>> GetAllRejectedStockRequestsAsync()
        {
            return await _acceptStockRequestRepository.GetAllAsync(query => query.Where(x => x.Deleted != true && x.Accepted == false));
        }

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
        public async Task<IPagedList<AcceptStockRequest>> GetAllAcceptStockRequestAsync(int warehouseId, string processType = null , string accepted  =null , string requestId = null,  int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var processTypeAsInt = int.TryParse(processType, out int result2) ? result2 : 0;
            var requestIdAsInt = int.TryParse(requestId, out int result) ? result : 0;
            
            var acceptStockRequests = await _acceptStockRequestRepository.GetAllAsync(query =>
            {
                query = query.Where(x => x.Deleted != true && x.WarehouseId == warehouseId);
                if(accepted != null)
                {
                    if (accepted == "1")
                        query = query.Where(x => x.Accepted == true);
                    if (accepted == "2")
                        query = query.Where(x => x.Accepted == false);
                }
                if(processTypeAsInt != 0)
                {
                    query = query.Where(x => x.RequestType == processTypeAsInt);
                }
                if (requestIdAsInt != 0)
                {
                    query = query.Where(x => x.StockRequestId == requestIdAsInt);
                }
               
                

                return query.OrderByDescending(c => c.Id);
            });

            //paging
            return new PagedList<AcceptStockRequest>(acceptStockRequests, pageIndex, pageSize);
        }

        /// <summary>
        /// Get accept stock request by identifiers
        /// </summary>
        /// <param name="acceptStockRequestIds">accept stock request identifiers</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the accept stock request that retrieved by identifiers
        /// </returns>
        public async Task<IList<AcceptStockRequest>> GetAcceptStockRequestByIdsAsync(int[] acceptStockRequestIds)
        {
            return await _acceptStockRequestRepository.GetByIdsAsync(acceptStockRequestIds, includeDeleted: false);
        }

        /// <summary>
        /// Inserts a accept Stock Request
        /// </summary>
        /// <param name="acceptStockRequest">>acceptStockRequest</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task InsertAcceptStockRequestAsync(AcceptStockRequest acceptStockRequest)
        {
            if (acceptStockRequest is null)
                throw new ArgumentNullException(nameof(acceptStockRequest));

            await _acceptStockRequestRepository.InsertAsync(acceptStockRequest);
        }

        /// <summary>
        /// Updates the accept Stock Request 
        /// </summary>
        /// <param name="acceptStockRequest">>acceptStockRequest</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task UpdateAcceptStockRequestAsync(AcceptStockRequest acceptStockRequest)
        {
            if (acceptStockRequest is null)
                throw new ArgumentNullException(nameof(acceptStockRequest));

            await _acceptStockRequestRepository.UpdateAsync(acceptStockRequest);
        }

        #endregion
    }
}