
using System.Threading.Tasks;
using Nop.Core.Domain.Warehouses;
using Nop.Web.Areas.Admin.Models.Warehouses;

namespace Nop.Web.Areas.Admin.Factories.WarehouseFactories
{
    /// <summary>
    /// Represents the warehouse stand model factory
    /// </summary>
    public interface IWarehouseStandModelFactory
    {

        /// <summary>
        /// Prepare warehouse stand search model
        /// </summary>
        /// <param name="searchModel">warehouse stand search model</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the warehouse stand search model
        /// </returns>
        WarehouseStandSearchModel PrepareWarehouseStandSearchModelAsync(WarehouseStandSearchModel searchModel);

        /// <summary>
        /// Prepare paged warehouse stand list model
        /// </summary>
        /// <param name="searchModel">warehouse stand search model</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the warehouse stand list model
        /// </returns>
        Task<WarehouseStandListModel> PrepareWarehouseStandListModelAsync(WarehouseStandSearchModel searchModel);

        /// <summary>
        /// Prepare warehouse stand model
        /// </summary>
        /// <param name="model">warehouse stand model</param>
        /// <param name="warehouseStand">WarehouseStand</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the warehouse stand model
        /// </returns>
        WarehouseStandModel PrepareWarehouseStandModelAsync(WarehouseStandModel model, WarehouseStand warehouseStand);

    }

}
