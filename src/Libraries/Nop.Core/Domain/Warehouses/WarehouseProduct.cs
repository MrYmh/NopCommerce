using System;
using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.Warehouses
{
    /// <summary>
    /// Represents a product stored within a warehouse, including its categorization, 
    /// identification, availability, and descriptive details.
    /// </summary>
    public class WarehouseProduct : BaseEntity, ISoftDeletedEntity
    {
        /// <summary>
        /// Gets or sets the identifier for the warehouse-product category mapping, linking the product to its warehouse-specific category.
        /// </summary>
        public int WarehouseProductCategoryMappingId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the product.
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating whether the product is currently available in the warehouse.
        /// </summary>
        public bool Available { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the warehouse where the product is stored.
        /// </summary>
        public int WarehouseId { get; set; }

        /// <summary>
        /// Gets or sets the name of the product.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a short description of the product, providing a quick overview.
        /// </summary>
        public string ShortDescription { get; set; }

        /// <summary>
        /// Gets or sets a full description of the product, offering detailed information.
        /// </summary>
        public string FullDescription { get; set; }

        /// <summary>
        /// Gets or sets the stock keeping unit (SKU) for the product, used for inventory tracking.
        /// </summary>
        public string Sku { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the product record was initially created, in Coordinated Universal Time (UTC).
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the product record was last updated, in Coordinated Universal Time (UTC).
        /// </summary>
        public DateTime UpdatedOnUtc { get; set; }

        /// <summary>
        /// Gets or sets the user ID of the individual who initially created the product record.
        /// </summary>
        public int CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the user ID of the individual who last updated the product record.
        /// </summary>
        public int UpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the product record has been marked as deleted from the system.
        /// </summary>
        public bool Deleted { get; set; }
    }
}
