using System;
using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.Warehouses
{
    /// <summary>
    /// Represents an individual item within the warehouse.
    /// </summary>
    public class WarehouseItem : BaseEntity, ISoftDeletedEntity
    {
        /// <summary>
        /// Gets or sets the entity identifier
        /// </summary>
        //public new decimal Id { get; set; }

        /// <summary>
        /// Gets or sets the identifier for the warehouse-product combination, detailing the specific product and its warehouse location.
        /// </summary>
        public int WarehouseProductCombinationId { get; set; }

        /// <summary>
        /// Gets or sets the stock keeping unit (SKU), a unique identifier for the product within the warehouse.
        /// </summary>
        public string Sku { get; set; }

        /// <summary>
        /// Gets or sets the barcode for the item, used for scanning and inventory management.
        /// </summary>
        public string Barcode { get; set; }

        /// <summary>
        /// Gets or sets the status of the item within the warehouse, such as ordered, reserved, available, or damaged.
        /// </summary>
        public int ItemStatus { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating whether the item is received.
        /// </summary>
        public bool Received { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating whether the item's label has been printed.
        /// </summary>
        public bool Printed { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating whether the item has been scanned for inventory tracking or processing.
        /// </summary>
        public bool Scanned { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating whether the item has been linked to a shelf.
        /// </summary>
        public bool MappedToShelf { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating whether the item returned to the vendor.
        /// </summary>
        public bool ReturnedToVendor { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating whether the item returned from a client.
        /// </summary>
        public bool ReturnedFromClient { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating whether the item is damaged.
        /// </summary>
        public bool Damaged { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating whether the item has been ordered by customers or for restocking purposes.
        /// </summary>
        public bool Ordered { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating whether the item has an expiration date.
        /// </summary>
        public bool HasExpirationDate { get; set; }

        /// <summary>
        /// Gets or sets the expiration date of the item. This field is relevant only if HasExpirationDate is true.
        /// </summary>
        public DateTime? ExpirationDate { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the warehouse.
        /// </summary>
        public int WarehouseId { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the item record was initially created, in Coordinated Universal Time (UTC).
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the item record was last updated, in Coordinated Universal Time (UTC).
        /// </summary>
        public DateTime UpdatedOnUtc { get; set; }

        /// <summary>
        /// Gets or sets the user ID of the individual who initially created the item record.
        /// </summary>
        public int CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the user ID of the individual who last updated the item record.
        /// </summary>
        public int UpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the item record has been marked as deleted from the system.
        /// </summary>
        public bool Deleted { get; set; }
    }

    public enum ItemStatus
    {
        Received = 1,
        Printed,
        Scanned,
        Ordered,
        Expired,
        ReturnedFromClient,
        ReturnedToTheVendor,
        Damaged

    }
}
