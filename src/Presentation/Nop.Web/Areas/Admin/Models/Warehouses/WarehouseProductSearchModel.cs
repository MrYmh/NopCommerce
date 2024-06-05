using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Web.Areas.Admin.Models.Warehouses
{
    /// <summary>
    /// Represents a warehouse product search model
    /// </summary>
    public record WarehouseProductSearchModel : BaseSearchModel
    {
        #region Ctor

        public WarehouseProductSearchModel()
        {
        }

        #endregion

        #region Properties

        [NopResourceDisplayName("Admin.Warehouses.WarehouseProduct.List.WarehouseId")]
        public int WarehouseId { get; init; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseProduct.List.Name")]
        public string Name { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseProduct.List.Available")]
        public bool Available { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseProduct.List.Sku")]
        public string Sku { get; set; }

        #endregion
    }

}
