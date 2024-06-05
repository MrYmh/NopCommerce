using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Web.Areas.Admin.Models.Warehouses
{
    /// <summary>
    /// Represents a shelf search model
    /// </summary>
    public record ShelfSearchModel : BaseSearchModel
    {
        #region Ctor

        public ShelfSearchModel()
        {
        }

        #endregion

        #region Properties

        [NopResourceDisplayName("Admin.Warehouses.Shelf.List.WarehouseId")]
        public int WarehouseId { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.Shelf.List.StandId")]
        public int StandId { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.Shelf.List.Barcode")]
        public string Barcode { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.Shelf.List.Active")]
        public bool Active { get; set; }

        #endregion
    }

}
