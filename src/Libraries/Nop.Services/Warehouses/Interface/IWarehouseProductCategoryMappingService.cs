using System.Collections.Generic;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Core.Domain.Warehouses;

namespace Nop.Services.Warehouses.Interface
{
    /// <summary>
    /// Warehouse Product Category Mapping Service Interface
    /// </summary>
    public interface IWarehouseProductCategoryMappingService
    {
        /// <summary>
        /// Delete Warehouse Product Category Mapping
        /// </summary>
        /// <param name="warehouseProductCategory">warehouseProductCategory</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task DeleteWarehouseProductCategoryMappingAsync(WarehouseProductCategoryMapping warehouseProductCategory);

        /// <summary>
        /// Delete a list of Warehouse Product Categories
        /// </summary>
        /// <param name="warehouseProductCategories">warehouseProductCategories</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task DeleteWarehouseProductCategoryMappingAsync(IList<WarehouseProductCategoryMapping> warehouseProductCategories);

        /// <summary>
        /// Gets all Warehouse Product Categories
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the Warehouse Product Categories
        /// </returns>
        Task<IList<WarehouseProductCategoryMapping>> GetAllWarehouseProductCategoryMappingAsync();

        /// <summary>
        /// Gets Warehouse Product Category by identifier
        /// </summary>
        /// <param name="warehouseProductCategoryId">warehouseProductCategory identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the Warehouse Product Category
        /// </returns>
        Task<WarehouseProductCategoryMapping> GetWarehouseProductCategoryMappingByIdAsync(int warehouseProductCategoryId);

        /// <summary>
        /// Gets all Warehouse Product Categories
        /// </summary>
        /// <param name="warehouseCategoryMappingIds">warehouseCategoryMappingIds</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the mapped warehouse product categories
        /// </returns>
        Task<IList<WarehouseProductCategoryMapping>> GetWarehouseProductCategoryMappingByWarehouseCategoryMappingIdAsync(int[] warehouseCategoryMappingIds);

        /// <summary>
        /// Gets all Warehouse Product Categories
        /// </summary>
        /// <param name="warehouseCategoryMappingId">warehouseCategoryMappingId</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the mapped warehouse product categories
        /// </returns>
        Task<IList<WarehouseProductCategoryMapping>> GetWarehouseProductCategoryMappingByWarehouseCategoryMappingIdAsync(int warehouseCategoryMappingId);

        /// <summary>
        /// Gets Product Categories' identifiers
        /// </summary>
        /// <param name="warehouseProductCategoryId">warehouseProductCategory identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the Warehouse Product Category
        /// </returns>
        Task<IList<int>> GetProductCategoriesIdsAsync(int warehouseCategoryMappingId);

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
        Task<IPagedList<WarehouseProductCategoryMapping>> GetAllWarehouseProductCategoryMappingAsync(int warehouseId, string productCategory, int pageIndex = 0, int pageSize = int.MaxValue);

        /// <summary>
        /// Get warehouse product category mapping by identifiers
        /// </summary>
        /// <param name="warehouseProductCategoryMappingIds">warehouse product category mapping identifiers</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the warehouse product category mapping that retrieved by identifiers
        /// </returns>
        Task<IList<WarehouseProductCategoryMapping>> GetWarehouseProductCategoryMappingByIdsAsync(int[] warehouseProductCategoryMappingIds);

        /// <summary>
        /// Inserts a Warehouse Product Category
        /// </summary>
        /// <param name="warehouseProductCategory">>warehouseProductCategory</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task InsertWarehouseProductCategoryMappingAsync(WarehouseProductCategoryMapping warehouseProductCategory);

        /// <summary>
        /// Insert Warehouse Product Categories
        /// </summary>
        /// <param name="warehouseProductCategories">>warehouseProductCategories</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task InsertWarehouseProductCategoryMappingAsync(IList<WarehouseProductCategoryMapping> warehouseProductCategories);

        /// <summary>
        /// Updates the Warehouse Product Category 
        /// </summary>
        /// <param name="warehouseProductCategory">>warehouseProductCategory</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task UpdateWarehouseProductCategoryMappingAsync(WarehouseProductCategoryMapping warehouseProductCategory);
    }
}
