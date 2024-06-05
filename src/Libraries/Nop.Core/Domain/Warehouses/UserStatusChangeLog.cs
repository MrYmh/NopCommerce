using System;

namespace Nop.Core.Domain.Warehouses
{
    /// <summary>
    /// Records and tracks changes in the status of warehouse employees within the warehouse management system.
    /// </summary>
    public class UserStatusChangeLog : BaseEntity
    {

        /// <summary>
        /// Gets or sets the unique identifier for the warehouse.
        /// </summary>
        public int WarehouseId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the warehouse user (employee) whose status has changed.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the type of action performed on the user's status, such as "Blocked" or "Unblocked".
        /// </summary>
        public string ActionType { get; set; }

        /// <summary>
        /// Gets or sets the reason provided for the status change, offering context and justification for the action taken.
        /// </summary>
        public string Reason { get; set; }

        /// <summary>
        /// Gets or sets the user ID of the administrator or manager who performed the block or unblock action.
        /// </summary>
        public int ActionTakenBy { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the action was taken, recorded in Coordinated Universal Time (UTC). This timestamp is crucial for auditing and compliance purposes.
        /// </summary>
        public DateTime ActionDateUtc { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the user status change log has been marked as deleted from the system.
        /// </summary>
        public bool Deleted { get; set; }
    }


}
