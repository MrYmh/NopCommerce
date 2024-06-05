using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Shipping;
using Nop.Core.Domain.Warehouses;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Warehouses
{
    /// <summary>
    /// Represents a warehouse stand entity builder
    /// </summary>
    public class WarehouseStandBuilder : NopEntityBuilder<WarehouseStand>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(WarehouseStand.WarehouseId)).AsInt32().NotNullable().ForeignKey<Warehouse>()
                .WithColumn(nameof(WarehouseStand.MaterialType)).AsString(1000).NotNullable()
                .WithColumn(nameof(WarehouseStand.CreatedOnUtc)).AsNopDateTime2().Nullable()
                .WithColumn(nameof(WarehouseStand.UpdatedOnUtc)).AsNopDateTime2().Nullable()
                .WithColumn(nameof(WarehouseStand.CreatedBy)).AsInt32().Nullable()
                .WithColumn(nameof(WarehouseStand.UpdatedBy)).AsInt32().Nullable();
        }

        #endregion
    }
}