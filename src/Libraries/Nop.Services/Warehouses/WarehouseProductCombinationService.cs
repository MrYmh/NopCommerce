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
    public class WarehouseProductCombinationService : IWarehouseProductCombinationService
    {
        #region Fields

        private readonly ILocalizationService _localizationService;
        private readonly IRepository<WarehouseProductCombination> _warehouseProductCombinationRepository;
        private readonly IStaticCacheManager _staticCacheManager;

        #endregion

        #region Ctor

        public WarehouseProductCombinationService(
            ILocalizationService localizationService,
            IRepository<WarehouseProductCombination> warehouseProductCombinationRepository,
            IStaticCacheManager staticCacheManager)
        {
            _localizationService = localizationService;
            _warehouseProductCombinationRepository = warehouseProductCombinationRepository;
            _staticCacheManager = staticCacheManager;
        }



        #endregion

        #region Methods

        /// <summary>
        /// Delete Warehouse Product Combination
        /// </summary>
        /// <param name="warehouseProductCombination">warehouseProductCombination</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task DeleteWarehouseProductCombinationAsync(WarehouseProductCombination warehouseProductCombination)
        {
            if (warehouseProductCombination is null)
                throw new ArgumentNullException(nameof(warehouseProductCombination));

            await _warehouseProductCombinationRepository.DeleteAsync(warehouseProductCombination);
        }

        /// <summary>
        /// Delete a list of Warehouse Product Combinations
        /// </summary>
        /// <param name="warehouseProductCombination">warehouseProductCombination</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task DeleteWarehouseProductCombinationAsync(IList<WarehouseProductCombination> warehouseProductCombinations)
        {
            if (warehouseProductCombinations is null)
                throw new ArgumentNullException(nameof(warehouseProductCombinations));

            await _warehouseProductCombinationRepository.DeleteAsync(warehouseProductCombinations);
        }

        /// <summary>
        /// Gets all Warehouse Product Combinations
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the Warehouse Product Combinations
        /// </returns>
        public async Task<IList<WarehouseProductCombination>> GetAllWarehouseProductCombinationsAsync()
        {
            return await _warehouseProductCombinationRepository.GetAllAsync(query => query.Where(x => !x.Deleted));
        }

        /// <summary>
        /// Gets all available Warehouse Product Combinations
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the available Warehouse Product Combinations
        /// </returns>
        public async Task<IList<WarehouseProductCombination>> GetAllAvailableWarehouseProductCombinationsAsync()
        {
            return await _warehouseProductCombinationRepository.GetAllAsync(query => query.Where(x => !x.Deleted && x.Available));
        }

        /// <summary>
        /// Get warehouse product combinations by warehouse product identifier
        /// </summary>
        /// <param name="warehouseProductId">warehouse product identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the warehouse product combinations
        /// </returns>
        public async Task<IList<WarehouseProductCombination>> GetWarehouseProductCombinationsByWarehouseProductIdAsync(int warehouseProductId)
        {
            return await _warehouseProductCombinationRepository.GetAllAsync(query => query.Where(x => !x.Deleted && x.WarehouseProductId == warehouseProductId));
        }

        /// <summary>
        /// Gets a warehouse product combination by warehouse identifier and sku
        /// </summary>
        /// <param name="warehouseId">warehouse identifier</param>
        /// <param name="sku">sku</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains a warehouse product combination
        /// </returns>
        public async Task<WarehouseProductCombination> GetWarehouseProductCombinationBySkuAsync(int warehouseId, string sku)
        {
            var productCombinations = await _warehouseProductCombinationRepository.GetAllAsync(query => query.Where(x => !x.Deleted && x.Sku.Equals(sku) && x.WarehouseId == warehouseId));
            return productCombinations.FirstOrDefault();
        }

        /// <summary>
        /// Get warehouse product combinations by warehouse product identifiers
        /// </summary>
        /// <param name="warehouseProductsIds">warehouse product identifiers</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the warehouse product combinations
        /// </returns>
        public async Task<IList<WarehouseProductCombination>> GetWarehouseProductCombinationsByWarehouseProductIdAsync(int[] warehouseProductsIds)
        {
            try
            {
                return await _warehouseProductCombinationRepository.GetAllAsync(query => query.Where(x => !x.Deleted && warehouseProductsIds.Contains(x.WarehouseProductId)));
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Gets Warehouse Product Combination by identifier
        /// </summary>
        /// <param name="warehouseProductCombinationId">warehouse Product Combination identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the warehouse Product Combination
        /// </returns>
        public async Task<WarehouseProductCombination> GetWarehouseProductCombinationByIdAsync(int warehouseProductCombinationId)
        {
            return await _warehouseProductCombinationRepository.GetByIdAsync(warehouseProductCombinationId);
        }

        /// <summary>
        /// Gets all warehouse product combinations
        /// </summary>
        /// <param name="warehouseId">Warehouse Id</param>
        /// <param name="warehouseProductId">Warehouse Product Id</param>
        /// <param name="sku">sku</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the warehouse product combinations
        /// </returns>
        public async Task<IPagedList<WarehouseProductCombination>> GetAllWarehouseProductCombinationsAsync(int warehouseId, string sku, int pageIndex = 0, int pageSize = int.MaxValue)
        {
            try
            {
                var warehouseProductCombinations = await _warehouseProductCombinationRepository.GetAllAsync(query =>
                {
                    query = query.Where(x => x.WarehouseId == warehouseId && !x.Deleted);
                    if (!string.IsNullOrWhiteSpace(sku))
                        query = query.Where(x => x.Sku.Contains(sku));

                    return query.OrderBy(x => x.Id);
                });

                return new PagedList<WarehouseProductCombination>(warehouseProductCombinations, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IPagedList<WarehouseProductCombination>> GetAllWarehouseProductCombinationsListAsync(int warehouseId, int pageIndex = 0, int pageSize = int.MaxValue)
        {
            try
            {
                var warehouseProductCombinations = await _warehouseProductCombinationRepository.GetAllAsync(query =>
                    query.Where(x => x.WarehouseId == warehouseId && !x.Deleted).OrderBy(c => c.Id));

                //paging
                return new PagedList<WarehouseProductCombination>(warehouseProductCombinations, pageIndex, pageSize);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Get warehouse product combination by identifiers
        /// </summary>
        /// <param name="warehouseProductCombinationIds">warehouse product combination identifiers</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the warehouse product combination that retrieved by identifiers
        /// </returns>
        public async Task<IList<WarehouseProductCombination>> GetWarehouseProductCombinationByIdsAsync(int[] warehouseProductCombinationIds)
        {
            return await _warehouseProductCombinationRepository.GetByIdsAsync(warehouseProductCombinationIds, includeDeleted: false);
        }

        /// <summary>
        /// Inserts a Warehouse Product Combination
        /// </summary>
        /// <param name="warehouseProductCombination">>warehouseProductCombination</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task InsertWarehouseProductCombinationAsync(WarehouseProductCombination warehouseProductCombination)
        {
            if (warehouseProductCombination is null)
                throw new ArgumentNullException(nameof(warehouseProductCombination));

            await _warehouseProductCombinationRepository.InsertAsync(warehouseProductCombination);
        }

        /// <summary>
        /// Insert warehouse product combinations
        /// </summary>
        /// <param name="warehouseProductCombinations">>warehouseProductCombinations</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task InsertWarehouseProductCombinationAsync(IList<WarehouseProductCombination> warehouseProductCombinations)
        {
            if (warehouseProductCombinations is null)
                throw new ArgumentNullException(nameof(warehouseProductCombinations));

            await _warehouseProductCombinationRepository.InsertAsync(warehouseProductCombinations);
        }

        /// <summary>
        /// Updates the Warehouse Product Combination 
        /// </summary>
        /// <param name="warehouseProductCombination">>warehouseProductCombination</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task UpdateWarehouseProductCombinationAsync(WarehouseProductCombination warehouseProductCombination)
        {
            if (warehouseProductCombination is null)
                throw new ArgumentNullException(nameof(warehouseProductCombination));

            await _warehouseProductCombinationRepository.UpdateAsync(warehouseProductCombination);
        }

        /// <summary>
        /// Update the warehouse product combinations
        /// </summary>
        /// <param name="warehouseProductCombinations">>warehouseProductCombinations</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task UpdateWarehouseProductCombinationAsync(IList<WarehouseProductCombination> warehouseProductCombinations)
        {
            if (warehouseProductCombinations is null)
                throw new ArgumentNullException(nameof(warehouseProductCombinations));

            await _warehouseProductCombinationRepository.UpdateAsync(warehouseProductCombinations);
        }

        #endregion
    }
}
