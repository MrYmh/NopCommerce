using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Shipping;
using Nop.Core.Domain.Warehouses;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Warehouses
{

    /// <summary>
    /// Represents a stock request entity builder
    /// </summary>
    public class StockRequestBuilder : NopEntityBuilder<StockRequest>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(StockRequest.WarehouseId)).AsInt32().NotNullable().ForeignKey<Warehouse>()
                .WithColumn(nameof(StockRequest.VendorId)).AsInt32().Nullable()
                .WithColumn(nameof(StockRequest.CreatedOnUtc)).AsNopDateTime2().Nullable()
                .WithColumn(nameof(StockRequest.UpdatedOnUtc)).AsNopDateTime2().Nullable()
                .WithColumn(nameof(StockRequest.CreatedBy)).AsInt32().Nullable()
                .WithColumn(nameof(StockRequest.UpdatedBy)).AsInt32().Nullable();
        }

        #endregion
    }
}
