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
    public class ShelfService : IShelfService
    {
        #region Fields

        private readonly ILocalizationService _localizationService;
        private readonly IRepository<Shelf> _shelfRepository;
        private readonly IStaticCacheManager _staticCacheManager;

        #endregion

        #region Ctor

        public ShelfService(
            ILocalizationService localizationService,
            IRepository<Shelf> shelfRepository,
            IStaticCacheManager staticCacheManager)
        {
            _localizationService = localizationService;
            _shelfRepository = shelfRepository;
            _staticCacheManager = staticCacheManager;
        }



        #endregion

        #region Methods

        /// <summary>
        /// Delete Shelf
        /// </summary>
        /// <param name="shelf">Shelf</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task DeleteShelfAsync(Shelf shelf)
        {
            if (shelf is null)
                throw new ArgumentNullException(nameof(shelf));

            await _shelfRepository.DeleteAsync(shelf);
        }

        /// <summary>
        /// Delete a list of Shelves
        /// </summary>
        /// <param name="Shelves">Shelves</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task DeleteShelfAsync(IList<Shelf> shelves)
        {
            if (shelves is null)
                throw new ArgumentNullException(nameof(shelves));

            await _shelfRepository.DeleteAsync(shelves);
        }

        /// <summary>
        /// Gets all Warehouse Shelves
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the Shelves
        /// </returns>
        public async Task<IList<Shelf>> GetAllShelvesAsync()
        {
            return await _shelfRepository.GetAllAsync(query => query.Where(x => !x.Deleted));
        }

        /// <summary>
        /// Gets all Shelves of specific stand
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the Shelves of specific stand
        /// </returns>
        public async Task<IList<Shelf>> GetStandShelvesAsync(int standId)
        {
            return await _shelfRepository.GetAllAsync(query => query.Where(x => !x.Deleted && x.StandId == standId));
        }

        /// <summary>
        /// Gets specific number of Shelves of specific stand
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains specific number of Shelves of specific stand
        /// </returns>
        public async Task<IList<Shelf>> GetShelvesSubsetForStandAsync(int standId, int noOfShelves)
        {
            return await _shelfRepository.GetAllAsync(query => query.Where(x => !x.Deleted && x.StandId == standId).Take(noOfShelves));
        }

        /// <summary>
        /// Gets all active Shelves
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the active Shelves
        /// </returns>
        public async Task<IList<Shelf>> GetAllActiveShelvesAsync()
        {
            return await _shelfRepository.GetAllAsync(query => query.Where(x => x.Active && !x.Deleted));
        }

        /// <summary>
        /// Gets Shelf by identifier
        /// </summary>
        /// <param name="shelf">Shelf identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the Shelf
        /// </returns>
        public async Task<Shelf> GetShelfByIdAsync(int shelf)
        {
            return await _shelfRepository.GetByIdAsync(shelf);
        }

        /// <summary>
        /// Gets all shelves
        /// </summary>
        /// <param name="standId">Stand Id</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the shelves
        /// </returns>
        public async Task<IPagedList<Shelf>> GetAllShelvesAsync(int warehouseId, int standId, string barcode, int pageIndex = 0, int pageSize = int.MaxValue)
        {

            var shelves = await _shelfRepository.GetAllAsync(query =>
            {
                query = query.Where(x => x.WarehouseId == warehouseId && !x.Deleted);

                if (standId >= 1)
                    query = query.Where(x => x.StandId == standId);

                if (!string.IsNullOrWhiteSpace(barcode))
                    query = query.Where(x => x.Barcode.Contains(barcode));
                
                return query.OrderBy(c => c.Id);
            });

            //paging
            return new PagedList<Shelf>(shelves, pageIndex, pageSize);
        }

        /// <summary>
        /// Get shelf by identifiers
        /// </summary>
        /// <param name="shelfIds">shelf identifiers</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the shelf that retrieved by identifiers
        /// </returns>
        public async Task<IList<Shelf>> GetShelfByIdsAsync(int[] shelfIds)
        {
            return await _shelfRepository.GetByIdsAsync(shelfIds, includeDeleted: false);
        }

        /// <summary>
        /// Gets a shelf by barcode
        /// </summary>
        /// <param name="barcode">barcode</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains a shelf
        /// </returns>
        public async Task<Shelf> GetShelfByBarcodeAsync(string barcode)
        {
            if (barcode != null)
            {
                var shelf = barcode.Split('-')[1];

                var shelfId = shelf[2..]; // cut 'SH' from the shelf id in the barcode.

                if (int.TryParse(shelfId, out var id))
                    return await _shelfRepository.GetByIdAsync(id);
            }

            return null;
        }

        /// <summary>
        /// Get shelves by stands identifiers
        /// </summary>
        /// <param name="standsIds">stands identifiers</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the shelves that retrieved by stands identifiers
        /// </returns>
        public async Task<IList<Shelf>> GetShelvesByStandsIdsAsync(int[] standsIds)
        {
            return await _shelfRepository.GetAllAsync(query => query.Where(x => !x.Deleted && standsIds.Contains(x.StandId)));
        }

        /// <summary>
        /// Inserts a Shelf
        /// </summary>
        /// <param name="shelf">>Shelf</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task InsertShelfAsync(Shelf shelf)
        {
            if (shelf is null)
                throw new ArgumentNullException(nameof(shelf));

            await _shelfRepository.InsertAsync(shelf);
        }

        /// <summary>
        /// Insert Shelves
        /// </summary>
        /// <param name="shelves">>shelves</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task InsertShelfAsync(IList<Shelf> shelves)
        {
            if (shelves is null)
                throw new ArgumentNullException(nameof(shelves));

            await _shelfRepository.InsertAsync(shelves);
        }

        /// <summary>
        /// Updates the Shelf 
        /// </summary>
        /// <param name="shelf">>Shelf</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task UpdateShelfAsync(Shelf shelf)
        {
            if (shelf is null)
                throw new ArgumentNullException(nameof(shelf));

            await _shelfRepository.UpdateAsync(shelf);
        }

        /// <summary>
        /// Updates the Shelves
        /// </summary>
        /// <param name="shelves">>shelves</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task UpdateShelfAsync(IList<Shelf> shelves)
        {
            if (shelves is null)
                throw new ArgumentNullException(nameof(shelves));

            await _shelfRepository.UpdateAsync(shelves);
        }

        #endregion
    }
}
