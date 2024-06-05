using System.Threading.Tasks;
using Nop.Core.Domain.Warehouses;
using Nop.Web.Areas.Admin.Models.Catalog;
using Nop.Web.Areas.Admin.Models.Warehouses;

namespace Nop.Web.Areas.Admin.Factories.WarehouseFactories
{
    /// <summary>
    /// Represents the warehouse category model factory
    /// </summary>
    public interface IWarehouseCategoryModelFactory
    {
        /// <summary>
        /// Prepare warehouse category search model
        /// </summary>
        /// <param name="searchModel">Warehouse Category search model</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the warehouse category search model
        /// </returns>
        WarehouseCategorySearchModel PrepareWarehouseCategorySearchModelAsync(WarehouseCategorySearchModel searchModel);

        /// <summary>
        /// Prepare paged Warehouse category list model
        /// </summary>
        /// <param name="searchModel">Warehouse category search model</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the warehouse category list model
        /// </returns>
        Task<WarehouseCategoryListModel> PrepareWarehouseCategoryListModelAsync(WarehouseCategorySearchModel searchModel);

        /// <summary>
        /// Prepare warehouse category model
        /// </summary>
        /// <param name="model">Warehouse category model</param>
        /// <param name="category">Warehouse category</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the Warehouse category model
        /// </returns>
        Task<WarehouseCategoryModel> PrepareWarehouseCategoryModelAsync(WarehouseCategoryModel model, WarehouseCategory category);

    }

}