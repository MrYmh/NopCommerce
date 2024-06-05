using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Web.Areas.Admin.Models.Warehouses
{
    /// <summary>
    /// Represents a warehouse stand search model
    /// </summary>
    public record WarehouseStandSearchModel : BaseSearchModel
    {
        #region Ctor

        public WarehouseStandSearchModel()
        {
        }

        #endregion

        #region Properties

        [NopResourceDisplayName("Admin.Warehouses.WarehouseStand.List.WarehouseId")]
        public int WarehouseId { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseStand.List.MaterialType")]
        public string SearchMaterialType { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseStand.List.Description")]
        public string Description { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseStand.List.Active")]
        public bool Active { get; set; }

        #endregion
    }

}
