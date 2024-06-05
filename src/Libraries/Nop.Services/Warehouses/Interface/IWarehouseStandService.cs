using System.Collections.Generic;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Core.Domain.Warehouses;

namespace Nop.Services.Warehouses.Interface
{
    /// <summary>
    /// Warehouse Stand Service Interface
    /// </summary>
    public interface IWarehouseStandService
    {
        /// <summary>
        /// Delete category
        /// </summary>
        /// <param name="warehouseStand">warehouseStand</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task DeleteWarehouseStandAsync(WarehouseStand warehouseStand);

        /// <summary>
        /// Delete a list of categories
        /// </summary>
        /// <param name="warehouseStands">Warehouse Stands</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task DeleteWarehouseStandAsync(IList<WarehouseStand> warehouseStands);

        /// <summary>
        /// Gets all Warehouse Stands
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the Warehouse Stands
        /// </returns>
        Task<IList<WarehouseStand>> GetAllWarehouseStandsAsync();

        /// <summary>
        /// Gets all active Warehouse Stands
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the active Warehouse Stands
        /// </returns>
        Task<IList<WarehouseStand>> GetAllActiveWarehouseStandsAsync();

        /// <summary>
        /// Gets Warehouse Stand by identifier
        /// </summary>
        /// <param name="warehouseStandId">warehouseStand identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the Warehouse Stand
        /// </returns>
        Task<WarehouseStand> GetWarehouseStandByIdAsync(int warehouseStandId);

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
        Task<IPagedList<WarehouseStand>> GetAllWarehouseStandsAsync(int warehouseId, string materialType, int pageIndex = 0, int pageSize = int.MaxValue);

        /// <summary>
        /// Get warehouse stand by identifiers
        /// </summary>
        /// <param name="warehouseStandIds">warehouse stand identifiers</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the warehouse stand that retrieved by identifiers
        /// </returns>
        Task<IList<WarehouseStand>> GetWarehouseStandByIdsAsync(int[] warehouseStandIds);

        /// <summary>
        /// Inserts a Warehouse Stand
        /// </summary>
        /// <param name="warehouseStand">>warehouse Stand</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task InsertWarehouseStandAsync(WarehouseStand warehouseStand);

        /// <summary>
        /// Insert warehouse stands
        /// </summary>
        /// <param name="warehouseStands">>Warehouse stands</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task InsertWarehouseStandAsync(IList<WarehouseStand> warehouseStands);

        /// <summary>
        /// Updates the Warehouse Stand 
        /// </summary>
        /// <param name="warehouseStand">>Warehouse Stand</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task UpdateWarehouseStandAsync(WarehouseStand warehouseStand);
    }
}
