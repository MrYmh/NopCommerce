using System;
using Nop.Core.Domain.Common;
using Nop.Core.Domain.Localization;

namespace Nop.Core.Domain.Warehouses
{
    /// <summary>
    /// Manages the details of a warehouse shelf, including its location, identification, status, and lifecycle metadata.
    /// </summary>
    public class Shelf : BaseEntity, ISoftDeletedEntity, ILocalizedEntity
    {
        /// <summary>
        /// Gets or sets the unique identifier for the stand where the shelf is located.
        /// </summary>
        public int StandId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the warehouse.
        /// </summary>
        public int WarehouseId { get; set; }

        /// <summary>
        /// Gets or sets the barcode associated with the shelf, serving as a unique identifier.
        /// </summary>
        public string Barcode { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating whether the shelf is currently active and available for use in the system.
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the shelf record was initially created, in Coordinated Universal Time (UTC).
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the shelf record was last updated, in Coordinated Universal Time (UTC).
        /// </summary>
        public DateTime UpdatedOnUtc { get; set; }

        /// <summary>
        /// Gets or sets the user ID of the individual who initially created the shelf record.
        /// </summary>
        public int CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the user ID of the individual who last updated the shelf record.
        /// </summary>
        public int UpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the shelf record has been marked as deleted from the system.
        /// </summary>
        public bool Deleted { get; set; }
    }
}
