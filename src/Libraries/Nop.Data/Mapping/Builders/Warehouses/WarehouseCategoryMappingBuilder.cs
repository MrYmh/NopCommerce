using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Shipping;
using Nop.Core.Domain.Warehouses;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Warehouses
{

    /// <summary>
    /// Represents a warehouse category mapping entity builder
    /// </summary>
    public class WarehouseCategoryMappingBuilder : NopEntityBuilder<WarehouseCategoryMapping>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(WarehouseCategoryMapping.WarehouseId)).AsInt32().NotNullable().ForeignKey<Warehouse>()
                .WithColumn(nameof(WarehouseCategoryMapping.WarehouseCategoryId)).AsInt32().NotNullable().ForeignKey<WarehouseCategory>()
                .WithColumn(nameof(WarehouseCategoryMapping.CreatedOnUtc)).AsNopDateTime2().Nullable()
                .WithColumn(nameof(WarehouseCategoryMapping.UpdatedOnUtc)).AsNopDateTime2().Nullable()
                .WithColumn(nameof(WarehouseCategoryMapping.CreatedBy)).AsInt32().Nullable()
                .WithColumn(nameof(WarehouseCategoryMapping.UpdatedBy)).AsInt32().Nullable();
        }

        #endregion
    }
}