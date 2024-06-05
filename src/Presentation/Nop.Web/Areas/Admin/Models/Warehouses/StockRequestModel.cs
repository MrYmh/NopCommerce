using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Core.Domain.Warehouses;
using Nop.Web.Areas.Admin.Models.Vendors;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Web.Areas.Admin.Models.Warehouses
{
    /// <summary>
    /// Represents a stock request model
    /// </summary>
    public record StockRequestModel : BaseNopEntityModel, ILocalizedModel<StockRequestLocalizedModel>
    {
        #region Ctor

        public StockRequestModel()
        {
            StockRequestItems = new List<StockRequestItemModel>();
            Vendor = new VendorModel();
            AvailableTypeOfProcesses = new List<SelectListItem>();
            AvailableVendors = new List<SelectListItem>();
            AvailablePriorities = new List<SelectListItem>();
            Locales = new List<StockRequestLocalizedModel>();
        }

        #endregion

        #region Properties

        [NopResourceDisplayName("Admin.Warehouses.StockRequest.Fields.WarehouseId")]
        public int WarehouseId { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.StockRequest.Fields.VendorId")]
        public int VendorId { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.StockRequest.Fields.TypeOfProcess")]
        public StockProcess TypeOfProcess { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.StockRequest.Fields.Priority")]
        public int Priority { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.StockRequest.Fields.CreatedOnUtc")]
        public DateTime CreatedOnUtc { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.StockRequest.Fields.UpdatedOnUtc")]
        public DateTime UpdatedOnUtc { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.StockRequest.Fields.CreatedBy")]
        public int CreatedBy { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.StockRequest.Fields.UpdatedBy")]
        public int UpdatedBy { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.StockRequest.Fields.Deleted")]
        public bool Deleted { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.StockRequest.Fields.TypeOfProcess")]
        public IList<SelectListItem> AvailableTypeOfProcesses { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.StockRequest.Fields.VendorId")]
        public IList<SelectListItem> AvailableVendors { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.StockHistory.Fields.Priority")]
        public IList<SelectListItem> AvailablePriorities { get; set; }

        public IList<StockRequestItemModel> StockRequestItems { get; set; }
        public StockRequestItemModel StockRequestItem { get; set; }
        public bool Reviewed { get; set; }

        public VendorModel Vendor { get; set; }
        public string VendorName { get; set; }

        public IList<StockRequestLocalizedModel> Locales { get; set; }

        #endregion
    }

    public record StockRequestLocalizedModel : ILocalizedLocaleModel
    {
        public int LanguageId { get; set; }
    }

}
