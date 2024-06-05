using System;
using System.Collections.Generic;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Web.Areas.Admin.Models.Warehouses
{
    /// <summary>
    /// Represents a shelf model
    /// </summary>
    public record ShelfModel : BaseNopEntityModel , ILocalizedModel<ShelfLocalizedModel>
    {
        #region Ctor

        public ShelfModel()
        {
            Locales = new List<ShelfLocalizedModel>();
        }

        #endregion

        #region Properties

        [NopResourceDisplayName("Admin.Warehouses.Shelf.Fields.StandId")]
        public int StandId { get; set; }
        public int WarehouseId { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.Shelf.Fields.Barcode")]
        public string Barcode { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.Shelf.Fields.Active")]
        public bool Active { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.Shelf.Fields.CreatedOnUtc")]
        public DateTime CreatedOnUtc { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.Shelf.Fields.UpdatedOnUtc")]
        public DateTime UpdatedOnUtc { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.Shelf.Fields.CreatedBy")]
        public int CreatedBy { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.Shelf.Fields.UpdatedBy")]
        public int UpdatedBy { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.Shelf.Fields.Deleted")]
        public bool Deleted { get; set; }

        public IList<ShelfLocalizedModel> Locales { get; set; }


        #endregion
    }

    public record ShelfLocalizedModel : ILocalizedLocaleModel
    {
        public int LanguageId { get; set; }
    }

}
