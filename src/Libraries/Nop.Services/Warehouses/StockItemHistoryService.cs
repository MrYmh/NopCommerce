using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Core.Caching;
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
    /// Stock item history mapping service
    /// </summary>
    public class StockItemHistoryMappingService : IStockItemHistoryMappingService
    {
        #region Fields

        private readonly IRepository<StockItemHistoryMapping> _stockItemHistoryMappingRepository;

        #endregion

        #region Ctor

        public StockItemHistoryMappingService(IRepository<StockItemHistoryMapping> stockItemHistoryMappingRepository)
        {
            _stockItemHistoryMappingRepository = stockItemHistoryMappingRepository;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Delete stock item history mapping.
        /// </summary>
        /// <param name="mappedStockItemHistory">mappedStockItemHistory</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task DeleteStockItemHistoryMappingAsync(StockItemHistoryMapping mappedStockItemHistory)
        {
            if (mappedStockItemHistory is null)
                throw new ArgumentNullException(nameof(mappedStockItemHistory));

            await _stockItemHistoryMappingRepository.DeleteAsync(mappedStockItemHistory);
        }

        /// <summary>
        /// Delete a list of stock item history mapping.
        /// </summary>
        /// <param name="mappedStockItemHistories">mappedStockItemHistories</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task DeleteStockItemHistoryMappingAsync(IList<StockItemHistoryMapping> mappedStockItemHistories)
        {
            if (mappedStockItemHistories == null)
                throw new ArgumentNullException(nameof(mappedStockItemHistories));

            await _stockItemHistoryMappingRepository.DeleteAsync(mappedStockItemHistories);
        }

        /// <summary>
        /// Gets all stock item history mapping by warehouse item identifier.
        /// </summary>
        /// <param name="warehouseItemId">warehouseItemId</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains a list of Stock Item History Mapping
        /// </returns>
        public async Task<IList<StockItemHistoryMapping>> GetAllStockItemHistoryMappingByWarehouseItemIdAsync(int warehouseItemId)
        {
            return await _stockItemHistoryMappingRepository.GetAllAsync(query => query.Where(x => !x.Deleted && x.WarehouseItemId == warehouseItemId));
        }

        /// <summary>
        /// Gets stock item history mapping by stock item history identifier.
        /// </summary>
        /// <param name="stockItemHistoryId">stock item history identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the Stock Items History Mapping
        /// </returns>
        public async Task<IList<StockItemHistoryMapping>> GetStockItemHistoryMappingByStockItemHistoryIdAsync(int stockItemHistoryId)
        {
            return await _stockItemHistoryMappingRepository.GetAllAsync(query => query.Where(x => !x.Deleted && x.StockItemHistoryId == stockItemHistoryId));
        }

        /// <summary>
        /// Get stock item history mapping by identifiers
        /// </summary>
        /// <param name="stockItemHistoryIds">stock item history identifiers</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the stock item history that retrieved by identifiers
        /// </returns>
        public async Task<IList<StockItemHistoryMapping>> GetStockItemHistoryMappingByIdsAsync(int[] mappedStockItemHistoryIds)
        {
            return await _stockItemHistoryMappingRepository.GetByIdsAsync(mappedStockItemHistoryIds, includeDeleted: false);
        }

        /// <summary>
        /// Inserts a stock item history mapping
        /// </summary>
        /// <param name="stockItemHistory">>stockItemHistory</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task InsertStockItemHistoryMappingAsync(StockItemHistoryMapping mappedStockItemHistory)
        {
            if (mappedStockItemHistory is null)
                throw new ArgumentNullException(nameof(mappedStockItemHistory));

            await _stockItemHistoryMappingRepository.InsertAsync(mappedStockItemHistory);
        }

        /// <summary>
        /// Insert stock item history mapping
        /// </summary>
        /// <param name="mappedStockItemHistory">>mappedStockItemHistory</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task InsertStockItemHistoryMappingAsync(IList<StockItemHistoryMapping> mappedStockItemHistory)
        {
            if (mappedStockItemHistory is null)
                throw new ArgumentNullException(nameof(mappedStockItemHistory));

            await _stockItemHistoryMappingRepository.InsertAsync(mappedStockItemHistory);
        }

        /// <summary>
        /// Updates a stock item history mapping
        /// </summary>
        /// <param name="mappedStockItemHistory">>mappedStockItemHistory</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task UpdateStockItemHistoryMappingAsync(StockItemHistoryMapping mappedStockItemHistory)
        {
            if (mappedStockItemHistory is null)
                throw new ArgumentNullException(nameof(mappedStockItemHistory));

            await _stockItemHistoryMappingRepository.UpdateAsync(mappedStockItemHistory);
        }

        /// <summary>
        /// Update stock item history mapping
        /// </summary>
        /// <param name="mappedStockItemHistory">>mappedStockItemHistory</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task UpdateStockItemHistoryMappingAsync(IList<StockItemHistoryMapping> mappedStockItemHistory)
        {
            if (mappedStockItemHistory is null)
                throw new ArgumentNullException(nameof(mappedStockItemHistory));

            await _stockItemHistoryMappingRepository.UpdateAsync(mappedStockItemHistory);
        }

        #endregion
    }

    /// <summary>
    /// Stock Item History service
    /// </summary>
    public class StockItemHistoryService : IStockItemHistoryService
    {
        #region Fields

        private readonly IAclService _aclService;
        private readonly ICustomerService _customerService;
        private readonly ILocalizationService _localizationService;
        private readonly IRepository<StockItemHistory> _stockItemHistoryRepository;
        private readonly IStaticCacheManager _staticCacheManager;
        private readonly IStoreContext _storeContext;
        private readonly IStoreMappingService _storeMappingService;
        private readonly IWorkContext _workContext;

        #endregion

        #region Ctor

        public StockItemHistoryService(
            IAclService aclService,
            ICustomerService customerService,
            ILocalizationService localizationService,
            IRepository<StockItemHistory> stockItemHistoryRepository,
            IStaticCacheManager staticCacheManager,
            IStoreContext storeContext,
            IStoreMappingService storeMappingService,
            IWorkContext workContext)
        {
            _aclService = aclService;
            _customerService = customerService;
            _localizationService = localizationService;
            _stockItemHistoryRepository = stockItemHistoryRepository;
            _staticCacheManager = staticCacheManager;
            _storeContext = storeContext;
            _storeMappingService = storeMappingService;
            _workContext = workContext;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Delete Stock Item History
        /// </summary>
        /// <param name="stockItemHistory">stockItemHistory</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task DeleteStockItemHistoryAsync(StockItemHistory stockItemHistory)
        {
            if (stockItemHistory is null)
                throw new ArgumentNullException(nameof(stockItemHistory));

            await _stockItemHistoryRepository.DeleteAsync(stockItemHistory);
        }

        /// <summary>
        /// Delete a list of Stock Items History
        /// </summary>
        /// <param name="stockItemHistories">stockItemHistories</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task DeleteStockItemHistoryAsync(IList<StockItemHistory> stockItemsHistory)
        {
            if (stockItemsHistory is null)
                throw new ArgumentNullException(nameof(stockItemsHistory));

            await _stockItemHistoryRepository.DeleteAsync(stockItemsHistory);
        }

        /// <summary>
        /// Gets all Stock Items History
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the Stock Items History
        /// </returns>
        public async Task<IList<StockItemHistory>> GetAllStockItemsHistoryAsync(int stockHistoryId)
        {
            return await _stockItemHistoryRepository.GetAllAsync(query => query.Where(x => x.StockHistoryId == stockHistoryId && !x.Deleted));
        }

        /// <summary>
        /// Gets Stock Item History by identifier
        /// </summary>
        /// <param name="stockItemHistoryId">stockItemHistory identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the Stock Items History
        /// </returns>
        public async Task<StockItemHistory> GetStockItemHistoryByIdAsync(int stockItemHistoryId)
        {
            return await _stockItemHistoryRepository.GetByIdAsync(stockItemHistoryId);
        }

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
        public async Task<IPagedList<StockItemHistory>> GetAllStockItemsHistoryAsync(int stockHistoryId, int pageIndex = 0, int pageSize = int.MaxValue)
        {

            var stockItemsHistory = await _stockItemHistoryRepository.GetAllAsync(query =>
            {
                query = query.Where(x => x.StockHistoryId == stockHistoryId && !x.Deleted);


                return query.OrderBy(c => c.Id);
            });

            //paging
            return new PagedList<StockItemHistory>(stockItemsHistory, pageIndex, pageSize);
        }

        /// <summary>
        /// Get stock item history by identifiers
        /// </summary>
        /// <param name="stockItemHistoryIds">stock item history identifiers</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the stock item history that retrieved by identifiers
        /// </returns>
        public async Task<IList<StockItemHistory>> GetStockItemHistoryByIdsAsync(int[] stockItemHistoryIds)
        {
            return await _stockItemHistoryRepository.GetByIdsAsync(stockItemHistoryIds, includeDeleted: false);
        }

        /// <summary>
        /// Inserts a Stock Item History
        /// </summary>
        /// <param name="stockItemHistory">>stockItemHistory</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task InsertStockItemHistoryAsync(StockItemHistory stockItemHistory)
        {
            if (stockItemHistory is null)
                throw new ArgumentNullException(nameof(stockItemHistory));

            await _stockItemHistoryRepository.InsertAsync(stockItemHistory);
        }

        /// <summary>
        /// Insert Stock Item Histories
        /// </summary>
        /// <param name="stockItemHistories">>stockItemHistories</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task InsertStockItemHistoryAsync(IList<StockItemHistory> stockItemHistories)
        {
            try
            {
                if (stockItemHistories is null)
                    throw new ArgumentNullException(nameof(stockItemHistories));

                await _stockItemHistoryRepository.InsertAsync(stockItemHistories);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Updates a Stock Item History
        /// </summary>
        /// <param name="stockItemHistory">>stockItemHistory</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task UpdateStockItemHistoryAsync(StockItemHistory stockItemHistory)
        {
            if (stockItemHistory is null)
                throw new ArgumentNullException(nameof(stockItemHistory));

            await _stockItemHistoryRepository.UpdateAsync(stockItemHistory);
        }

        /// <summary>
        /// Update Stock Items History
        /// </summary>
        /// <param name="stockItemsHistory">>stockItemsHistory</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task UpdateStockItemHistoryAsync(IList<StockItemHistory> stockItemsHistory)
        {
            try
            {
                if (stockItemsHistory is null)
                    throw new ArgumentNullException(nameof(stockItemsHistory));

                await _stockItemHistoryRepository.UpdateAsync(stockItemsHistory);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        #endregion
    }
}