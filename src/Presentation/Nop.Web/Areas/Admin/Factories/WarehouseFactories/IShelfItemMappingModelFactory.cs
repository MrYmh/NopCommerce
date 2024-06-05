
using System.Threading.Tasks;
using Nop.Core.Domain.Warehouses;
using Nop.Web.Areas.Admin.Models.Warehouses;

namespace Nop.Web.Areas.Admin.Factories.WarehouseFactories
{
    /// <summary>
    /// Represents the shelf item mapping model factory
    /// </summary>
    public interface IShelfItemMappingModelFactory
    {

        /// <summary>
        /// Prepare shelf item mapping search model
        /// </summary>
        /// <param name="searchModel">shelf item mapping search model</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the shelf item mapping search model
        /// </returns>
        ShelfItemMappingSearchModel PrepareShelfItemMappingSearchModelAsync(ShelfItemMappingSearchModel searchModel);

        /// <summary>
        /// Prepare paged shelf item mapping list model
        /// </summary>
        /// <param name="searchModel">shelf item mapping search model</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the shelf item mapping list model
        /// </returns>
        Task<ShelfItemMappingListModel> PrepareShelfItemMappingListModelAsync(ShelfItemMappingSearchModel searchModel);

        /// <summary>
        /// Prepare shelf item mapping model
        /// </summary>
        /// <param name="model">shelf item mapping model</param>
        /// <param name="shelfItemMapping">ShelfItemMapping</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the shelf item mapping model
        /// </returns>
        Task<ShelfItemMappingModel> PrepareShelfItemMappingModelAsync(ShelfItemMappingModel model, ShelfItemMapping shelfItemMapping);

    }

}
