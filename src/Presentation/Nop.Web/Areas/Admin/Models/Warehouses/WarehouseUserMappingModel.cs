using System;
using System.Collections.Generic;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Web.Areas.Admin.Models.Warehouses
{

    /// <summary>
    /// Represents a warehouse user mapping model
    /// </summary>
    public record WarehouseUserMappingModel : BaseNopEntityModel, ILocalizedModel<WarehouseUserMappingLocalizedModel>
    {
        #region Ctor

        public WarehouseUserMappingModel()
        {
            Locales = new List<WarehouseUserMappingLocalizedModel>();
        }

        #endregion

        #region Properties

        [NopResourceDisplayName("Admin.Warehouses.WarehouseUserMapping.Fields.WarehouseId")]
        public int WarehouseId { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseUserMapping.Fields.UserId")]
        public int UserId { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseUserMapping.Fields.IsActive")]
        public bool IsActive { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseUserMapping.Fields.IsBlocked")]
        public bool IsBlocked { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseUserMapping.Fields.BlockReason")]
        public string BlockReason { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseUserMapping.Fields.BlockedOnUtc")]
        public DateTime BlockedOnUtc { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseUserMapping.Fields.CreatedOnUtc")]
        public DateTime CreatedOnUtc { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseUserMapping.Fields.UpdatedOnUtc")]
        public DateTime UpdatedOnUtc { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseUserMapping.Fields.CreatedBy")]
        public int CreatedBy { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseUserMapping.Fields.UpdatedBy")]
        public int UpdatedBy { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseUserMapping.Fields.Deleted")]
        public bool Deleted { get; set; }

        public IList<WarehouseUserMappingLocalizedModel> Locales { get; set; }

        #endregion
    }

    public record WarehouseUserMappingLocalizedModel : ILocalizedLocaleModel
    {
        public int LanguageId { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseUserMapping.Fields.BlockReason")]
        public string BlockReason { get; set; }
    }
}
