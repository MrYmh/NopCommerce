using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Core.Domain.Warehouses;

namespace Nop.Services.Warehouses.Interface
{
    /// <summary>
    /// Warehouse Item Service Interface
    /// </summary>
    public interface IWarehouseItemService
    {
        /// <summary>
        /// Delete Warehouse Item
        /// </summary>
        /// <param name="warehouseItem">WarehouseItem</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task DeleteWarehouseItemAsync(WarehouseItem warehouseItem);

        /// <summary>
        /// Delete a list of Warehouse Items
        /// </summary>
        /// <param name="warehouseItems">Warehouse Items</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task<bool> DeleteWarehouseItemAsync(IList<WarehouseItem> warehouseItems);

        /// <summary>
        /// Gets all Warehouse Items
        /// </summary>
        /// <param name="warehouseId">warehouseId</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the Warehouse Items
        /// </returns>
        Task<IList<WarehouseItem>> GetAllWarehouseItemsAsync(int warehouseId);

        /// <summary>
        /// Gets Warehouse Item by identifier
        /// </summary>
        /// <param name="warehouseItemId">Warehouse Item identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the Warehouse Item
        /// </returns>
        Task<WarehouseItem> GetWarehouseItemByIdAsync(int warehouseItemId);

        /// <summary>
        /// Gets Warehouse Item by Barcode
        /// </summary>
        /// <param name="barcode">barcode</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the Warehouse Item
        /// </returns>
        Task<WarehouseItem> GetWarehouseItemByBarcodeAsync(string barcode);

        /// <summary>
        /// Gets Available Warehouse Items Count
        /// </summary>
        /// <param name="warehouseId">warehouseId</param>
        /// <param name="WarehouseProductCombinationId">WarehouseProductCombinationId</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains Available Warehouse Items Count for specific Combination
        /// </returns>
        Task<int> GetAvailableWarehouseItemsCountAsync(int warehouseId, int warehouseProductCombinationId);

        /// <summary>
        /// Gets Available Warehouse Items Count
        /// </summary>
        /// <param name="warehouseId">warehouseId</param>
        /// <param name="sku">sku</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains Available Warehouse Items Count for all Combinations together
        /// </returns>
        Task<int> GetAvailableWarehouseItemsCountAsync(int warehouseId, string sku);

        /// <summary>
        /// Get warehouse items by barcodes
        /// </summary>
        /// <param name="warehouseId">warehouse identifier</param>
        /// <param name="itemsBarcodes">itemsBarcodes</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contain the Warehouse Items
        /// </returns>
        Task<IList<WarehouseItem>> GetWarehouseItemsByBarcodesAsync(IList<string> itemsBarcodes);

        /// <summary>
        /// Get Printed Warehouse Items Barcodes
        /// </summary>
        /// <param name="warehouseId">warehouseId</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the Printed Warehouse Items Barcodes
        /// </returns>
        Task<IList<string>> GetPrintedWarehouseItemsBarcodesAsync(int warehouseId);

        /// <summary>
        /// Get UnPrinted Warehouse Items Barcodes
        /// </summary>
        /// <param name="warehouseId">warehouseId</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the UnPrinted Warehouse Items Barcodes
        /// </returns>
        Task<IList<WarehouseItem>> GetUnPrintedWarehouseItemsBarcodesAsync(int warehouseId, string sku, int quantity = 0);

        /// <summary>
        /// Get Unscanned Warehouse Items Barcodes
        /// </summary>
        /// <param name="warehouseId">warehouseId</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the Unscanned Warehouse Items Barcodes
        /// </returns>
        Task<IList<string>> GetUnscannedWarehouseItemsBarcodesAsync(int warehouseId);

        /// <summary>
        /// Gets received warehouse items using stock item history identifier
        /// </summary>
        /// <param name="warehouseId">warehouse identifier</param>
        /// <param name="stockItemHistoryId">stock item history identifier</param>
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contain the warehouse items
        /// </returns>
        Task<IList<WarehouseItem>> GetReceivedWarehouseItemsByStockItemHistoryIdAsync(int warehouseId, int stockItemHistoryId);

        /// <summary>
        /// Gets all warehouse items
        /// </summary>
        /// <param name="stockItemHistoryId">Stock Item History Id</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the warehouse items
        /// </returns>
        Task<IPagedList<WarehouseItem>> GetAllWarehouseItemsAsync(int warehouseId, int pageIndex = 0, int pageSize = int.MaxValue);

        /// <summary>
        /// Get warehouse item by identifiers
        /// </summary>
        /// <param name="warehouseItemIds">warehouse item identifiers</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the warehouse item that retrieved by identifiers
        /// </returns>
        Task<IList<WarehouseItem>> GetWarehouseItemByIdsAsync(int[] warehouseItemIds);

        /// <summary>
        /// Inserts a Warehouse Item
        /// </summary>
        /// <param name="warehouseItem">>Warehouse Item</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task InsertWarehouseItemAsync(WarehouseItem warehouseItem);

        /// <summary>
        /// Insert Warehouse Items
        /// </summary>
        /// <param name="warehouseItems">>Warehouse Items</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task InsertWarehouseItemAsync(IList<WarehouseItem> warehouseItems);

        /// <summary>
        /// Updates the Warehouse Item 
        /// </summary>
        /// <param name="warehouseItem">>Warehouse Item</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task UpdateWarehouseItemAsync(WarehouseItem warehouseItem);

        /// <summary>
        /// Update Warehouse Items
        /// </summary>
        /// <param name="warehouseItems">>Warehouse Items</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task UpdateWarehouseItemAsync(IList<WarehouseItem> warehouseItems);
    }
}
