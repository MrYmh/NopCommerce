using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Warehouses;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Warehouses
{

    /// <summary>
    /// Represents a warehouse category entity builder
    /// </summary>
    public class WarehouseCategoryBuilder : NopEntityBuilder<WarehouseCategory>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(WarehouseCategory.Name)).AsString(1000).NotNullable()
                .WithColumn(nameof(WarehouseCategory.CreatedOnUtc)).AsNopDateTime2().Nullable()
                .WithColumn(nameof(WarehouseCategory.UpdatedOnUtc)).AsNopDateTime2().Nullable()
                .WithColumn(nameof(WarehouseCategory.CreatedBy)).AsInt32().Nullable()
                .WithColumn(nameof(WarehouseCategory.UpdatedBy)).AsInt32().Nullable();
        }

        #endregion
    }
}