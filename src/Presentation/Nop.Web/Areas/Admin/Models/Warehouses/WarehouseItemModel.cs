using System;
using System.Collections.Generic;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Web.Areas.Admin.Models.Warehouses
{
    /// <summary>
    /// Represents a warehouse item model
    /// </summary>
    public record WarehouseItemModel : BaseNopEntityModel, ILocalizedModel<WarehouseItemLocalizedModel>
    {
        #region Ctor

        public WarehouseItemModel()
        {
            WarehouseProductCombination = new WarehouseProductCombinationModel();
            Locales = new List<WarehouseItemLocalizedModel>();
        }

        #endregion

        #region Properties

        [NopResourceDisplayName("Admin.Warehouses.WarehouseItem.Fields.WarehouseId")]
        public int WarehouseId { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseItem.Fields.StockItemHistoryId")]
        public int StockItemHistoryId { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseItem.Fields.WarehouseProductCombinationId")]
        public int WarehouseProductCombinationId { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseItem.Fields.Sku")]
        public string Sku { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseItem.Fields.Barcode")]
        public string Barcode { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseItem.Fields.ItemStatus")]
        public int ItemStatus { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseItem.Fields.Printed")]
        public bool Printed { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseItem.Fields.Scanned")]
        public bool Scanned { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseItem.Fields.Ordered")]
        public bool Ordered { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseItem.Fields.HasExpirationDate")]
        public bool HasExpirationDate { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseItem.Fields.ExpirationDate")]
        public DateTime ExpirationDate { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseItem.Fields.CreatedOnUtc")]
        public DateTime CreatedOnUtc { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseItem.Fields.UpdatedOnUtc")]
        public DateTime UpdatedOnUtc { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseItem.Fields.CreatedBy")]
        public int CreatedBy { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseItem.Fields.UpdatedBy")]
        public int UpdatedBy { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseItem.Fields.Deleted")]
        public bool Deleted { get; set; }

        public WarehouseProductCombinationModel WarehouseProductCombination { get; set; }

        public IList<WarehouseItemLocalizedModel> Locales { get; set; }

        #endregion
    }

    public record WarehouseItemLocalizedModel : ILocalizedLocaleModel
    {
        public int LanguageId { get; set; }
    }

}
