using System;
using Nop.Core.Domain.Common;
using Nop.Core.Domain.Localization;

namespace Nop.Core.Domain.Warehouses
{
    /// <summary>
    /// Represents a category within the warehouse.
    /// </summary>
    public class WarehouseCategory : BaseEntity, ISoftDeletedEntity, ILocalizedEntity
    {
        /// <summary>
        /// Gets or sets the name of the category.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a detailed description of the category's purpose or contents.
        /// </summary>
        public string Description { get; set; }


        /// <summary>
        /// Gets or sets the identifier for the parent category, enabling a hierarchical organization structure. A value of 0 typically indicates a top-level category.
        /// </summary>
        public int ParentCategoryId { get; set; }

        /// <summary>
        /// Gets or sets the display order of the category within its hierarchical level, determining the sequence categories appear.
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating whether the category is a system-defined category (true) or user-defined (false).
        /// </summary>
        public bool IsSystem { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the category was initially created, in Coordinated Universal Time (UTC).
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the category was last updated, in Coordinated Universal Time (UTC).
        /// </summary>
        public DateTime UpdatedOnUtc { get; set; }

        /// <summary>
        /// Gets or sets the user ID of the individual who initially created the category.
        /// </summary>
        public int CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the user ID of the individual who last updated the category.
        /// </summary>
        public int UpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the category has been marked as deleted from the system.
        /// </summary>
        public bool Deleted { get; set; }
    }
}
