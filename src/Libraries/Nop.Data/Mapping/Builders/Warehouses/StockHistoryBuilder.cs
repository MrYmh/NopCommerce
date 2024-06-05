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
    /// Represents a stock history entity builder
    /// </summary>
    public class StockHistoryBuilder : NopEntityBuilder<StockHistory>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(StockHistory.WarehouseId)).AsInt32().NotNullable().ForeignKey<Warehouse>()
                .WithColumn(nameof(StockHistory.VendorId)).AsInt32().Nullable()
                .WithColumn(nameof(StockHistory.Priority)).AsInt32().Nullable()
                .WithColumn(nameof(StockHistory.RequestId)).AsInt32().Nullable()
                .WithColumn(nameof(StockHistory.CreatedOnUtc)).AsNopDateTime2().Nullable()
                .WithColumn(nameof(StockHistory.UpdatedOnUtc)).AsNopDateTime2().Nullable()
                .WithColumn(nameof(StockHistory.CreatedBy)).AsInt32().Nullable()
                .WithColumn(nameof(StockHistory.UpdatedBy)).AsInt32().Nullable();
        }

        #endregion
    }
}