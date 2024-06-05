using System;
using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.Warehouses
{
    /// <summary>
    /// Represents a specific combination of product attributes within a warehouse.
    /// </summary>
    public class WarehouseProductCombination : BaseEntity, ISoftDeletedEntity
    {
        /// <summary>
        /// Gets or sets the identifier for the warehouse where the product combination is located.
        /// </summary>
        public int WarehouseId { get; set; }

        /// <summary>
        /// Gets or sets the identifier for the warehouse-specific product associated with this combination.
        /// </summary>
        public int WarehouseProductId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for this specific combination of product attributes.
        /// </summary>
        public int CombinationId { get; set; }

        /// <summary>
        /// Gets or sets the XML representation of the product attributes that define this combination.
        /// </summary>
        public string AttributesXml { get; set; }

        /// <summary>
        /// Gets or sets the total quantity of this product combination available in the warehouse.
        /// </summary>
        public int TotalQuantity { get; set; }

        /// <summary>
        /// Gets or sets the total damaged quantity of this product combination in the warehouse.
        /// </summary>
        public int DamagedQuantity { get; set; }

        /// <summary>
        /// Gets or sets the total damaged quantity of this product combination in the warehouse.
        /// </summary>
        public int ReturnedToVendorQuantity { get; set; }

        //      50,            5,             10,           35 
        // total price, affiliate price, system price, vendor price

        /// <summary>
        /// Gets or sets the stock keeping unit (SKU) for this product combination, used for inventory tracking.
        /// </summary>
        public string Sku { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating whether this product combination is currently available for sale or distribution.
        /// </summary>
        public bool Available { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the product combination was initially created, in Coordinated Universal Time (UTC).
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the product combination was last updated, in Coordinated Universal Time (UTC).
        /// </summary>
        public DateTime UpdatedOnUtc { get; set; }

        /// <summary>
        /// Gets or sets the user ID of the individual who initially created the product combination.
        /// </summary>
        public int CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the user ID of the individual who last updated the product combination.
        /// </summary>
        public int UpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the product combination has been marked as deleted from the system.
        /// </summary>
        public bool Deleted { get; set; }
    }
}
