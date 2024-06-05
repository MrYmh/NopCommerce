using System;
using System.Collections;
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
    /// Warehouse Category service
    /// </summary>
    public class WarehouseCategoryService : IWarehouseCategoryService
    {
        #region Fields

        private readonly IAclService _aclService;
        private readonly ICustomerService _customerService;
        private readonly ILocalizationService _localizationService;
        private readonly IRepository<WarehouseCategory> _warehouseCategoryRepository;
        private readonly IStaticCacheManager _staticCacheManager;
        private readonly IStoreContext _storeContext;
        private readonly IStoreMappingService _storeMappingService;
        private readonly IWorkContext _workContext;

        #endregion

        #region Ctor

        public WarehouseCategoryService(
            IAclService aclService,
            ICustomerService customerService,
            ILocalizationService localizationService,
            IRepository<WarehouseCategory> warehouseCategoryRepository,
            IStaticCacheManager staticCacheManager,
            IStoreContext storeContext,
            IStoreMappingService storeMappingService,
            IWorkContext workContext)
        {
            _aclService = aclService;
            _customerService = customerService;
            _localizationService = localizationService;
            _warehouseCategoryRepository = warehouseCategoryRepository;
            _staticCacheManager = staticCacheManager;
            _storeContext = storeContext;
            _storeMappingService = storeMappingService;
            _workContext = workContext;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Delete Warehouse Category
        /// </summary>
        /// <param name="warehouseCategory">warehouseCategory</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task DeleteWarehouseCategoryAsync(WarehouseCategory warehouseCategory)
        {
            if (warehouseCategory is null)
                throw new ArgumentNullException(nameof(warehouseCategory));

            await _warehouseCategoryRepository.DeleteAsync(warehouseCategory);
        }

        /// <summary>
        /// Delete a list of Warehouse Categories
        /// </summary>
        /// <param name="warehouseCategories">warehouseCategories</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task DeleteWarehouseCategoryAsync(IList<WarehouseCategory> warehouseCategories)
        {
            if (warehouseCategories is null)
                throw new ArgumentNullException(nameof(warehouseCategories));

            await _warehouseCategoryRepository.DeleteAsync(warehouseCategories);
        }

        /// <summary>
        /// Gets all Warehouse Categories
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the Warehouse Categories
        /// </returns>
        public async Task<IList<WarehouseCategory>> GetAllWarehouseCategoriesAsync()
        {
            return await _warehouseCategoryRepository.GetAllAsync(query =>
            {
                return query.Where(x => !x.Deleted)
                .OrderBy(x => x.DisplayOrder)
                .ThenBy(x => x.Id);
            });
        }

        /// <summary>
        /// Gets all Warehouse Categories
        /// </summary>
        /// <param name="exceptedIds">Categories Identifiers to be ignored</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the Warehouse Categories
        /// </returns>
        public async Task<IList<WarehouseCategory>> GetAvailableWarehouseCategoriesForMappingAsync(int[] exceptedIds)
        {
            return await _warehouseCategoryRepository.GetAllAsync(query =>
            {
                return query.Where(x => !x.Deleted && !exceptedIds.Contains(x.Id));
            });
        }

        /// <summary>
        /// Gets all warehouse categories
        /// </summary>
        /// <param name="categoryName">Category name</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the warehouse categories
        /// </returns>
        public async Task<IPagedList<WarehouseCategory>> GetAllWarehouseCategoriesAsync(string categoryName, int pageIndex = 0, int pageSize = int.MaxValue)
        {
            try
            {
                var categories = await _warehouseCategoryRepository.GetAllAsync(query =>
                {
                    query = query.Where(c => !c.Deleted);
                    if (!string.IsNullOrWhiteSpace(categoryName))
                        query = query.Where(c => c.Name.Contains(categoryName));

                    return query.OrderBy(c => c.DisplayOrder).ThenBy(c => c.Id);
                });

                //paging
                return new PagedList<WarehouseCategory>(categories, pageIndex, pageSize);
            }
            catch (Exception)
            {
                return new PagedList<WarehouseCategory>(new List<WarehouseCategory>(), pageIndex, pageSize);
            }

        }

        /// <summary>
        /// Gets all warehouse categories by name
        /// </summary>
        /// <param name="categoryName">Category name</param>
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the warehouse categories
        /// </returns>
        public async Task<IList<WarehouseCategory>> GetAllWarehouseCategoriesByNameAsync(string categoryName)
        {
            return await _warehouseCategoryRepository.GetAllAsync(query =>
            {
                if (!string.IsNullOrWhiteSpace(categoryName))
                {
                    query = query.Where(c => c.Name.Contains(categoryName));
                    return query.OrderBy(c => c.DisplayOrder).ThenBy(c => c.Id);
                }
                else
                {
                    return query.Take(0);
                }
            });
        }

        /// <summary>
        /// Gets Warehouse Category by identifier
        /// </summary>
        /// <param name="warehouseCategoryId">warehouseCategory identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the Warehouse Category
        /// </returns>
        public async Task<WarehouseCategory> GetWarehouseCategoryByIdAsync(int warehouseCategoryId)
        {
            return await _warehouseCategoryRepository.GetByIdAsync(warehouseCategoryId);
        }

        /// <summary>
        /// Get warehouse categories by identifier
        /// </summary>
        /// <param name="warehouseCategoryIds">Warehouse category identifiers</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the warehouse categories
        /// </returns>
        public async Task<IList<WarehouseCategory>> GetWarehouseCategoriesByIdsAsync(int[] warehouseCategoryIds)
        {
            return await _warehouseCategoryRepository.GetByIdsAsync(warehouseCategoryIds, includeDeleted: false);
        }

        /// <summary>
        /// Inserts a Warehouse Category
        /// </summary>
        /// <param name="warehouseCategory">>warehouseCategory</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task InsertWarehouseCategoryAsync(WarehouseCategory warehouseCategory)
        {
            if (warehouseCategory is null)
                throw new ArgumentNullException(nameof(warehouseCategory));

            await _warehouseCategoryRepository.InsertAsync(warehouseCategory);
        }

        /// <summary>
        /// Insert Warehouse Categories
        /// </summary>
        /// <param name="warehouseCategories">>warehouseCategories</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task InsertWarehouseCategoryAsync(IList<WarehouseCategory> warehouseCategories)
        {
            if (warehouseCategories is null)
                throw new ArgumentNullException(nameof(warehouseCategories));

            await _warehouseCategoryRepository.InsertAsync(warehouseCategories);
        }

        /// <summary>
        /// Updates a Warehouse Category 
        /// </summary>
        /// <param name="warehouseCategory">>warehouseCategory</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task UpdateWarehouseCategoryAsync(WarehouseCategory warehouseCategory)
        {
            if (warehouseCategory is null)
                throw new ArgumentNullException(nameof(warehouseCategory));

            await _warehouseCategoryRepository.UpdateAsync(warehouseCategory);
        }

        #endregion
    }
}