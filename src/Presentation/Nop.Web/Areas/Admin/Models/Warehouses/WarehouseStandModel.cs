using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Web.Areas.Admin.Models.Warehouses
{
    /// <summary>
    /// Represents a warehouse stand model
    /// </summary>
    public record WarehouseStandModel : BaseNopEntityModel, ILocalizedModel<WarehouseStandLocalizedModel>
    {
        #region Ctor

        public WarehouseStandModel()
        {
            Locales = new List<WarehouseStandLocalizedModel>();
            Shelves = new List<ShelfModel>();
        }

        #endregion

        #region Properties

        [NopResourceDisplayName("Admin.Warehouses.WarehouseStand.Fields.WarehouseId")]
        public int WarehouseId { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseStand.Fields.MaterialType")]
        public string MaterialType { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseStand.Fields.Description")]
        public string Description { get; set; }

        [Range(1, 1000)]
        [NopResourceDisplayName("Admin.Warehouses.WarehouseStand.Fields.NoOfShelves")]
        public int NoOfShelves { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseStand.Fields.Active")]
        public bool Active { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseStand.Fields.CreatedOnUtc")]
        public DateTime CreatedOnUtc { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseStand.Fields.UpdatedOnUtc")]
        public DateTime UpdatedOnUtc { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseStand.Fields.CreatedBy")]
        public int CreatedBy { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseStand.Fields.UpdatedBy")]
        public int UpdatedBy { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseStand.Fields.Deleted")]
        public bool Deleted { get; set; }

        //for creation purpose
        [NopResourceDisplayName("Admin.Warehouses.WarehouseStand.Fields.NoOfStands")]
        public int NoOfStands { get; set; }

        public bool IsEditMode { get; set; }

        public IList<WarehouseStandLocalizedModel> Locales { get; set; }
        public IList<ShelfModel> Shelves { get; set; }

        #endregion
    }

    public record WarehouseStandLocalizedModel : ILocalizedLocaleModel
    {
        public int LanguageId { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseStand.Fields.MaterialType")]
        public string MaterialType { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseStand.Fields.Description")]
        public string Description { get; set; }

    }
}
