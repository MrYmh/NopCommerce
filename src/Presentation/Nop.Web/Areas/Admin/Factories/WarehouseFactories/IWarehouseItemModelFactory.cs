
using System.Threading.Tasks;
using Nop.Core.Domain.Warehouses;
using Nop.Web.Areas.Admin.Models.Warehouses;

namespace Nop.Web.Areas.Admin.Factories.WarehouseFactories
{
    /// <summary>
    /// Represents the warehouse item model factory
    /// </summary>
    public interface IWarehouseItemModelFactory
    {

        /// <summary>
        /// Prepare warehouse item search model
        /// </summary>
        /// <param name="searchModel">warehouse item search model</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the warehouse item search model
        /// </returns>
        WarehouseItemSearchModel PrepareWarehouseItemSearchModelAsync(WarehouseItemSearchModel searchModel);

        /// <summary>
        /// Prepare paged warehouse item list model
        /// </summary>
        /// <param name="searchModel">warehouse item search model</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the warehouse item list model
        /// </returns>
        Task<WarehouseItemListModel> PrepareWarehouseItemListModelAsync(WarehouseItemSearchModel searchModel);

        /// <summary>
        /// Prepare warehouse item model
        /// </summary>
        /// <param name="model">warehouse item model</param>
        /// <param name="warehouseItem">WarehouseItem</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the warehouse item model
        /// </returns>
        Task<WarehouseItemModel> PrepareWarehouseItemModelAsync(WarehouseItemModel model, WarehouseItem warehouseItem);

    }

}
