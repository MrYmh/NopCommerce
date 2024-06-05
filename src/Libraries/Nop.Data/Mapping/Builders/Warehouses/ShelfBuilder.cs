using System;
using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Common;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Localization;
using Nop.Core.Domain.Shipping;
using Nop.Core.Domain.Warehouses;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Warehouses
{

    /// <summary>
    /// Represents a shelf entity builder
    /// </summary>
    public class ShelfBuilder : NopEntityBuilder<Shelf>
    {

        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(Shelf.StandId)).AsInt32().NotNullable().ForeignKey<WarehouseStand>()
                .WithColumn(nameof(Shelf.CreatedOnUtc)).AsNopDateTime2().Nullable()
                .WithColumn(nameof(Shelf.UpdatedOnUtc)).AsNopDateTime2().Nullable()
                .WithColumn(nameof(Shelf.CreatedBy)).AsInt32().Nullable()
                .WithColumn(nameof(Shelf.UpdatedBy)).AsInt32().Nullable();
        }

        #endregion
    }
}
