using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Web.Areas.Admin.Models.Warehouses
{
    /// <summary>
    /// Represents a stock item history model
    /// </summary>
    public record StockItemHistoryModel : BaseNopEntityModel, ILocalizedModel<StockItemHistoryLocalizedModel>
    {
        #region Ctor

        public StockItemHistoryModel()
        {
            WarehouseProduct = new WarehouseProductModel();
            WarehouseProductCombination = new WarehouseProductCombinationModel();
            WarehouseItems = new List<WarehouseItemModel>();
            Locales = new List<StockItemHistoryLocalizedModel>();
        }

        #endregion

        #region Properties

        [NopResourceDisplayName("Admin.Warehouses.StockItemHistory.Fields.StockHistoryId")]
        public int StockHistoryId { get; set; }
        public int WarehouseId { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseProductCombination.Fields.AttributesXml")]
        public string AttributesXml { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.StockItemHistory.Fields.WarehouseProductCombinationId")]
        public int WarehouseProductCombinationId { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.StockItemHistory.Fields.StockQuantity")]
        public int StockQuantity { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.StockItemHistory.Fields.UnitPrice")]
        public decimal UnitPrice { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.StockItemHistory.Fields.Tax")]
        public decimal Tax { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.StockItemHistory.Fields.Discount")]
        public decimal Discount { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.StockItemHistory.Fields.Profit")]
        public decimal Profit { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.StockItemHistory.Fields.ItemDescription")]
        public string ItemDescription { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.StockHistory.Fields.ProductName")]
        public string ProductName { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.StockItemHistory.Fields.Sku")]
        public string Sku { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.StockItemHistory.Fields.HasExpirationDate")]
        public bool HasExpirationDate { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.StockItemHistory.Fields.ExpirationDate")]
        public DateTime? ExpirationDate { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.StockItemHistory.Fields.CreatedOnUtc")]
        public DateTime CreatedOnUtc { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.StockItemHistory.Fields.UpdatedOnUtc")]
        public DateTime UpdatedOnUtc { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.StockItemHistory.Fields.CreatedBy")]
        public int CreatedBy { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.StockItemHistory.Fields.UpdatedBy")]
        public int UpdatedBy { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.StockItemHistory.Fields.Deleted")]
        public bool Deleted { get; set; }

        public WarehouseProductModel WarehouseProduct { get; set; }

        public WarehouseProductCombinationModel WarehouseProductCombination { get; set; }

        public IList<StockItemHistoryLocalizedModel> Locales { get; set; }

        //for creational purpose
        public IList<WarehouseItemModel> WarehouseItems { get; set; }

        #endregion
    }

    public record StockItemHistoryLocalizedModel : ILocalizedLocaleModel
    {
        public int LanguageId { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.StockItemHistory.Fields.ItemDescription")]
        public string ItemDescription { get; set; }
    }

}
