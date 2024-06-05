using System;
using FluentMigrator;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Warehouses;

namespace Nop.Data.Migrations.WarehouseMigrations
{
    [NopMigration("2024/01/02 11:26:08", "Warehouse Data Migration", MigrationProcessType.Update)]
    public class WarehouseDataMigration : Migration
    {
        /// <summary>
        /// Collect the UP migration expressions
        /// </summary>
        public override void Up()
        {
            #region Warehouse Customer Roles

            Insert.IntoTable(nameof(CustomerRole)).Row(new
            {
                Name = "Warehouse Administrators",
                FreeShipping = 0,
                TaxExempt = 0,
                Active = true,
                IsSystemRole = false,
                SystemName = "WarehouseAdministrators",
                EnablePasswordLifetime = 0,
                OverrideTaxDisplayType = 0,
                DefaultTaxDisplayTypeId = 0,
                PurchasedWithProductId = 0
            });

            Insert.IntoTable(nameof(CustomerRole)).Row(new
            {
                Name = "Warehouse Supervisors",
                FreeShipping = 0,
                TaxExempt = 0,
                Active = true,
                IsSystemRole = false,
                SystemName = "WarehouseSupervisors",
                EnablePasswordLifetime = 0,
                OverrideTaxDisplayType = 0,
                DefaultTaxDisplayTypeId = 0,
                PurchasedWithProductId = 0
            });

            Insert.IntoTable(nameof(CustomerRole)).Row(new
            {
                Name = "Warehouse Staff",
                FreeShipping = 0,
                TaxExempt = 0,
                Active = true,
                IsSystemRole = false,
                SystemName = "WarehouseStaff",
                EnablePasswordLifetime = 0,
                OverrideTaxDisplayType = 0,
                DefaultTaxDisplayTypeId = 0,
                PurchasedWithProductId = 0
            });

            Insert.IntoTable(nameof(CustomerRole)).Row(new
            {
                Name = "Warehouse Trainees",
                FreeShipping = 0,
                TaxExempt = 0,
                Active = true,
                IsSystemRole = false,
                SystemName = "WarehouseTrainees",
                EnablePasswordLifetime = 0,
                OverrideTaxDisplayType = 0,
                DefaultTaxDisplayTypeId = 0,
                PurchasedWithProductId = 0
            });

            #endregion
        }

        public override void Down()
        {
        }
    }
}
