using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Web.Areas.Admin.Models.Warehouses
{
    /// <summary>
    /// Represents a shelf item mapping search model
    /// </summary>
    public record ShelfItemMappingSearchModel : BaseSearchModel
    {
        #region Ctor

        public ShelfItemMappingSearchModel()
        {
        }

        #endregion

        #region Properties

        [NopResourceDisplayName("Admin.Warehouses.ShelfItemMapping.List.ShelfId")]
        public int ShelfId { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.ShelfItemMapping.List.ShelfBarcode")]
        public string ShelfBarcode { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.ShelfItemMapping.List.ItemId")]
        public int ItemId { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.ShelfItemMapping.List.ItemBarcode")]
        public string ItemBarcode { get; set; }

        #endregion
    }

}
