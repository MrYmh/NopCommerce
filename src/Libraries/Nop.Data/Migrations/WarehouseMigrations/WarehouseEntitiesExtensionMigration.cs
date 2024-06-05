using FluentMigrator;
using Nop.Core.Domain.Warehouses;
using Nop.Data.Extensions;

namespace Nop.Data.Migrations.WarehouseMigrations
{
    [NopMigration("2024/01/01 00:00:00", "Warehouse Entities Extension Migration", MigrationProcessType.Update)]
    public class WarehouseEntitiesExtensionMigration : Migration
    {
        public override void Up()
        {
            Create.TableFor<WarehouseStand>();
            Create.TableFor<Shelf>();
            Create.TableFor<WarehouseUserMapping>();
            Create.TableFor<UserStatusChangeLog>();
            Create.TableFor<WarehouseCategory>();
            Create.TableFor<WarehouseCategoryMapping>();
            Create.TableFor<WarehouseProductCategoryMapping>();
            Create.TableFor<WarehouseProduct>();
            Create.TableFor<WarehouseProductCombination>();
            Create.TableFor<WarehouseItem>();
            Create.TableFor<ShelfItemMapping>();
            Create.TableFor<StockHistory>();
            Create.TableFor<StockItemHistory>();
            Create.TableFor<StockItemHistoryMapping>();
            Create.TableFor<StockRequest>();
            Create.TableFor<StockRequestItem>();
            Create.TableFor<AcceptStockRequest>();
        }

        public override void Down()
        {
        }
    }
}
