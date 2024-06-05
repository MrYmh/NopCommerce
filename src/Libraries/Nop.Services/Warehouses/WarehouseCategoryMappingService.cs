using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.EMMA;
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
    /// Warehouse Category Mapping service
    /// </summary>
    public class WarehouseCategoryMappingService : IWarehouseCategoryMappingService
    {
        #region Fields

        private readonly IAclService _aclService;
        private readonly ICustomerService _customerService;
        private readonly ILocalizationService _localizationService;
        private readonly IWarehouseCategoryService _warehouseCategoryService;
        private readonly IRepository<WarehouseCategoryMapping> _warehouseCategoryMappingRepository;
        private readonly IStaticCacheManager _staticCacheManager;
        private readonly IStoreContext _storeContext;
        private readonly IStoreMappingService _storeMappingService;
        private readonly IWorkContext _workContext;

        #endregion

        #region Ctor

        public WarehouseCategoryMappingService(
            IAclService aclService,
            ICustomerService customerService,
            ILocalizationService localizationService,
            IRepository<WarehouseCategoryMapping> warehouseCategoryMappingRepository,
            IStaticCacheManager staticCacheManager,
            IStoreContext storeContext,
            IStoreMappingService storeMappingService,
            IWorkContext workContext,
            IWarehouseCategoryService warehouseCategoryService)
        {
            _aclService = aclService;
            _customerService = customerService;
            _localizationService = localizationService;
            _warehouseCategoryMappingRepository = warehouseCategoryMappingRepository;
            _staticCacheManager = staticCacheManager;
            _storeContext = storeContext;
            _storeMappingService = storeMappingService;
            _workContext = workContext;
            _warehouseCategoryService = warehouseCategoryService;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Delete Warehouse Category
        /// </summary>
        /// <param name="warehouseCategory">warehouseCategory</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task DeleteWarehouseCategoryMappingAsync(WarehouseCategoryMapping warehouseCategory)
        {
            if (warehouseCategory is null)
                throw new ArgumentNullException(nameof(warehouseCategory));

            await _warehouseCategoryMappingRepository.DeleteAsync(warehouseCategory);

        }

        /// <summary>
        /// Delete a list of Warehouse Categories
        /// </summary>
        /// <param name="warehouseCategories">warehouseCategories</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task DeleteWarehouseCategoryMappingAsync(IList<WarehouseCategoryMapping> warehouseCategories)
        {
            if (warehouseCategories is null)
                throw new ArgumentNullException(nameof(warehouseCategories));

            await _warehouseCategoryMappingRepository.DeleteAsync(warehouseCategories);
        }

        /// <summary>
        /// Gets all Warehouse Categories
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the Warehouse Categories
        /// </returns>
        public async Task<IList<WarehouseCategoryMapping>> GetAllWarehouseCategoryMappingAsync()
        {
            return await _warehouseCategoryMappingRepository.GetAllAsync(query => query.Where(x => !x.Deleted));
        }

        /// <summary>
        /// Gets all Warehouse Categories
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the Warehouse Categories
        /// </returns>
        public async Task<IList<WarehouseCategoryMapping>> GetAllWarehouseCategoryMappingAsync(int warehouseId)
        {
            return await _warehouseCategoryMappingRepository.GetAllAsync(query => query.Where(x => !x.Deleted && x.WarehouseId == warehouseId && !x.IsSystem));
        }

        /// <summary>
        /// Gets Warehouse Category by identifier
        /// </summary>
        /// <param name="warehouseCategoryId">warehouseCategory identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the Warehouse Category
        /// </returns>
        public async Task<WarehouseCategoryMapping> GetWarehouseCategoryMappingByIdAsync(int warehouseCategoryId)
        {
            return await _warehouseCategoryMappingRepository.GetByIdAsync(warehouseCategoryId);
        }

        /// <summary>
        /// Gets all mapped warehouse categories
        /// </summary>
        /// <param name="warehouseId">warehouse</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the mapped warehouse categories
        /// </returns>
        public async Task<IPagedList<WarehouseCategoryMapping>> GetAllWarehouseCategoryMappingAsync(int warehouseId, string categoryName, int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var categories = await _warehouseCategoryService.GetAllWarehouseCategoriesByNameAsync(categoryName);

            var categoriesIds = categories.Select(x => x.Id);

            var mappedCategories = await _warehouseCategoryMappingRepository.GetAllAsync(query =>
            {
                query = query.Where(x => x.WarehouseId == warehouseId && !x.Deleted);

                if (categories.Any())
                {
                    query = query.Where(x => categoriesIds.Contains(x.WarehouseCategoryId));
                }

                return query.OrderBy(c => c.WarehouseCategoryId);
            });

            return new PagedList<WarehouseCategoryMapping>(mappedCategories, pageIndex, pageSize);
        }

        /// <summary>
        /// Get warehouse category mapping by identifiers
        /// </summary>
        /// <param name="warehouseCategoryMappingIds">warehouse category mapping identifiers</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the warehouse category mapping that retrieved by identifiers
        /// </returns>
        public async Task<IList<WarehouseCategoryMapping>> GetWarehouseCategoryMappingByIdsAsync(int[] warehouseCategoryMappingIds)
        {
            return await _warehouseCategoryMappingRepository.GetByIdsAsync(warehouseCategoryMappingIds, includeDeleted: false);
        }


        /// <summary>
        /// Inserts a Warehouse Category
        /// </summary>
        /// <param name="warehouseCategory">>warehouseCategory</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task InsertWarehouseCategoryMappingAsync(WarehouseCategoryMapping warehouseCategory)
        {
            if (warehouseCategory is null)
                throw new ArgumentNullException(nameof(warehouseCategory));

            await _warehouseCategoryMappingRepository.InsertAsync(warehouseCategory);
        }

        /// <summary>
        /// Insert warehouse categories
        /// </summary>
        /// <param name="warehouseCategories">>warehouseCategories</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task InsertWarehouseCategoryMappingAsync(IList<WarehouseCategoryMapping> warehouseCategories)
        {
            if (warehouseCategories is null)
                throw new ArgumentNullException(nameof(warehouseCategories));

            await _warehouseCategoryMappingRepository.InsertAsync(warehouseCategories);
        }

        /// <summary>
        /// Updates a Warehouse Category 
        /// </summary>
        /// <param name="warehouseCategory">>warehouseCategory</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task UpdateWarehouseCategoryMappingAsync(WarehouseCategoryMapping warehouseCategory)
        {
            if (warehouseCategory is null)
                throw new ArgumentNullException(nameof(warehouseCategory));

            await _warehouseCategoryMappingRepository.UpdateAsync(warehouseCategory);
        }

        //public async Task<IList<int>> WarehouseCategoryMappingExists(int warehouseId, IList<int> selectedWarehouseCategoriesIds)
        //{
        //    var result = new List<int>();

        //    var entities = await _warehouseCategoryMappingRepository.GetAllAsync(
        //        query => query.Where(x => !x.Deleted && 
        //                             x.WarehouseId == warehouseId && 
        //                             selectedWarehouseCategoriesIds.Contains(x.WarehouseCategoryId))
        //        );

        //    if (entities != null && entities.Any())
        //        result.AddRange(entities.Select(x => x.WarehouseCategoryId));

        //    return result;
        //}

        //public async Task<int?> WarehouseCategoryMappingExists(int warehouseId, int selectedWarehouseCategoryId)
        //{
        //    var entities = await _warehouseCategoryMappingRepository.GetAllAsync(
        //        query => query.Where(x => !x.Deleted &&
        //                             x.WarehouseId == warehouseId &&
        //                             x.WarehouseCategoryId == selectedWarehouseCategoryId)
        //        );
        //    if (entities != null && entities.Any())
        //    {
        //        var entity = entities.FirstOrDefault();
        //        return entity.WarehouseCategoryId;
        //    }
        //    else
        //        return null;
        //}

        #endregion
    }
}