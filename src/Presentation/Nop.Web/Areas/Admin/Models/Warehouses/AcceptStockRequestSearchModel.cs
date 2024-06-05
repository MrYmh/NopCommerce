using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Web.Areas.Admin.Models.Warehouses
{
    /// <summary>
    /// Represents a accept stock request search model
    /// </summary>
    public record AcceptStockRequestSearchModel : BaseSearchModel
    {
        #region Ctor

        public AcceptStockRequestSearchModel()
        {
        }

        #endregion

        #region Properties

        [NopResourceDisplayName("Admin.Warehouses.AcceptStockRequest.List.SearchProductCategoryId")]
        public int SearchProductCategoryId { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.AcceptStockRequest.List.SearchProductCategoryId")]
        public string SearchProductCategoryName { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.AcceptStockRequest.List.RequestorId")]
        public int RequestorId { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.AcceptStockRequest.List.RequestorId")]
        public string RequestorName { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.AcceptStockRequest.List.StockRequestId")]
        public string StockRequestId { get; set; } // --> request id

        [NopResourceDisplayName("Admin.Warehouses.AcceptStockRequest.List.Approved")]
        public string Approved { get; set; }  // --> approved

        [NopResourceDisplayName("Admin.Warehouses.AcceptStockRequest.List.RequestType")]
        public string RequestType { get; set; } // --> type

        [NopResourceDisplayName("Admin.Warehouses.AcceptStockRequest.List.RequestType")]
        public int RequestTypeName { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.AcceptStockRequest.List.ActionTakenBy")]
        public int ActionTakenBy { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.AcceptStockRequest.List.ActionTakenBy")]
        public string SupervisorName { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.AcceptStockRequest.List.WarehouseId")]
        public int WarehouseId { get; set; }

        #endregion
    }

}
