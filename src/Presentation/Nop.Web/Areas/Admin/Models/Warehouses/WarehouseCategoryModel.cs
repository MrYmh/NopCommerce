using System;
using Nop.Web.Areas.Admin.Models.Catalog;
using System.Collections.Generic;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Nop.Web.Areas.Admin.Models.Warehouses
{
    /// <summary>
    /// Represents a warehouse category model
    /// </summary>
    public record WarehouseCategoryModel : BaseNopEntityModel , ILocalizedModel<WarehouseCategoryLocalizedModel>
    {
        #region Ctor

        public WarehouseCategoryModel()
        {
            AvailableWarehouseCategories = new List<SelectListItem>();
            Locales = new List<WarehouseCategoryLocalizedModel>();
        }

        #endregion

        #region Properties

        [NopResourceDisplayName("Admin.Warehouses.WarehouseCategory.Fields.Name")]
        public string Name { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseCategory.Fields.Description")]
        public string Description { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseCategory.Fields.ParentCategoryId")]
        public int ParentCategoryId { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseCategory.Fields.DisplayOrder")]
        public int DisplayOrder { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseCategory.Fields.IsSystem")]
        public bool IsSystem { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseCategory.Fields.CreatedOnUtc")]
        public DateTime CreatedOnUtc { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseCategory.Fields.UpdatedOnUtc")]
        public DateTime UpdatedOnUtc { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseCategory.Fields.CreatedBy")]
        public int CreatedBy { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseCategory.Fields.UpdatedBy")]
        public int UpdatedBy { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseCategory.Fields.Deleted")]
        public bool Deleted { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseCategory.Fields.AvailableWarehouseCategories")]
        public IList<SelectListItem> AvailableWarehouseCategories { get; set; }

        public IList<WarehouseCategoryLocalizedModel> Locales { get; set; }

        #endregion
    }

    public record WarehouseCategoryLocalizedModel : ILocalizedLocaleModel
    {
        public int LanguageId { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseCategory.Fields.Name")]
        public string Name { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseCategory.Fields.Description")]
        public string Description { get; set; }

    }

}
