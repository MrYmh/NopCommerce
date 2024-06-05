using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Shipping;
using Nop.Core.Domain.Warehouses;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Warehouses
{

    /// <summary>
    /// Represents a warehouse product category mapping entity builder
    /// </summary>
    public class WarehouseProductCategoryMappingBuilder : NopEntityBuilder<WarehouseProductCategoryMapping>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(WarehouseProductCategoryMapping.WarehouseId)).AsInt32().NotNullable().ForeignKey<Warehouse>()
                .WithColumn(nameof(WarehouseProductCategoryMapping.WarehouseCategoryMappingId)).AsInt32().NotNullable()
                .WithColumn(nameof(WarehouseProductCategoryMapping.ProductCategoryId)).AsInt32().NotNullable().ForeignKey<ProductCategory>()
                .WithColumn(nameof(WarehouseProductCategoryMapping.CreatedOnUtc)).AsNopDateTime2().Nullable()
                .WithColumn(nameof(WarehouseProductCategoryMapping.UpdatedOnUtc)).AsNopDateTime2().Nullable()
                .WithColumn(nameof(WarehouseProductCategoryMapping.CreatedBy)).AsInt32().Nullable()
                .WithColumn(nameof(WarehouseProductCategoryMapping.UpdatedBy)).AsInt32().Nullable();
        }

        #endregion
    }
}