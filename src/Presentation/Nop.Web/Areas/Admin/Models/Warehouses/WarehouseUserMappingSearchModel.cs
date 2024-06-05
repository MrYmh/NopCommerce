using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Web.Areas.Admin.Models.Warehouses
{
    /// <summary>
    /// Represents a warehouse user mapping search model
    /// </summary>
    public record WarehouseUserMappingSearchModel : BaseSearchModel
    {
        #region Ctor

        public WarehouseUserMappingSearchModel()
        {
        }

        #endregion

        #region Properties

        [NopResourceDisplayName("Admin.Warehouses.WarehouseUserMapping.List.WarehouseId")]
        public int WarehouseId { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseUserMapping.List.UserId")]
        public int UserId { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseUserMapping.List.IsActive")]
        public bool IsActive { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseUserMapping.List.IsBlocked")]
        public bool IsBlocked { get; set; }


        #endregion
    }
}
