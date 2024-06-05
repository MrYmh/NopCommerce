using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Warehouses;
using Nop.Data.Extensions;


namespace Nop.Data.Mapping.Builders.Warehouses
{

    /// <summary>
    /// Represents a stock item history entity builder
    /// </summary>
    public class StockItemHistoryBuilder : NopEntityBuilder<StockItemHistory>
    {

        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(StockItemHistory.StockHistoryId)).AsInt32().NotNullable().ForeignKey<StockHistory>()
                .WithColumn(nameof(StockItemHistory.WarehouseProductCombinationId)).AsInt32().NotNullable()
                .WithColumn(nameof(StockItemHistory.UnitPrice)).AsDecimal().Nullable()
                .WithColumn(nameof(StockItemHistory.Tax)).AsDecimal().Nullable()
                .WithColumn(nameof(StockItemHistory.Discount)).AsDecimal().Nullable()
                .WithColumn(nameof(StockItemHistory.Profit)).AsDecimal().Nullable()
                .WithColumn(nameof(StockItemHistory.ExpirationDate)).AsNopDateTime2().Nullable()
                .WithColumn(nameof(StockItemHistory.CreatedOnUtc)).AsNopDateTime2().Nullable()
                .WithColumn(nameof(StockItemHistory.UpdatedOnUtc)).AsNopDateTime2().Nullable()
                .WithColumn(nameof(StockItemHistory.CreatedBy)).AsInt32().Nullable()
                .WithColumn(nameof(StockItemHistory.UpdatedBy)).AsInt32().Nullable();
        }

        #endregion
    }
}

