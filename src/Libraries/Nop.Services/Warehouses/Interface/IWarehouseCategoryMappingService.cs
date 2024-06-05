using System.Collections.Generic;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Core.Domain.Warehouses;

namespace Nop.Services.Warehouses.Interface
{
    /// <summary>
    /// Warehouse Category Mapping Service Interface
    /// </summary>
    public interface IWarehouseCategoryMappingService
    {

        /// <summary>
        /// Delete Warehouse Category
        /// </summary>
        /// <param name="warehouseCategory">warehouseCategory</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task DeleteWarehouseCategoryMappingAsync(WarehouseCategoryMapping warehouseCategory);

        /// <summary>
        /// Delete a list of Warehouse Categories
        /// </summary>
        /// <param name="warehouseCategories">warehouseCategories</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task DeleteWarehouseCategoryMappingAsync(IList<WarehouseCategoryMapping> warehouseCategories);

        /// <summary>
        /// Gets all Warehouse Categories
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the Warehouse Categories
        /// </returns>
        Task<IList<WarehouseCategoryMapping>> GetAllWarehouseCategoryMappingAsync();

        /// <summary>
        /// Gets all Warehouse Categories
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the Warehouse Categories
        /// </returns>
        Task<IList<WarehouseCategoryMapping>> GetAllWarehouseCategoryMappingAsync(int warehouseId);

        /// <summary>
        /// Gets Warehouse Category by identifier
        /// </summary>
        /// <param name="warehouseCategoryId">warehouseCategory identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the Warehouse Category
        /// </returns>
        Task<WarehouseCategoryMapping> GetWarehouseCategoryMappingByIdAsync(int warehouseCategoryId);

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
        Task<IPagedList<WarehouseCategoryMapping>> GetAllWarehouseCategoryMappingAsync(int warehouseId, string categoryName, int pageIndex = 0, int pageSize = int.MaxValue);

        /// <summary>
        /// Get warehouse category mapping by identifiers
        /// </summary>
        /// <param name="warehouseCategoryMappingIds">warehouse category mapping identifiers</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the warehouse category mapping that retrieved by identifiers
        /// </returns>
        Task<IList<WarehouseCategoryMapping>> GetWarehouseCategoryMappingByIdsAsync(int[] warehouseCategoryMappingIds);

        /// <summary>
        /// Inserts a Warehouse Category
        /// </summary>
        /// <param name="warehouseCategory">>warehouseCategory</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task InsertWarehouseCategoryMappingAsync(WarehouseCategoryMapping warehouseCategory);

        /// <summary>
        /// Insert warehouse categories
        /// </summary>
        /// <param name="warehouseCategories">>warehouseCategories</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task InsertWarehouseCategoryMappingAsync(IList<WarehouseCategoryMapping> warehouseCategories);

        /// <summary>
        /// Updates a Warehouse Category 
        /// </summary>
        /// <param name="warehouseCategory">>warehouseCategory</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task UpdateWarehouseCategoryMappingAsync(WarehouseCategoryMapping warehouseCategory);

        //Task<IList<int>> WarehouseCategoryMappingExists(int warehouseId, IList<int> selectedWarehouseCategoriesIds);
        //Task<int?> WarehouseCategoryMappingExists(int warehouseId, int selectedWarehouseCategoryId);
        //Task<IList<WarehouseCategoryMapping>> GetCategoriesByIdsAsync(int[] WarehouseCategoryMappingIds);
    }
}