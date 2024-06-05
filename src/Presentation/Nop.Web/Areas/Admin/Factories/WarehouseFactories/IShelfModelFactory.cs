
using System.Threading.Tasks;
using Nop.Core.Domain.Warehouses;
using Nop.Web.Areas.Admin.Models.Warehouses;

namespace Nop.Web.Areas.Admin.Factories.WarehouseFactories
{
    /// <summary>
    /// Represents the shelf model factory
    /// </summary>
    public interface IShelfModelFactory
    {

        /// <summary>
        /// Prepare shelf search model
        /// </summary>
        /// <param name="searchModel">shelf search model</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the shelf search model
        /// </returns>
        ShelfSearchModel PrepareShelfSearchModelAsync(ShelfSearchModel searchModel);

        /// <summary>
        /// Prepare paged shelf list model
        /// </summary>
        /// <param name="searchModel">shelf search model</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the shelf list model
        /// </returns>
        Task<ShelfListModel> PrepareShelfListModelAsync(ShelfSearchModel searchModel);

        /// <summary>
        /// Prepare shelf model
        /// </summary>
        /// <param name="model">shelf model</param>
        /// <param name="shelf">Shelf</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the shelf model
        /// </returns>
        Task<ShelfModel> PrepareShelfModelAsync(ShelfModel model, Shelf shelf);

    }

}
