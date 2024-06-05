using System.Collections.Generic;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Core.Domain.Warehouses;

namespace Nop.Services.Warehouses.Interface
{
    /// <summary>
    /// Shelf Service Interface
    /// </summary>
    public interface IShelfService
    {
        /// <summary>
        /// Delete Shelf
        /// </summary>
        /// <param name="shelf">Shelf</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task DeleteShelfAsync(Shelf shelf);

        /// <summary>
        /// Delete a list of Shelves
        /// </summary>
        /// <param name="Shelves">Shelves</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task DeleteShelfAsync(IList<Shelf> shelves);

        /// <summary>
        /// Gets all Warehouse Shelves
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the Shelves
        /// </returns>
        Task<IList<Shelf>> GetAllShelvesAsync();

        /// <summary>
        /// Gets all Shelves of specific stand
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the Shelves of specific stand
        /// </returns>
        Task<IList<Shelf>> GetStandShelvesAsync(int standId);

        /// <summary>
        /// Gets specific number of Shelves of specific stand
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains specific number of Shelves of specific stand
        /// </returns>
        Task<IList<Shelf>> GetShelvesSubsetForStandAsync(int standId, int noOfShelves);

        /// <summary>
        /// Gets all active Shelves
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the active Shelves
        /// </returns>
        Task<IList<Shelf>> GetAllActiveShelvesAsync();

        /// <summary>
        /// Gets Shelf by identifier
        /// </summary>
        /// <param name="shelf">Shelf identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the Shelf
        /// </returns>
        Task<Shelf> GetShelfByIdAsync(int shelf);

        /// <summary>
        /// Gets a shelf by barcode
        /// </summary>
        /// <param name="barcode">barcode</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains a shelf
        /// </returns>
        Task<Shelf> GetShelfByBarcodeAsync(string barcode);

        /// <summary>
        /// Gets all shelves
        /// </summary>
        /// <param name="standId">Stand Id</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the shelves
        /// </returns>
        Task<IPagedList<Shelf>> GetAllShelvesAsync(int warehouseId, int standId, string barcode, int pageIndex = 0, int pageSize = int.MaxValue);

        /// <summary>
        /// Get shelf by identifiers
        /// </summary>
        /// <param name="shelfIds">shelf identifiers</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the shelf that retrieved by identifiers
        /// </returns>
        Task<IList<Shelf>> GetShelfByIdsAsync(int[] shelfIds);

        /// <summary>
        /// Get shelves by stands identifiers
        /// </summary>
        /// <param name="standsIds">stands identifiers</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the shelves that retrieved by stands identifiers
        /// </returns>
        Task<IList<Shelf>> GetShelvesByStandsIdsAsync(int[] standsIds);

        /// <summary>
        /// Inserts a Shelf
        /// </summary>
        /// <param name="shelf">>Shelf</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task InsertShelfAsync(Shelf shelf);

        /// <summary>
        /// Insert Shelves
        /// </summary>
        /// <param name="shelves">>shelves</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task InsertShelfAsync(IList<Shelf> shelves);

        /// <summary>
        /// Updates the Shelf 
        /// </summary>
        /// <param name="shelf">>Shelf</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task UpdateShelfAsync(Shelf shelf);

        /// <summary>
        /// Updates the Shelves
        /// </summary>
        /// <param name="shelves">>shelves</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task UpdateShelfAsync(IList<Shelf> shelves);
    }
}
