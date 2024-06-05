using System;
using System.Collections.Generic;
using ExCSS;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Core.Domain.Warehouses;
using Nop.Web.Areas.Admin.Models.Vendors;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Web.Areas.Admin.Models.Warehouses
{
    /// <summary>
    /// Represents a stock history model
    /// </summary>
    public record StockHistoryModel : BaseNopEntityModel, ILocalizedModel<StockHistoryLocalizedModel>
    {
        #region Ctor

        public StockHistoryModel()
        {
            Vendor = new VendorModel();
            StockItems = new List<StockItemHistoryModel>();
            AvailableVendors = new List<SelectListItem>();
            AvailableTypeOfProcesses = new List<SelectListItem>();
            AvailableVendors = new List<SelectListItem>();
            AvailablePriorities = new List<SelectListItem>();
            Locales = new List<StockHistoryLocalizedModel>();
        }

        #endregion

        #region Properties

        [NopResourceDisplayName("Admin.Warehouses.StockHistory.Fields.WarehouseId")]
        public int WarehouseId { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.StockHistory.Fields.VendorId")]
        public int VendorId { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.StockHistory.Fields.TypeOfProcess")]
       public StockProcess TypeOfProcess { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.StockHistory.Fields.Priority")]
        public int Priority { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.StockHistory.Fields.RequestId")]
        public int? RequestId { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.StockHistory.Fields.CreatedOnUtc")]
        public DateTime CreatedOnUtc { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.StockHistory.Fields.UpdatedOnUtc")]
        public DateTime UpdatedOnUtc { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.StockHistory.Fields.CreatedBy")]
        public int CreatedBy { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.StockHistory.Fields.UpdatedBy")]
        public int UpdatedBy { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.StockHistory.Fields.Deleted")]
        public bool Deleted { get; set; }

        public VendorModel Vendor { get; set; }
        public string VendorName { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.StockHistory.Fields.TypeOfProcess")]
        public IList<SelectListItem> AvailableTypeOfProcesses { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.StockHistory.Fields.Priority")]
        public IList<SelectListItem> AvailablePriorities { get; set; }

        public IList<SelectListItem> AvailableVendors { get; set; }

        public IList<StockHistoryLocalizedModel> Locales { get; set; }

        //for creational purpose
        public IList<StockItemHistoryModel> StockItems { get; set; }

        public StockItemHistoryModel StockItem { get; set; }

        #endregion
    }

    public record StockHistoryLocalizedModel : ILocalizedLocaleModel
    {
        public int LanguageId { get; set; }
    }

    public enum Priority
    {
        High = 1,
        Normal,
        Low
    }

}
