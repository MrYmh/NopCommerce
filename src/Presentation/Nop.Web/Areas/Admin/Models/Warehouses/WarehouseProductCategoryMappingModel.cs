using System;
using System.Collections.Generic;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Nop.Web.Areas.Admin.Models.Warehouses
{
    /// <summary>
    /// Represents a warehouse category mapping model
    /// </summary>
    public record WarehouseProductCategoryMappingModel : BaseNopEntityModel, ILocalizedModel<WarehouseProductCategoryMappingLocalizedModel>
    {
        #region Ctor

        public WarehouseProductCategoryMappingModel()
        {
            AvailableProductCategories = new List<SelectListItem>();
            AvailableMappedWarehouseCategories = new List<SelectListItem>();
            SelectedProductCategoriesIds = new List<int>();
            Locales = new List<WarehouseProductCategoryMappingLocalizedModel>();
        }

        #endregion

        #region Properties

        [NopResourceDisplayName("Admin.Warehouses.WarehouseProductCategoryMapping.Fields.WarehouseId")]
        public int WarehouseId { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseProductCategoryMapping.Fields.WarehouseCategoryMappingId")]
        public int WarehouseCategoryMappingId { get; set; }

        public string WarehouseCategoryName { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseProductCategoryMapping.Fields.ProductCategoryId")]
        public int ProductCategoryId { get; set; }

        public string ProductCategoryName { get; set; }


        [NopResourceDisplayName("Admin.Warehouses.WarehouseProductCategoryMapping.Fields.CreatedOnUtc")]
        public DateTime CreatedOnUtc { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseProductCategoryMapping.Fields.UpdatedOnUtc")]
        public DateTime UpdatedOnUtc { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseProductCategoryMapping.Fields.CreatedBy")]
        public int CreatedBy { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseProductCategoryMapping.Fields.UpdatedBy")]
        public int UpdatedBy { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseProductCategoryMapping.Fields.Deleted")]
        public bool Deleted { get; set; }
        public bool IsEditMode { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseProductCategoryMapping.Fields.AvailableProductCategories")]
        public IList<SelectListItem> AvailableProductCategories { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseProductCategoryMapping.Fields.AvailableMappedWarehouseCategories")]
        public IList<SelectListItem> AvailableMappedWarehouseCategories { get; set; }

        public IList<int> SelectedProductCategoriesIds { get; set; }

        public IList<WarehouseProductCategoryMappingLocalizedModel> Locales { get; set; }

        #endregion
    }

    public record WarehouseProductCategoryMappingLocalizedModel : ILocalizedLocaleModel
    {
        public int LanguageId { get; set; }
    }

}
