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
    /// Represents a stock request item entity builder
    /// </summary>
    public class StockRequestItemBuilder : NopEntityBuilder<StockRequestItem>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(StockRequestItem.StockRequestId)).AsInt32().NotNullable().ForeignKey<StockRequest>()
                .WithColumn(nameof(StockRequestItem.WarehouseProductCombinationId)).AsInt32().NotNullable()
                .WithColumn(nameof(StockRequestItem.UnitPrice)).AsDecimal().Nullable()
                .WithColumn(nameof(StockRequestItem.Tax)).AsDecimal().Nullable()
                .WithColumn(nameof(StockRequestItem.Discount)).AsDecimal().Nullable()
                .WithColumn(nameof(StockRequestItem.Profit)).AsDecimal().Nullable()
                .WithColumn(nameof(StockRequestItem.CreatedOnUtc)).AsNopDateTime2().Nullable()
                .WithColumn(nameof(StockRequestItem.UpdatedOnUtc)).AsNopDateTime2().Nullable()
                .WithColumn(nameof(StockRequestItem.CreatedBy)).AsInt32().Nullable()
                .WithColumn(nameof(StockRequestItem.UpdatedBy)).AsInt32().Nullable();
        }

        #endregion
    }
}