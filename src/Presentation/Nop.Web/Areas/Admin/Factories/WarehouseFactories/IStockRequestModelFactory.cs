
using System.Threading.Tasks;
using Nop.Core.Domain.Warehouses;
using Nop.Web.Areas.Admin.Models.Warehouses;

namespace Nop.Web.Areas.Admin.Factories.WarehouseFactories
{
    /// <summary>
    /// Represents the stock request model factory
    /// </summary>
    public interface IStockRequestModelFactory
    {

        /// <summary>
        /// Prepare stock request search model
        /// </summary>
        /// <param name="searchModel">stock request search model</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the stock request search model
        /// </returns>
        StockRequestSearchModel PrepareStockRequestSearchModelAsync(StockRequestSearchModel searchModel);

        /// <summary>
        /// Prepare paged stock request list model
        /// </summary>
        /// <param name="searchModel">stock request search model</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the stock request list model
        /// </returns>
        Task<StockRequestListModel> PrepareStockRequestListModelAsync(StockRequestSearchModel searchModel);

        /// <summary>
        /// Prepare stock request model
        /// </summary>
        /// <param name="model">stock request model</param>
        /// <param name="stockRequest">StockRequest</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the stock request model
        /// </returns>
        Task<StockRequestModel> PrepareStockRequestModelAsync(StockRequestModel model, StockRequest stockRequest);

    }

}
