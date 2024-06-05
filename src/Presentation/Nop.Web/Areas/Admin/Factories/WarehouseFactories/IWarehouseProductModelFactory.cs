
using System.Threading.Tasks;
using Nop.Core.Domain.Warehouses;
using Nop.Web.Areas.Admin.Models.Warehouses;

namespace Nop.Web.Areas.Admin.Factories.WarehouseFactories
{
    /// <summary>
    /// Represents the warehouse product model factory
    /// </summary>
    public interface IWarehouseProductModelFactory
    {

        /// <summary>
        /// Prepare warehouse product search model
        /// </summary>
        /// <param name="searchModel">warehouse product search model</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the warehouse product search model
        /// </returns>
        WarehouseProductSearchModel PrepareWarehouseProductSearchModelAsync(WarehouseProductSearchModel searchModel);

        /// <summary>
        /// Prepare paged warehouse product list model
        /// </summary>
        /// <param name="searchModel">warehouse product search model</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the warehouse product list model
        /// </returns>
        Task<WarehouseProductListModel> PrepareWarehouseProductListModelAsync(WarehouseProductSearchModel searchModel);

        /// <summary>
        /// Prepare warehouse product model
        /// </summary>
        /// <param name="model">warehouse product model</param>
        /// <param name="warehouseProduct">WarehouseProduct</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the warehouse product model
        /// </returns>
        Task<WarehouseProductModel> PrepareWarehouseProductModelAsync(WarehouseProductModel model, WarehouseProduct warehouseProduct);

    }

}
