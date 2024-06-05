using System;
using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Common;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Warehouses;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Warehouses
{

    /// <summary>
    /// Represents a shelf item mapping entity builder
    /// </summary>
    public class ShelfItemMappingBuilder : NopEntityBuilder<ShelfItemMapping>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(ShelfItemMapping.ShelfId)).AsInt32().NotNullable().ForeignKey<Shelf>()
                .WithColumn(nameof(ShelfItemMapping.ItemId)).AsInt32().NotNullable()
                .WithColumn(nameof(ShelfItemMapping.CreatedOnUtc)).AsNopDateTime2().Nullable()
                .WithColumn(nameof(ShelfItemMapping.UpdatedOnUtc)).AsNopDateTime2().Nullable()
                .WithColumn(nameof(ShelfItemMapping.CreatedBy)).AsInt32().Nullable()
                .WithColumn(nameof(ShelfItemMapping.UpdatedBy)).AsInt32().Nullable();
        }

        #endregion
    }
}