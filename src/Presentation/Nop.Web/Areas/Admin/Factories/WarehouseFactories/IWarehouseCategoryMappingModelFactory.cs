using System.Threading.Tasks;
using Nop.Core.Domain.Warehouses;
using Nop.Web.Areas.Admin.Models.Warehouses;

namespace Nop.Web.Areas.Admin.Factories.WarehouseFactories
{
    /// <summary>
    /// Represents the warehouse category mapping model factory
    /// </summary>
    public interface IWarehouseCategoryMappingModelFactory
    {

        /// <summary>
        /// Prepare mapped warehouse category search model
        /// </summary>
        /// <param name="searchModel">Warehouse Category search model</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the mapped warehouse category search model
        /// </returns>
        WarehouseCategoryMappingSearchModel PrepareWarehouseCategoryMappingSearchModelAsync(WarehouseCategoryMappingSearchModel searchModel);

        /// <summary>
        /// Prepare paged mapped Warehouse category list model
        /// </summary>
        /// <param name="searchModel">Warehouse category search model</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the mapped warehouse category list model
        /// </returns>
        Task<WarehouseCategoryMappingListModel> PrepareWarehouseCategoryMappingListModelAsync(WarehouseCategoryMappingSearchModel searchModel);

        /// <summary>
        /// Prepare mapped warehouse category model
        /// </summary>
        /// <param name="model">Warehouse category model</param>
        /// <param name="category">Warehouse category</param>
        /// <param name="excludeProperties">Whether to exclude populating of some properties of model</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the mapped warehouse category model
        /// </returns>
        Task<WarehouseCategoryMappingModel> PrepareWarehouseCategoryMappingModelAsync(WarehouseCategoryMappingModel model, WarehouseCategoryMapping category);

    }

}