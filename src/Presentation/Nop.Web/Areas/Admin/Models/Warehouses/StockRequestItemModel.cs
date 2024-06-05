using System;
using System.Collections.Generic;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Web.Areas.Admin.Models.Warehouses
{
    /// <summary>
    /// Represents a stock request item model
    /// </summary>
    public record StockRequestItemModel : BaseNopEntityModel, ILocalizedModel<StockRequestItemLocalizedModel>
    {
        #region Ctor

        public StockRequestItemModel()
        {
            WarehouseProductCombination = new WarehouseProductCombinationModel();
            Locales = new List<StockRequestItemLocalizedModel>();
        }

        #endregion

        #region Properties

        [NopResourceDisplayName("Admin.Warehouses.StockRequestItem.Fields.StockRequestId")]
        public int StockRequestId { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.StockRequestItem.Fields.WarehouseProductCombinationId")]
        public int WarehouseProductCombinationId { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.StockRequestItem.Fields.StockQuantity")]
        public int StockQuantity { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.StockRequestItem.Fields.UnitPrice")]
        public decimal UnitPrice { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseProductCombination.Fields.AttributesXml")]
        public string AttributesXml { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.StockRequestItem.Fields.Tax")]
        public decimal Tax { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.StockRequestItem.Fields.Discount")]
        public decimal Discount { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.StockRequestItem.Fields.Profit")]
        public decimal Profit { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.StockHistory.Fields.ProductName")]
        public string ProductName { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.StockRequestItem.Fields.ItemDescription")]
        public string ItemDescription { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.StockRequestItem.Fields.CreatedOnUtc")]
        public DateTime CreatedOnUtc { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.StockRequestItem.Fields.UpdatedOnUtc")]
        public DateTime UpdatedOnUtc { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.StockRequestItem.Fields.CreatedBy")]
        public int CreatedBy { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.StockRequestItem.Fields.UpdatedBy")]
        public int UpdatedBy { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.StockItemHistory.Fields.Sku")]
        public string Sku { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.StockRequestItem.Fields.Deleted")]
        public bool Deleted { get; set; }

        public WarehouseProductCombinationModel WarehouseProductCombination { get; set; }

        public IList<StockRequestItemLocalizedModel> Locales { get; set; }

        #endregion
    }

    public record StockRequestItemLocalizedModel : ILocalizedLocaleModel
    {
        public int LanguageId { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.AcceptStockRequest.Fields.Comment")]
        public string Comment { get; set; }
    }

}
