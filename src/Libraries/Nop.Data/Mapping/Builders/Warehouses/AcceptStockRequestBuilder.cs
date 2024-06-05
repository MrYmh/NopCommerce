using System;
using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Common;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Shipping;
using Nop.Core.Domain.Stores;
using Nop.Core.Domain.Warehouses;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Warehouses
{

    /// <summary>
    /// Represents a accept stock request entity builder
    /// </summary>
    public class AcceptStockRequestBuilder : NopEntityBuilder<AcceptStockRequest>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(AcceptStockRequest.RequestorId)).AsInt32().NotNullable()
                .WithColumn(nameof(AcceptStockRequest.StockRequestId)).AsInt32().NotNullable().ForeignKey<StockRequest>()
                .WithColumn(nameof(AcceptStockRequest.ActionTakenBy)).AsInt32().NotNullable()
                .WithColumn(nameof(AcceptStockRequest.WarehouseId)).AsInt32().NotNullable()
                .WithColumn(nameof(AcceptStockRequest.CreatedOnUtc)).AsNopDateTime2().Nullable()
                .WithColumn(nameof(AcceptStockRequest.UpdatedOnUtc)).AsNopDateTime2().Nullable()
                .WithColumn(nameof(AcceptStockRequest.CreatedBy)).AsInt32().Nullable()
                .WithColumn(nameof(AcceptStockRequest.UpdatedBy)).AsInt32().Nullable();
        }

        #endregion
    }
}
