using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Web.Areas.Admin.Models.Warehouses
{
    /// <summary>
    /// Represents a mapped warehouse category search model
    /// </summary>
    public record WarehouseCategoryMappingSearchModel : BaseSearchModel
    {
        #region Ctor

        public WarehouseCategoryMappingSearchModel()
        {
        }

        #endregion

        #region Properties

        [NopResourceDisplayName("Admin.Warehouses.WarehouseCategoryMapping.Fields.Name")]
        public string SearchWarehouseCategoryName { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseCategoryMapping.Fields.Name")]
        public string SearchWarehouseCategoryId { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseCategoryMapping.List.WarehouseId")]
        public int WarehouseId { get; set; }

        #endregion
    }

}
