
using System.Threading.Tasks;
using Nop.Core.Domain.Warehouses;
using Nop.Web.Areas.Admin.Models.Warehouses;

namespace Nop.Web.Areas.Admin.Factories.WarehouseFactories
{
    /// <summary>
    /// Represents the warehouse product category mapping model factory
    /// </summary>
    public interface IWarehouseProductCategoryMappingModelFactory
    {

        /// <summary>
        /// Prepare warehouse product category mapping search model
        /// </summary>
        /// <param name="searchModel">warehouse product category mapping search model</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the warehouse product category mapping search model
        /// </returns>
        WarehouseProductCategoryMappingSearchModel PrepareWarehouseProductCategoryMappingSearchModelAsync(WarehouseProductCategoryMappingSearchModel searchModel);

        /// <summary>
        /// Prepare paged warehouse product category mapping list model
        /// </summary>
        /// <param name="searchModel">warehouse product category mapping search model</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the warehouse product category mapping list model
        /// </returns>
        Task<WarehouseProductCategoryMappingListModel> PrepareWarehouseProductCategoryMappingListModelAsync(WarehouseProductCategoryMappingSearchModel searchModel);

        /// <summary>
        /// Prepare warehouse product category mapping model
        /// </summary>
        /// <param name="model">warehouse product category mapping model</param>
        /// <param name="warehouseProductCategoryMapping">WarehouseProductCategoryMapping</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the warehouse product category mapping model
        /// </returns>
        Task<WarehouseProductCategoryMappingModel> PrepareWarehouseProductCategoryMappingModelAsync(WarehouseProductCategoryMappingModel model, WarehouseProductCategoryMapping warehouseProductCategoryMapping, bool isEditMode = false);

    }

}
