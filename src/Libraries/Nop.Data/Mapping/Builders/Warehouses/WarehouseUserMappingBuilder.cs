using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Shipping;
using Nop.Core.Domain.Warehouses;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Warehouses
{
    /// <summary>
    /// Represents a warehouse user mapping entity builder
    /// </summary>
    public class WarehouseUserMappingBuilder : NopEntityBuilder<WarehouseUserMapping>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(WarehouseUserMapping.WarehouseId)).AsInt32().NotNullable().ForeignKey<Warehouse>()
                .WithColumn(nameof(WarehouseUserMapping.UserId)).AsInt32().NotNullable()
                .WithColumn(nameof(WarehouseUserMapping.BlockedOnUtc)).AsNopDateTime2().Nullable()
                .WithColumn(nameof(WarehouseUserMapping.CreatedOnUtc)).AsNopDateTime2().Nullable()
                .WithColumn(nameof(WarehouseUserMapping.UpdatedOnUtc)).AsNopDateTime2().Nullable()
                .WithColumn(nameof(WarehouseUserMapping.CreatedBy)).AsInt32().Nullable()
                .WithColumn(nameof(WarehouseUserMapping.UpdatedBy)).AsInt32().Nullable();
        }

        #endregion
    }
}