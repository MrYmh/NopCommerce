using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Core.Caching;
using Nop.Core.Domain.Shipping;
using Nop.Core.Domain.Warehouses;
using Nop.Data;
using Nop.Services.Customers;
using Nop.Services.Localization;
using Nop.Services.Security;
using Nop.Services.Stores;
using Nop.Services.Warehouses.Interface;

namespace Nop.Services.Warehouses
{
    /// <summary>
    /// Stock Request Service
    /// </summary>
    public class StockRequestService : IStockRequestService
    {
        #region Fields

        private readonly IAclService _aclService;
        private readonly ICustomerService _customerService;
        private readonly ILocalizationService _localizationService;
        private readonly IRepository<StockRequest> _stockRequestRepository;
        private readonly IStaticCacheManager _staticCacheManager;
        private readonly IStoreContext _storeContext;
        private readonly IStoreMappingService _storeMappingService;
        private readonly IWorkContext _workContext;

        #endregion

        #region Ctor

        public StockRequestService(
            IAclService aclService,
            ICustomerService customerService,
            ILocalizationService localizationService,
            IRepository<StockRequest> stockRequestRepository,
            IStaticCacheManager staticCacheManager,
            IStoreContext storeContext,
            IStoreMappingService storeMappingService,
            IWorkContext workContext)
        {
            _aclService = aclService;
            _customerService = customerService;
            _localizationService = localizationService;
            _stockRequestRepository = stockRequestRepository;
            _staticCacheManager = staticCacheManager;
            _storeContext = storeContext;
            _storeMappingService = storeMappingService;
            _workContext = workContext;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Delete Stock Request
        /// </summary>
        /// <param name="stockRequest">stockRequest</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task DeleteStockRequestAsync(StockRequest stockRequest)
        {
            if (stockRequest is null)
                throw new ArgumentNullException(nameof(stockRequest));

            await _stockRequestRepository.DeleteAsync(stockRequest);
        }

        /// <summary>
        /// Delete a list of Stock Requests
        /// </summary>
        /// <param name="stockRequests">stockRequests</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task DeleteStockRequestAsync(IList<StockRequest> stockRequests)
        {
            if (stockRequests is null)
                throw new ArgumentNullException(nameof(stockRequests));

            await _stockRequestRepository.DeleteAsync(stockRequests);
        }

        /// <summary>
        /// Gets all Stock Requests
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the Stock Requests
        /// </returns>
        public async Task<IList<StockRequest>> GetAllStockRequestsAsync()
        {
            return await _stockRequestRepository.GetAllAsync(query => query.Where(x => !x.Deleted));
        }

        /// <summary>
        /// Gets Stock Requests by identifier
        /// </summary>
        /// <param name="stockRequestId">stockRequest identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the Stock Requests
        /// </returns>
        public async Task<StockRequest> GetStockRequestByIdAsync(int stockRequestId)
        {
            return await _stockRequestRepository.GetByIdAsync(stockRequestId);
        }

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
        public async Task<IPagedList<StockRequest>> GetAllStockRequestsAsync(int warehouseId, int typeOfProcess = 0, int stockRequestId = 0, IEnumerable<int> vendorIds = null, int pageIndex = 0, int pageSize = int.MaxValue)
        {

            var stockRequests = await _stockRequestRepository.GetAllAsync(query =>
            {
                query = query.Where(x => x.WarehouseId == warehouseId && !x.Deleted);

                //check if type of process is null
                if (typeOfProcess != 0)
                    //search by type of process 
                    query = query.Where(x => x.TypeOfProcess == typeOfProcess);

                //check if stock request id is null
                if (stockRequestId != 0)
                    //search by stock request id 
                    query = query.Where(x => x.Id == stockRequestId);

                //check if vendor ids list is null
                if (vendorIds != null && vendorIds.Any())
                    //search by vendor ids
                    query = query.Where(x => vendorIds.Contains(x.VendorId));

                return query.OrderByDescending(c => c.Id);
            });

            //paging
            return new PagedList<StockRequest>(stockRequests, pageIndex, pageSize);
        }

        /// <summary>
        /// Get stock request by identifiers
        /// </summary>
        /// <param name="stockRequestIds">stock request identifiers</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the stock request that retrieved by identifiers
        /// </returns>
        public async Task<IList<StockRequest>> GetStockRequestByIdsAsync(int[] stockRequestIds)
        {
            return await _stockRequestRepository.GetByIdsAsync(stockRequestIds, includeDeleted: false);
        }

        /// <summary>
        /// Inserts a Stock Request
        /// </summary>
        /// <param name="stockRequest">>stockRequest</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task InsertStockRequestAsync(StockRequest stockRequest)
        {
            if (stockRequest is null)
                throw new ArgumentNullException(nameof(stockRequest));

            await _stockRequestRepository.InsertAsync(stockRequest);
        }

        /// <summary>
        /// Updates a Stock Request
        /// </summary>
        /// <param name="stockRequest">>stockRequest</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task UpdateStockRequestAsync(StockRequest stockRequest)
        {
            if (stockRequest is null)
                throw new ArgumentNullException(nameof(stockRequest));

            await _stockRequestRepository.UpdateAsync(stockRequest);
        }

        #endregion
    }
}