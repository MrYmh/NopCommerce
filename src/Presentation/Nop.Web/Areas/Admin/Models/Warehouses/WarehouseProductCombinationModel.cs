using System;
using System.Collections.Generic;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Web.Areas.Admin.Models.Warehouses
{
    /// <summary>
    /// Represents a warehouse product combination model
    /// </summary>
    public record WarehouseProductCombinationModel : BaseNopEntityModel, ILocalizedModel<WarehouseProductCombinationLocalizedModel>
    {
        #region Ctor

        public WarehouseProductCombinationModel()
        {
            WarehouseProduct = new WarehouseProductModel();
            Locales = new List<WarehouseProductCombinationLocalizedModel>();
        }

        #endregion

        #region Properties

        [NopResourceDisplayName("Admin.Warehouses.WarehouseProductCombination.Fields.WarehouseId")]
        public int WarehouseId { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseProductCombination.Fields.WarehouseProductId")]
        public int WarehouseProductId { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseProductCombination.Fields.CombinationId")]
        public int CombinationId { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseProductCombination.Fields.AttributesXml")]
        public string AttributesXml { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseProductCombination.Fields.TotalQuantity")]
        public int TotalQuantity { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseProductCombination.Fields.ReturnedToVendorQuantity")]
        public int ReturnedToVendorQuantity { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseProductCombination.Fields.DamagedQuantity")]
        public int DamagedQuantity { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseProductCombination.Fields.Sku")]
        public string Sku { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseProductCombination.Fields.Available")]
        public bool Available { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseProductCombination.Fields.CreatedOnUtc")]
        public DateTime CreatedOnUtc { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseProductCombination.Fields.UpdatedOnUtc")]
        public DateTime UpdatedOnUtc { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseProductCombination.Fields.CreatedBy")]
        public int CreatedBy { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseProductCombination.Fields.UpdatedBy")]
        public int UpdatedBy { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseProductCombination.Fields.Deleted")]
        public bool Deleted { get; set; }

        public WarehouseProductModel WarehouseProduct { get; set; }

        public IList<WarehouseProductCombinationLocalizedModel> Locales { get; set; }

        #endregion
    }

    public record WarehouseProductCombinationLocalizedModel : ILocalizedLocaleModel
    {
        public int LanguageId { get; set; }
    }

}
