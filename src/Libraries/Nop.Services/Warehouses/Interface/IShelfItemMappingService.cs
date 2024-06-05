using System.Collections.Generic;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Core.Domain.Warehouses;

namespace Nop.Services.Warehouses.Interface
{
    /// <summary>
    /// Shelf Item Mapping Service Interface
    /// </summary>
    public interface IShelfItemMappingService
    {
        /// <summary>
        /// Delete shelfItem
        /// </summary>
        /// <param name="shelfItem">shelfItem</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task DeleteShelfItemMappingAsync(ShelfItemMapping shelfItem);

        /// <summary>
        /// Delete a list of shelfItems
        /// </summary>
        /// <param name="shelfItem">shelfItem</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task DeleteShelfItemMappingAsync(IList<ShelfItemMapping> shelfItems);

        ///// <summary>
        ///// Delete a list of ShelfItems
        ///// </summary>
        ///// <param name="shelfItemMapping">ShelfItemMapping</param>
        ///// <returns>A task that represents the asynchronous operation</returns>
        //Task DeleteShelfItemMappingAsync(string itemBarcode);

        /// <summary>
        /// Delete a list of ShelfItems
        /// </summary>
        /// <param name="itemsBarcodes">itemsBarcodes</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task DeleteShelfItemMappingAsync(IList<string> itemsBarcodes);

        /// <summary>
        /// Gets all mapped entities related to a specific items ids
        /// </summary>
        /// <param name="itemsIds">itemsIds</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the mapped entities
        /// </returns>
        Task<IList<ShelfItemMapping>> GetShelfItemMappingByItemsIdsAsync(IEnumerable<int> itemsIds);

        /// <summary>
        /// Gets all ShelfItemMapping
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the ShelfItemMapping
        /// </returns>
        Task<IList<ShelfItemMapping>> GetAllShelfItemMappingAsync();

        /// <summary>
        /// Gets all Items Ids related to a specific shelf
        /// </summary>
        /// <param name="shelfId">shelfId</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the Items Ids
        /// </returns>
        Task<IList<int>> GetShelfItemMappingIdsAsync(int shelfId);

        /// <summary>
        /// Gets all Accept Stock Requests
        /// </summary>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the accept stock request
        /// </returns>
        Task<IPagedList<ShelfItemMapping>> GetAllShelfItemMappingAsync(int pageIndex = 0, int pageSize = int.MaxValue);

        /// <summary>
        /// Get shelf item mapping by identifier
        /// </summary>
        /// <param name="shelfItemMappingId">shelf item mapping identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the shelf item mapping
        /// </returns>
        Task<ShelfItemMapping> GetShelfItemMappingByIdAsync(int shelfItemMappingId);

        /// <summary>
        /// Get shelf item mapping by identifiers
        /// </summary>
        /// <param name="shelfItemMappingIds">shelf item mapping identifiers</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the shelf item mapping that retrieved by identifiers
        /// </returns>
        Task<IList<ShelfItemMapping>> GetShelfItemMappingByIdsAsync(int[] shelfItemMappingIds);

        /// <summary>
        /// Inserts a ShelfItemMapping
        /// </summary>
        /// <param name="shelfItem">>shelfItem</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task InsertShelfItemMappingAsync(ShelfItemMapping shelfItem);

        /// <summary>
        /// Insert ShelfItemMappings
        /// </summary>
        /// <param name="shelfItems">>shelfItems</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task InsertShelfItemMappingAsync(IList<ShelfItemMapping> shelfItems);

        /// <summary>
        /// Updates the ShelfItem
        /// </summary>
        /// <param name="shelfItem">>shelfItem</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task UpdateShelfItemMappingAsync(ShelfItemMapping shelfItem);
    }
}
