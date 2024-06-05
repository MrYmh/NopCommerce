using System;
using System.Collections.Generic;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Web.Areas.Admin.Models.Warehouses
{
    /// <summary>
    /// Represents a shelf item mapping model
    /// </summary>
    public record ShelfItemMappingModel : BaseNopEntityModel, ILocalizedModel<ShelfItemMappingLocalizedModel>
    {
        #region Ctor

        public ShelfItemMappingModel()
        {
            Shelf = new ShelfModel();
            Item = new WarehouseItemModel();
            Locales = new List<ShelfItemMappingLocalizedModel>();
        }

        #endregion

        #region Properties
        [NopResourceDisplayName("Admin.Warehouses.ShelfItemMapping.Fields.ShelfId")]
        public int ShelfId { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.ShelfItemMapping.Fields.ItemId")]
        public int ItemId { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.ShelfItemMapping.Fields.CreatedOnUtc")]
        public DateTime CreatedOnUtc { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.ShelfItemMapping.Fields.UpdatedOnUtc")]
        public DateTime UpdatedOnUtc { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.ShelfItemMapping.Fields.CreatedBy")]
        public int CreatedBy { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.ShelfItemMapping.Fields.UpdatedBy")]
        public int UpdatedBy { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.ShelfItemMapping.Fields.Deleted")]
        public bool Deleted { get; set; }

        public ShelfModel Shelf { get; set; }

        public WarehouseItemModel Item { get; set; }

        public IList<ShelfItemMappingLocalizedModel> Locales { get; set; }

        #endregion
    }

    public record ShelfItemMappingLocalizedModel : ILocalizedLocaleModel
    {
        public int LanguageId { get; set; }
    }

}
