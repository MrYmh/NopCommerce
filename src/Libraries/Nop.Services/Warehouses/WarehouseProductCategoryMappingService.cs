using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Core.Caching;
using Nop.Core.Domain.Warehouses;
using Nop.Data;
using Nop.Services.Catalog;
using Nop.Services.Localization;
using Nop.Services.Warehouses.Interface;

namespace Nop.Services.Warehouses
{
    public class WarehouseProductCategoryMappingService : IWarehouseProductCategoryMappingService
    {
        #region Fields

        private readonly ILocalizationService _localizationService;
        private readonly IRepository<WarehouseProductCategoryMapping> _warehouseProductCategoryMappingRepository;
        private readonly IStaticCacheManager _staticCacheManager;
        private readonly ICategoryService _categoryService;

        #endregion

        #region Ctor

        public WarehouseProductCategoryMappingService(
            ILocalizationService localizationService,
            IRepository<WarehouseProductCategoryMapping> warehouseProductCategoryMappingRepository,
            IStaticCacheManager staticCacheManager,
            ICategoryService categoryService)
        {
            _localizationService = localizationService;
            _warehouseProductCategoryMappingRepository = warehouseProductCategoryMappingRepository;
            _staticCacheManager = staticCacheManager;
            _categoryService = categoryService;
        }



        #endregion

        #region Methods

        /// <summary>
        /// Delete Warehouse Product Category Mapping
        /// </summary>
        /// <param name="warehouseProductCategory">warehouseProductCategory</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task DeleteWarehouseProductCategoryMappingAsync(WarehouseProductCategoryMapping warehouseProductCategory)
        {
            if (warehouseProductCategory is null)
                throw new ArgumentNullException(nameof(warehouseProductCategory));

            await _warehouseProductCategoryMappingRepository.DeleteAsync(warehouseProductCategory);
        }

        /// <summary>
        /// Delete a list of Warehouse Product Categories
        /// </summary>
        /// <param name="warehouseProductCategories">warehouseProductCategories</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task DeleteWarehouseProductCategoryMappingAsync(IList<WarehouseProductCategoryMapping> warehouseProductCategories)
        {
            if (warehouseProductCategories is null)
                throw new ArgumentNullException(nameof(warehouseProductCategories));

            await _warehouseProductCategoryMappingRepository.DeleteAsync(warehouseProductCategories);
        }

        /// <summary>
        /// Gets all Warehouse Product Categories
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the Warehouse Product Categories
        /// </returns>
        public async Task<IList<WarehouseProductCategoryMapping>> GetAllWarehouseProductCategoryMappingAsync()
        {
            return await _warehouseProductCategoryMappingRepository.GetAllAsync(query => query.Where(x => !x.Deleted));
        }

        /// <summary>
        /// Gets all Warehouse Product Categories
        /// </summary>
        /// <param name="warehouseCategoryMappingIds">warehouseCategoryMappingIds</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the mapped warehouse product categories
        /// </returns>
        public async Task<IList<WarehouseProductCategoryMapping>> GetWarehouseProductCategoryMappingByWarehouseCategoryMappingIdAsync(int[] warehouseCategoryMappingIds)
        {
            return await _warehouseProductCategoryMappingRepository.GetAllAsync(query => query.Where(x => !x.Deleted && warehouseCategoryMappingIds.Contains(x.WarehouseCategoryMappingId)));
        }

        /// <summary>
        /// Gets all Warehouse Product Categories
        /// </summary>
        /// <param name="warehouseCategoryMappingId">warehouseCategoryMappingId</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the mapped warehouse product categories
        /// </returns>
        public async Task<IList<WarehouseProductCategoryMapping>> GetWarehouseProductCategoryMappingByWarehouseCategoryMappingIdAsync(int warehouseCategoryMappingId)
        {
            return await _warehouseProductCategoryMappingRepository.GetAllAsync(query => query.Where(x => !x.Deleted && x.WarehouseCategoryMappingId == warehouseCategoryMappingId));
        }

        /// <summary>
        /// Gets Warehouse Product Category by identifier
        /// </summary>
        /// <param name="warehouseProductCategoryId">warehouseProductCategory identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the Warehouse Product Category
        /// </returns>
        public async Task<WarehouseProductCategoryMapping> GetWarehouseProductCategoryMappingByIdAsync(int warehouseProductCategoryId)
        {
            return await _warehouseProductCategoryMappingRepository.GetByIdAsync(warehouseProductCategoryId);
        }

        /// <summary>
        /// Gets Product Categories' identifiers
        /// </summary>
        /// <param name="warehouseProductCategoryId">warehouseProductCategory identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the Product Categories' identifiers
        /// </returns>
        public async Task<IList<int>> GetProductCategoriesIdsAsync(int warehouseCategoryMappingId)
        {
            var warehouseProductCategories = await _warehouseProductCategoryMappingRepository.GetAllAsync(
                query => query.Where(x => !x.Deleted && x.WarehouseCategoryMappingId == warehouseCategoryMappingId)
                );

            return warehouseProductCategories.Select(x => x.ProductCategoryId).ToList();
        }

        /// <summary>
        /// Gets all mapped warehouse product category
        /// </summary>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the mapped warehouse product category
        /// </returns>
        public async Task<IPagedList<WarehouseProductCategoryMapping>> GetAllWarehouseProductCategoryMappingAsync(int warehouseId, string productCategory, int pageIndex = 0, int pageSize = int.MaxValue)
        {
            
            var mappedWarehouseProductCategory = await _warehouseProductCategoryMappingRepository.GetAllAsync(async query =>
            {
                query = query.Where(x => !x.Deleted && x.WarehouseId == warehouseId);

                if (!string.IsNullOrWhiteSpace(productCategory))
                {
                    var categories = await _categoryService.GetAllCategoriesAsync(productCategory);
                    var categoriesIds = categories.Select(x => x.Id);
                    query = query.Where(x => categoriesIds.Contains(x.ProductCategoryId));
                }

                return query.OrderBy(c => c.Id);
            });

            //paging
            return new PagedList<WarehouseProductCategoryMapping>(mappedWarehouseProductCategory, pageIndex, pageSize);
        }

        /// <summary>
        /// Get warehouse product category mapping by identifiers
        /// </summary>
        /// <param name="warehouseProductCategoryMappingIds">warehouse product category mapping identifiers</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the warehouse product category mapping that retrieved by identifiers
        /// </returns>
        public async Task<IList<WarehouseProductCategoryMapping>> GetWarehouseProductCategoryMappingByIdsAsync(int[] warehouseProductCategoryMappingIds)
        {
            return await _warehouseProductCategoryMappingRepository.GetByIdsAsync(warehouseProductCategoryMappingIds, includeDeleted: false);
        }

        /// <summary>
        /// Inserts a Warehouse Product Category
        /// </summary>
        /// <param name="warehouseProductCategory">>warehouseProductCategory</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task InsertWarehouseProductCategoryMappingAsync(WarehouseProductCategoryMapping warehouseProductCategory)
        {
            if (warehouseProductCategory is null)
                throw new ArgumentNullException(nameof(warehouseProductCategory));

            await _warehouseProductCategoryMappingRepository.InsertAsync(warehouseProductCategory);
        }

        /// <summary>
        /// Insert Warehouse Product Categories
        /// </summary>
        /// <param name="warehouseProductCategories">>warehouseProductCategories</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task InsertWarehouseProductCategoryMappingAsync(IList<WarehouseProductCategoryMapping> warehouseProductCategories)
        {
            if (warehouseProductCategories is null)
                throw new ArgumentNullException(nameof(warehouseProductCategories));

            await _warehouseProductCategoryMappingRepository.InsertAsync(warehouseProductCategories);
        }

        /// <summary>
        /// Updates the Warehouse Product Category 
        /// </summary>
        /// <param name="warehouseProductCategory">>warehouseProductCategory</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task UpdateWarehouseProductCategoryMappingAsync(WarehouseProductCategoryMapping warehouseProductCategory)
        {
            if (warehouseProductCategory is null)
                throw new ArgumentNullException(nameof(warehouseProductCategory));

            await _warehouseProductCategoryMappingRepository.UpdateAsync(warehouseProductCategory);
        }

        #endregion
    }
}
