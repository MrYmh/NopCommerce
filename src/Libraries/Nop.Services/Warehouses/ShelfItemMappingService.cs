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
    public class ShelfItemMappingService : IShelfItemMappingService
    {
        #region Fields

        private readonly ILocalizationService _localizationService;
        private readonly IRepository<ShelfItemMapping> _shelfItemMappingRepository;
        private readonly IStaticCacheManager _staticCacheManager;

        #endregion

        #region Ctor

        public ShelfItemMappingService(
            ILocalizationService localizationService,
            IRepository<ShelfItemMapping> shelfItemRepository,
            IStaticCacheManager staticCacheManager)
        {
            _localizationService = localizationService;
            _shelfItemMappingRepository = shelfItemRepository;
            _staticCacheManager = staticCacheManager;
        }



        #endregion

        #region Methods

        /// <summary>
        /// Delete shelfItem
        /// </summary>
        /// <param name="shelfItem">shelfItem</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task DeleteShelfItemMappingAsync(ShelfItemMapping shelfItem)
        {
            if (shelfItem is null)
                throw new ArgumentNullException(nameof(shelfItem));

            await _shelfItemMappingRepository.DeleteAsync(shelfItem);
        }

        /// <summary>
        /// Delete a list of shelfItems
        /// </summary>
        /// <param name="shelfItem">shelfItem</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task DeleteShelfItemMappingAsync(IList<ShelfItemMapping> shelfItems)
        {
            if (shelfItems is null)
                throw new ArgumentNullException(nameof(shelfItems));

            await _shelfItemMappingRepository.DeleteAsync(shelfItems);
        }

        ///// <summary>
        ///// Delete a shelfItem
        ///// </summary>
        ///// <param name="itemBarcode">itemBarcode</param>
        ///// <returns>A task that represents the asynchronous operation</returns>
        //public async Task DeleteShelfItemMappingAsync(string itemBarcode)
        //{
        //    if (itemBarcode is null)
        //        throw new ArgumentNullException(nameof(itemBarcode));

        //    var itemId = itemBarcode.Split('-')[1];

        //    if (int.TryParse(itemId, out var id))
        //    {
        //        var shelfItems = await _shelfItemMappingRepository.GetAllAsync(
        //            query => query.Where(i => i.ItemId == id && !i.Deleted)
        //            );

        //        var shelfItem = shelfItems.FirstOrDefault();

        //        await _shelfItemMappingRepository.DeleteAsync(shelfItem);
        //    }
        //}

        /// <summary>
        /// Delete a list of ShelfItems
        /// </summary>
        /// <param name="itemsBarcodes">itemsBarcodes</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task DeleteShelfItemMappingAsync(IList<string> itemsBarcodes)
        {
            if (itemsBarcodes is null)
                throw new ArgumentNullException(nameof(itemsBarcodes));

            var itemsIds = itemsBarcodes.Select(barcode => Convert.ToInt32(barcode.Split('-')[1]));

            var shelfItems = await _shelfItemMappingRepository.GetAllAsync(
                query => query.Where(i => itemsIds.Contains(i.ItemId) && !i.Deleted)
                );

            await _shelfItemMappingRepository.DeleteAsync(shelfItems);
        }

        /// <summary>
        /// Gets all ShelfItemMapping
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the ShelfItemMapping
        /// </returns>
        public async Task<IList<ShelfItemMapping>> GetAllShelfItemMappingAsync()
        {
            return await _shelfItemMappingRepository.GetAllAsync(query => query.Where(i => !i.Deleted));
        }

        /// <summary>
        /// Gets all Items Ids related to a specific shelf
        /// </summary>
        /// <param name="shelfId">shelfId</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the Items Ids
        /// </returns>
        public async Task<IList<int>> GetShelfItemMappingIdsAsync(int shelfId)
        {
            var shelfItems = await _shelfItemMappingRepository.GetAllAsync(
                query => query.Where(i => !i.Deleted && i.ShelfId == shelfId)
                );

            return shelfItems.Select(i => i.ItemId).ToList();
        }

        /// <summary>
        /// Gets all mapped entities related to a specific items ids
        /// </summary>
        /// <param name="itemsIds">itemsIds</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the mapped entities
        /// </returns>
        public async Task<IList<ShelfItemMapping>> GetShelfItemMappingByItemsIdsAsync(IEnumerable<int> itemsIds)
        {
            return await _shelfItemMappingRepository.GetAllAsync(
                query => query.Where(i => !i.Deleted && itemsIds.Contains(i.ItemId))
                );
        }

        /// <summary>
        /// Gets all Accept Stock Requests
        /// </summary>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the accept stock request
        /// </returns>
        public async Task<IPagedList<ShelfItemMapping>> GetAllShelfItemMappingAsync(int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var mappedShelfItems = await _shelfItemMappingRepository.GetAllAsync(query =>
            {
                query = query.Where(x => !x.Deleted);


                return query.OrderBy(c => c.Id);
            });

            //paging
            return new PagedList<ShelfItemMapping>(mappedShelfItems, pageIndex, pageSize);
        }

        /// <summary>
        /// Get shelf item mapping by identifier
        /// </summary>
        /// <param name="shelfItemMappingId">shelf item mapping identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the shelf item mapping
        /// </returns>
        public async Task<ShelfItemMapping> GetShelfItemMappingByIdAsync(int shelfItemMappingId)
        {
            return await _shelfItemMappingRepository.GetByIdAsync(shelfItemMappingId);
        }

        /// <summary>
        /// Get shelf item mapping by identifiers
        /// </summary>
        /// <param name="shelfItemMappingIds">shelf item mapping identifiers</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the shelf item mapping that retrieved by identifiers
        /// </returns>
        public async Task<IList<ShelfItemMapping>> GetShelfItemMappingByIdsAsync(int[] shelfItemMappingIds)
        {
            return await _shelfItemMappingRepository.GetByIdsAsync(shelfItemMappingIds, includeDeleted: false);
        }

        /// <summary>
        /// Inserts a ShelfItemMapping
        /// </summary>
        /// <param name="shelfItem">>shelfItem</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task InsertShelfItemMappingAsync(ShelfItemMapping shelfItem)
        {
            if (shelfItem is null)
                throw new ArgumentNullException(nameof(shelfItem));

            await _shelfItemMappingRepository.InsertAsync(shelfItem);
        }

        /// <summary>
        /// Insert ShelfItemMappings
        /// </summary>
        /// <param name="shelfItems">>shelfItems</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task InsertShelfItemMappingAsync(IList<ShelfItemMapping> shelfItems)
        {
            if (shelfItems is null)
                throw new ArgumentNullException(nameof(shelfItems));

            await _shelfItemMappingRepository.InsertAsync(shelfItems);
        }

        /// <summary>
        /// Updates the ShelfItem
        /// </summary>
        /// <param name="shelfItem">>shelfItem</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task UpdateShelfItemMappingAsync(ShelfItemMapping shelfItem)
        {
            if (shelfItem is null)
                throw new ArgumentNullException(nameof(shelfItem));

            await _shelfItemMappingRepository.UpdateAsync(shelfItem);
        }

        #endregion
    }
}
