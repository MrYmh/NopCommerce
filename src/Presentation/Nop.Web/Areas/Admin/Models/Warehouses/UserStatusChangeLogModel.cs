using System;
using System.Collections.Generic;
using Nop.Core.Domain.Warehouses;
using Nop.Web.Areas.Admin.Models.Customers;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Web.Areas.Admin.Models.Warehouses
{
    /// <summary>
    /// Represents a user status change log model
    /// </summary>
    public record UserStatusChangeLogModel : BaseNopEntityModel, ILocalizedModel<UserStatusChangeLogLocalizedModel>
    {
        #region Ctor

        public UserStatusChangeLogModel()
        {
            User = new CustomerModel();
            Doer = new CustomerModel();
            Locales = new List<UserStatusChangeLogLocalizedModel>();
        }

        #endregion

        #region Properties

        [NopResourceDisplayName("Admin.Warehouses.UserStatusChangeLog.Fields.WarehouseId")]
        public int WarehouseId { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.UserStatusChangeLog.Fields.UserId")]
        public int UserId { get; set; }
        [NopResourceDisplayName("Admin.Warehouses.UserStatusChangeLog.Fields.ActionType")]
        public string ActionType { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.UserStatusChangeLog.Fields.Reason")]
        public string Reason { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.UserStatusChangeLog.Fields.ActionTakenBy")]
        public int ActionTakenBy { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.UserStatusChangeLog.Fields.ActionDateUtc")]
        public DateTime ActionDateUtc { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.UserStatusChangeLog.Fields.Deleted")]
        public bool Deleted { get; set; }

        public CustomerModel User { get; set; }
        public CustomerModel Doer { get; set; }

        public IList<UserStatusChangeLogLocalizedModel> Locales { get; set; }

        #endregion
    }

    public record UserStatusChangeLogLocalizedModel : ILocalizedLocaleModel
    {
        public int LanguageId { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.UserStatusChangeLog.Fields.Reason")]
        public string Reason { get; set; }
    }

}
