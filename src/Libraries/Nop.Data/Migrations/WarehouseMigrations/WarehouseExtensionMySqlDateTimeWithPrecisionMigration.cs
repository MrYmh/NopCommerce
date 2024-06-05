using FluentMigrator;
using Nop.Core.Domain.Warehouses;
using Nop.Data.Mapping;

namespace Nop.Data.Migrations.WarehouseMigrations
{
    [NopMigration("2024/05/03 00:00:00", "Warehouse Extension MySql DateTime With Precision Migration", MigrationProcessType.Update)]
    public class WarehouseExtensionMySqlDateTimeWithPrecisionMigration : Migration
    {
        public override void Up()
        {
            var dataSettings = DataSettingsManager.LoadSettings();

            #region Other Providers

            //update the types only in MySql 
            if (dataSettings.DataProvider != DataProviderType.MySql)
                return;

            #endregion

            #region MySql Provider

            //warehouse stand
            Alter.Table(NameCompatibilityManager.GetTableName(typeof(WarehouseStand)))
                .AlterColumn(NameCompatibilityManager.GetColumnName(typeof(WarehouseStand), nameof(WarehouseStand.CreatedOnUtc)))
                .AsCustom("datetime(6)")
                .Nullable();

            Alter.Table(NameCompatibilityManager.GetTableName(typeof(WarehouseStand)))
                .AlterColumn(NameCompatibilityManager.GetColumnName(typeof(WarehouseStand), nameof(WarehouseStand.UpdatedOnUtc)))
                .AsCustom("datetime(6)")
                .Nullable();

            //shelf
            Alter.Table(NameCompatibilityManager.GetTableName(typeof(Shelf)))
                .AlterColumn(NameCompatibilityManager.GetColumnName(typeof(Shelf), nameof(Shelf.CreatedOnUtc)))
                .AsCustom("datetime(6)")
                .Nullable();

            Alter.Table(NameCompatibilityManager.GetTableName(typeof(Shelf)))
                .AlterColumn(NameCompatibilityManager.GetColumnName(typeof(Shelf), nameof(Shelf.UpdatedOnUtc)))
                .AsCustom("datetime(6)")
                .Nullable();

            //warehouse user mapping
            Alter.Table(NameCompatibilityManager.GetTableName(typeof(WarehouseUserMapping)))
                .AlterColumn(NameCompatibilityManager.GetColumnName(typeof(WarehouseUserMapping), nameof(WarehouseUserMapping.CreatedOnUtc)))
                .AsCustom("datetime(6)")
                .Nullable();

            Alter.Table(NameCompatibilityManager.GetTableName(typeof(WarehouseUserMapping)))
                .AlterColumn(NameCompatibilityManager.GetColumnName(typeof(WarehouseUserMapping), nameof(WarehouseUserMapping.UpdatedOnUtc)))
                .AsCustom("datetime(6)")
                .Nullable();

            Alter.Table(NameCompatibilityManager.GetTableName(typeof(WarehouseUserMapping)))
                .AlterColumn(NameCompatibilityManager.GetColumnName(typeof(WarehouseUserMapping), nameof(WarehouseUserMapping.BlockedOnUtc)))
                .AsCustom("datetime(6)")
                .Nullable();

            //user status change log
            Alter.Table(NameCompatibilityManager.GetTableName(typeof(UserStatusChangeLog)))
                .AlterColumn(NameCompatibilityManager.GetColumnName(typeof(UserStatusChangeLog), nameof(UserStatusChangeLog.ActionDateUtc)))
                .AsCustom("datetime(6)");

            //warehouse category
            Alter.Table(NameCompatibilityManager.GetTableName(typeof(WarehouseCategory)))
                .AlterColumn(NameCompatibilityManager.GetColumnName(typeof(WarehouseCategory), nameof(WarehouseCategory.CreatedOnUtc)))
                .AsCustom("datetime(6)")
                .Nullable();

            Alter.Table(NameCompatibilityManager.GetTableName(typeof(WarehouseCategory)))
                .AlterColumn(NameCompatibilityManager.GetColumnName(typeof(WarehouseCategory), nameof(WarehouseCategory.UpdatedOnUtc)))
                .AsCustom("datetime(6)")
                .Nullable();

            //warehouse category mapping
            Alter.Table(NameCompatibilityManager.GetTableName(typeof(WarehouseCategoryMapping)))
                .AlterColumn(NameCompatibilityManager.GetColumnName(typeof(WarehouseCategoryMapping), nameof(WarehouseCategoryMapping.CreatedOnUtc)))
                .AsCustom("datetime(6)")
                .Nullable();

            Alter.Table(NameCompatibilityManager.GetTableName(typeof(WarehouseCategoryMapping)))
                .AlterColumn(NameCompatibilityManager.GetColumnName(typeof(WarehouseCategoryMapping), nameof(WarehouseCategoryMapping.UpdatedOnUtc)))
                .AsCustom("datetime(6)")
                .Nullable();

            //warehouse product category mapping
            Alter.Table(NameCompatibilityManager.GetTableName(typeof(WarehouseProductCategoryMapping)))
                .AlterColumn(NameCompatibilityManager.GetColumnName(typeof(WarehouseProductCategoryMapping), nameof(WarehouseProductCategoryMapping.CreatedOnUtc)))
                .AsCustom("datetime(6)")
                .Nullable();

            Alter.Table(NameCompatibilityManager.GetTableName(typeof(WarehouseProductCategoryMapping)))
                .AlterColumn(NameCompatibilityManager.GetColumnName(typeof(WarehouseProductCategoryMapping), nameof(WarehouseProductCategoryMapping.UpdatedOnUtc)))
                .AsCustom("datetime(6)")
                .Nullable();

            //warehouse product
            Alter.Table(NameCompatibilityManager.GetTableName(typeof(WarehouseProduct)))
                .AlterColumn(NameCompatibilityManager.GetColumnName(typeof(WarehouseProduct), nameof(WarehouseProduct.CreatedOnUtc)))
                .AsCustom("datetime(6)")
                .Nullable();

            Alter.Table(NameCompatibilityManager.GetTableName(typeof(WarehouseProduct)))
                .AlterColumn(NameCompatibilityManager.GetColumnName(typeof(WarehouseProduct), nameof(WarehouseProduct.UpdatedOnUtc)))
                .AsCustom("datetime(6)")
                .Nullable();

            //warehouse product combination
            Alter.Table(NameCompatibilityManager.GetTableName(typeof(WarehouseProductCombination)))
                .AlterColumn(NameCompatibilityManager.GetColumnName(typeof(WarehouseProductCombination), nameof(WarehouseProductCombination.CreatedOnUtc)))
                .AsCustom("datetime(6)")
                .Nullable();

            Alter.Table(NameCompatibilityManager.GetTableName(typeof(WarehouseProductCombination)))
                .AlterColumn(NameCompatibilityManager.GetColumnName(typeof(WarehouseProductCombination), nameof(WarehouseProductCombination.UpdatedOnUtc)))
                .AsCustom("datetime(6)")
                .Nullable();

            //warehouse item
            Alter.Table(NameCompatibilityManager.GetTableName(typeof(WarehouseItem)))
                .AlterColumn(NameCompatibilityManager.GetColumnName(typeof(WarehouseItem), nameof(WarehouseItem.CreatedOnUtc)))
                .AsCustom("datetime(6)")
                .Nullable();

            Alter.Table(NameCompatibilityManager.GetTableName(typeof(WarehouseItem)))
                .AlterColumn(NameCompatibilityManager.GetColumnName(typeof(WarehouseItem), nameof(WarehouseItem.UpdatedOnUtc)))
                .AsCustom("datetime(6)")
                .Nullable();

            //shelf item mapping
            Alter.Table(NameCompatibilityManager.GetTableName(typeof(ShelfItemMapping)))
                .AlterColumn(NameCompatibilityManager.GetColumnName(typeof(ShelfItemMapping), nameof(ShelfItemMapping.CreatedOnUtc)))
                .AsCustom("datetime(6)")
                .Nullable();

            Alter.Table(NameCompatibilityManager.GetTableName(typeof(ShelfItemMapping)))
                .AlterColumn(NameCompatibilityManager.GetColumnName(typeof(ShelfItemMapping), nameof(ShelfItemMapping.UpdatedOnUtc)))
                .AsCustom("datetime(6)")
                .Nullable();

            //stock history
            Alter.Table(NameCompatibilityManager.GetTableName(typeof(StockHistory)))
                .AlterColumn(NameCompatibilityManager.GetColumnName(typeof(StockHistory), nameof(StockHistory.CreatedOnUtc)))
                .AsCustom("datetime(6)")
                .Nullable();

            Alter.Table(NameCompatibilityManager.GetTableName(typeof(StockHistory)))
                .AlterColumn(NameCompatibilityManager.GetColumnName(typeof(StockHistory), nameof(StockHistory.UpdatedOnUtc)))
                .AsCustom("datetime(6)")
                .Nullable();

            //stock item history
            Alter.Table(NameCompatibilityManager.GetTableName(typeof(StockItemHistory)))
                .AlterColumn(NameCompatibilityManager.GetColumnName(typeof(StockItemHistory), nameof(StockItemHistory.CreatedOnUtc)))
                .AsCustom("datetime(6)")
                .Nullable();

            Alter.Table(NameCompatibilityManager.GetTableName(typeof(StockItemHistory)))
                .AlterColumn(NameCompatibilityManager.GetColumnName(typeof(StockItemHistory), nameof(StockItemHistory.UpdatedOnUtc)))
                .AsCustom("datetime(6)")
                .Nullable();

            //stock item history mapping
            Alter.Table(NameCompatibilityManager.GetTableName(typeof(StockItemHistoryMapping)))
                .AlterColumn(NameCompatibilityManager.GetColumnName(typeof(StockItemHistoryMapping), nameof(StockItemHistoryMapping.CreatedOnUtc)))
                .AsCustom("datetime(6)");

            //stock request
            Alter.Table(NameCompatibilityManager.GetTableName(typeof(StockRequest)))
                .AlterColumn(NameCompatibilityManager.GetColumnName(typeof(StockRequest), nameof(StockRequest.CreatedOnUtc)))
                .AsCustom("datetime(6)")
                .Nullable();

            Alter.Table(NameCompatibilityManager.GetTableName(typeof(StockRequest)))
                .AlterColumn(NameCompatibilityManager.GetColumnName(typeof(StockRequest), nameof(StockRequest.UpdatedOnUtc)))
                .AsCustom("datetime(6)")
                .Nullable();

            //stock request item
            Alter.Table(NameCompatibilityManager.GetTableName(typeof(StockRequestItem)))
                .AlterColumn(NameCompatibilityManager.GetColumnName(typeof(StockRequestItem), nameof(StockRequestItem.CreatedOnUtc)))
                .AsCustom("datetime(6)")
                .Nullable();

            Alter.Table(NameCompatibilityManager.GetTableName(typeof(StockRequestItem)))
                .AlterColumn(NameCompatibilityManager.GetColumnName(typeof(StockRequestItem), nameof(StockRequestItem.UpdatedOnUtc)))
                .AsCustom("datetime(6)")
                .Nullable();

            //accept stock request
            Alter.Table(NameCompatibilityManager.GetTableName(typeof(AcceptStockRequest)))
                .AlterColumn(NameCompatibilityManager.GetColumnName(typeof(AcceptStockRequest), nameof(AcceptStockRequest.CreatedOnUtc)))
                .AsCustom("datetime(6)")
                .Nullable();

            Alter.Table(NameCompatibilityManager.GetTableName(typeof(AcceptStockRequest)))
                .AlterColumn(NameCompatibilityManager.GetColumnName(typeof(AcceptStockRequest), nameof(AcceptStockRequest.UpdatedOnUtc)))
                .AsCustom("datetime(6)")
                .Nullable();

            #endregion
        }

        public override void Down()
        {
        }
    }
}
