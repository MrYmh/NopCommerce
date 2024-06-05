using System.Collections.Generic;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Warehouses;

namespace Nop.Services.Warehouses.Interface
{
    /// <summary>
    /// Warehouse Product Service Interface
    /// </summary>
    public interface IWarehouseProductService
    {
        /// <summary>
        /// Delete Warehouse Product
        /// </summary>
        /// <param name="warehouseProduct">warehouseProduct</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task DeleteWarehouseProductAsync(WarehouseProduct warehouseProduct);

        /// <summary>
        /// Delete a list of Warehouse Products
        /// </summary>
        /// <param name="WarehouseProducts">WarehouseProducts</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task DeleteWarehouseProductAsync(IList<WarehouseProduct> warehouseProducts);

        /// <summary>
        /// Gets all Warehouse Products
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the Warehouse Products
        /// </returns>
        Task<IList<WarehouseProduct>> GetAllWarehouseProductsAsync();

        /// <summary>
        /// Gets all available Warehouse Products
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the available Warehouse Products
        /// </returns>
        Task<IList<WarehouseProduct>> GetAllAvailableWarehouseProductsAsync();

        /// <summary>
        /// Gets Warehouse Product by identifier
        /// </summary>
        /// <param name="warehouseProductId">Warehouse Product identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the Warehouse Product
        /// </returns>
        Task<WarehouseProduct> GetWarehouseProductByIdAsync(int warehouseProductId);

        /// <summary>
        /// Gets all warehouse products
        /// </summary>
        /// <param name="warehouseId">Warehouse identifier</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the warehouse products
        /// </returns>
        Task<IPagedList<WarehouseProduct>> GetAllWarehouseProductsAsync(int warehouseId, string productName, string sku, int pageIndex = 0, int pageSize = int.MaxValue);

        /// <summary>
        /// Get warehouse product by identifiers
        /// </summary>
        /// <param name="warehouseProductIds">warehouse product identifiers</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the warehouse product that retrieved by identifiers
        /// </returns>
        Task<IList<WarehouseProduct>> GetWarehouseProductByIdsAsync(int[] warehouseProductIds);

        /// <summary>
        /// Inserts a Warehouse Product
        /// </summary>
        /// <param name="warehouseProduct">>warehouseProduct</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task InsertWarehouseProductAsync(WarehouseProduct warehouseProduct);

        /// <summary>
        /// Updates the Warehouse Product 
        /// </summary>
        /// <param name="warehouseProduct">>warehouseProduct</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task UpdateWarehouseProductAsync(WarehouseProduct warehouseProduct);
        Task<IEnumerable<int>> GetProductsIdsByWarehouseProductCategoryMappingIdsAsync(IEnumerable<int> warehouseProductCategoryMappingIds);
    }
}
