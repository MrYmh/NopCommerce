using System;
using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.Warehouses
{
    /// <summary>
    /// Links items to their specific storage locations on shelves. 
    /// </summary>
    public class ShelfItemMapping : BaseEntity, ISoftDeletedEntity
    {
        /// <summary>
        /// Gets or sets the unique identifier for the shelf where the item is stored.
        /// </summary>
        public int ShelfId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the item stored on the shelf.
        /// </summary>
        public int ItemId { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the item-shelf mapping was initially created, in Coordinated Universal Time (UTC).
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the item-shelf mapping was last updated, in Coordinated Universal Time (UTC).
        /// </summary>
        public DateTime UpdatedOnUtc { get; set; }

        /// <summary>
        /// Gets or sets the user ID of the individual who initially created the mapping instance.
        /// </summary>
        public int CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the user ID of the individual who last updated the mapping instance.
        /// </summary>
        public int UpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the mapping has been marked as deleted from the system.
        /// </summary>
        public bool Deleted { get; set; }
    }
}
