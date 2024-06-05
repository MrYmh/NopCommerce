using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Web.Areas.Admin.Models.Warehouses
{
    /// <summary>
    /// Represents a stock request search model
    /// </summary>
    public record UserStatusChangeLogSearchModel : BaseSearchModel
    {
        #region Ctor

        public UserStatusChangeLogSearchModel()
        {
        }

        #endregion

        #region Properties

        [NopResourceDisplayName("Admin.Warehouses.UserStatusChangeLog.List.WarehouseId")]
        public int WarehouseId { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.UserStatusChangeLog.List.UserId")]
        public int UserId { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.UserStatusChangeLog.List.UserId")]
        public string UserName { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.UserStatusChangeLog.List.ActionType")]
        public string ActionType { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.UserStatusChangeLog.List.ActionTakenBy")]
        public int ActionTakenBy { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.UserStatusChangeLog.List.ActionTakenBy")]
        public string DoerName { get; set; }

        #endregion
    }

}
