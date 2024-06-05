using System;
using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Common;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Shipping;
using Nop.Core.Domain.Warehouses;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Warehouses
{

    /// <summary>
    /// Represents a warehouse item entity builder
    /// </summary>
    public class WarehouseItemBuilder : NopEntityBuilder<WarehouseItem>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(WarehouseItem.WarehouseId)).AsInt32().NotNullable().ForeignKey<Warehouse>()
                .WithColumn(nameof(WarehouseItem.WarehouseProductCombinationId)).AsInt32().NotNullable()
                .WithColumn(nameof(WarehouseItem.Sku)).AsString(400).Nullable()
                .WithColumn(nameof(WarehouseItem.ExpirationDate)).AsNopDateTime2().Nullable()
                .WithColumn(nameof(WarehouseItem.CreatedOnUtc)).AsNopDateTime2().Nullable()
                .WithColumn(nameof(WarehouseItem.UpdatedOnUtc)).AsNopDateTime2().Nullable()
                .WithColumn(nameof(WarehouseItem.CreatedBy)).AsInt32().Nullable()
                .WithColumn(nameof(WarehouseItem.UpdatedBy)).AsInt32().Nullable();
        }

        #endregion
    }
}