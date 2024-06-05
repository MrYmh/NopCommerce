using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Web.Areas.Admin.Models.Warehouses
{
    /// <summary>
    /// Represents a warehouse product model
    /// </summary>
    public record WarehouseProductModel : BaseNopEntityModel, ILocalizedModel<WarehouseProductLocalizedModel>
    {
        #region Ctor

        public WarehouseProductModel()
        {
            WarehouseProductCombinationModels = new List<WarehouseProductCombinationModel>();
            AvailableWarehouseProductCategoryMappingIds = new List<SelectListItem>();
            Locales = new List<WarehouseProductLocalizedModel>();
        }

        #endregion

        #region Properties

        [NopResourceDisplayName("Admin.Warehouses.WarehouseProduct.Fields.WarehouseProductCategoryMappingId")]
        public int WarehouseProductCategoryMappingId { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseProduct.Fields.ProductId")]
        public int ProductId { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseProduct.Fields.Available")]
        public bool Available { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseProduct.Fields.WarehouseId")]
        public int WarehouseId { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseProduct.Fields.Name")]
        public string Name { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseProduct.Fields.ShortDescription")]
        public string ShortDescription { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseProduct.Fields.FullDescription")]
        public string FullDescription { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseProduct.Fields.Sku")]
        public string Sku { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseProduct.Fields.CreatedOnUtc")]
        public DateTime CreatedOnUtc { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseProduct.Fields.UpdatedOnUtc")]
        public DateTime UpdatedOnUtc { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseProduct.Fields.CreatedBy")]
        public int CreatedBy { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseProduct.Fields.UpdatedBy")]
        public int UpdatedBy { get; set; }

        [NopResourceDisplayName("Admin.Warehouses.WarehouseProduct.Fields.Deleted")]
        public bool Deleted { get; set; }

        public int WarehouseCategoryMappingId { get; set; }

        public IList<WarehouseProductCombinationModel> WarehouseProductCombinationModels { get; set; }

        public IList<SelectListItem> AvailableWarehouseProductCategoryMappingIds { get; set; }
        public IList<SelectListItem> AvailableWarehouseProductIds { get; set; }
        

        public IList<WarehouseProductLocalizedModel> Locales { get; set; }

        #endregion
    }

    public record WarehouseProductLocalizedModel : ILocalizedLocaleModel
    {
        public int LanguageId { get; set; }
    }

}
