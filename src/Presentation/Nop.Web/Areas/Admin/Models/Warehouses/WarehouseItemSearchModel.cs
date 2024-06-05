using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Web.Areas.Admin.Models.Warehouses
{
    /// <summary>
    /// Represents a warehouse item search model
    /// </summary>
    public record WarehouseItemSearchModel : BaseSearchModel
    {
        #region Ctor

        public WarehouseItemSearchModel()
        {
        }

        #endregion

        #region Properties

        [NopResourceDisplayName("Admin.Warehouses.WarehouseItem.List.StockItemHistoryId")]
        public int StockItemHistoryId { get; set; }
        public int WarehouseId { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseItem.List.Barcode")]
        public string Barcode { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseItem.List.ItemStatus")]
        public int ItemStatus { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseItem.List.Printed")]
        public bool Printed { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseItem.List.Scanned")]
        public bool Scanned { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseItem.List.Ordered")]
        public bool Ordered { get; set; }

        #endregion
    }

}
