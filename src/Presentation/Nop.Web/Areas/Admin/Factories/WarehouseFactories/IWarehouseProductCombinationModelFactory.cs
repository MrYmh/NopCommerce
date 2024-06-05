
using System.Threading.Tasks;
using Nop.Core.Domain.Warehouses;
using Nop.Web.Areas.Admin.Models.Warehouses;

namespace Nop.Web.Areas.Admin.Factories.WarehouseFactories
{
    /// <summary>
    /// Represents the warehouse product combination model factory
    /// </summary>
    public interface IWarehouseProductCombinationModelFactory
    {

        /// <summary>
        /// Prepare warehouse product combination search model
        /// </summary>
        /// <param name="searchModel">warehouse product combination search model</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the warehouse product combination search model
        /// </returns>
        WarehouseProductCombinationSearchModel PrepareWarehouseProductCombinationSearchModelAsync(WarehouseProductCombinationSearchModel searchModel);

        /// <summary>
        /// Prepare paged warehouse product combination list model
        /// </summary>
        /// <param name="searchModel">warehouse product combination search model</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the warehouse product combination list model
        /// </returns>
        Task<WarehouseProductCombinationListModel> PrepareWarehouseProductCombinationListModelAsync(WarehouseProductCombinationSearchModel searchModel);

        /// <summary>
        /// Prepare warehouse product combination model
        /// </summary>
        /// <param name="model">warehouse product combination model</param>
        /// <param name="warehouseProductCombination">WarehouseProductCombination</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the warehouse product combination model
        /// </returns>
        Task<WarehouseProductCombinationModel> PrepareWarehouseProductCombinationModelAsync(WarehouseProductCombinationModel model, WarehouseProductCombination warehouseProductCombination);

    }

}
