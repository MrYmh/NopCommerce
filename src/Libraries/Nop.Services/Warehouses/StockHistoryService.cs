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
    /// StockHistory service
    /// </summary>
    public class StockHistoryService : IStockHistoryService
    {
        #region Fields

        private readonly IAclService _aclService;
        private readonly ICustomerService _customerService;
        private readonly ILocalizationService _localizationService;
        private readonly IRepository<StockHistory> _stockHistoryRepository;
        private readonly IStaticCacheManager _staticCacheManager;
        private readonly IStoreContext _storeContext;
        private readonly IStoreMappingService _storeMappingService;
        private readonly IWorkContext _workContext;

        #endregion

        #region Ctor

        public StockHistoryService(
            IAclService aclService,
            ICustomerService customerService,
            ILocalizationService localizationService,
            IRepository<StockHistory> stockHistoryRepository,
            IStaticCacheManager staticCacheManager,
            IStoreContext storeContext,
            IStoreMappingService storeMappingService,
            IWorkContext workContext)
        {
            _aclService = aclService;
            _customerService = customerService;
            _localizationService = localizationService;
            _stockHistoryRepository = stockHistoryRepository;
            _staticCacheManager = staticCacheManager;
            _storeContext = storeContext;
            _storeMappingService = storeMappingService;
            _workContext = workContext;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Delete Stock History
        /// </summary>
        /// <param name="stockHistory">stockHistory</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task DeleteStockHistoryAsync(StockHistory stockHistory)
        {
            if (stockHistory is null)
                throw new ArgumentNullException(nameof(stockHistory));

            await _stockHistoryRepository.DeleteAsync(stockHistory);
        }

        /// <summary>
        /// Delete a list of Stock Histories
        /// </summary>
        /// <param name="stockHistories">stockHistories</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task DeleteStockHistoryAsync(IList<StockHistory> stockHistories)
        {
            if (stockHistories == null)
                throw new ArgumentNullException(nameof(stockHistories));

            await _stockHistoryRepository.DeleteAsync(stockHistories);
        }

        /// <summary>
        /// Gets all Stock Histories
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the Stock Histories
        /// </returns>
        public async Task<IList<StockHistory>> GetAllStockHistoriesAsync()
        {
            return await _stockHistoryRepository.GetAllAsync(query => query.Where(x => !x.Deleted));
        }

        /// <summary>
        /// Gets Stock History by identifier
        /// </summary>
        /// <param name="stockHistoryId">stockHistory identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the Stock History
        /// </returns>
        public async Task<StockHistory> GetStockHistoryByIdAsync(int stockHistoryId)
        {
            return await _stockHistoryRepository.GetByIdAsync(stockHistoryId);
        }

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
        public async Task<IPagedList<StockHistory>> GetAllStockHistoryAsync(int warehouseId,int typeOfProcess = 0, int stockRequestId = 0 , IEnumerable<int> vendorIds = null , int pageIndex = 0, int pageSize = int.MaxValue)
        {

            try
            {
                var stockHistories = await _stockHistoryRepository.GetAllAsync(query =>
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

                    return query.OrderBy(c => c.Id);
                });

                //paging
                return new PagedList<StockHistory>(stockHistories, pageIndex, pageSize);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Get stock history by identifiers
        /// </summary>
        /// <param name="stockHistoryIds">stock history identifiers</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the stock history that retrieved by identifiers
        /// </returns>
        public async Task<IList<StockHistory>> GetStockHistoryByIdsAsync(int[] stockHistoryIds)
        {
            return await _stockHistoryRepository.GetByIdsAsync(stockHistoryIds, includeDeleted: false);
        }

        /// <summary>
        /// Inserts a Stock History
        /// </summary>
        /// <param name="stockHistory">>stockHistory</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task InsertStockHistoryAsync(StockHistory stockHistory)
        {
            if (stockHistory is null)
                throw new ArgumentNullException(nameof(stockHistory));

            await _stockHistoryRepository.InsertAsync(stockHistory);
        }

        /// <summary>
        /// Updates a Stock History 
        /// </summary>
        /// <param name="stockHistory">>stockHistory</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task UpdateStockHistoryAsync(StockHistory stockHistory)
        {
            if (stockHistory is null)
                throw new ArgumentNullException(nameof(stockHistory));

            await _stockHistoryRepository.UpdateAsync(stockHistory);
        }

        #endregion
    }
}