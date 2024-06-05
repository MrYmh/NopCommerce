using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Shipping;
using Nop.Core.Domain.Warehouses;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Warehouses
{

    /// <summary>
    /// Represents a warehouse product combination entity builder
    /// </summary>
    public class WarehouseProductCombinationBuilder : NopEntityBuilder<WarehouseProductCombination>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(WarehouseProductCombination.WarehouseId)).AsInt32().NotNullable().ForeignKey<Warehouse>()
                .WithColumn(nameof(WarehouseProductCombination.WarehouseProductId)).AsInt32().NotNullable()
                .WithColumn(nameof(WarehouseProductCombination.CombinationId)).AsInt32().NotNullable().ForeignKey<ProductAttributeCombination>()
                .WithColumn(nameof(WarehouseProductCombination.Sku)).AsString(400).Nullable()
                .WithColumn(nameof(WarehouseProductCombination.CreatedOnUtc)).AsNopDateTime2().Nullable()
                .WithColumn(nameof(WarehouseProductCombination.UpdatedOnUtc)).AsNopDateTime2().Nullable()
                .WithColumn(nameof(WarehouseProductCombination.CreatedBy)).AsInt32().Nullable()
                .WithColumn(nameof(WarehouseProductCombination.UpdatedBy)).AsInt32().Nullable();
        }

        #endregion
    }
}