using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Shipping;
using Nop.Core.Domain.Warehouses;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Warehouses
{

    /// <summary>
    /// Represents a user status change log entity builder
    /// </summary>
    public class UserStatusChangeLogBuilder : NopEntityBuilder<UserStatusChangeLog>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(UserStatusChangeLog.WarehouseId)).AsInt32().NotNullable().ForeignKey<Warehouse>()
                .WithColumn(nameof(UserStatusChangeLog.UserId)).AsInt32().NotNullable()
                .WithColumn(nameof(UserStatusChangeLog.ActionType)).AsString(200).NotNullable()
                .WithColumn(nameof(UserStatusChangeLog.Reason)).AsString(500).Nullable()
                .WithColumn(nameof(UserStatusChangeLog.ActionTakenBy)).AsInt32().Nullable()
                .WithColumn(nameof(UserStatusChangeLog.ActionDateUtc)).AsNopDateTime2().Nullable();
        }

        #endregion
    }
}