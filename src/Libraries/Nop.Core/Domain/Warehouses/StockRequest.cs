using System;
using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.Warehouses
{
    /// <summary>
    /// Manages requests for stock transactions within a warehouse.
    /// </summary>
    public class StockRequest : BaseEntity, ISoftDeletedEntity
    {
        /// <summary>
        /// Gets or sets the unique identifier for the warehouse where the stock transaction is requested.
        /// </summary>
        public int WarehouseId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the vendor associated with the stock transaction.
        /// </summary>
        public int VendorId { get; set; }

        /// <summary>
        /// Gets or sets the type of stock transaction being requested, such as addition, subtraction, damage report, or order.
        /// </summary>
        public int TypeOfProcess { get; set; }

        /// <summary>
        /// Gets or sets the priority level of the stock request, aiding in its management and fulfillment.
        /// </summary>
        public int Priority { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the stock request was initially created, in Coordinated Universal Time (UTC).
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the stock request was last updated, in Coordinated Universal Time (UTC).
        /// </summary>
        public DateTime UpdatedOnUtc { get; set; }

        /// <summary>
        /// Gets or sets the user ID of the individual who initially created the stock request.
        /// </summary>
        public int CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the user ID of the individual who last updated the stock request.
        /// </summary>
        public int UpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the stock request has been marked as deleted from the system.
        /// </summary>
        public bool Deleted { get; set; }
        public bool Reviewed { get; set; }
    }
}
