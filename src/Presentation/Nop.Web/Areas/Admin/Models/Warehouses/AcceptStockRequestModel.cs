using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Core.Domain.Warehouses;
using Nop.Web.Areas.Admin.Models.Customers;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Web.Areas.Admin.Models.Warehouses
{
    /// <summary>
    /// Represents a accept stock request model
    /// </summary>
    public record AcceptStockRequestModel : BaseNopEntityModel, ILocalizedModel<AcceptStockRequestLocalizedModel>
    {
        #region Ctor

        public AcceptStockRequestModel()
        {
            StockRequest = new StockRequestModel();
            StockRequestItems = new List<StockRequestItemModel>();
            Requestor = new CustomerModel();
            Supervisor = new CustomerModel();
            Locales = new List<AcceptStockRequestLocalizedModel>();
        }

        #endregion

        #region Properties

        [NopResourceDisplayName("Admin.Warehouses.AcceptStockRequest.Fields.RequestorId")]
        public int RequestorId { get; set; }   //created by


        [NopResourceDisplayName("Admin.Warehouses.AcceptStockRequest.Fields.StockRequestId")]
        public int StockRequestId { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.AcceptStockRequest.Fields.Accepted")]
        public bool Accepted { get; set; } //by user

        [NopResourceDisplayName("Admin.Warehouses.AcceptStockRequest.Fields.RequestType")]
        public StockProcess RequestType { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.AcceptStockRequest.Fields.Comment")]
        public string Comment { get; set; }  //by user

        [NopResourceDisplayName("Admin.Warehouses.AcceptStockRequest.Fields.ActionTakenBy")]
        public int ActionTakenBy { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.AcceptStockRequest.Fields.WarehouseId")]
        public int WarehouseId { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.AcceptStockRequest.Fields.CreatedOnUtc")]
        public DateTime CreatedOnUtc { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.AcceptStockRequest.Fields.UpdatedOnUtc")]
        public DateTime UpdatedOnUtc { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.AcceptStockRequest.Fields.CreatedBy")]
        public int CreatedBy { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.AcceptStockRequest.Fields.UpdatedBy")]
        public int UpdatedBy { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.AcceptStockRequest.Fields.Deleted")]
        public bool Deleted { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.AcceptStockRequest.Fields.Approved")]

        public CustomerModel Requestor { get; set; }
        public CustomerModel Supervisor { get; set; }
        public StockRequestModel StockRequest { get; set; }
        public IList<StockRequestItemModel> StockRequestItems { get; set; }

        public IList<AcceptStockRequestLocalizedModel> Locales { get; set; }

        #endregion
    }

    public record AcceptStockRequestLocalizedModel : ILocalizedLocaleModel
    {
        public int LanguageId { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.AcceptStockRequest.Fields.Comment")]
        public string Comment { get; set; }
    }
}

