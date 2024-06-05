using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Web.Areas.Admin.Models.Warehouses
{
    /// <summary>
    /// Represents a warehouse category search model
    /// </summary>
    public record WarehouseCategorySearchModel : BaseSearchModel
    {
        #region Ctor

        public WarehouseCategorySearchModel()
        {
        }

        #endregion

        #region Properties

        [NopResourceDisplayName("Admin.Warehouses.WarehouseCategory.List.SearchWarehouseCategoryName")]
        public string SearchWarehouseCategoryName { get; set; }

        #endregion
    }

}
