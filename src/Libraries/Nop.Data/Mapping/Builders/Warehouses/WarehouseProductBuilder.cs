using System;
using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Common;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Shipping;
using Nop.Core.Domain.Warehouses;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Warehouses
{

    /// <summary>
    /// Represents a warehouse product entity builder
    /// </summary>
    public class WarehouseProductBuilder : NopEntityBuilder<WarehouseProduct>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(WarehouseProduct.WarehouseId)).AsInt32().NotNullable().ForeignKey<Warehouse>()
                .WithColumn(nameof(WarehouseProduct.WarehouseProductCategoryMappingId)).AsInt32().NotNullable()
                .WithColumn(nameof(WarehouseProduct.ProductId)).AsInt32().NotNullable().ForeignKey<Product>()
                .WithColumn(nameof(WarehouseProduct.Sku)).AsString(400).Nullable()
                .WithColumn(nameof(WarehouseProduct.CreatedOnUtc)).AsNopDateTime2().Nullable()
                .WithColumn(nameof(WarehouseProduct.UpdatedOnUtc)).AsNopDateTime2().Nullable()
                .WithColumn(nameof(WarehouseProduct.CreatedBy)).AsInt32().Nullable()
                .WithColumn(nameof(WarehouseProduct.UpdatedBy)).AsInt32().Nullable();
        }

        #endregion
    }
}