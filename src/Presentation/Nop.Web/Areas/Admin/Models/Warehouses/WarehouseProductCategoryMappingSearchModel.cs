using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Web.Areas.Admin.Models.Warehouses
{
    /// <summary>
    /// Represents a warehouse product category mapping search model
    /// </summary>
    public record WarehouseProductCategoryMappingSearchModel : BaseSearchModel
    {
        #region Ctor

        public WarehouseProductCategoryMappingSearchModel()
        {
        }

        #endregion

        #region Properties

        [NopResourceDisplayName("Admin.Warehouses.WarehouseProductCategoryMapping.List.SearchProductCategoryId")]
        public int SearchProductCategoryId { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseProductCategoryMapping.List.SearchProductCategoryId")]
        public string SearchProductCategoryName { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseProductCategoryMapping.List.SearchWarehouseCategoryMappingId")]
        public int SearchWarehouseCategoryMappingId { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseProductCategoryMapping.List.WarehouseId")]
        public int WarehouseId { get; set; }


        #endregion
    }

}
