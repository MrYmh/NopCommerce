using Nop.Core.Domain.Warehouses;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Web.Areas.Admin.Models.Warehouses
{
    /// <summary>
    /// Represents a stock request search model
    /// </summary>
    public record StockRequestSearchModel : BaseSearchModel
    {
        #region Ctor

        public StockRequestSearchModel()
        {
        }

        #endregion

        #region Properties
        [NopResourceDisplayName("Admin.Warehouses.StockRequest.List.StockRequestId")]
        public string StockRequestId { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.StockRequest.List.WarehouseId")]
        public int WarehouseId { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.StockRequest.List.VendorId")]
        public string VendorName { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.StockRequest.List.TypeOfProcess")]
        public string TypeOfProcess { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.StockRequest.List.Priority")]
        public int Priority { get; set; }

        #endregion
    }

}
