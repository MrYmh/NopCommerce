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
using Nop.Services.Warehouses.Interface;

namespace Nop.Services.Warehouses
{
    public class WarehouseStandService : IWarehouseStandService
    {
        #region Fields

        private readonly IAclService _aclService;
        private readonly ICustomerService _customerService;
        private readonly ILocalizationService _localizationService;
        private readonly IRepository<WarehouseStand> _warehouseStandRepository;
        private readonly IStaticCacheManager _staticCacheManager;
        private readonly IWorkContext _workContext;

        #endregion

        #region Ctor

        public WarehouseStandService(
            IAclService aclService,
            ICustomerService customerService,
            ILocalizationService localizationService,
            IRepository<WarehouseStand> warehouseStandRepository,
            IStaticCacheManager staticCacheManager,
            IWorkContext workContext)
        {
            _aclService = aclService;
            _customerService = customerService;
            _localizationService = localizationService;
            _warehouseStandRepository = warehouseStandRepository;
            _staticCacheManager = staticCacheManager;
            _workContext = workContext;
        }



        #endregion

        #region Methods

        /// <summary>
        /// Delete Warehouse Stand
        /// </summary>
        /// <param name="warehouseStand">warehouseStand</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task DeleteWarehouseStandAsync(WarehouseStand warehouseStand)
        {
            if (warehouseStand is null)
                throw new ArgumentNullException(nameof(warehouseStand));

            await _warehouseStandRepository.DeleteAsync(warehouseStand);
        }

        /// <summary>
        /// Delete a list of Warehouse Stands
        /// </summary>
        /// <param name="warehouseStands">Warehouse Stands</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task DeleteWarehouseStandAsync(IList<WarehouseStand> warehouseStands)
        {
            if (warehouseStands is null)
                throw new ArgumentNullException(nameof(warehouseStands));

            await _warehouseStandRepository.DeleteAsync(warehouseStands);
        }

        /// <summary>
        /// Gets all Warehouse Stands
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the Warehouse Stands
        /// </returns>
        public async Task<IList<WarehouseStand>> GetAllWarehouseStandsAsync()
        {
            return await _warehouseStandRepository.GetAllAsync(query => query.Where(stand => !stand.Deleted));
        }

        /// <summary>
        /// Gets all active Warehouse Stands
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the active Warehouse Stands
        /// </returns>
        public async Task<IList<WarehouseStand>> GetAllActiveWarehouseStandsAsync()
        {
            return await _warehouseStandRepository.GetAllAsync(query => query.Where(stand => stand.Active && !stand.Deleted));
        }

        /// <summary>
        /// Gets Warehouse Stand by identifier
        /// </summary>
        /// <param name="warehouseStandId">warehouseStand identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the Warehouse Stand
        /// </returns>
        public async Task<WarehouseStand> GetWarehouseStandByIdAsync(int warehouseStandId)
        {
            return await _warehouseStandRepository.GetByIdAsync(warehouseStandId);
        }

        /// <summary>
        /// Gets all Accept Warehouse Stands
        /// </summary>
        /// <param name="warehouseId">Warehouse Id</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the Warehouse Stands
        /// </returns>
        public async Task<IPagedList<WarehouseStand>> GetAllWarehouseStandsAsync(int warehouseId, string materialType, int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var warehouseStands = await _warehouseStandRepository.GetAllAsync(query =>
            {
                if (!string.IsNullOrWhiteSpace(materialType))
                    query = query.Where(c => c.MaterialType.Contains(materialType));

                query = query.Where(x => x.WarehouseId == warehouseId && !x.Deleted);
                return query.OrderBy(c => c.Id);
            });

            //paging
            return new PagedList<WarehouseStand>(warehouseStands, pageIndex, pageSize);
        }

        /// <summary>
        /// Get warehouse stand by identifiers
        /// </summary>
        /// <param name="warehouseStandIds">warehouse stand identifiers</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the warehouse stand that retrieved by identifiers
        /// </returns>
        public async Task<IList<WarehouseStand>> GetWarehouseStandByIdsAsync(int[] warehouseStandIds)
        {
            return await _warehouseStandRepository.GetByIdsAsync(warehouseStandIds, includeDeleted: false);
        }

        /// <summary>
        /// Inserts a Warehouse Stand
        /// </summary>
        /// <param name="warehouseStand">>warehouse Stand</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task InsertWarehouseStandAsync(WarehouseStand warehouseStand)
        {
            if (warehouseStand is null)
                throw new ArgumentNullException(nameof(warehouseStand));

            await _warehouseStandRepository.InsertAsync(warehouseStand);
        }

        /// <summary>
        /// Insert warehouse stands
        /// </summary>
        /// <param name="warehouseStands">>Warehouse stands</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task InsertWarehouseStandAsync(IList<WarehouseStand> warehouseStands)
        {
            if (warehouseStands is null)
                throw new ArgumentNullException(nameof(warehouseStands));

            await _warehouseStandRepository.InsertAsync(warehouseStands);
        }

        /// <summary>
        /// Updates the Warehouse Stand 
        /// </summary>
        /// <param name="warehouseStand">>Warehouse Stand</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task UpdateWarehouseStandAsync(WarehouseStand warehouseStand)
        {
            if (warehouseStand is null)
                throw new ArgumentNullException(nameof(warehouseStand));

            await _warehouseStandRepository.UpdateAsync(warehouseStand);
        }

        #endregion
    }
}
