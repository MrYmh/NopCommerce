using System;
using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.Warehouses
{
    /// <summary>
    /// Captures detailed historical changes for specific stock items.
    /// </summary>
    public class StockItemHistoryMapping : BaseEntity, ISoftDeletedEntity
    {
        /// <summary>
        /// Gets or sets the unique identifier for the related stock history entry.
        /// </summary>
        public int StockItemHistoryId { get; set; }

        /// <summary>
        /// Gets or sets the identifier for the specific warehouse-product item.
        /// </summary>
        public int WarehouseItemId { get; set; }

        /// <summary>
        /// Gets or sets the stock process type.
        /// </summary>
        public StockProcess ProcessType { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the stock item history record was initially created, in Coordinated Universal Time (UTC).
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the stock item history record has been marked as deleted from the system.
        /// </summary>
        public bool Deleted { get; set; }
    }
}
