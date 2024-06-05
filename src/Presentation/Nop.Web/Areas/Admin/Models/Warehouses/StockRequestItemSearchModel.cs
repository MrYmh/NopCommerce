using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Web.Areas.Admin.Models.Warehouses
{
    /// <summary>
    /// Represents a stock request item search model
    /// </summary>
    public record StockRequestItemSearchModel : BaseSearchModel
    {
        #region Ctor

        public StockRequestItemSearchModel()
        {
        }

        #endregion

        #region Properties

        [NopResourceDisplayName("Admin.Warehouses.StockRequestItem.List.StockRequestId")]
        public int StockRequestId { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.StockRequestItem.List.WarehouseProductCombinationId")]
        public int WarehouseProductCombinationId { get; set; }

        #endregion
    }

}
