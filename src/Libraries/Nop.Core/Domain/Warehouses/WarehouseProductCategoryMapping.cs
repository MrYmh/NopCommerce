using System;
using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.Warehouses
{
    /// <summary>
    /// Establishes a mapping between warehouse categories and product categories.
    /// </summary>
    public class WarehouseProductCategoryMapping : BaseEntity, ISoftDeletedEntity
    {
        /// <summary>
        /// Gets or sets the identifier for the warehouse.
        /// </summary>
        public int WarehouseId { get; set; }

        /// <summary>
        /// Gets or sets the identifier for the warehouse category mapping, linking warehouse-specific categories.
        /// </summary>
        public int WarehouseCategoryMappingId { get; set; }

        /// <summary>
        /// Gets or sets the identifier for the product category, enabling products to be categorized within the warehouse environment.
        /// </summary>
        public int ProductCategoryId { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the mapping record was initially created, in Coordinated Universal Time (UTC).
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the mapping record was last updated, in Coordinated Universal Time (UTC).
        /// </summary>
        public DateTime UpdatedOnUtc { get; set; }

        /// <summary>
        /// Gets or sets the user ID of the individual who initially created the category mapping.
        /// </summary>
        public int CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the user ID of the individual who last updated the category mapping.
        /// </summary>
        public int UpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the category mapping has been marked as deleted, allowing for soft deletion where records are retained but not actively used.
        /// </summary>
        public bool Deleted { get; set; }
    }
}
