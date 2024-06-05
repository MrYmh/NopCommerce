using Nop.Core.Domain.Warehouses;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Web.Areas.Admin.Models.Warehouses
{
    /// <summary>
    /// Represents a stock history search model
    /// </summary>
    public record StockHistorySearchModel : BaseSearchModel
    {
        #region Ctor

        public StockHistorySearchModel()
        {
        }

        #endregion

        #region Properties

        [NopResourceDisplayName("Admin.Warehouses.StockHistory.List.StockHistoryId")]
        public string StockHistoryId { get; set; }


        [NopResourceDisplayName("Admin.Warehouses.StockHistory.List.WarehouseId")]
        public int WarehouseId { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.StockHistory.List.VendorId")]
        public string VendorName { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.StockHistory.List.TypeOfProcess")]
        public string TypeOfProcess { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.StockHistory.List.Priority")]
        public int Priority { get; set; }

        #endregion
    }

}
