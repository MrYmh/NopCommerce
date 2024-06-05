using System;
using System.Collections.Generic;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Web.Areas.Admin.Models.Shipping;

namespace Nop.Web.Areas.Admin.Models.Warehouses
{
    /// <summary>
    /// Represents a warehouse category mapping model
    /// </summary>
    public record WarehouseCategoryMappingModel : BaseNopEntityModel , ILocalizedModel<WarehouseCategoryMappingLocalizedModel>
    {
        #region Ctor

        public WarehouseCategoryMappingModel()
        {
            WarehouseModel = new WarehouseModel();
            WarehouseCategoryModel = new WarehouseCategoryModel();
            Locales = new List<WarehouseCategoryMappingLocalizedModel>();
            AvailableWarehouseCategories = new List<SelectListItem>();
            SelectedWarehouseCategoriesIds = new List<int>();
        }

        #endregion

        #region Properties

        [NopResourceDisplayName("Admin.Warehouses.WarehouseCategoryMapping.Fields.WarehouseId")]
        public int WarehouseId { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseCategoryMapping.Fields.WarehouseCategoryId")]
        public int WarehouseCategoryId { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseCategoryMapping.Fields.IsSystem")]
        public bool IsSystem { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseCategoryMapping.Fields.CreatedOnUtc")]
        public DateTime CreatedOnUtc { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseCategoryMapping.Fields.UpdatedOnUtc")]
        public DateTime UpdatedOnUtc { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseCategoryMapping.Fields.CreatedBy")]
        public int CreatedBy { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseCategoryMapping.Fields.UpdatedBy")]
        public int UpdatedBy { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseCategoryMapping.Fields.Deleted")]
        public bool Deleted { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseCategoryMapping.Fields.Name")]
        public string Name { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseCategoryMapping.Fields.Description")]
        public string Description { get; set; }

        public WarehouseCategoryModel WarehouseCategoryModel { get; set; }
        public WarehouseModel WarehouseModel { get; set; }

        public IList<SelectListItem> AvailableWarehouseCategories { get; set; }
        public IList<int> SelectedWarehouseCategoriesIds { get; set; }
        public IList<int> ExistedWarehouseCategoriesIds { get; set; }

        public IList<WarehouseCategoryMappingLocalizedModel> Locales { get; set; }

        #endregion
    }

    public record WarehouseCategoryMappingLocalizedModel : ILocalizedLocaleModel
    {
        public int LanguageId { get; set; }
    }

}
