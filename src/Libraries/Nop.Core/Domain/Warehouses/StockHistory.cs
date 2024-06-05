using System;
using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.Warehouses
{
    /// <summary>
    /// Records and tracks historical changes to stock within a warehouse, 
    /// detailing the nature of stock movements, associated vendors, and the warehouse context. 
    /// This includes additions, subtractions, damages, and orders, providing a comprehensive view of inventory adjustments over time.
    /// </summary>
    public class StockHistory : BaseEntity, ISoftDeletedEntity
    {
        /// <summary>
        /// Gets or sets the unique identifier for the warehouse where the stock change occurred.
        /// </summary>
        public int WarehouseId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the vendor associated with the stock movement.
        /// </summary>
        public int VendorId { get; set; }

        /// <summary>
        /// Gets or sets the type of process that the stock underwent, such as addition, subtraction, damage, or ordering.
        /// </summary>
        public int TypeOfProcess { get; set; }

        /// <summary>
        /// Gets or sets the priority level of the stock request, aiding in its management and fulfillment.
        /// </summary>
        public int Priority { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the request associated with the stock.
        /// </summary>
        public int? RequestId { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the stock history record was initially created, in Coordinated Universal Time (UTC).
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the stock history record was last updated, in Coordinated Universal Time (UTC).
        /// </summary>
        public DateTime UpdatedOnUtc { get; set; }

        /// <summary>
        /// Gets or sets the user ID of the individual who initially created the stock history record.
        /// </summary>
        public int CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the user ID of the individual who last updated the stock history record.
        /// </summary>
        public int UpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the stock history record has been marked as deleted from the system.
        /// </summary>
        public bool Deleted { get; set; }
    }
}
