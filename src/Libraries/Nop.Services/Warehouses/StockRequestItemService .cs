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
    /// Stock Request Item Service
    /// </summary>
    public class StockRequestItemService : IStockRequestItemService
    {
        #region Fields

        private readonly IAclService _aclService;
        private readonly ICustomerService _customerService;
        private readonly ILocalizationService _localizationService;
        private readonly IRepository<StockRequestItem> _stockRequestItemRepository;
        private readonly IStaticCacheManager _staticCacheManager;
        private readonly IStoreContext _storeContext;
        private readonly IStoreMappingService _storeMappingService;
        private readonly IWorkContext _workContext;

        #endregion

        #region Ctor
        public StockRequestItemService(
            IAclService aclService,
            ICustomerService customerService,
            ILocalizationService localizationService,
            IRepository<StockRequestItem> stockRequestItemRepository,
            IStaticCacheManager staticCacheManager,
            IStoreContext storeContext,
            IStoreMappingService storeMappingService,
            IWorkContext workContext)
        {
            _aclService = aclService;
            _customerService = customerService;
            _localizationService = localizationService;
            _stockRequestItemRepository = stockRequestItemRepository;
            _staticCacheManager = staticCacheManager;
            _storeContext = storeContext;
            _storeMappingService = storeMappingService;
            _workContext = workContext;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Delete Stock Request Item
        /// </summary>
        /// <param name="stockRequestItem">stockRequestItem</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task DeleteStockRequestItemAsync(StockRequestItem stockRequestItem)
        {
            if (stockRequestItem is null)
                throw new ArgumentNullException(nameof(stockRequestItem));

            await _stockRequestItemRepository.DeleteAsync(stockRequestItem);
        }

        /// <summary>
        /// Delete a list of Stock Request Items
        /// </summary>
        /// <param name="stockRequestItems">stockRequestItems</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task DeleteStockRequestItemAsync(IList<StockRequestItem> stockRequestItems)
        {
            if (stockRequestItems == null)
                throw new ArgumentNullException(nameof(stockRequestItems));

            await _stockRequestItemRepository.DeleteAsync(stockRequestItems);
        }

        /// <summary>
        /// Gets all Stock Request Items
        /// </summary>
        /// <param name="stockRequestId">stockRequestId</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the Stock Request Items
        /// </returns>
        public async Task<IList<StockRequestItem>> GetAllStockRequestItemsAsync(int stockRequestId)
        {
            return await _stockRequestItemRepository.GetAllAsync(query => query.Where(x => x.Deleted != true && x.StockRequestId == stockRequestId));
        }

        /// <summary>
        /// Gets Stock Request Item by identifier
        /// </summary>
        /// <param name="stockRequestItemId">stockRequestItem identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the Stock Request Item
        /// </returns>
        public async Task<StockRequestItem> GetStockRequestItemByIdAsync(int stockRequestItemId)
        {
            return await _stockRequestItemRepository.GetByIdAsync(stockRequestItemId, cache => default);
        }

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
        public async Task<IPagedList<StockRequestItem>> GetAllStockRequestItemsAsync(int stockRequestId, int pageIndex = 0, int pageSize = int.MaxValue)
        {

            var stockRequestItems = await _stockRequestItemRepository.GetAllAsync(query =>
            {
                query = query.Where(x => x.StockRequestId == stockRequestId && x.Deleted != true);


                return query.OrderBy(c => c.Id);
            });

            //paging
            return new PagedList<StockRequestItem>(stockRequestItems, pageIndex, pageSize);
        }

        /// <summary>
        /// Get stock request item by identifiers
        /// </summary>
        /// <param name="stockRequestItemIds">stock request item identifiers</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the stock request item that retrieved by identifiers
        /// </returns>
        public async Task<IList<StockRequestItem>> GetStockRequestItemByIdsAsync(int[] stockRequestItemIds)
        {
            return await _stockRequestItemRepository.GetByIdsAsync(stockRequestItemIds, includeDeleted: false);
        }

        /// <summary>
        /// Inserts a Stock Request Item
        /// </summary>
        /// <param name="stockRequestItem">>stockRequestItem</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task InsertStockRequestItemAsync(StockRequestItem stockRequestItem)
        {
            if (stockRequestItem is null)
                throw new ArgumentNullException(nameof(stockRequestItem));

            await _stockRequestItemRepository.InsertAsync(stockRequestItem);
        }

        /// <summary>
        /// Insert Stock Request Items
        /// </summary>
        /// <param name="stockRequestItems">>stockRequestItems</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task InsertStockRequestItemAsync(IList<StockRequestItem> stockRequestItems)
        {
            try
            {
                if (stockRequestItems is null)
                    throw new ArgumentNullException(nameof(stockRequestItems));

                await _stockRequestItemRepository.InsertAsync(stockRequestItems);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Updates the Stock Request Item 
        /// </summary
        /// <param name="stockRequestItem">>stockRequestItem</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task UpdateStockRequestItemAsync(StockRequestItem stockRequestItem)
        {
            if (stockRequestItem is null)
                throw new ArgumentNullException(nameof(stockRequestItem));

            await _stockRequestItemRepository.UpdateAsync(stockRequestItem);
        }

        /// <summary>
        /// Updates the Stock Request Items
        /// </summary>
        /// <param name="stockRequestItems">>stockRequestItems</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task UpdateStockRequestItemAsync(IList<StockRequestItem> stockRequestItems)
        {
            if (stockRequestItems is null)
                throw new ArgumentNullException(nameof(stockRequestItems));

            await _stockRequestItemRepository.UpdateAsync(stockRequestItems);
        }

        #endregion
    }
}