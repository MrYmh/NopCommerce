using System.Collections.Generic;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Core.Domain.Warehouses;

namespace Nop.Services.Warehouses.Interface
{
    /// <summary>
    /// Warehouse Category Service Interface
    /// </summary>
    public interface IWarehouseCategoryService
    {
        /// <summary>
        /// Delete Warehouse Category
        /// </summary>
        /// <param name="warehouseCategory">warehouseCategory</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task DeleteWarehouseCategoryAsync(WarehouseCategory warehouseCategory);

        /// <summary>
        /// Delete a list of Warehouse Categories
        /// </summary>
        /// <param name="warehouseCategories">warehouseCategories</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task DeleteWarehouseCategoryAsync(IList<WarehouseCategory> warehouseCategories);

        /// <summary>
        /// Gets all Warehouse Categories
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the Warehouse Categories
        /// </returns>
        Task<IList<WarehouseCategory>> GetAllWarehouseCategoriesAsync();

        /// <summary>
        /// Gets all Warehouse Categories
        /// </summary>
        /// <param name="exceptedIds">Categories Identifiers to be ignored</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the Warehouse Categories
        /// </returns>
        Task<IList<WarehouseCategory>> GetAvailableWarehouseCategoriesForMappingAsync(int[] exceptedIds);

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
        Task<IPagedList<WarehouseCategory>> GetAllWarehouseCategoriesAsync(string categoryName, int pageIndex = 0, int pageSize = int.MaxValue);

        /// <summary>
        /// Gets Warehouse Category by identifier
        /// </summary>
        /// <param name="warehouseCategoryId">warehouseCategory identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the Warehouse Category
        /// </returns>
        Task<WarehouseCategory> GetWarehouseCategoryByIdAsync(int warehouseCategoryId);

        /// <summary>
        /// Get warehouse categories by identifier
        /// </summary>
        /// <param name="warehouseCategoryIds">Warehouse category identifiers</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the warehouse categories
        /// </returns>
        Task<IList<WarehouseCategory>> GetWarehouseCategoriesByIdsAsync(int[] warehouseCategoryIds);

        /// <summary>
        /// Gets all warehouse categories by name
        /// </summary>
        /// <param name="categoryName">Category name</param>
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the warehouse categories
        /// </returns>
        Task<IList<WarehouseCategory>> GetAllWarehouseCategoriesByNameAsync(string categoryName);

        /// <summary>
        /// Inserts a Warehouse Category
        /// </summary>
        /// <param name="warehouseCategory">>warehouseCategory</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task InsertWarehouseCategoryAsync(WarehouseCategory warehouseCategory);

        /// <summary>
        /// Insert Warehouse Categories
        /// </summary>
        /// <param name="warehouseCategories">>warehouseCategories</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task InsertWarehouseCategoryAsync(IList<WarehouseCategory> warehouseCategories);

        /// <summary>
        /// Updates a Warehouse Category 
        /// </summary>
        /// <param name="warehouseCategory">>warehouseCategory</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task UpdateWarehouseCategoryAsync(WarehouseCategory warehouseCategory);

        //Task<IList<WarehouseCategory>> GetCategoriesByIdsAsync(int[] WarehouseCategoryIds);
    }
}