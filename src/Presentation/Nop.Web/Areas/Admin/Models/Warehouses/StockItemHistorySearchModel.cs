using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Web.Areas.Admin.Models.Warehouses
{
    /// <summary>
    /// Represents a stock item history search model
    /// </summary>
    public record StockItemHistorySearchModel : BaseSearchModel
    {
        #region Ctor

        public StockItemHistorySearchModel()
        {
        }

        #endregion

        #region Properties

        [NopResourceDisplayName("Admin.Warehouses.StockItemHistory.List.StockHistoryId")]
        public int StockHistoryId { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.StockItemHistory.List.WarehouseProductCombinationId")]
        public int WarehouseProductCombinationId { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.StockItemHistory.List.Sku")]
        public string Sku { get; set; }

        #endregion
    }

}
