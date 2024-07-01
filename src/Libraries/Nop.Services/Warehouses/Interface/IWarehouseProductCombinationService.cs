using System.Collections.Generic;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Core.Domain.Warehouses;
using Nop.Services.Helpers;

namespace Nop.Services.Warehouses.Interface
{
    /// <summary>
    /// Warehouse Product Combination Service Interface
    /// </summary>
    public interface IWarehouseProductCombinationService
    {
        /// <summary>
        /// Delete Warehouse Product Combination
        /// </summary>
        /// <param name="warehouseProductCombination">warehouseProductCombination</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task DeleteWarehouseProductCombinationAsync(WarehouseProductCombination warehouseProductCombination);

        /// <summary>
        /// Delete a list of Warehouse Product Combinations
        /// </summary>
        /// <param name="warehouseProductCombination">warehouseProductCombination</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task DeleteWarehouseProductCombinationAsync(IList<WarehouseProductCombination> warehouseProductCombinations);

        /// <summary>
        /// Gets all Warehouse Product Combinations
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the Warehouse Product Combinations
        /// </returns>
        Task<IList<WarehouseProductCombination>> GetAllWarehouseProductCombinationsAsync();

        /// <summary>
        /// Gets all available Warehouse Product Combinations
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the available Warehouse Product Combinations
        /// </returns>
        Task<IList<WarehouseProductCombination>> GetAllAvailableWarehouseProductCombinationsAsync();

        /// <summary>
        /// Get warehouse product combinations by warehouse product identifier
        /// </summary>
        /// <param name="warehouseProductId">warehouse product identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the warehouse product combinations
        /// </returns>
        Task<IList<WarehouseProductCombination>> GetWarehouseProductCombinationsByWarehouseProductIdAsync(int warehouseProductId);

        /// <summary>
        /// Gets a warehouse product combination by warehouse identifier and sku
        /// </summary>
        /// <param name="warehouseId">warehouse identifier</param>
        /// <param name="sku">sku</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains a warehouse product combination
        /// </returns>
        Task<WarehouseProductCombination> GetWarehouseProductCombinationBySkuAsync(int warehouseId, string sku);

        /// <summary>
        /// Gets Warehouse Product Combination by identifier
        /// </summary>
        /// <param name="warehouseProductCombinationId">warehouse Product Combination identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the warehouse Product Combination
        /// </returns>
        Task<WarehouseProductCombination> GetWarehouseProductCombinationByIdAsync(int warehouseProductCombinationId);

        /// <summary>
        /// Gets all warehouse product combinations
        /// </summary>
        /// <param name="warehouseId">Warehouse Id</param>
        /// <param name="warehouseProductId">Warehouse Product Id</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the warehouse product combinations
        /// </returns>
        Task<IPagedList<WarehouseProductCombination>> GetAllWarehouseProductCombinationsAsync(int warehouseId, string sku, int pageIndex = 0, int pageSize = int.MaxValue);

        /// <summary>
        /// Get warehouse product combination by identifiers
        /// </summary>
        /// <param name="warehouseProductCombinationIds">warehouse product combination identifiers</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the warehouse product combination that retrieved by identifiers
        /// </returns>
        Task<IList<WarehouseProductCombination>> GetWarehouseProductCombinationByIdsAsync(int[] warehouseProductCombinationIds);

        /// <summary>
        /// Get warehouse product combinations by warehouse product identifiers
        /// </summary>
        /// <param name="warehouseProductsIds">warehouse product identifiers</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the warehouse product combinations
        /// </returns>
        Task<IList<WarehouseProductCombination>> GetWarehouseProductCombinationsByWarehouseProductIdAsync(int[] warehouseProductsIds);

        /// <summary>
        /// Inserts a Warehouse Product Combination
        /// </summary>
        /// <param name="warehouseProductCombination">>warehouseProductCombination</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task InsertWarehouseProductCombinationAsync(WarehouseProductCombination warehouseProductCombination);

        /// <summary>
        /// Insert warehouse product combinations
        /// </summary>
        /// <param name="warehouseProductCombinations">>warehouseProductCombinations</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task InsertWarehouseProductCombinationAsync(IList<WarehouseProductCombination> warehouseProductCombinations);

        /// <summary>
        /// Updates the Warehouse Product Combination 
        /// </summary>
        /// <param name="warehouseProductCombination">>warehouseProductCombination</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task UpdateWarehouseProductCombinationAsync(WarehouseProductCombination warehouseProductCombination);

        /// <summary>
        /// Update the warehouse product combinations
        /// </summary>
        /// <param name="warehouseProductCombinations">>warehouseProductCombinations</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task UpdateWarehouseProductCombinationAsync(IList<WarehouseProductCombination> warehouseProductCombinations);
        Task<IList<WarehouseItemGroup>> GetAllUnPrintedSerialsAsync(int warehouseId, int pageIndex = 0, int pageSize = int.MaxValue);
    }
}
