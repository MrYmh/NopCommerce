using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Web.Areas.Admin.Models.Warehouses
{
    /// <summary>
    /// Represents a warehouse product combination search model
    /// </summary>
    public record WarehouseProductCombinationSearchModel : BaseSearchModel
    {
        #region Ctor

        public WarehouseProductCombinationSearchModel()
        {
        }

        #endregion

        #region Properties

        [NopResourceDisplayName("Admin.Warehouses.WarehouseProductCombination.List.WarehouseId")]
        public int WarehouseId { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseProductCombination.List.WarehouseProductId")]
        public int WarehouseProductId { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseProductCombination.List.WarehouseProductId")]
        public int WarehouseProductName { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseProductCombination.List.Sku")]
        public string Sku { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseProductCombination.List.Available")]
        public bool Available { get; set; }

        #endregion
    }

}
