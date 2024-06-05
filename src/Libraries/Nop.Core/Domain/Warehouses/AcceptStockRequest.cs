using System;
using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.Warehouses
{
    /// <summary>
    /// Manages the acceptance or rejection of stock requests, encompassing the essential details and outcomes of each request. 
    /// It tracks the initial requestor, the action taken, the status, and type of the request, 
    /// enabling clear decision-making processes within inventory management.
    /// </summary>
    public class AcceptStockRequest : BaseEntity, ISoftDeletedEntity
    {
        /// <summary>
        /// Gets or sets the unique identifier for the user who initially created the stock request.
        /// </summary>
        public int RequestorId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the stock request. This is used to reference the specific request being accepted or rejected.
        /// </summary>
        public int StockRequestId { get; set; }

        /// <summary>
        /// Gets or sets the status of the stock request, represented as an integer. This status can indicate various states such as accepted, rejected, etc.
        /// </summary>
        public bool Accepted { get; set; }

        /// <summary>
        /// Gets or sets the type of the stock request, identified by an integer. Different types can represent different kinds of requests, such as additions, returns, or adjustments.
        /// </summary>
        public int RequestType { get; set; }

        /// <summary>
        /// Gets or sets comments or notes attached to the stock request. This can include reasons for rejection or any other relevant information.
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Gets or sets the user ID of the individual who takes the final action (accept or reject) on the stock request.
        /// </summary>
        public int ActionTakenBy { get; set; }

        /// <summary>
        /// Gets or sets the warehouse id.
        /// </summary>
        public int WarehouseId { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the stock request was initially created, in Coordinated Universal Time (UTC).
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the stock request was last updated, in Coordinated Universal Time (UTC).
        /// </summary>
        public DateTime UpdatedOnUtc { get; set; }

        /// <summary>
        /// Gets or sets the user ID of the individual who originally created the stock request instance.
        /// </summary>
        public int CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the user ID of the individual who last updated the stock request instance.
        /// </summary>
        public int UpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the stock request entity has been marked as deleted.
        /// </summary>
        public bool Deleted { get; set; }
    }
}
