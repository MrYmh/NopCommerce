
using System.Threading.Tasks;
using Nop.Core.Domain.Warehouses;
using Nop.Web.Areas.Admin.Models.Warehouses;

namespace Nop.Web.Areas.Admin.Factories.WarehouseFactories
{
    /// <summary>
    /// Represents the accept stock request model factory
    /// </summary>
    public interface IAcceptStockRequestModelFactory
    {

        /// <summary>
        /// Prepare accept stock request search model
        /// </summary>
        /// <param name="searchModel">accept stock request search model</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the accept stock request search model
        /// </returns>
        AcceptStockRequestSearchModel PrepareAcceptStockRequestSearchModelAsync(AcceptStockRequestSearchModel searchModel);

        /// <summary>
        /// Prepare paged accept stock request list model
        /// </summary>
        /// <param name="searchModel">accept stock request search model</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the accept stock request list model
        /// </returns>
        Task<AcceptStockRequestListModel> PrepareAcceptStockRequestListModelAsync(AcceptStockRequestSearchModel searchModel);

        /// <summary>
        /// Prepare accept stock request model
        /// </summary>
        /// <param name="model">accept stock request model</param>
        /// <param name="acceptStockRequest">AcceptStockRequest</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the accept stock request model
        /// </returns>
        Task<AcceptStockRequestModel> PrepareAcceptStockRequestModelAsync(AcceptStockRequestModel model, AcceptStockRequest acceptStockRequest);

    }

}
