using System;
using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.Warehouses
{
    /// <summary>
    /// Represents an individual item within a stock request, 
    /// detailing its association with specific warehouse product combinations, 
    /// quantities involved, and financial implications like pricing, taxes, discounts, and profits. 
    /// </summary>
    public class StockRequestItem : BaseEntity, ISoftDeletedEntity
    {
        /// <summary>
        /// Gets or sets the unique identifier for the related stock request.
        /// </summary>
        public int StockRequestId { get; set; }

        /// <summary>
        /// Gets or sets the identifier for the warehouse-product combination.
        /// </summary>
        public int WarehouseProductCombinationId { get; set; }

        /// <summary>
        /// Gets or sets the quantity of stock requested for this item.
        /// </summary>
        public int StockQuantity { get; set; }

        /// <summary>
        /// Gets or sets the unit price for the stock item at the time of the request.
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Gets or sets the tax amount applicable to the stock item.
        /// </summary>
        public decimal Tax { get; set; }

        /// <summary>
        /// Gets or sets the discount amount applicable to the stock item.
        /// </summary>
        public decimal Discount { get; set; }

        /// <summary>
        /// Gets or sets a Sku value.
        /// </summary>
        public string Sku { get; set; }

        /// <summary>
        /// Gets or sets the profit calculated for the stock item, considering the unit price, tax, and discount.
        /// </summary>
        public decimal Profit { get; set; }

        /// <summary>
        /// Gets or sets a description of the stock item for easier identification.
        /// </summary>
        public string ItemDescription { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the stock request item was initially created, in Coordinated Universal Time (UTC).
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the stock request item was last updated, in Coordinated Universal Time (UTC).
        /// </summary>
        public DateTime UpdatedOnUtc { get; set; }

        /// <summary>
        /// Gets or sets the user ID of the individual who initially created the stock request item.
        /// </summary>
        public int CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the user ID of the individual who last updated the stock request item.
        /// </summary>
        public int UpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the stock request item has been marked as deleted from the system.
        /// </summary>
        public bool Deleted { get; set; }
    }
}
