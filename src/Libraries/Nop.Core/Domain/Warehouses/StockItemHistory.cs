using System;
using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.Warehouses
{
    /// <summary>
    /// Captures detailed historical changes for specific stock items, including quantity and financial adjustments. 
    /// This class is linked to general stock history and tracks changes at the item level, 
    /// including pricing, taxes, discounts, and profits, to provide a comprehensive view of stock management over time.
    /// </summary>
    public class StockItemHistory : BaseEntity, ISoftDeletedEntity
    {
        /// <summary>
        /// Gets or sets the unique identifier for the related stock history entry.
        /// </summary>
        public int StockHistoryId { get; set; }

        /// <summary>
        /// Gets or sets the identifier for the specific warehouse-product combination, linking the item to a unique warehouse product combination.
        /// </summary>
        public int WarehouseProductCombinationId { get; set; }

        /// <summary>
        /// Gets or sets the quantity of stock for this specific entry, reflecting additions, subtractions, or adjustments.
        /// </summary>
        public int StockQuantity { get; set; }

        /// <summary>
        /// Gets or sets the unit price of the stock item at the time of the stock history entry.
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Gets or sets the tax amount applied to the stock item, which can affect the overall cost calculations.
        /// </summary>
        public decimal Tax { get; set; }

        /// <summary>
        /// Gets or sets the discount amount applied to the stock item, reflecting any reductions in price.
        /// </summary>
        public decimal Discount { get; set; }

        /// <summary>
        /// Gets or sets the profit calculated for the stock item, factoring in the unit price, tax, and discount.
        /// </summary>
        public decimal Profit { get; set; }

        /// <summary>
        /// Gets or sets a description of the stock item for easier identification.
        /// </summary>
        public string ItemDescription { get; set; }

        /// <summary>
        /// Gets or sets a Sku value.
        /// </summary>
        public string Sku { get; set; }

        /// <summary>
        /// Gets or sets Has Expiration Date flag.
        /// </summary>
        public bool HasExpirationDate { get; set; }

        /// <summary>
        /// Gets or sets a Expiration Date.
        /// </summary>
        public DateTime? ExpirationDate { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the stock item history record was initially created, in Coordinated Universal Time (UTC).
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the stock item history record was last updated, in Coordinated Universal Time (UTC).
        /// </summary>
        public DateTime UpdatedOnUtc { get; set; }

        /// <summary>
        /// Gets or sets the user ID of the individual who initially created the stock item history record.
        /// </summary>
        public int CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the user ID of the individual who last updated the stock item history record.
        /// </summary>
        public int UpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the stock item history record has been marked as deleted from the system.
        /// </summary>
        public bool Deleted { get; set; }
    }
}
