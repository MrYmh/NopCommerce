using System;
using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Common;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Warehouses;
using Nop.Data.Extensions;


namespace Nop.Data.Mapping.Builders.Warehouses
{

    /// <summary>
    /// Represents a stock item history mapping entity builder
    /// </summary>
    public class StockItemHistoryMappingBuilder : NopEntityBuilder<StockItemHistoryMapping>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(StockItemHistoryMapping.StockItemHistoryId)).AsInt32().NotNullable().ForeignKey<StockItemHistory>()
                .WithColumn(nameof(StockItemHistoryMapping.WarehouseItemId)).AsInt32().NotNullable();
        }

        #endregion
    }
}