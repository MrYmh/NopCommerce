using FluentMigrator;
using Nop.Core.Domain.Localization;

namespace Nop.Data.Migrations.WarehouseMigrations
{
    [NopMigration("2024/09/07 00:00:00", "Warehouse Localization Data Migration", MigrationProcessType.Update)]
    public class WarehouseLocalizationDataMigration : Migration
    {
        /// <summary>
        /// Collect the UP migration expressions
        /// </summary>
        public override void Up()
        {
            #region Warehouse Localization

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseStand.Fields.StandNo".ToLower(),
                ResourceValue = "Stand No"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseStand.Fields.StandNo".ToLower(),
                ResourceValue = "رقم الحامل"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.Stock.Values.NotAssigned".ToLower(),
                ResourceValue = "Unknown"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.Stock.Values.NotAssigned".ToLower(),
                ResourceValue = "مجهول"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.Stock.Values.ReturnedFromCustomer".ToLower(),
                ResourceValue = "Returned From Customer"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.Stock.Values.ReturnedFromCustomer".ToLower(),
                ResourceValue = "إرجاع من عميل"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.Stock.Values.ReturnedToVendor".ToLower(),
                ResourceValue = "Returned To Vendor"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.Stock.Values.ReturnedToVendor".ToLower(),
                ResourceValue = "إرجاع للتاجر"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.Stock.Values.Receiving".ToLower(),
                ResourceValue = "Received"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.Stock.Values.Receiving".ToLower(),
                ResourceValue = "إستلام مخزون"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses".ToLower(),
                ResourceValue = "Warehouses"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseShelf".ToLower(),
                ResourceValue = "Warehouse Shelves"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseProductCategory".ToLower(),
                ResourceValue = "Warehouse Product Category"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseCategory.Fields.Description".ToLower(),
                ResourceValue = "Category Description"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses".ToLower(),
                ResourceValue = "ادارة المخازن"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseShelf".ToLower(),
                ResourceValue = "الأرفف"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseProductCategory".ToLower(),
                ResourceValue = "فئة المنتجات"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.Warehouses".ToLower(),
                ResourceValue = "Warehouses"
            });
            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.Warehouses".ToLower(),
                ResourceValue = "المخازن"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Warehouse.Home".ToLower(),
                ResourceValue = "Go Home"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Warehouse.Home".ToLower(),
                ResourceValue = "الذهاب للرئيسية"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.BackToList".ToLower(),
                ResourceValue = "Back To List"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.BackToList".ToLower(),
                ResourceValue = "العودة للقائمة"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseStand.AddNew".ToLower(),
                ResourceValue = "Add New"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseStand.AddNew".ToLower(),
                ResourceValue = "إضافة"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseStand.List".ToLower(),
                ResourceValue = "Warehouse Stands"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseStand.List".ToLower(),
                ResourceValue = "قائمة بحوامل المخزن"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseStand.EditWarehouseStandDetails".ToLower(),
                ResourceValue = "Warehouse Stand Details"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseStand.EditWarehouseStandDetails".ToLower(),
                ResourceValue = "تفاصيل الحامل"
            });

            //content header
            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseStand".ToLower(),
                ResourceValue = "Warehouse Stands"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseStand".ToLower(),
                ResourceValue = "قائمة بحوامل المخزن"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseStand.EditWarehouseStandDetails".ToLower(),
                ResourceValue = "Warehouse Stand Details"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseStand.EditWarehouseStandDetails".ToLower(),
                ResourceValue = "تفاصيل الحامل"
            });

            //content
            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseStand.Values.Active".ToLower(),
                ResourceValue = "Active"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseStand.Values.Active".ToLower(),
                ResourceValue = "فعال"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseStand.Values.Inactive".ToLower(),
                ResourceValue = "Inactive"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseStand.Values.Inactive".ToLower(),
                ResourceValue = "غير فعال"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseStand.Info".ToLower(),
                ResourceValue = "Info"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseStand.Info".ToLower(),
                ResourceValue = "معلومات"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseProductCombination.List".ToLower(),
                ResourceValue = "Warehouse Product Combinations"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseProductCombination.List".ToLower(),
                ResourceValue = "قائمة المتغيرات"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseProductCombination".ToLower(),
                ResourceValue = "Warehouse Product Combinations"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseProductCombination".ToLower(),
                ResourceValue = "قائمة المتغيرات"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseProductCombination.Values.Unavailable".ToLower(),
                ResourceValue = "Unavailable"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseProductCombination.Values.Unavailable".ToLower(),
                ResourceValue = "غير متوفر"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseProductCombination.Values.Available".ToLower(),
                ResourceValue = "Available"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseProductCombination.Values.Available".ToLower(),
                ResourceValue = "متوفر"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseProductCombination.EditCategoryDetails".ToLower(),
                ResourceValue = "Category Details"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseProductCombination.EditCategoryDetails".ToLower(),
                ResourceValue = "تفاصيل القسم"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseProductCombination.Info".ToLower(),
                ResourceValue = "Info"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseProductCombination.Info".ToLower(),
                ResourceValue = "معلومات"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseProductCategoryMapping.List".ToLower(),
                ResourceValue = "Warehouse Product Category Mapping"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseProductCategoryMapping.List".ToLower(),
                ResourceValue = "ربط قسم منتج بمخزن"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseProductCategoryMapping".ToLower(),
                ResourceValue = "Warehouse Product Category Mapping"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseProductCategoryMapping".ToLower(),
                ResourceValue = "ربط قسم منتج بمخزن"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseProductCategoryMapping.EditWarehouseProductCategoryMappingDetails".ToLower(),
                ResourceValue = "Edit Warehouse Product Category Mapping"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseProductCategoryMapping.EditWarehouseProductCategoryMappingDetails".ToLower(),
                ResourceValue = "تعديل ربط قسم منتج بمخزن"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseProductCategoryMapping.AddNew".ToLower(),
                ResourceValue = "Add New"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseProductCategoryMapping.AddNew".ToLower(),
                ResourceValue = "إضافة"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseProductCategoryMapping.Info".ToLower(),
                ResourceValue = "Info"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseProductCategoryMapping.Info".ToLower(),
                ResourceValue = "معلومات"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseProduct.List".ToLower(),
                ResourceValue = "Warehouse Products"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseProduct.List".ToLower(),
                ResourceValue = "منتجات المخزن"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseProduct".ToLower(),
                ResourceValue = "Warehouse Products"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseProduct".ToLower(),
                ResourceValue = "منتجات المخزن"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Common.Refresh".ToLower(),
                ResourceValue = "Refresh"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Common.Refresh".ToLower(),
                ResourceValue = "تحديث المنتج"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseProduct.EditWarehouseProductDetails".ToLower(),
                ResourceValue = "Edit Warehouse Product"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseProduct.EditWarehouseProductDetails".ToLower(),
                ResourceValue = "تعديل منتج المخزن"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseProduct.AddNew".ToLower(),
                ResourceValue = "Add New"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseProduct.AddNew".ToLower(),
                ResourceValue = "إضافة"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseProduct.Info".ToLower(),
                ResourceValue = "Info"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseProduct.Info".ToLower(),
                ResourceValue = "معلومات"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseCategoryMapping.List".ToLower(),
                ResourceValue = "Warehouse Category Mapping"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseCategoryMapping.List".ToLower(),
                ResourceValue = "ربط قسم بالمخزن"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseCategoryMapping".ToLower(),
                ResourceValue = "Warehouse Category Mapping"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseCategoryMapping".ToLower(),
                ResourceValue = "ربط قسم بالمخزن"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseCategoryMapping.Fields.Name".ToLower(),
                ResourceValue = "Category Name"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseCategoryMapping.Fields.Name".ToLower(),
                ResourceValue = "إسم القسم"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseCategoryMapping.Fields.Description".ToLower(),
                ResourceValue = "Description"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseCategoryMapping.Fields.Description".ToLower(),
                ResourceValue = "الوصف"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseCategoryMapping.EditWarehouseCategoryMappingDetails".ToLower(),
                ResourceValue = "Edit Warehouse Category Mapping"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseCategoryMapping.EditWarehouseCategoryMappingDetails".ToLower(),
                ResourceValue = "تعديل ربط القسم بالمخزن"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseCategoryMapping.AddNew".ToLower(),
                ResourceValue = "Add New"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseCategoryMapping.AddNew".ToLower(),
                ResourceValue = "إضافة"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseCategoryMapping.Info".ToLower(),
                ResourceValue = "Info"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseCategoryMapping.Info".ToLower(),
                ResourceValue = "معلومات"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseCategory.List".ToLower(),
                ResourceValue = "Warehouse Categories"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseCategory.List".ToLower(),
                ResourceValue = "أقسام المخزن"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseCategory".ToLower(),
                ResourceValue = "Warehouse Categories"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseCategory".ToLower(),
                ResourceValue = "أقسام المخزن"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseCategory.EditCategoryDetails".ToLower(),
                ResourceValue = "Edit Category"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseCategory.EditCategoryDetails".ToLower(),
                ResourceValue = "تعديل القسم"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseCategory.AddNew".ToLower(),
                ResourceValue = "Add New"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseCategory.AddNew".ToLower(),
                ResourceValue = "إضافة"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseCategory.Info".ToLower(),
                ResourceValue = "Info"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseCategory.Info".ToLower(),
                ResourceValue = "معلومات"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.Shelf.List".ToLower(),
                ResourceValue = "Shelves List"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.Shelf.List".ToLower(),
                ResourceValue = "قائمة الأرفف"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.Shelf".ToLower(),
                ResourceValue = "Shelves List"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.Shelf".ToLower(),
                ResourceValue = "قائمة الأرفف"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.Shelf.Values.Active".ToLower(),
                ResourceValue = "Active"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.Shelf.Values.Active".ToLower(),
                ResourceValue = "فعال"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.Shelf.Values.Inactive".ToLower(),
                ResourceValue = "Inactive"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.Shelf.Values.Inactive".ToLower(),
                ResourceValue = "غير فعال"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.Shelf.EditShelfDetails".ToLower(),
                ResourceValue = "Edit Shelf"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.Shelf.EditShelfDetails".ToLower(),
                ResourceValue = "تعديل الرف"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.Shelf.AddNew".ToLower(),
                ResourceValue = "Add New"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.Shelf.AddNew".ToLower(),
                ResourceValue = "إضافة"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.Shelf.Info".ToLower(),
                ResourceValue = "Info"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.Shelf.Info".ToLower(),
                ResourceValue = "معلومات"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Common.Viewdetails".ToLower(),
                ResourceValue = "Details"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Common.Viewdetails".ToLower(),
                ResourceValue = "التفاصيل"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseCategories.List.SearchWarehouseCategoryName".ToLower(),
                ResourceValue = "Warehouse category Name"
            });
            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseCategories.List.SearchWarehouseCategoryName".ToLower(),
                ResourceValue = "اسم فئة المخزن"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseCategories.Fields.DisplayOrder".ToLower(),
                ResourceValue = "Display Order"
            });
            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseCategories.Fields.DisplayOrder".ToLower(),
                ResourceValue = "ترتيب العرض"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.SystemSetup".ToLower(),
                ResourceValue = "System Setup"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.SystemSetup".ToLower(),
                ResourceValue = "إعدادات النظام"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "admin.warehouses.warehouseproductcombination.fields.damagedquantity".ToLower(),
                ResourceValue = "Damaged Quantity"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "admin.warehouses.warehouseproductcombination.fields.damagedquantity".ToLower(),
                ResourceValue = "كمية الهالك"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "admin.warehouses.warehouseproductcombination.fields.returnedtovendorquantity".ToLower(),
                ResourceValue = "Returned Quantity"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "admin.warehouses.warehouseproductcombination.fields.returnedtovendorquantity".ToLower(),
                ResourceValue = "كمية المرتجع"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.NavBar.Home".ToLower(),
                ResourceValue = "Home"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.NavBar.Home".ToLower(),
                ResourceValue = "الرئيسية"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.NavBar.SystemSetup".ToLower(),
                ResourceValue = "System Setup"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.NavBar.SystemSetup".ToLower(),
                ResourceValue = "إعدادات النظام"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.NavBar.StockOperations".ToLower(),
                ResourceValue = "Stock Operations"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.NavBar.StockOperations".ToLower(),
                ResourceValue = "عمليات المخزن"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockOperations.ReceivingAndReturningAction.Header".ToLower(),
                ResourceValue = "Stock Receiving/Returning Actions"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockOperations.ReceivingAndReturningAction.Header".ToLower(),
                ResourceValue = "عمليات إستلام/إرجاع مخزون"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockOperations.ReceivingAndReturningAction.Message".ToLower(),
                ResourceValue = "Displays the list of received/returned stocks, and allows you to receive/return stock to/from the warehouse."
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockOperations.ReceivingAndReturningAction.Message".ToLower(),
                ResourceValue = "عرض قائمة بالمخزون المستلم والمرتجع بالإضافة الي السماح بإستلام وإرجاع مخزون من و إلى المخزن."
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockOperations.ReceivingAndReturningAction.Button".ToLower(),
                ResourceValue = "Manage Stocks"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockOperations.ReceivingAndReturningAction.Button".ToLower(),
                ResourceValue = "إدارة المخزون"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "admin.common.viewdetails".ToLower(),
                ResourceValue = "View Details"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "admin.common.viewdetails".ToLower(),
                ResourceValue = "عرض التفاصيل"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockOperations.DamagingStockAction.Header".ToLower(),
                ResourceValue = "Damaging Stock Action"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockOperations.DamagingStockAction.Header".ToLower(),
                ResourceValue = "إجراء إهلاك للمخزون"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockOperations.DamagingStockAction.Message".ToLower(),
                ResourceValue = "Allows you to scan items directly to record them as damaged."
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockOperations.DamagingStockAction.Message".ToLower(),
                ResourceValue = "السماح بقراءة المنتجات المراد إهلاكها بشكل مباشر"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockOperations.DamagingStockAction.Button".ToLower(),
                ResourceValue = "Damaging Stocks"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockOperations.DamagingStockAction.Button".ToLower(),
                ResourceValue = "إهلاك المخزون"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockOperations.PrintBarcodes.Header".ToLower(),
                ResourceValue = "Print Barcodes"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockOperations.PrintBarcodes.Header".ToLower(),
                ResourceValue = "طباعة باركود المنتجات"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockOperations.PrintBarcodes.Message".ToLower(),
                ResourceValue = "Navigate to the page that allows you to print barcodes for items in the warehouse."
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockOperations.PrintBarcodes.Message".ToLower(),
                ResourceValue = "السماح بطباعة الباركود الخاص بالمنتجات المتعلقة بالمخزن والمستلمة بالفعل"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockOperations.PrintBarcodes.Button".ToLower(),
                ResourceValue = "Print"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockOperations.PrintBarcodes.Button".ToLower(),
                ResourceValue = "طباعة"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockOperations.ScanReceivedItems.Header".ToLower(),
                ResourceValue = "Scan Received Items"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockOperations.ScanReceivedItems.Header".ToLower(),
                ResourceValue = "قراءة المنتجات المستلمة"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockOperations.ScanReceivedItems.Message".ToLower(),
                ResourceValue = "allows you to scan, and register newly received items into the warehouse inventory."
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockOperations.ScanReceivedItems.Message".ToLower(),
                ResourceValue = "السماح بقراءة وتسجيل المنتجات المستلمة حديثا ليتم إدراجها بالمخزن."
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockOperations.ScanReceivedItems.Button".ToLower(),
                ResourceValue = "Scan Items"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockOperations.ScanReceivedItems.Button".ToLower(),
                ResourceValue = "قراءة المنتجات"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockOperations.LinkItemsToShelf.Header".ToLower(),
                ResourceValue = "Link Items To Shelf"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockOperations.LinkItemsToShelf.Header".ToLower(),
                ResourceValue = "ربط المنتجات بالأرفف"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockOperations.LinkItemsToShelf.Message".ToLower(),
                ResourceValue = "Allows you to assign and manage the placement of items on specific shelves within the warehouse."
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockOperations.LinkItemsToShelf.Message".ToLower(),
                ResourceValue = "السماح بإدارة الربط بين المنتجات وأرفف الحوامل الخاصه بالمخزن."
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockOperations.LinkItemsToShelf.Button".ToLower(),
                ResourceValue = "Link To Shelf"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockOperations.LinkItemsToShelf.Button".ToLower(),
                ResourceValue = "الربط بالأرفف"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.Stock.EditReceivedStock".ToLower(),
                ResourceValue = "Edit Received Stock"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.Stock.EditReceivedStock".ToLower(),
                ResourceValue = "تعديل المخزون المستلم"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.Stock.EditReturnedStock".ToLower(),
                ResourceValue = "Edit Returned Stock"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.Stock.EditReturnedStock".ToLower(),
                ResourceValue = "تعديل المخزون المرتجع"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "admin.warehouses.stock".ToLower(),
                ResourceValue = "Stock Processes"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "admin.warehouses.stock".ToLower(),
                ResourceValue = "عمليات على المخزون"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.Stock.AddNewReceivedStock".ToLower(),
                ResourceValue = "Receiving Stock"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.Stock.AddNewReceivedStock".ToLower(),
                ResourceValue = "إستلام مخزون جديد"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.Stock.AddNewReturnToVendor".ToLower(),
                ResourceValue = "Returning Stock"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.Stock.AddNewReturnToVendor".ToLower(),
                ResourceValue = "إرجاع مخزون"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockHistory.List.StockHistoryId".ToLower(),
                ResourceValue = "Stock NO"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockHistory.List.StockHistoryId".ToLower(),
                ResourceValue = "رقم المخزون"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockHistory.Fields.Vendor".ToLower(),
                ResourceValue = "Vendor"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockHistory.Fields.Vendor".ToLower(),
                ResourceValue = "التاجر"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "admin.warehouses.stock.fields.typeofprocess".ToLower(),
                ResourceValue = "Type of Process"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "admin.warehouses.stock.fields.typeofprocess".ToLower(),
                ResourceValue = "نوع العملية"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "admin.warehouses.stock.vendor".ToLower(),
                ResourceValue = "Vendor Data"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "admin.warehouses.stock.vendor".ToLower(),
                ResourceValue = "بيانات التاجر"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "admin.common.item".ToLower(),
                ResourceValue = "Item Data"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "admin.common.item".ToLower(),
                ResourceValue = "بيانات المنتج"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "admin.warehouse.stock.stockitems".ToLower(),
                ResourceValue = "Added Items"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "admin.warehouse.stock.stockitems".ToLower(),
                ResourceValue = "المنتجات المضافة"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "admin.warehouses.stockrequest.fields.vendor".ToLower(),
                ResourceValue = "Vendor"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "admin.warehouses.stockrequest.fields.vendor".ToLower(),
                ResourceValue = "التاجر"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.Stock.Values.All".ToLower(),
                ResourceValue = "All"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.Stock.Values.All".ToLower(),
                ResourceValue = "الكل"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "admin.warehouses.stockhistory.fields.id".ToLower(),
                ResourceValue = "Stock NO"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "admin.warehouses.stockhistory.fields.id".ToLower(),
                ResourceValue = "رقم المخزون"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockHistory.Fields.ProductName".ToLower(),
                ResourceValue = "Product Name"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockHistory.Fields.ProductName".ToLower(),
                ResourceValue = "إسم المنتج"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockRequest".ToLower(),
                ResourceValue = "Stock Requests"
            });
            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockRequest".ToLower(),
                ResourceValue = "طلبات حركة المخزون"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockRequest.List.StockRequestId".ToLower(),
                ResourceValue = "Request NO"
            });
            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockRequest.List.StockRequestId".ToLower(),
                ResourceValue = "رقم الطلب"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockRequest.List.VendorId".ToLower(),
                ResourceValue = "Vendor"
            });
            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockRequest.List.VendorId".ToLower(),
                ResourceValue = "التاجر"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockRequest.List.TypeOfProcess".ToLower(),
                ResourceValue = "Type Of Process"
            });
            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockRequest.List.TypeOfProcess".ToLower(),
                ResourceValue = "نوع العملية"
            });
            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockRequest.List.Priority".ToLower(),
                ResourceValue = "Priority"
            });
            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockRequest.List.Priority".ToLower(),
                ResourceValue = "الأولوية"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockRequest.Fields.VendorId".ToLower(),
                ResourceValue = "Vendor"
            });
            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockRequest.Fields.VendorId".ToLower(),
                ResourceValue = "التاجر"
            });
            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockRequest.Fields.TypeOfProcess".ToLower(),
                ResourceValue = "Type Of Process"
            });
            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockRequest.Fields.TypeOfProcess".ToLower(),
                ResourceValue = "نوع العملية"
            });
            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockRequest.Fields.Priority".ToLower(),
                ResourceValue = "Priority"
            });
            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockRequest.Fields.Priority".ToLower(),
                ResourceValue = "الأولوية"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockRequest.Fields.Id".ToLower(),
                ResourceValue = "Request NO"
            });
            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockRequest.Fields.Id".ToLower(),
                ResourceValue = "رقم الطلب"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.Stock.AddNewReceivedStockRequest".ToLower(),
                ResourceValue = "Receiving Stock Request"
            });
            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.Stock.AddNewReceivedStockRequest".ToLower(),
                ResourceValue = "طلب إضافة مخزون"
            });
            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.Stock.AddNewReturnToVendorRequest".ToLower(),
                ResourceValue = "Returning Stock Request"
            });
            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.Stock.AddNewReturnToVendorRequest".ToLower(),
                ResourceValue = "طلب إرجاع مخزون"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.Stock.EditReceivedStockRequest".ToLower(),
                ResourceValue = "Edit Receiving Stock Request"
            });
            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.Stock.EditReceivedStockRequest".ToLower(),
                ResourceValue = "تعديل طلب إضافة المخزون"
            });
            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.Stock.EditReturnedStockRequest".ToLower(),
                ResourceValue = "Edit Returning Stock Request"
            });
            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.Stock.EditReturnedStockRequest".ToLower(),
                ResourceValue = "تعديل طلب مرتجع مخزون"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.AcceptStockRequest.Fields.Id".ToLower(),
                ResourceValue = "Acceptance NO"
            });
            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.AcceptStockRequest.Fields.Id".ToLower(),
                ResourceValue = " كود الموافقة على الطلب"
            });
            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.AcceptStockRequest.Fields.StockRequestId".ToLower(),
                ResourceValue = "Request NO"
            });
            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.AcceptStockRequest.Fields.StockRequestId".ToLower(),
                ResourceValue = " رقم الطلب"
            });
            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.AcceptStockRequest.Fields.Accepted".ToLower(),
                ResourceValue = "Request Status"
            });
            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.AcceptStockRequest.Fields.Accepted".ToLower(),
                ResourceValue = " حالة الطلب"
            });
            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.AcceptStockRequest.Fields.RequestType".ToLower(),
                ResourceValue = "Request Type"
            });
            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.AcceptStockRequest.Fields.RequestType".ToLower(),
                ResourceValue = " نوع الطلب"
            });
            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.AcceptStockRequest.Fields.Comment".ToLower(),
                ResourceValue = "Comment"
            });
            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.AcceptStockRequest.Fields.Comment".ToLower(),
                ResourceValue = "تعليق"
            });
            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.Stock.Values.Damaged".ToLower(),
                ResourceValue = "Damaged"
            });
            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.Stock.Values.Damaged".ToLower(),
                ResourceValue = "تالف"
            });
            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.Stock.Values.ReturnedFromCustomer".ToLower(),
                ResourceValue = "Returned From Customer"
            });
            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.Stock.Values.ReturnedFromCustomer".ToLower(),
                ResourceValue = "مرتجع من العميل"
            });
            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.Stock.Values.Ordered".ToLower(),
                ResourceValue = "Ordered"
            });
            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.Stock.Values.Ordered".ToLower(),
                ResourceValue = "تم الطلب"
            });
            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockAction.Values.Accepted".ToLower(),
                ResourceValue = "Accepted"
            });
            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockAction.Values.Accepted".ToLower(),
                ResourceValue = "مقبول"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "admin.warehouses.stockrequestactions".ToLower(),
                ResourceValue = "Accepting Stock Requests"
            });
            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "admin.warehouses.stockrequestactions".ToLower(),
                ResourceValue = "حالة طلبات المخزون"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.AcceptStockRequest.List.Approved".ToLower(),
                ResourceValue = "Status"
            });
            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.AcceptStockRequest.List.Approved".ToLower(),
                ResourceValue = "الحالة"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockAction.Values.Refused".ToLower(),
                ResourceValue = "Rejected"
            });
            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockAction.Values.Refused".ToLower(),
                ResourceValue = "مرفوض"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.Stock.AcceptStockRequest".ToLower(),
                ResourceValue = "Stock Request Action"
            });
            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.Stock.AcceptStockRequest".ToLower(),
                ResourceValue = "الموافقة على طلب المخزون"
            });
            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.Stock.RequestData".ToLower(),
                ResourceValue = "Request Data"
            });
            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.Stock.RequestData".ToLower(),
                ResourceValue = "بيانات طلب المخزون"
            });
            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouse.Stock.StockRequestItems".ToLower(),
                ResourceValue = "Stock Request Items"
            });
            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouse.Stock.StockRequestItems".ToLower(),
                ResourceValue = "منتجات طلب المخزون"
            });
            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Common.StockActions".ToLower(),
                ResourceValue = "Stock Request Actions"
            });
            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Common.StockActions".ToLower(),
                ResourceValue = "الموافقة على طلب المخزون"
            });
            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Common.Review".ToLower(),
                ResourceValue = " Review"
            });
            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Common.Review".ToLower(),
                ResourceValue = "مراجعة"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockOperations.StockRequestAction.Header".ToLower(),
                ResourceValue = "Stock Receiving/Returning Request Actions"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockOperations.StockRequestAction.Header".ToLower(),
                ResourceValue = "طلب إستلام/إرجاع مخزون"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockOperations.StockRequestAction.Message".ToLower(),
                ResourceValue = "Displays the list of received/returned stocks, and allows you to receive/return stock to/from the warehouse."
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockOperations.StockRequestAction.Message".ToLower(),
                ResourceValue = "عرض قائمة بالمخزون المستلم والمرتجع والسماح بإنشاء طلبات استلام وإرجاع للمخزون بالمخزن."
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockOperations.StockRequestAction.Button".ToLower(),
                ResourceValue = "Manage Requests"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockOperations.StockRequestAction.Button".ToLower(),
                ResourceValue = "إدارة الطلبات"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockOperations.AcceptingStockRequests.Header".ToLower(),
                ResourceValue = "Accepting Stock Requests"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockOperations.AcceptingStockRequests.Header".ToLower(),
                ResourceValue = "الموافقة على طلبات المخزون"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockOperations.AcceptingStockRequests.Message".ToLower(),
                ResourceValue = "Displays the list of stock requests awaiting acceptance, and allows you to manage the approval process for stock requests."
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockOperations.AcceptingStockRequests.Message".ToLower(),
                ResourceValue = "عرض قائمة بطلبات المخزون المراد إتخاذ قرار بشأنها و السماح بإدارة هذه الطلبات."
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockOperations.AcceptingStockRequests.Button".ToLower(),
                ResourceValue = "Accepting Requests"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockOperations.AcceptingStockRequests.Button".ToLower(),
                ResourceValue = "قبول الطلبات"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.Barcode.LinkItemsToShelf".ToLower(),
                ResourceValue = "Link items to shelf"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.Barcode.LinkItemsToShelf".ToLower(),
                ResourceValue = "ربط منتجات برف"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.Barcode.LinkItemsToShelfCardTitle".ToLower(),
                ResourceValue = "Scan Barcodes"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.Barcode.LinkItemsToShelfCardTitle".ToLower(),
                ResourceValue = "قراءة الأكواد"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.Barcode.LinkedItemBarcode".ToLower(),
                ResourceValue = "Item Barcode"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.Barcode.LinkedItemBarcode".ToLower(),
                ResourceValue = "كود المنتج"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.Barcode.ScannedItems".ToLower(),
                ResourceValue = "Scanned Items"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.Barcode.ScannedItems".ToLower(),
                ResourceValue = "الأكواد المقروءة"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.Barcode.ShelfBarcode".ToLower(),
                ResourceValue = "Shelf Barcode"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.Barcode.ShelfBarcode".ToLower(),
                ResourceValue = "كود الرف"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.Barcode.ScanDamagedItems".ToLower(),
                ResourceValue = "Scan Damaged Items"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.Barcode.ScanDamagedItems".ToLower(),
                ResourceValue = "قراءة المنتجات الهالكة"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.Barcode.ScanItems".ToLower(),
                ResourceValue = "Scan Items"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.Barcode.ScanItems".ToLower(),
                ResourceValue = "قراءة المنتجات"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.Barcode.DamagedItemBarcode".ToLower(),
                ResourceValue = "Barcode"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.Barcode.DamagedItemBarcode".ToLower(),
                ResourceValue = "الباركود"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.ScanDamaged.NotValidItemsToScan".ToLower(),
                ResourceValue = "You have tried to scan invalid items"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.ScanDamaged.NotValidItemsToScan".ToLower(),
                ResourceValue = "الأكواد المقروءة غير صالحة"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.ScanDamaged.ImpossibleToHaveNegativeQuantity".ToLower(),
                ResourceValue = "Impossible to have negative quantity"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.ScanDamaged.ImpossibleToHaveNegativeQuantity".ToLower(),
                ResourceValue = "لا يمكن إتمام هذه العملية"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.Barcode.ScanSuccess".ToLower(),
                ResourceValue = "Scanning has been done successfully."
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.Barcode.ScanSuccess".ToLower(),
                ResourceValue = "تم إدخال الأكواد بنجاح"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.Barcode.PrintBarcodes".ToLower(),
                ResourceValue = "Print Barcodes"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.Barcode.PrintBarcodes".ToLower(),
                ResourceValue = "طباعة الباركود"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Common.Print".ToLower(),
                ResourceValue = "Print"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Common.Print".ToLower(),
                ResourceValue = "طباعة"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.Barcode.Sku".ToLower(),
                ResourceValue = "Sku"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.Barcode.Sku".ToLower(),
                ResourceValue = "الرمز المميز للمتغير"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.Barcode.Quantity".ToLower(),
                ResourceValue = "Quantity"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.Barcode.Quantity".ToLower(),
                ResourceValue = "الكمية"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.Barcode.QuantityError".ToLower(),
                ResourceValue = "Allowed range is between 1 and 200."
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.Barcode.QuantityError".ToLower(),
                ResourceValue = "الكمية المسموحة من 1 إلى 200"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.Barcode.ScanReceivedItems".ToLower(),
                ResourceValue = "Scan Received Items"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.Barcode.ScanReceivedItems".ToLower(),
                ResourceValue = "تسجيل المنتجات المستلمة"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.Barcode.ItemBarcode".ToLower(),
                ResourceValue = "Item Barcode"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.Barcode.ItemBarcode".ToLower(),
                ResourceValue = "باركود المنتج"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.Barcode.ConfirmSubmission".ToLower(),
                ResourceValue = "Confirm Submission"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.Barcode.ConfirmSubmission".ToLower(),
                ResourceValue = "تأكيد العملية"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.Barcode.Confirmation".ToLower(),
                ResourceValue = "Do you really want to submit the form?"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.Barcode.Confirmation".ToLower(),
                ResourceValue = "هل تريد بالفعل تأكيد العملية؟"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.Barcode.ConfirmationHeader".ToLower(),
                ResourceValue = "The following barcodes will not be processed:"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.Barcode.ConfirmationHeader".ToLower(),
                ResourceValue = "يوجد خطأ في الأكواد التالية ولن يتم إتخاذ إجراء لهم:"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.Barcode.ConfirmationSubmit".ToLower(),
                ResourceValue = "Submit"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.Barcode.ConfirmationSubmit".ToLower(),
                ResourceValue = "إرسال"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.Barcode.ConfirmationCancel".ToLower(),
                ResourceValue = "Cancel"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.Barcode.ConfirmationCancel".ToLower(),
                ResourceValue = "إلغاء"
            });

            //Accept Stock Request Model

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.AcceptStockRequest.Fields.RequestorId".ToLower(),
                ResourceValue = "Requestor"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.AcceptStockRequest.Fields.RequestorId".ToLower(),
                ResourceValue = "الطالب"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.AcceptStockRequest.Fields.StockRequestId".ToLower(),
                ResourceValue = "Request NO"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.AcceptStockRequest.Fields.StockRequestId".ToLower(),
                ResourceValue = "رقم الطلب"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.AcceptStockRequest.Fields.Accepted".ToLower(),
                ResourceValue = "Accepted"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.AcceptStockRequest.Fields.Accepted".ToLower(),
                ResourceValue = "تم القبول"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.AcceptStockRequest.Fields.RequestType".ToLower(),
                ResourceValue = "Request Type"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.AcceptStockRequest.Fields.RequestType".ToLower(),
                ResourceValue = "نوع الطلب"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.AcceptStockRequest.Fields.Comment".ToLower(),
                ResourceValue = "Comment"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.AcceptStockRequest.Fields.Comment".ToLower(),
                ResourceValue = "تعليق"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.AcceptStockRequest.Fields.ActionTakenBy".ToLower(),
                ResourceValue = "Action Taken By"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.AcceptStockRequest.Fields.ActionTakenBy".ToLower(),
                ResourceValue = "متخذ القرار"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.AcceptStockRequest.Fields.CreatedOnUtc".ToLower(),
                ResourceValue = "Created On Utc"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.AcceptStockRequest.Fields.CreatedOnUtc".ToLower(),
                ResourceValue = "تاريخ الإنشاء"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.AcceptStockRequest.Fields.UpdatedOnUtc".ToLower(),
                ResourceValue = "Updated On Utc"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.AcceptStockRequest.Fields.UpdatedOnUtc".ToLower(),
                ResourceValue = "تاريخ التحديث"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.AcceptStockRequest.Fields.CreatedBy".ToLower(),
                ResourceValue = "Created By"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.AcceptStockRequest.Fields.CreatedBy".ToLower(),
                ResourceValue = "تم الإنشاء بواسطة"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.AcceptStockRequest.Fields.UpdatedBy".ToLower(),
                ResourceValue = "Updated By"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.AcceptStockRequest.Fields.UpdatedBy".ToLower(),
                ResourceValue = "تم التحديث بواسطة"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.AcceptStockRequest.Fields.Deleted".ToLower(),
                ResourceValue = "Deleted"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.AcceptStockRequest.Fields.Deleted".ToLower(),
                ResourceValue = "تم الحذف"
            });

            //Accept Stock Request Search Model

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.AcceptStockRequest.List.SearchProductCategoryId".ToLower(),
                ResourceValue = "Product Category"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.AcceptStockRequest.List.SearchProductCategoryId".ToLower(),
                ResourceValue = "قسم المنتج"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.AcceptStockRequest.List.SearchProductCategoryName".ToLower(),
                ResourceValue = "Product Category"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.AcceptStockRequest.List.SearchProductCategoryName".ToLower(),
                ResourceValue = "قسم المنتج"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.AcceptStockRequest.List.RequestorId".ToLower(),
                ResourceValue = "Requestor"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.AcceptStockRequest.List.RequestorId".ToLower(),
                ResourceValue = "الطالب"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.AcceptStockRequest.List.RequestorName".ToLower(),
                ResourceValue = "Requestor"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.AcceptStockRequest.List.RequestorName".ToLower(),
                ResourceValue = "الطالب"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.AcceptStockRequest.List.StockRequestId".ToLower(),
                ResourceValue = "Request NO"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.AcceptStockRequest.List.StockRequestId".ToLower(),
                ResourceValue = "رقم طلب المخزون"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.AcceptStockRequest.List.Accepted".ToLower(),
                ResourceValue = "Accepted"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.AcceptStockRequest.List.Accepted".ToLower(),
                ResourceValue = "تم القبول"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.AcceptStockRequest.List.RequestType".ToLower(),
                ResourceValue = "Request Type"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.AcceptStockRequest.List.RequestType".ToLower(),
                ResourceValue = "نوع الطلب"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.AcceptStockRequest.List.RequestTypeName".ToLower(),
                ResourceValue = "Request Type Name"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.AcceptStockRequest.List.RequestTypeName".ToLower(),
                ResourceValue = "نوع الطلب"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.AcceptStockRequest.List.ActionTakenBy".ToLower(),
                ResourceValue = "Action Taken By"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.AcceptStockRequest.List.ActionTakenBy".ToLower(),
                ResourceValue = "متخذ القرار"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.AcceptStockRequest.List.SupervisorName".ToLower(),
                ResourceValue = "Supervisor Name"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.AcceptStockRequest.List.SupervisorName".ToLower(),
                ResourceValue = "متخذ القرار"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.AcceptStockRequest.List.WarehouseId".ToLower(),
                ResourceValue = "Warehouse"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.AcceptStockRequest.List.WarehouseId".ToLower(),
                ResourceValue = "مخزن"
            });

            //Shelf Model

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.Shelf.Fields.StandId".ToLower(),
                ResourceValue = "Stand NO"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.Shelf.Fields.StandId".ToLower(),
                ResourceValue = "رقم الحامل"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.Shelf.Fields.Barcode".ToLower(),
                ResourceValue = "Barcode"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.Shelf.Fields.Barcode".ToLower(),
                ResourceValue = "الباركود"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.Shelf.Fields.Active".ToLower(),
                ResourceValue = "Active"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.Shelf.Fields.Active".ToLower(),
                ResourceValue = "نشط"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.Shelf.Fields.CreatedOnUtc".ToLower(),
                ResourceValue = "Created On Utc"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.Shelf.Fields.CreatedOnUtc".ToLower(),
                ResourceValue = "تاريخ الإنشاء"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.Shelf.Fields.UpdatedOnUtc".ToLower(),
                ResourceValue = "Updated On Utc"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.Shelf.Fields.UpdatedOnUtc".ToLower(),
                ResourceValue = "تاريخ التحديث"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.Shelf.Fields.CreatedBy".ToLower(),
                ResourceValue = "Created By"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.Shelf.Fields.CreatedBy".ToLower(),
                ResourceValue = "تم الانشاء بواسطة"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.Shelf.Fields.UpdatedBy".ToLower(),
                ResourceValue = "Updated By"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.Shelf.Fields.UpdatedBy".ToLower(),
                ResourceValue = "تم التحديث بواسطة"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.Shelf.Fields.Deleted".ToLower(),
                ResourceValue = "Deleted"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.Shelf.Fields.Deleted".ToLower(),
                ResourceValue = "تم الحذف"
            });

            //Shelf Search Model

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.Shelf.List.WarehouseId".ToLower(),
                ResourceValue = "Warehouse"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.Shelf.List.WarehouseId".ToLower(),
                ResourceValue = "مخزن"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.Shelf.List.StandId".ToLower(),
                ResourceValue = "Stand NO"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.Shelf.List.StandId".ToLower(),
                ResourceValue = "رقم الحامل"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.Shelf.List.Barcode".ToLower(),
                ResourceValue = "Barcode"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.Shelf.List.Barcode".ToLower(),
                ResourceValue = "الباركود"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.Shelf.List.Active".ToLower(),
                ResourceValue = "Active"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.Shelf.List.Active".ToLower(),
                ResourceValue = "نشط"
            });

            //Shelf Item Mapping Model

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.ShelfItemMapping.Fields.ShelfId".ToLower(),
                ResourceValue = "Shelf NO"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.ShelfItemMapping.Fields.ShelfId".ToLower(),
                ResourceValue = "رقم الحامل"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.ShelfItemMapping.Fields.ItemId".ToLower(),
                ResourceValue = "Item NO"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.ShelfItemMapping.Fields.ItemId".ToLower(),
                ResourceValue = "رقم العنصر"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.ShelfItemMapping.Fields.CreatedOnUtc".ToLower(),
                ResourceValue = "Created On Utc"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.ShelfItemMapping.Fields.CreatedOnUtc".ToLower(),
                ResourceValue = "تاريخ الإنشاء"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.ShelfItemMapping.Fields.UpdatedOnUtc".ToLower(),
                ResourceValue = "Updated On Utc"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.ShelfItemMapping.Fields.UpdatedOnUtc".ToLower(),
                ResourceValue = "تاريخ التحديث"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.ShelfItemMapping.Fields.CreatedBy".ToLower(),
                ResourceValue = "Created By"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.ShelfItemMapping.Fields.CreatedBy".ToLower(),
                ResourceValue = "تم الانشاء بواسطة"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.ShelfItemMapping.Fields.UpdatedBy".ToLower(),
                ResourceValue = "Updated By"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.ShelfItemMapping.Fields.UpdatedBy".ToLower(),
                ResourceValue = "تم التحديث بواسطة"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.ShelfItemMapping.Fields.Deleted".ToLower(),
                ResourceValue = "Deleted"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.ShelfItemMapping.Fields.Deleted".ToLower(),
                ResourceValue = "تم الحذف"
            });

            //Shelf Item Mapping Search Model

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.ShelfItemMapping.List.ShelfId".ToLower(),
                ResourceValue = "Shelf NO"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.ShelfItemMapping.List.ShelfId".ToLower(),
                ResourceValue = "رقم الرف"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.ShelfItemMapping.List.ShelfBarcode".ToLower(),
                ResourceValue = "Shelf Barcode"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.ShelfItemMapping.List.ShelfBarcode".ToLower(),
                ResourceValue = "باركود الرف"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.ShelfItemMapping.List.ItemId".ToLower(),
                ResourceValue = "Item NO"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.ShelfItemMapping.List.ItemId".ToLower(),
                ResourceValue = "رقم العنصر"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.ShelfItemMapping.List.ItemBarcode".ToLower(),
                ResourceValue = "Item Barcode"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.ShelfItemMapping.List.ItemBarcode".ToLower(),
                ResourceValue = "باركود العنصر"
            });

            //Stock History Model

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockHistory.Fields.RequestId".ToLower(),
                ResourceValue = "Request NO"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockHistory.Fields.RequestId".ToLower(),
                ResourceValue = "رقم الطلب"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockHistory.Fields.WarehouseId".ToLower(),
                ResourceValue = "Warehouse"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockHistory.Fields.WarehouseId".ToLower(),
                ResourceValue = "مخزن"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockHistory.Fields.VendorId".ToLower(),
                ResourceValue = "Vendor"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockHistory.Fields.VendorId".ToLower(),
                ResourceValue = "التاجر"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockHistory.Fields.TypeOfProcess".ToLower(),
                ResourceValue = "Type Of Process"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockHistory.Fields.TypeOfProcess".ToLower(),
                ResourceValue = "نوع العملية"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockHistory.Fields.Priority".ToLower(),
                ResourceValue = "Priority"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockHistory.Fields.Priority".ToLower(),
                ResourceValue = "الأولوية"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockHistory.Fields.Id	".ToLower(),
                ResourceValue = "Stock NO"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "admin.warehouses.stockhistory.fields.id	".ToLower(),
                ResourceValue = "رقم المخزون"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockHistory.Fields.CreatedOnUtc".ToLower(),
                ResourceValue = "Created On Utc"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockHistory.Fields.CreatedOnUtc".ToLower(),
                ResourceValue = "تاريخ الانشاء"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockHistory.Fields.UpdatedOnUtc".ToLower(),
                ResourceValue = "Updated On Utc"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockHistory.Fields.UpdatedOnUtc".ToLower(),
                ResourceValue = "تاريخ التحديث"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockHistory.Fields.CreatedBy".ToLower(),
                ResourceValue = "Created By"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockHistory.Fields.CreatedBy".ToLower(),
                ResourceValue = "تم الانشاء بواسطة"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockHistory.Fields.UpdatedBy".ToLower(),
                ResourceValue = "Updated By"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockHistory.Fields.UpdatedBy".ToLower(),
                ResourceValue = "تم التحديث بواسطة"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockHistory.Fields.Deleted".ToLower(),
                ResourceValue = "Deleted"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockHistory.Fields.Deleted".ToLower(),
                ResourceValue = "تم الحذف"
            });

            //Stock History Search Model

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockHistory.List.WarehouseId".ToLower(),
                ResourceValue = "Warehouse"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockHistory.List.WarehouseId".ToLower(),
                ResourceValue = "مخزن"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockHistory.List.VendorId".ToLower(),
                ResourceValue = "Vendor"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockHistory.List.VendorId".ToLower(),
                ResourceValue = "التاجر"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockHistory.List.TypeOfProcess".ToLower(),
                ResourceValue = "Type Of Process"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockHistory.List.TypeOfProcess".ToLower(),
                ResourceValue = "نوع العملية"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockHistory.List.Priority".ToLower(),
                ResourceValue = "Priority"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockHistory.List.Priority".ToLower(),
                ResourceValue = "الأولوية"
            });

            //Stock Item History Model

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockItemHistory.Fields.StockHistoryId".ToLower(),
                ResourceValue = "Stock History Id"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockItemHistory.Fields.StockHistoryId".ToLower(),
                ResourceValue = "رقم سجل المخزون"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockItemHistory.Fields.WarehouseProductCombinationId".ToLower(),
                ResourceValue = "Warehouse Product Combination Id"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockItemHistory.Fields.WarehouseProductCombinationId".ToLower(),
                ResourceValue = "الرقم التعريفي لمتغير منتج مخزن"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockItemHistory.Fields.StockQuantity".ToLower(),
                ResourceValue = "Stock Quantity"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockItemHistory.Fields.StockQuantity".ToLower(),
                ResourceValue = "كمية المخزون"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockItemHistory.Fields.UnitPrice".ToLower(),
                ResourceValue = "Unit Price"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockItemHistory.Fields.UnitPrice".ToLower(),
                ResourceValue = "سعر الوحدة"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockItemHistory.Fields.Tax".ToLower(),
                ResourceValue = "Tax"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockItemHistory.Fields.Tax".ToLower(),
                ResourceValue = "الضريبة"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockItemHistory.Fields.Discount".ToLower(),
                ResourceValue = "Discount"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockItemHistory.Fields.Discount".ToLower(),
                ResourceValue = "الخصم"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockItemHistory.Fields.Profit".ToLower(),
                ResourceValue = "Profit"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockItemHistory.Fields.Profit".ToLower(),
                ResourceValue = "الربح"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockItemHistory.Fields.ItemDescription".ToLower(),
                ResourceValue = "Item Description"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockItemHistory.Fields.ItemDescription".ToLower(),
                ResourceValue = "وصف العنصر"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockItemHistory.Fields.SKU".ToLower(),
                ResourceValue = "SKU"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockItemHistory.Fields.HasExpirationDate".ToLower(),
                ResourceValue = "Has Expiration Date"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockItemHistory.Fields.HasExpirationDate".ToLower(),
                ResourceValue = "محدود الصلاحية"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockItemHistory.Fields.ExpirationDate".ToLower(),
                ResourceValue = "Expiration Date"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockItemHistory.Fields.ExpirationDate".ToLower(),
                ResourceValue = "تاريخ انتهاء الصلاحية"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockItemHistory.Fields.SKU".ToLower(),
                ResourceValue = "الرمز المميز للمتغير"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockItemHistory.Fields.CreatedOnUtc".ToLower(),
                ResourceValue = "Created On Utc"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockItemHistory.Fields.CreatedOnUtc".ToLower(),
                ResourceValue = "تاريخ الإنشاء"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockItemHistory.Fields.UpdatedOnUtc".ToLower(),
                ResourceValue = "Updated On Utc"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockItemHistory.Fields.UpdatedOnUtc".ToLower(),
                ResourceValue = "تاريخ التحديث"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockItemHistory.Fields.CreatedBy".ToLower(),
                ResourceValue = "Created By"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockItemHistory.Fields.CreatedBy".ToLower(),
                ResourceValue = "تم الانشاء بواسطة"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockItemHistory.Fields.UpdatedBy".ToLower(),
                ResourceValue = "Updated By"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockItemHistory.Fields.UpdatedBy".ToLower(),
                ResourceValue = "تم التحديث بواسطة"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockItemHistory.Fields.Deleted".ToLower(),
                ResourceValue = "Deleted"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockItemHistory.Fields.Deleted".ToLower(),
                ResourceValue = "تم الحذف"
            });

            //Stock Item History Search Model

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockItemHistory.List.StockHistoryId".ToLower(),
                ResourceValue = "Stock History"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockItemHistory.List.StockHistoryId".ToLower(),
                ResourceValue = "سجل المخزون"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockItemHistory.List.WarehouseProductCombinationId".ToLower(),
                ResourceValue = "Warehouse Product Combination"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockItemHistory.List.WarehouseProductCombinationId".ToLower(),
                ResourceValue = "متغير منتج مخزن"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockItemHistory.List.Sku".ToLower(),
                ResourceValue = "Sku"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockItemHistory.List.Sku".ToLower(),
                ResourceValue = "الرمز المميز للمتغير"
            });

            //Stock Request Model

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockRequest.Fields.WarehouseId".ToLower(),
                ResourceValue = "Warehouse NO"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockRequest.Fields.WarehouseId".ToLower(),
                ResourceValue = "المخزن"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockRequest.Fields.VendorId".ToLower(),
                ResourceValue = "Vendor Id"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockRequest.Fields.VendorId".ToLower(),
                ResourceValue = "التاجر"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockRequest.Fields.TypeOfProcess".ToLower(),
                ResourceValue = "Type Of Process"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockRequest.Fields.TypeOfProcess".ToLower(),
                ResourceValue = "نوع العملية"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockRequest.Fields.Priority".ToLower(),
                ResourceValue = "Priority"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockRequest.Fields.Priority".ToLower(),
                ResourceValue = "الأولوية"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockRequest.Fields.CreatedOnUtc".ToLower(),
                ResourceValue = "Created On Utc"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockRequest.Fields.CreatedOnUtc".ToLower(),
                ResourceValue = "تاريخ الإنشاء"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockRequest.Fields.UpdatedOnUtc".ToLower(),
                ResourceValue = "Updated On Utc"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockRequest.Fields.UpdatedOnUtc".ToLower(),
                ResourceValue = "تاريخ التحديث"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockRequest.Fields.CreatedBy".ToLower(),
                ResourceValue = "Created By"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockRequest.Fields.CreatedBy".ToLower(),
                ResourceValue = "تم الإنشاء بواسطة"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockRequest.Fields.UpdatedBy".ToLower(),
                ResourceValue = "Updated By"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockRequest.Fields.UpdatedBy".ToLower(),
                ResourceValue = "تم التحديث بواسطة"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockRequest.Fields.Deleted".ToLower(),
                ResourceValue = "Deleted"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockRequest.Fields.Deleted".ToLower(),
                ResourceValue = "تم الحذف"
            });

            //Stock Request Search Model

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockRequest.List.WarehouseId".ToLower(),
                ResourceValue = "Warehouse"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockRequest.List.WarehouseId".ToLower(),
                ResourceValue = "المخزن"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockRequest.List.VendorId".ToLower(),
                ResourceValue = "Vendor"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockRequest.List.VendorId".ToLower(),
                ResourceValue = "التاجر"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockRequest.List.TypeOfProcess".ToLower(),
                ResourceValue = "Type Of Process"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockRequest.List.TypeOfProcess".ToLower(),
                ResourceValue = "نوع العملية"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockRequest.List.Priority".ToLower(),
                ResourceValue = "Priority"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockRequest.List.Priority".ToLower(),
                ResourceValue = "الأولوية"
            });

            //Stock Request Item Model

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockRequestItem.Fields.StockRequestId".ToLower(),
                ResourceValue = "Request NO"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockRequestItem.Fields.StockRequestId".ToLower(),
                ResourceValue = "رقم الطلب"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockRequestItem.Fields.WarehouseProductCombinationId".ToLower(),
                ResourceValue = "Warehouse Product Combination Id"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockRequestItem.Fields.WarehouseProductCombinationId".ToLower(),
                ResourceValue = "الرقم التعريفي لمتغير منتج مخزن"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockRequestItem.Fields.StockQuantity".ToLower(),
                ResourceValue = "Stock Quantity"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockRequestItem.Fields.StockQuantity".ToLower(),
                ResourceValue = "كمية المخزون"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockRequestItem.Fields.UnitPrice".ToLower(),
                ResourceValue = "Unit Price"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockRequestItem.Fields.UnitPrice".ToLower(),
                ResourceValue = "سعر الوحدة"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockRequestItem.Fields.Tax".ToLower(),
                ResourceValue = "Tax"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockRequestItem.Fields.Tax".ToLower(),
                ResourceValue = "الضريبة"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockRequestItem.Fields.Discount".ToLower(),
                ResourceValue = "Discount"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockRequestItem.Fields.Discount".ToLower(),
                ResourceValue = "الخصم"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockRequestItem.Fields.Profit".ToLower(),
                ResourceValue = "Profit"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockRequestItem.Fields.Profit".ToLower(),
                ResourceValue = "الربح"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockRequestItem.Fields.ItemDescription".ToLower(),
                ResourceValue = "Item Description"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockRequestItem.Fields.ItemDescription".ToLower(),
                ResourceValue = "وصف العنصر"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockRequestItem.Fields.CreatedOnUtc".ToLower(),
                ResourceValue = "Created On Utc"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockRequestItem.Fields.CreatedOnUtc".ToLower(),
                ResourceValue = "تاريخ الإنشاء"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockRequestItem.Fields.UpdatedOnUtc".ToLower(),
                ResourceValue = "Updated On Utc"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockRequestItem.Fields.UpdatedOnUtc".ToLower(),
                ResourceValue = "تاريخ التحديث"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockRequestItem.Fields.CreatedBy".ToLower(),
                ResourceValue = "Created By"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockRequestItem.Fields.CreatedBy".ToLower(),
                ResourceValue = "تم الإنشاء بواسطة"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockRequestItem.Fields.UpdatedBy".ToLower(),
                ResourceValue = "Updated By"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockRequestItem.Fields.UpdatedBy".ToLower(),
                ResourceValue = "تم التحديث بواسطة"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockRequestItem.Fields.Deleted".ToLower(),
                ResourceValue = "Deleted"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockRequestItem.Fields.Deleted".ToLower(),
                ResourceValue = "تم الحذف"
            });

            //Stock Request Item Search Model

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockRequestItem.List.StockRequestId".ToLower(),
                ResourceValue = "Request NO"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockRequestItem.List.StockRequestId".ToLower(),
                ResourceValue = "رقم الطلب"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockRequestItem.List.WarehouseProductCombinationId".ToLower(),
                ResourceValue = "Warehouse Product Combination Id"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockRequestItem.List.WarehouseProductCombinationId".ToLower(),
                ResourceValue = "الرقم التعريفي لمتغير منتج مخزن"
            });

            //User Status Change Log Model

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.UserStatusChangeLog.Fields.WarehouseId".ToLower(),
                ResourceValue = "Warehouse Id"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.UserStatusChangeLog.Fields.WarehouseId".ToLower(),
                ResourceValue = "رقم المخزن"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.UserStatusChangeLog.Fields.UserId".ToLower(),
                ResourceValue = "User Id"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.UserStatusChangeLog.Fields.UserId".ToLower(),
                ResourceValue = "رقم المستخدم"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.UserStatusChangeLog.Fields.ActionType".ToLower(),
                ResourceValue = "Action Type"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.UserStatusChangeLog.Fields.ActionType".ToLower(),
                ResourceValue = "نوع الاجراء"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.UserStatusChangeLog.Fields.Reason".ToLower(),
                ResourceValue = "Reason"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.UserStatusChangeLog.Fields.Reason".ToLower(),
                ResourceValue = "السبب"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.UserStatusChangeLog.Fields.ActionTakenBy".ToLower(),
                ResourceValue = "Action Taken By"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.UserStatusChangeLog.Fields.ActionTakenBy".ToLower(),
                ResourceValue = "متخذ الاجراء"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.UserStatusChangeLog.Fields.ActionDateUtc".ToLower(),
                ResourceValue = "Action Date Utc"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.UserStatusChangeLog.Fields.ActionDateUtc".ToLower(),
                ResourceValue = "تاريخ الاجراء"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.UserStatusChangeLog.Fields.Deleted".ToLower(),
                ResourceValue = "Deleted"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.UserStatusChangeLog.Fields.Deleted".ToLower(),
                ResourceValue = "تم الحذف"
            });

            //User Status Change Log Search Model

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.UserStatusChangeLog.List.WarehouseId".ToLower(),
                ResourceValue = "Warehouse"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.UserStatusChangeLog.List.WarehouseId".ToLower(),
                ResourceValue = "المخزن"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.UserStatusChangeLog.List.UserId".ToLower(),
                ResourceValue = "User"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.UserStatusChangeLog.List.UserId".ToLower(),
                ResourceValue = "المستخدم"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.UserStatusChangeLog.List.UserName".ToLower(),
                ResourceValue = "User Name"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.UserStatusChangeLog.List.UserName".ToLower(),
                ResourceValue = "اسم المستخدم"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.UserStatusChangeLog.List.ActionType".ToLower(),
                ResourceValue = "Action Type"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.UserStatusChangeLog.List.ActionType".ToLower(),
                ResourceValue = "نوع الاجراء"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.UserStatusChangeLog.List.ActionTakenBy".ToLower(),
                ResourceValue = "Action Taken By"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.UserStatusChangeLog.List.ActionTakenBy".ToLower(),
                ResourceValue = "متخذ الاجراء"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.UserStatusChangeLog.List.DoerName".ToLower(),
                ResourceValue = "Doer Name"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.UserStatusChangeLog.List.DoerName".ToLower(),
                ResourceValue = "اسم متخذ الاجراء"
            });

            //Warehouse Category Model

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseCategory.Fields.Name".ToLower(),
                ResourceValue = "Name"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseCategory.Fields.Name".ToLower(),
                ResourceValue = "الاسم"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseCategory.Fields.Description".ToLower(),
                ResourceValue = "Description"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseCategory.Fields.Description".ToLower(),
                ResourceValue = "الوصف"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseCategory.Fields.ParentCategoryId".ToLower(),
                ResourceValue = "Parent Category"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseCategory.Fields.ParentCategoryId".ToLower(),
                ResourceValue = "الفئة الأم"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseCategory.Fields.DisplayOrder".ToLower(),
                ResourceValue = "Display Order"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseCategory.Fields.DisplayOrder".ToLower(),
                ResourceValue = "ترتيب العرض"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseCategory.Fields.IsSystem".ToLower(),
                ResourceValue = "Is System"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseCategory.Fields.IsSystem".ToLower(),
                ResourceValue = "تابع للنظام"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseCategory.Fields.CreatedOnUtc".ToLower(),
                ResourceValue = "Created On Utc"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseCategory.Fields.CreatedOnUtc".ToLower(),
                ResourceValue = "تاريخ الانشاء"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseCategory.Fields.UpdatedOnUtc".ToLower(),
                ResourceValue = "Updated On Utc"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseCategory.Fields.UpdatedOnUtc".ToLower(),
                ResourceValue = "تاريخ التحديث"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseCategory.Fields.CreatedBy".ToLower(),
                ResourceValue = "Created By"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseCategory.Fields.CreatedBy".ToLower(),
                ResourceValue = "تم الانشاء بواسطة"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseCategory.Fields.UpdatedBy".ToLower(),
                ResourceValue = "Updated By"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseCategory.Fields.UpdatedBy".ToLower(),
                ResourceValue = "تم التحديث بواسطة"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseCategory.Fields.Deleted".ToLower(),
                ResourceValue = "Deleted"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseCategory.Fields.Deleted".ToLower(),
                ResourceValue = "تم الحذف"
            });

            //Warehouse Category Search Model

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseCategory.List.SearchWarehouseCategoryName".ToLower(),
                ResourceValue = "Warehouse Category"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseCategory.List.SearchWarehouseCategoryName".ToLower(),
                ResourceValue = "قسم المخزن"
            });

            //Warehouse Category Mapping Model

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseCategoryMapping.Fields.WarehouseId".ToLower(),
                ResourceValue = "Warehouse"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseCategoryMapping.Fields.WarehouseId".ToLower(),
                ResourceValue = "مخزن"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseCategoryMapping.Fields.WarehouseCategoryId".ToLower(),
                ResourceValue = "Warehouse Category"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseCategoryMapping.Fields.WarehouseCategoryId".ToLower(),
                ResourceValue = "قسم مخزن"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseCategoryMapping.Fields.IsSystem".ToLower(),
                ResourceValue = "Is System"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseCategoryMapping.Fields.IsSystem".ToLower(),
                ResourceValue = "تابع للنظام"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseCategoryMapping.Fields.CreatedOnUtc".ToLower(),
                ResourceValue = "Created On Utc"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseCategoryMapping.Fields.CreatedOnUtc".ToLower(),
                ResourceValue = "تاريخ الانشاء"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseCategoryMapping.Fields.UpdatedOnUtc".ToLower(),
                ResourceValue = "Updated On Utc"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseCategoryMapping.Fields.UpdatedOnUtc".ToLower(),
                ResourceValue = "تاريخ التحديث"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseCategoryMapping.Fields.CreatedBy".ToLower(),
                ResourceValue = "Created By"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseCategoryMapping.Fields.CreatedBy".ToLower(),
                ResourceValue = "تم الانشاء بواسطة"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseCategoryMapping.Fields.UpdatedBy".ToLower(),
                ResourceValue = "Updated By"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseCategoryMapping.Fields.UpdatedBy".ToLower(),
                ResourceValue = "تم التحديث بواسطة"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseCategoryMapping.Fields.Deleted".ToLower(),
                ResourceValue = "Deleted"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseCategoryMapping.Fields.Deleted".ToLower(),
                ResourceValue = "تم الحذف"
            });

            //Warehouse Category Mapping Search Model

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseCategoryMapping.List.SearchWarehouseCategoryName".ToLower(),
                ResourceValue = "Warehouse Category"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseCategoryMapping.List.SearchWarehouseCategoryName".ToLower(),
                ResourceValue = "قسم المخزن"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseCategoryMapping.List.SearchWarehouseCategoryId".ToLower(),
                ResourceValue = "Warehouse Category"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseCategoryMapping.List.SearchWarehouseCategoryId".ToLower(),
                ResourceValue = "قسم المخزن"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseCategoryMapping.List.WarehouseId".ToLower(),
                ResourceValue = "Warehouse"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseCategoryMapping.List.WarehouseId".ToLower(),
                ResourceValue = "مخزن"
            });

            //Warehouse Item Model

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseItem.Fields.StockItemHistoryId".ToLower(),
                ResourceValue = "Stock Item History Id"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseItem.Fields.StockItemHistoryId".ToLower(),
                ResourceValue = "سجل عنصر"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseItem.Fields.WarehouseProductCombinationId".ToLower(),
                ResourceValue = "Warehouse Product Combination Id"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseItem.Fields.WarehouseProductCombinationId".ToLower(),
                ResourceValue = "الرقم التعريفي لمتغير منتج مخزن"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseItem.Fields.Sku".ToLower(),
                ResourceValue = "Sku"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseItem.Fields.Sku".ToLower(),
                ResourceValue = "الرمز المميز للمتغير"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseItem.Fields.Barcode".ToLower(),
                ResourceValue = "Barcode"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseItem.Fields.Barcode".ToLower(),
                ResourceValue = "الباركود"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseItem.Fields.ItemStatus".ToLower(),
                ResourceValue = "Item Status"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseItem.Fields.ItemStatus".ToLower(),
                ResourceValue = "حالة العنصر"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseItem.Fields.Printed".ToLower(),
                ResourceValue = "Printed"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseItem.Fields.Printed".ToLower(),
                ResourceValue = "تم الطباعة"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseItem.Fields.Scanned".ToLower(),
                ResourceValue = "Scanned"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseItem.Fields.Scanned".ToLower(),
                ResourceValue = "تم الفحص"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseItem.Fields.Ordered".ToLower(),
                ResourceValue = "Ordered"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseItem.Fields.Ordered".ToLower(),
                ResourceValue = "تم الطلب"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseItem.Fields.HasExpirationDate".ToLower(),
                ResourceValue = "Has Expiration Date"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseItem.Fields.HasExpirationDate".ToLower(),
                ResourceValue = "محدود الصلاحية"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseItem.Fields.ExpirationDate".ToLower(),
                ResourceValue = "Expiration Date"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseItem.Fields.ExpirationDate".ToLower(),
                ResourceValue = "تاريخ انتهاء الصلاحية"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseItem.Fields.WarehouseId".ToLower(),
                ResourceValue = "Warehouse"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseItem.Fields.WarehouseId".ToLower(),
                ResourceValue = "مخزن"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseItem.Fields.CreatedOnUtc".ToLower(),
                ResourceValue = "Created On Utc"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseItem.Fields.CreatedOnUtc".ToLower(),
                ResourceValue = "تاريخ الانشاء"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseItem.Fields.UpdatedOnUtc".ToLower(),
                ResourceValue = "Updated On Utc"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseItem.Fields.UpdatedOnUtc".ToLower(),
                ResourceValue = "تاريخ الانتهاء"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseItem.Fields.CreatedBy".ToLower(),
                ResourceValue = "Created By"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseItem.Fields.CreatedBy".ToLower(),
                ResourceValue = "تم الانشاء بواسطة"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseItem.Fields.UpdatedBy".ToLower(),
                ResourceValue = "Updated By"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseItem.Fields.UpdatedBy".ToLower(),
                ResourceValue = "تم التحديث بواسطة"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseItem.Fields.Deleted".ToLower(),
                ResourceValue = "Deleted"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseItem.Fields.Deleted".ToLower(),
                ResourceValue = "تم الحذف"
            });

            //Warehouse Item Search Model

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseItem.List.StockItemHistoryId".ToLower(),
                ResourceValue = "Stock Item History Id"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseItem.List.StockItemHistoryId".ToLower(),
                ResourceValue = "سجل عنصر"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseItem.List.Barcode".ToLower(),
                ResourceValue = "Barcode"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseItem.List.Barcode".ToLower(),
                ResourceValue = "الباركود"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseItem.List.ItemStatus".ToLower(),
                ResourceValue = "Item Status"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseItem.List.ItemStatus".ToLower(),
                ResourceValue = "حالة العنصر"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseItem.List.Printed".ToLower(),
                ResourceValue = "Printed"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseItem.List.Printed".ToLower(),
                ResourceValue = "تم الطباعة"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseItem.List.Scanned".ToLower(),
                ResourceValue = "Scanned"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseItem.List.Scanned".ToLower(),
                ResourceValue = "تم الفحص"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseItem.List.Ordered".ToLower(),
                ResourceValue = "Ordered"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseItem.List.Ordered".ToLower(),
                ResourceValue = "تم الطلب"
            });

            //Warehouse Product Model

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseProduct.Fields.WarehouseProductCategoryMappingId".ToLower(),
                ResourceValue = "Warehouse Category"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseProduct.Fields.WarehouseProductCategoryMappingId".ToLower(),
                ResourceValue = "قسم المخزن"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseProduct.Fields.ProductId".ToLower(),
                ResourceValue = "Product"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseProduct.Fields.ProductId".ToLower(),
                ResourceValue = "المنتج"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseProduct.Fields.Available".ToLower(),
                ResourceValue = "Available"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseProduct.Fields.Available".ToLower(),
                ResourceValue = "متاح"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseProduct.Fields.WarehouseId".ToLower(),
                ResourceValue = "Warehouse Id"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseProduct.Fields.WarehouseId".ToLower(),
                ResourceValue = "رقم المخزن"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseProduct.Fields.Name".ToLower(),
                ResourceValue = "Name"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseProduct.Fields.Name".ToLower(),
                ResourceValue = "الاسم"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseProduct.Fields.ShortDescription".ToLower(),
                ResourceValue = "Short Description"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseProduct.Fields.ShortDescription".ToLower(),
                ResourceValue = "وصف قصير"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseProduct.Fields.FullDescription".ToLower(),
                ResourceValue = "Full Description"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseProduct.Fields.FullDescription".ToLower(),
                ResourceValue = "وصف مطول"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseProduct.Fields.Sku".ToLower(),
                ResourceValue = "Sku"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseProduct.Fields.Sku".ToLower(),
                ResourceValue = "الرمز المميز للمتغير"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseProduct.Fields.CreatedOnUtc".ToLower(),
                ResourceValue = "Created On Utc"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseProduct.Fields.CreatedOnUtc".ToLower(),
                ResourceValue = "تاريخ الانشاء"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseProduct.Fields.UpdatedOnUtc".ToLower(),
                ResourceValue = "Updated On Utc"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseProduct.Fields.UpdatedOnUtc".ToLower(),
                ResourceValue = "تاريخ التحديث"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseProduct.Fields.CreatedBy".ToLower(),
                ResourceValue = "Created By"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseProduct.Fields.CreatedBy".ToLower(),
                ResourceValue = "تم الانشاء بواسطة"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseProduct.Fields.UpdatedBy".ToLower(),
                ResourceValue = "Updated By"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseProduct.Fields.UpdatedBy".ToLower(),
                ResourceValue = "تم التحديث بواسطة"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseProduct.Fields.Deleted".ToLower(),
                ResourceValue = "Deleted"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseProduct.Fields.Deleted".ToLower(),
                ResourceValue = "تم الحذف"
            });

            //Warehouse Product Search Model

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseProduct.List.WarehouseId".ToLower(),
                ResourceValue = "Warehouse Id"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseProduct.List.WarehouseId".ToLower(),
                ResourceValue = "رقم المخزن"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseProduct.List.Name".ToLower(),
                ResourceValue = "Name"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseProduct.List.Name".ToLower(),
                ResourceValue = "الاسم"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseProduct.List.Available".ToLower(),
                ResourceValue = "Available"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseProduct.List.Available".ToLower(),
                ResourceValue = "متاح"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseProduct.List.Sku".ToLower(),
                ResourceValue = "Sku"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseProduct.List.Sku".ToLower(),
                ResourceValue = "الرمز المميز للمتغير"
            });

            //Warehouse Product Category Mapping Model

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseProductCategoryMapping.Fields.WarehouseId".ToLower(),
                ResourceValue = "Warehouse Id"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseProductCategoryMapping.Fields.WarehouseId".ToLower(),
                ResourceValue = "رقم المخزن"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseProductCategoryMapping.Fields.WarehouseCategoryMappingId".ToLower(),
                ResourceValue = "Warehouse Category"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseProductCategoryMapping.Fields.WarehouseCategoryMappingId".ToLower(),
                ResourceValue = "قسم المخزن"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseProductCategoryMapping.Fields.ProductCategoryId".ToLower(),
                ResourceValue = "Product Category"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseProductCategoryMapping.Fields.ProductCategoryId".ToLower(),
                ResourceValue = "قسم المنتج"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseProductCategoryMapping.Fields.CreatedOnUtc".ToLower(),
                ResourceValue = "Created On Utc"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseProductCategoryMapping.Fields.CreatedOnUtc".ToLower(),
                ResourceValue = "تاريخ الانشاء"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseProductCategoryMapping.Fields.UpdatedOnUtc".ToLower(),
                ResourceValue = "Updated On Utc"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseProductCategoryMapping.Fields.UpdatedOnUtc".ToLower(),
                ResourceValue = "تاريخ التحديث"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseProductCategoryMapping.Fields.CreatedBy".ToLower(),
                ResourceValue = "Created By"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseProductCategoryMapping.Fields.CreatedBy".ToLower(),
                ResourceValue = "تم الانشاء بواسطة"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseProductCategoryMapping.Fields.UpdatedBy".ToLower(),
                ResourceValue = "Updated By"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseProductCategoryMapping.Fields.UpdatedBy".ToLower(),
                ResourceValue = "تم التحديث بواسطة"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseProductCategoryMapping.Fields.Deleted".ToLower(),
                ResourceValue = "Deleted"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseProductCategoryMapping.Fields.Deleted".ToLower(),
                ResourceValue = "تم الحذف"
            });

            //Warehouse Product Category Mapping Search Model

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseProductCategoryMapping.List.SearchProductCategoryId".ToLower(),
                ResourceValue = "Product Category"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseProductCategoryMapping.List.SearchProductCategoryId".ToLower(),
                ResourceValue = "قسم المنتج"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseProductCategoryMapping.List.SearchProductCategoryName".ToLower(),
                ResourceValue = "Search Product Category Name"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseProductCategoryMapping.List.SearchProductCategoryName".ToLower(),
                ResourceValue = "قسم المنتج"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseProductCategoryMapping.List.SearchWarehouseCategoryMappingId".ToLower(),
                ResourceValue = "Search Warehouse Category Mapping Id"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseProductCategoryMapping.List.SearchWarehouseCategoryMappingId".ToLower(),
                ResourceValue = "ربط قسم المنتج"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseProductCategoryMapping.List.SearchWarehouseCategoryMappingName".ToLower(),
                ResourceValue = "Search Warehouse Category Mapping Name"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseProductCategoryMapping.List.SearchWarehouseCategoryMappingName".ToLower(),
                ResourceValue = "ربط قسم المنتج"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseProductCategoryMapping.List.WarehouseId".ToLower(),
                ResourceValue = "Warehouse"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseProductCategoryMapping.List.WarehouseId".ToLower(),
                ResourceValue = "مخزن"
            });

            //Warehouse Product Combination Model

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseProductCombination.Fields.WarehouseId".ToLower(),
                ResourceValue = "Warehouse"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseProductCombination.Fields.WarehouseId".ToLower(),
                ResourceValue = "مخزن"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseProductCombination.Fields.WarehouseProductId".ToLower(),
                ResourceValue = "Warehouse Product"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseProductCombination.Fields.WarehouseProductId".ToLower(),
                ResourceValue = "منتج مخزن"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseProductCombination.Fields.CombinationId".ToLower(),
                ResourceValue = "Combination Id"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseProductCombination.Fields.CombinationId".ToLower(),
                ResourceValue = "رقم المتغير"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseProductCombination.Fields.AttributesXml".ToLower(),
                ResourceValue = "Attributes"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseProductCombination.Fields.AttributesXml".ToLower(),
                ResourceValue = "المواصفات"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseProductCombination.Fields.TotalQuantity".ToLower(),
                ResourceValue = "Total Quantity"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseProductCombination.Fields.TotalQuantity".ToLower(),
                ResourceValue = "الكمية الكلية"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseProductCombination.Fields.Sku".ToLower(),
                ResourceValue = "Sku"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseProductCombination.Fields.Sku".ToLower(),
                ResourceValue = "الرمز المميز للمتغير"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseProductCombination.Fields.Available".ToLower(),
                ResourceValue = "Available"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseProductCombination.Fields.Available".ToLower(),
                ResourceValue = "متاح"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseProductCombination.Fields.CreatedOnUtc".ToLower(),
                ResourceValue = "Created On Utc"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseProductCombination.Fields.CreatedOnUtc".ToLower(),
                ResourceValue = "تاريخ الانشاء"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseProductCombination.Fields.UpdatedOnUtc".ToLower(),
                ResourceValue = "Updated On Utc"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseProductCombination.Fields.UpdatedOnUtc".ToLower(),
                ResourceValue = "تاريخ التحديث"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseProductCombination.Fields.CreatedBy".ToLower(),
                ResourceValue = "Created By"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseProductCombination.Fields.CreatedBy".ToLower(),
                ResourceValue = "تم الانشاء بواسطة"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseProductCombination.Fields.UpdatedBy".ToLower(),
                ResourceValue = "Updated By"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseProductCombination.Fields.UpdatedBy".ToLower(),
                ResourceValue = "تم التحديث بواسطة"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseProductCombination.Fields.Deleted".ToLower(),
                ResourceValue = "Deleted"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseProductCombination.Fields.Deleted".ToLower(),
                ResourceValue = "تم الحذف"
            });

            //Warehouse Product Combination Search Model

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseProductCombination.List.WarehouseId".ToLower(),
                ResourceValue = "Warehouse"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseProductCombination.List.WarehouseId".ToLower(),
                ResourceValue = "مخزن"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseProductCombination.List.WarehouseProductId".ToLower(),
                ResourceValue = "Warehouse Product"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseProductCombination.List.WarehouseProductId".ToLower(),
                ResourceValue = "منتج مخزن"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseProductCombination.List.WarehouseProductName".ToLower(),
                ResourceValue = "Warehouse Product Name"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseProductCombination.List.WarehouseProductName".ToLower(),
                ResourceValue = "منتج مخزن"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseProductCombination.List.Sku".ToLower(),
                ResourceValue = "Sku"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseProductCombination.List.Sku".ToLower(),
                ResourceValue = "الرمز المميز للمتغير"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseProductCombination.List.Available".ToLower(),
                ResourceValue = "Available"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseProductCombination.List.Available".ToLower(),
                ResourceValue = "متاح"
            });

            //Warehouse Stand Model

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseStand.Fields.WarehouseId".ToLower(),
                ResourceValue = "Warehouse Id"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseStand.Fields.WarehouseId".ToLower(),
                ResourceValue = "رقم المخزن"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseStand.Fields.MaterialType".ToLower(),
                ResourceValue = "Material Type"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseStand.Fields.MaterialType".ToLower(),
                ResourceValue = "نوع خامة التصنيع"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseStand.Fields.Description".ToLower(),
                ResourceValue = "Description"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseStand.Fields.Description".ToLower(),
                ResourceValue = "الوصف"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseStand.Fields.NoOfShelves".ToLower(),
                ResourceValue = "No Of Shelves"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseStand.Fields.NoOfShelves".ToLower(),
                ResourceValue = "عدد أرفف التخزين"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseStand.Fields.Active".ToLower(),
                ResourceValue = "Active"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseStand.Fields.Active".ToLower(),
                ResourceValue = "نشط"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseStand.Fields.CreatedOnUtc".ToLower(),
                ResourceValue = "Created On Utc"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseStand.Fields.CreatedOnUtc".ToLower(),
                ResourceValue = "تاريخ الانشاء"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseStand.Fields.UpdatedOnUtc".ToLower(),
                ResourceValue = "Updated On Utc"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseStand.Fields.UpdatedOnUtc".ToLower(),
                ResourceValue = "تاريخ التحديث"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseStand.Fields.CreatedBy".ToLower(),
                ResourceValue = "Created By"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseStand.Fields.CreatedBy".ToLower(),
                ResourceValue = "تم الانشاء بواسطة"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseStand.Fields.UpdatedBy".ToLower(),
                ResourceValue = "Updated By"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseStand.Fields.UpdatedBy".ToLower(),
                ResourceValue = "تم التحديث بواسطة"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseStand.Fields.Deleted".ToLower(),
                ResourceValue = "Deleted"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseStand.Fields.Deleted".ToLower(),
                ResourceValue = "تم الحذف"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseStand.Fields.NoOfStands".ToLower(),
                ResourceValue = "No Of Stands"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseStand.Fields.NoOfStands".ToLower(),
                ResourceValue = "عدد حوامل التخزين"
            });

            //Warehouse Stand Search Model

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseStand.List.WarehouseId".ToLower(),
                ResourceValue = "Warehouse"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseStand.List.WarehouseId".ToLower(),
                ResourceValue = "مخزن"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseStand.List.MaterialType".ToLower(),
                ResourceValue = "Material Type"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseStand.List.MaterialType".ToLower(),
                ResourceValue = "نوع خامة التصنيع"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseStand.List.Description".ToLower(),
                ResourceValue = "Description"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseStand.List.Description".ToLower(),
                ResourceValue = "الوصف"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseStand.List.Active".ToLower(),
                ResourceValue = "Active"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseStand.List.Active".ToLower(),
                ResourceValue = "نشط"
            });

            //Warehouse User Mapping Model

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseUserMapping.Fields.WarehouseId".ToLower(),
                ResourceValue = "Warehouse Id"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseUserMapping.Fields.WarehouseId".ToLower(),
                ResourceValue = "رقم المخزن"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseUserMapping.Fields.UserId".ToLower(),
                ResourceValue = "User Id"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseUserMapping.Fields.UserId".ToLower(),
                ResourceValue = "رقم المستخدم"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseUserMapping.Fields.IsActive".ToLower(),
                ResourceValue = "Is Active"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseUserMapping.Fields.IsActive".ToLower(),
                ResourceValue = "نشط"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseUserMapping.Fields.IsBlocked".ToLower(),
                ResourceValue = "Is Blocked"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseUserMapping.Fields.IsBlocked".ToLower(),
                ResourceValue = "محظور"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseUserMapping.Fields.BlockReason".ToLower(),
                ResourceValue = "Block Reason"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseUserMapping.Fields.BlockReason".ToLower(),
                ResourceValue = "سبب الحظر"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseUserMapping.Fields.BlockedOnUtc".ToLower(),
                ResourceValue = "Blocked On Utc"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseUserMapping.Fields.BlockedOnUtc".ToLower(),
                ResourceValue = "تاريخ الحظر"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseUserMapping.Fields.CreatedOnUtc".ToLower(),
                ResourceValue = "Created On Utc"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseUserMapping.Fields.CreatedOnUtc".ToLower(),
                ResourceValue = "تاريخ الانشاء"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseUserMapping.Fields.UpdatedOnUtc".ToLower(),
                ResourceValue = "Updated On Utc"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseUserMapping.Fields.UpdatedOnUtc".ToLower(),
                ResourceValue = "تاريخ التحديث"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseUserMapping.Fields.CreatedBy".ToLower(),
                ResourceValue = "Created By"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseUserMapping.Fields.CreatedBy".ToLower(),
                ResourceValue = "تم الانشاء بواسطة"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseUserMapping.Fields.UpdatedBy".ToLower(),
                ResourceValue = "Updated By"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseUserMapping.Fields.UpdatedBy".ToLower(),
                ResourceValue = "تم التحديث بواسطة"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseUserMapping.Fields.Deleted".ToLower(),
                ResourceValue = "Deleted"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseUserMapping.Fields.Deleted".ToLower(),
                ResourceValue = "تم الحذف"
            });

            //Warehouse User Mapping Search Model

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseUserMapping.List.WarehouseId".ToLower(),
                ResourceValue = "Warehouse"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseUserMapping.List.WarehouseId".ToLower(),
                ResourceValue = "مخزن"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseUserMapping.List.UserId".ToLower(),
                ResourceValue = "User"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseUserMapping.List.UserId".ToLower(),
                ResourceValue = "مستخدم"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseUserMapping.List.IsActive".ToLower(),
                ResourceValue = "Is Active"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseUserMapping.List.IsActive".ToLower(),
                ResourceValue = "نشط"
            });


            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseUserMapping.List.IsBlocked".ToLower(),
                ResourceValue = "Is Blocked"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseUserMapping.List.IsBlocked".ToLower(),
                ResourceValue = "محظور"
            });

            #endregion

            #region Warehouse Notifications Localization

            // Warehouse Product
            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseProduct.Added".ToLower(),
                ResourceValue = "The new warehouse product has been added successfully."
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseProduct.Updated".ToLower(),
                ResourceValue = "The warehouse product has been updated successfully."
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseProduct.Deleted".ToLower(),
                ResourceValue = "The warehouse product has been deleted successfully."
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseProduct.ProductCategoryNotMapped".ToLower(),
                ResourceValue = "The product isn't related to any product categories in the warehouse."
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseProduct.Added".ToLower(),
                ResourceValue = "تم إضافة منتج مخزن بنجاح"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseProduct.Updated".ToLower(),
                ResourceValue = "تم تحديث منتج مخزن بنجاح"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseProduct.Deleted".ToLower(),
                ResourceValue = "تم مسح منتج مخزن بنجاح"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseProduct.ProductCategoryNotMapped".ToLower(),
                ResourceValue = "المنتج لا ينتمي الى أي من أقسام المنتجات المتوفرة بالمخزن"
            });
            // Warehouse Product Combination
            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseProductCombination.Added".ToLower(),
                ResourceValue = "The new warehouse product combination has been added successfully."
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseProductCombination.Updated".ToLower(),
                ResourceValue = "The warehouse product combination has been updated successfully."
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseProductCombination.Deleted".ToLower(),
                ResourceValue = "The warehouse product combination has been deleted successfully."
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseProductCombination.UpToDate".ToLower(),
                ResourceValue = "All warehouse product combinations are up to date."
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseProductCombination.Added".ToLower(),
                ResourceValue = "تم إضافة متغير منتج مخزن بنجاح"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseProductCombination.Updated".ToLower(),
                ResourceValue = "تم تحديث متغير منتج مخزن بنجاح"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseProductCombination.Deleted".ToLower(),
                ResourceValue = "تم مسح متغير منتج مخزن بنجاح"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseProductCombination.UpToDate".ToLower(),
                ResourceValue = "جميع مجموعات سمات المنتج محدثة بالفعل"
            });

            // Warehouse Item
            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseItem.Added".ToLower(),
                ResourceValue = "The new warehouse item has been added successfully."
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseItem.Updated".ToLower(),
                ResourceValue = "The warehouse item has been updated successfully."
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseItem.Deleted".ToLower(),
                ResourceValue = "The warehouse item has been deleted successfully."
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseItem.Added".ToLower(),
                ResourceValue = "تم إضافة عنصر مخزن بنجاح"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseItem.Updated".ToLower(),
                ResourceValue = "تم تحديث عنصر مخزن بنجاح"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseItem.Deleted".ToLower(),
                ResourceValue = "تم مسح عنصر مخزن بنجاح"
            });

            // Shelf Item Mapping
            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.ShelfItemMapping.Added".ToLower(),
                ResourceValue = "The new shelf item mapping has been added successfully."
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.ShelfItemMapping.Updated".ToLower(),
                ResourceValue = "The shelf item mapping has been updated successfully."
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.ShelfItemMapping.Deleted".ToLower(),
                ResourceValue = "The shelf item mapping has been deleted successfully."
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.ShelfItemMapping.Added".ToLower(),
                ResourceValue = "تم إضافة ربط عنصر برف بنجاح"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.ShelfItemMapping.Updated".ToLower(),
                ResourceValue = "تم تحديث ربط عنصر برف بنجاح"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.ShelfItemMapping.Deleted".ToLower(),
                ResourceValue = "تم مسح ربط عنصر برف بنجاح"
            });

            // Stock Request
            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockRequest.Added".ToLower(),
                ResourceValue = "The new stock request has been added successfully."
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockRequest.Updated".ToLower(),
                ResourceValue = "The stock request has been updated successfully."
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockRequest.Deleted".ToLower(),
                ResourceValue = "The stock request has been deleted successfully."
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockRequest.Added".ToLower(),
                ResourceValue = "تم إضافة طلب مخزون بنجاح"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockRequest.Updated".ToLower(),
                ResourceValue = "تم تحديث طلب مخزون بنجاح"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockRequest.Deleted".ToLower(),
                ResourceValue = "تم مسح طلب مخزون بنجاح"
            });

            // Stock Request Item
            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockRequestItem.Added".ToLower(),
                ResourceValue = "The new stock request item has been added successfully."
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockRequestItem.Updated".ToLower(),
                ResourceValue = "The stock request item has been updated successfully."
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockRequestItem.Deleted".ToLower(),
                ResourceValue = "The stock request item has been deleted successfully."
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockRequestItem.Added".ToLower(),
                ResourceValue = "تم إضافة عنصر طلب مخزون بنجاح"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockRequestItem.Updated".ToLower(),
                ResourceValue = "تم تحديث عنصر طلب مخزون بنجاح"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockRequestItem.Deleted".ToLower(),
                ResourceValue = "تم مسح عنصر طلب مخزون بنجاح"
            });

            // Accept Stock Request
            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.AcceptStockRequest.Added".ToLower(),
                ResourceValue = "The new accept stock request has been added successfully."
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.AcceptStockRequest.Updated".ToLower(),
                ResourceValue = "The accept stock request has been updated successfully."
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.AcceptStockRequest.Deleted".ToLower(),
                ResourceValue = "The accept stock request has been deleted successfully."
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.AcceptStockRequest.Added".ToLower(),
                ResourceValue = "تم إضافة قبول طلب مخزون بنجاح"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.AcceptStockRequest.Updated".ToLower(),
                ResourceValue = "تم تحديث قبول طلب مخزون بنجاح"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.AcceptStockRequest.Deleted".ToLower(),
                ResourceValue = "تم مسح قبول طلب مخزون بنجاح"
            });

            // Stock History
            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockHistory.Added".ToLower(),
                ResourceValue = "The new stock history has been added successfully."
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockHistory.Updated".ToLower(),
                ResourceValue = "The stock history has been updated successfully."
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockHistory.Deleted".ToLower(),
                ResourceValue = "The stock history has been deleted successfully."
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockHistory.Added".ToLower(),
                ResourceValue = "تم إضافة سجل مخزون بنجاح"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockHistory.Updated".ToLower(),
                ResourceValue = "تم تحديث سجل مخزون بنجاح"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockHistory.Deleted".ToLower(),
                ResourceValue = "تم مسح سجل مخزون بنجاح"
            });

            // Stock Item History
            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockItemHistory.Added".ToLower(),
                ResourceValue = "The new stock item history has been added successfully."
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockItemHistory.Updated".ToLower(),
                ResourceValue = "The stock item history has been updated successfully."
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockItemHistory.Deleted".ToLower(),
                ResourceValue = "The stock item history has been deleted successfully."
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockItemHistory.Added".ToLower(),
                ResourceValue = "تم إضافة سجل عنصر مخزون بنجاح"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockItemHistory.Updated".ToLower(),
                ResourceValue = "تم تحديث سجل عنصر مخزون بنجاح"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockItemHistory.Deleted".ToLower(),
                ResourceValue = "تم مسح سجل عنصر مخزون بنجاح"
            });

            // Warehouse Stand
            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseStand.Added".ToLower(),
                ResourceValue = "The new warehouse stand has been added successfully."
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseStand.Updated".ToLower(),
                ResourceValue = "The warehouse stand has been updated successfully."
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseStand.Deleted".ToLower(),
                ResourceValue = "The warehouse stand has been deleted successfully."
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseStand.Added".ToLower(),
                ResourceValue = "تم إضافة حامل مخزن بنجاح"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseStand.Updated".ToLower(),
                ResourceValue = "تم تحديث حامل مخزن بنجاح"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseStand.Deleted".ToLower(),
                ResourceValue = "تم مسح حامل مخزن بنجاح"
            });

            // Shelf
            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.Shelf.Added".ToLower(),
                ResourceValue = "The new shelf has been added successfully."
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.Shelf.Updated".ToLower(),
                ResourceValue = "The shelf has been updated successfully."
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.Shelf.Deleted".ToLower(),
                ResourceValue = "The shelf has been deleted successfully."
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.Shelf.Added".ToLower(),
                ResourceValue = "تم إضافة رف تخزين بنجاح"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.Shelf.Updated".ToLower(),
                ResourceValue = "تم تحديث رف تخزين بنجاح"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.Shelf.Deleted".ToLower(),
                ResourceValue = "تم مسح رف تخزين بنجاح"
            });

            // Warehouse Category Mapping
            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseCategoryMapping.Added".ToLower(),
                ResourceValue = "The new warehouse category mapping has been added successfully."
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseCategoryMapping.Updated".ToLower(),
                ResourceValue = "The warehouse category mapping has been updated successfully."
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseCategoryMapping.Deleted".ToLower(),
                ResourceValue = "The warehouse category mapping has been deleted successfully."
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseCategoryMapping.CannotDeletedSystemMapping".ToLower(),
                ResourceValue = "Can't delete a system category."
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseCategoryMapping.Added".ToLower(),
                ResourceValue = "تم إضافة ربط قسم بمخزن بنجاح"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseCategoryMapping.Updated".ToLower(),
                ResourceValue = "تم تحديث ربط قسم بمخزن بنجاح"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseCategoryMapping.Deleted".ToLower(),
                ResourceValue = "تم مسح ربط قسم بمخزن بنجاح"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseCategoryMapping.CannotDeletedSystemMapping".ToLower(),
                ResourceValue = "لا يمكن حذف قسم تابع للنظام"
            });

            // Warehouse Product Category Mapping
            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseProductCategoryMapping.Added".ToLower(),
                ResourceValue = "The new warehouse product category mapping has been added successfully."
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseProductCategoryMapping.Updated".ToLower(),
                ResourceValue = "The warehouse product category mapping has been updated successfully."
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseProductCategoryMapping.Deleted".ToLower(),
                ResourceValue = "The warehouse product category mapping has been deleted successfully."
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseProductCategoryMapping.Added".ToLower(),
                ResourceValue = "تم إضافة ربط قسم منتج بمخزن بنجاح"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseProductCategoryMapping.Updated".ToLower(),
                ResourceValue = "تم تحديث ربط قسم منتج بمخزن بنجاح"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseProductCategoryMapping.Deleted".ToLower(),
                ResourceValue = "تم مسح ربط قسم منتج بمخزن بنجاح"
            });

            // Warehouse Category
            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseCategory.Added".ToLower(),
                ResourceValue = "The new warehouse category has been added successfully."
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseCategory.Updated".ToLower(),
                ResourceValue = "The warehouse category has been updated successfully."
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseCategory.Deleted".ToLower(),
                ResourceValue = "The warehouse category has been deleted successfully."
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseCategory.Added".ToLower(),
                ResourceValue = "تم إضافة قسم مخزن بنجاح"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseCategory.Updated".ToLower(),
                ResourceValue = "تم تحديث قسم مخزن بنجاح"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseCategory.Deleted".ToLower(),
                ResourceValue = "تم مسح قسم مخزن بنجاح"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseProduct.NotUpdatedTypeOfProcess".ToLower(),
                ResourceValue = "You can't change the process type."
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseProduct.NotUpdatedTypeOfProcess".ToLower(),
                ResourceValue = "لا يمكن تغيير نوع العملية"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.WarehouseProduct.NotUpdatedItemStatusNotReceived".ToLower(),
                ResourceValue = "Can't delete this combination."
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.WarehouseProduct.NotUpdatedItemStatusNotReceived".ToLower(),
                ResourceValue = "حدث خطأ أثناء حذف المتغير"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.Barcode.SomethingWrongInBarcodes".ToLower(),
                ResourceValue = "Something went wrong."
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.Barcode.SomethingWrongInBarcodes".ToLower(),
                ResourceValue = "يوجد خطأ بالباركود"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.Barcode.ScannedBefore".ToLower(),
                ResourceValue = "Something went wrong."
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.Barcode.ScannedBefore".ToLower(),
                ResourceValue = "يوجد خطأ بالباركود"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.Barcode.WarehouseProductCombinationNotFound".ToLower(),
                ResourceValue = "Product combination is not found."
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.Barcode.WarehouseProductCombinationNotFound".ToLower(),
                ResourceValue = "المتغير غير موجود بالنظام"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.MapItemToShelf.shelfNotFound".ToLower(),
                ResourceValue = "Invalid shelf barcode."
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.MapItemToShelf.shelfNotFound".ToLower(),
                ResourceValue = "الكود الخاص بالرف غير صالح"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.MapItemToShelf.shelfInactive".ToLower(),
                ResourceValue = "This Shelf is inactive."
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.MapItemToShelf.shelfInactive".ToLower(),
                ResourceValue = "الرف المستهدف غير مفعل"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.MapItemToShelf.ItemNotReadyToLink".ToLower(),
                ResourceValue = "One or more items are not ready for linking process."
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.MapItemToShelf.ItemNotReadyToLink".ToLower(),
                ResourceValue = "يوجد منتجات غير مجهزة لعملية الربط"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.MapItemToShelf.itemsNotFound".ToLower(),
                ResourceValue = "These items barcodes are invalid."
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.MapItemToShelf.itemsNotFound".ToLower(),
                ResourceValue = "جميع الباركود الخاصه بالمنتجات المدخلة غير صالحة"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.Barcode.InValid".ToLower(),
                ResourceValue = "Barcode {0} is invalid."
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.Barcode.InValid".ToLower(),
                ResourceValue = "باركود رقم = {0} غير صالح"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.Barcode.ItemScannedBefore".ToLower(),
                ResourceValue = "Barcode {0} scanned before."
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.Barcode.ItemScannedBefore".ToLower(),
                ResourceValue = "تم إدخال باركود رقم = {0} من قبل"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.Barcode.ItemAlreadyReturnedToVendor".ToLower(),
                ResourceValue = "Barcode {0} already returned to vendor."
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.Barcode.ItemAlreadyReturnedToVendor".ToLower(),
                ResourceValue = "تم إرجاع باركود رقم = {0} الى التاجر من قبل"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.Barcode.ItemAlreadyDamaged".ToLower(),
                ResourceValue = "Barcode {0} already damaged."
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.Barcode.ItemAlreadyDamaged".ToLower(),
                ResourceValue = "تم إهلاك باركود رقم = {0} من قبل"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.Barcode.CannotReturnOrderedItem".ToLower(),
                ResourceValue = "Barcode {0} already Ordered."
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.Barcode.CannotReturnOrderedItem".ToLower(),
                ResourceValue = "تم طلب باركود رقم = {0} بالفعل"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.ScanReturnedToVendor.ImpossibleToHaveNegativeQuantity".ToLower(),
                ResourceValue = "Not Allowed Action, The quantity will be negative value."
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.ScanReturnedToVendor.ImpossibleToHaveNegativeQuantity".ToLower(),
                ResourceValue = "لا يمكن إتمام العملية بسبب فقر الكمية المتاحة"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.ScanReturnedToVendor.YouTryToReturnQuantityMoreThanAllowed".ToLower(),
                ResourceValue = "You are trying to return items more than allowed. Total quantity = {0}, already returned quantity = {1}, allowed returnable quantity = {2}"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.ScanReturnedToVendor.YouTryToReturnQuantityMoreThanAllowed".ToLower(),
                ResourceValue = "أنت تحاول إرجاع كمية أكثر من المسموح، إجمالي الكمية = {0}، الكمية المرتجعة بالفعل = {1}، الكمية القابله للإرجاع = {2}"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.Barcode.YouTryToScanBarcodeNotRelatedToCurrentProductCombination".ToLower(),
                ResourceValue = "Barcode {0} not related to the current product combination."
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.Barcode.YouTryToScanBarcodeNotRelatedToCurrentProductCombination".ToLower(),
                ResourceValue = "باركود رقم = {0} لا ينتمي الي المتغير المستهدف"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.Barcode.ItemNotRelatedToThisWarehouse".ToLower(),
                ResourceValue = "Barcode {0} not related to the current warehouse."
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.Barcode.ItemNotRelatedToThisWarehouse".ToLower(),
                ResourceValue = "باركود رقم = {0} لا ينتمي الي هذا المخزن"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockRequest.ActionTakenInThisRequest".ToLower(),
                ResourceValue = "An action has already been taken on this stock request."
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockRequest.ActionTakenInThisRequest".ToLower(),
                ResourceValue = "تم إتخاذ إجراء بخصوص هذا الطلب بالفعل"
            });

            // Warehouse Product
            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "ActivityLog.AddNewWarehouseProduct".ToLower(),
                ResourceValue = "Added a new warehouse product (ID = {0})"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "ActivityLog.EditWarehouseProduct".ToLower(),
                ResourceValue = "Edited a warehouse product (ID = {0})"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "ActivityLog.DeleteWarehouseProduct".ToLower(),
                ResourceValue = "Deleted a warehouse product (ID = {0})"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "ActivityLog.AddNewWarehouseProduct".ToLower(),
                ResourceValue = "تم إضافة منتج مخزن جديد (رقم = {0})"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "ActivityLog.EditWarehouseProduct".ToLower(),
                ResourceValue = "تم تعديل منتج مخزن (رقم = {0})"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "ActivityLog.DeleteWarehouseProduct".ToLower(),
                ResourceValue = "تم مسح منتج مخزن (رقم = {0})"
            });

            // Warehouse Product Combination
            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "ActivityLog.AddNewWarehouseProductCombination".ToLower(),
                ResourceValue = "Added a new warehouse product combination (ID = {0})"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "ActivityLog.EditWarehouseProductCombination".ToLower(),
                ResourceValue = "Edited a warehouse product combination (ID = {0})"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "ActivityLog.DeleteWarehouseProductCombination".ToLower(),
                ResourceValue = "Deleted a warehouse product combination (ID = {0})"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "ActivityLog.AddNewWarehouseProductCombination".ToLower(),
                ResourceValue = "تم إضافة متغير منتج مخزن جديد (رقم = {0})"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "ActivityLog.EditWarehouseProductCombination".ToLower(),
                ResourceValue = "تم تعديل متغير منتج مخزن (رقم = {0})"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "ActivityLog.DeleteWarehouseProductCombination".ToLower(),
                ResourceValue = "تم مسح متغير منتج مخزن (رقم = {0})"
            });

            // Warehouse Item
            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "ActivityLog.AddNewWarehouseItem".ToLower(),
                ResourceValue = "Added a new warehouse item (ID = {0})"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "ActivityLog.EditWarehouseItem".ToLower(),
                ResourceValue = "Edited a warehouse item (ID = {0})"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "ActivityLog.DeleteWarehouseItem".ToLower(),
                ResourceValue = "Deleted a warehouse item (ID = {0})"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "ActivityLog.AddNewWarehouseItem".ToLower(),
                ResourceValue = "تم إضافة عنصر مخزن جديد (رقم = {0})"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "ActivityLog.EditWarehouseItem".ToLower(),
                ResourceValue = "تم تعديل عنصر مخزن (رقم = {0})"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "ActivityLog.DeleteWarehouseItem".ToLower(),
                ResourceValue = "تم مسح عنصر مخزن (رقم = {0})"
            });

            // Shelf Item Mapping
            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "ActivityLog.AddNewShelfItemMapping".ToLower(),
                ResourceValue = "Added a new shelf item mapping (ID = {0})"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "ActivityLog.EditShelfItemMapping".ToLower(),
                ResourceValue = "Edited a shelf item mapping (ID = {0})"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "ActivityLog.DeleteShelfItemMapping".ToLower(),
                ResourceValue = "Deleted a shelf item mapping (ID = {0})"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "ActivityLog.AddNewShelfItemMapping".ToLower(),
                ResourceValue = "تم إضافة ربط عنصر برف جديد (رقم = {0})"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "ActivityLog.EditShelfItemMapping".ToLower(),
                ResourceValue = "تم تعديل ربط عنصر برف (رقم = {0})"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "ActivityLog.DeleteShelfItemMapping".ToLower(),
                ResourceValue = "تم مسح ربط عنصر برف (رقم = {0})"
            });

            // Stock Request
            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "ActivityLog.AddNewStockRequest".ToLower(),
                ResourceValue = "Added a new stock request (ID = {0})"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "ActivityLog.EditStockRequest".ToLower(),
                ResourceValue = "Edited a stock request (ID = {0})"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "ActivityLog.DeleteStockRequest".ToLower(),
                ResourceValue = "Deleted a stock request (ID = {0})"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "ActivityLog.AddNewStockRequest".ToLower(),
                ResourceValue = "تم إضافة طلب مخزون جديد (رقم = {0})"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "ActivityLog.EditStockRequest".ToLower(),
                ResourceValue = "تم تعديل طلب مخزون (رقم = {0})"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "ActivityLog.DeleteStockRequest".ToLower(),
                ResourceValue = "تم مسح طلب مخزون (رقم = {0})"
            });

            // Stock Request Item
            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "ActivityLog.AddNewStockRequestItem".ToLower(),
                ResourceValue = "Added a new stock request item (ID = {0})"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "ActivityLog.EditStockRequestItem".ToLower(),
                ResourceValue = "Edited a stock request item (ID = {0})"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "ActivityLog.DeleteStockRequestItem".ToLower(),
                ResourceValue = "Deleted a stock request item (ID = {0})"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "ActivityLog.AddNewStockRequestItem".ToLower(),
                ResourceValue = "تم إضافة عنصر طلب مخزون جديد (رقم = {0})"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "ActivityLog.EditStockRequestItem".ToLower(),
                ResourceValue = "تم تعديل عنصر طلب مخزون (رقم = {0})"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "ActivityLog.DeleteStockRequestItem".ToLower(),
                ResourceValue = "تم مسح عنصر طلب مخزون (رقم = {0})"
            });

            // Accept Stock Request
            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "ActivityLog.AddNewAcceptStockRequest".ToLower(),
                ResourceValue = "Added a new accept stock request (ID = {0})"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "ActivityLog.EditAcceptStockRequest".ToLower(),
                ResourceValue = "Edited a accept stock request (ID = {0})"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "ActivityLog.DeleteAcceptStockRequest".ToLower(),
                ResourceValue = "Deleted a accept stock request (ID = {0})"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "ActivityLog.AddNewAcceptStockRequest".ToLower(),
                ResourceValue = "تم إضافة قبول طلب مخزون جديد (رقم = {0})"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "ActivityLog.EditAcceptStockRequest".ToLower(),
                ResourceValue = "تم تعديل قبول طلب مخزون (رقم = {0})"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "ActivityLog.DeleteAcceptStockRequest".ToLower(),
                ResourceValue = "تم مسح قبول طلب مخزون (رقم = {0})"
            });

            // Stock History
            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "ActivityLog.AddNewStockHistory".ToLower(),
                ResourceValue = "Added a new stock history (ID = {0})"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "ActivityLog.EditStockHistory".ToLower(),
                ResourceValue = "Edited a stock history (ID = {0})"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "ActivityLog.DeleteStockHistory".ToLower(),
                ResourceValue = "Deleted a stock history (ID = {0})"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "ActivityLog.AddNewStockHistory".ToLower(),
                ResourceValue = "تم إضافة سجل مخزون جديد (رقم = {0})"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "ActivityLog.EditStockHistory".ToLower(),
                ResourceValue = "تم تعديل سجل مخزون (رقم = {0})"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "ActivityLog.DeleteStockHistory".ToLower(),
                ResourceValue = "تم مسح سجل مخزون (رقم = {0})"
            });

            // Stock History returned
            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "ActivityLog.AddNewReturnedStockHistory".ToLower(),
                ResourceValue = "Added a new returned stock history (ID = {0})"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "ActivityLog.EditReturnedStockHistory".ToLower(),
                ResourceValue = "Edited a returned stock history (ID = {0})"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "ActivityLog.DeleteReturnedStockHistory".ToLower(),
                ResourceValue = "Deleted a returned stock history (ID = {0})"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "ActivityLog.AddNewReturnedStockHistory".ToLower(),
                ResourceValue = "تم إضافة سجل مرتجع مخزون جديد (رقم = {0})"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "ActivityLog.EditReturnedStockHistory".ToLower(),
                ResourceValue = "تم تعديل سجل مرتجع مخزون (رقم = {0})"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "ActivityLog.DeleteReturnedStockHistory".ToLower(),
                ResourceValue = "تم مسح سجل مرتجع مخزون (رقم = {0})"
            });

            // Stock Item History
            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "ActivityLog.AddNewStockItemHistory".ToLower(),
                ResourceValue = "Added a new stock item history (ID = {0})"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "ActivityLog.EditStockItemHistory".ToLower(),
                ResourceValue = "Edited a stock item history (ID = {0})"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "ActivityLog.DeleteStockItemHistory".ToLower(),
                ResourceValue = "Deleted a stock item history (ID = {0})"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "ActivityLog.AddNewStockItemHistory".ToLower(),
                ResourceValue = "تم إضافة سجل عنصر مخزون جديد (رقم = {0})"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "ActivityLog.EditStockItemHistory".ToLower(),
                ResourceValue = "تم تعديل سجل عنصر مخزون (رقم = {0})"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "ActivityLog.DeleteStockItemHistory".ToLower(),
                ResourceValue = "تم مسح سجل عنصر مخزون (رقم = {0})"
            });

            // Stock Item History returned
            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "ActivityLog.AddNewReturnedStockItemHistory".ToLower(),
                ResourceValue = "Added a new returned stock item history (ID = {0})"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "ActivityLog.EditReturnedStockItemHistory".ToLower(),
                ResourceValue = "Edited a returned stock item history (ID = {0})"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "ActivityLog.DeleteReturnedStockItemHistory".ToLower(),
                ResourceValue = "Deleted a returned stock item history (ID = {0})"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "ActivityLog.AddNewReturnedStockItemHistory".ToLower(),
                ResourceValue = "تم إضافة سجل مرتجع عنصر مخزون جديد (رقم = {0})"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "ActivityLog.EditReturnedStockItemHistory".ToLower(),
                ResourceValue = "تم تعديل سجل مرتجع عنصر مخزون (رقم = {0})"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "ActivityLog.DeleteReturnedStockItemHistory".ToLower(),
                ResourceValue = "تم مسح سجل مرتجع عنصر مخزون (رقم = {0})"
            });

            // Warehouse Stand
            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "ActivityLog.AddNewWarehouseStand".ToLower(),
                ResourceValue = "Added a new warehouse stand (ID = {0})"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "ActivityLog.EditWarehouseStand".ToLower(),
                ResourceValue = "Edited a warehouse stand (ID = {0})"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "ActivityLog.DeleteWarehouseStand".ToLower(),
                ResourceValue = "Deleted a warehouse stand (ID = {0})"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "ActivityLog.AddNewWarehouseStand".ToLower(),
                ResourceValue = "تم إضافة حامل مخزن جديد (رقم = {0})"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "ActivityLog.EditWarehouseStand".ToLower(),
                ResourceValue = "تم تعديل حامل مخزن (رقم = {0})"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "ActivityLog.DeleteWarehouseStand".ToLower(),
                ResourceValue = "تم مسح حامل مخزن (رقم = {0})"
            });

            // Shelf
            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "ActivityLog.AddNewShelf".ToLower(),
                ResourceValue = "Added a new shelf (ID = {0})"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "ActivityLog.EditShelf".ToLower(),
                ResourceValue = "Edited a shelf (ID = {0})"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "ActivityLog.DeleteShelf".ToLower(),
                ResourceValue = "Deleted a shelf (ID = {0})"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "ActivityLog.AddNewShelf".ToLower(),
                ResourceValue = "تم إضافة رف تخزين جديد (رقم = {0})"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "ActivityLog.EditShelf".ToLower(),
                ResourceValue = "تم تعديل رف تخزين (رقم = {0})"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "ActivityLog.DeleteShelf".ToLower(),
                ResourceValue = "تم مسح رف تخزين (رقم = {0})"
            });

            // Warehouse Category Mapping
            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "ActivityLog.AddNewWarehouseCategoryMapping".ToLower(),
                ResourceValue = "Added a new warehouse category mapping (ID = {0})"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "ActivityLog.EditWarehouseCategoryMapping".ToLower(),
                ResourceValue = "Edited a warehouse category mapping (ID = {0})"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "ActivityLog.DeleteWarehouseCategoryMapping".ToLower(),
                ResourceValue = "Deleted a warehouse category mapping (ID = {0})"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "ActivityLog.AddNewWarehouseCategoryMapping".ToLower(),
                ResourceValue = "تم إضافة ربط قسم بمخزن جديد (رقم = {0})"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "ActivityLog.EditWarehouseCategoryMapping".ToLower(),
                ResourceValue = "تم تعديل ربط قسم بمخزن (رقم = {0})"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "ActivityLog.DeleteWarehouseCategoryMapping".ToLower(),
                ResourceValue = "تم مسح ربط قسم بمخزن (رقم = {0})"
            });

            // Warehouse Product Category Mapping
            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "ActivityLog.AddNewWarehouseProductCategoryMapping".ToLower(),
                ResourceValue = "Added a new warehouse product category mapping (ID = {0})"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "ActivityLog.EditWarehouseProductCategoryMapping".ToLower(),
                ResourceValue = "Edited a warehouse product category mapping (ID = {0})"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "ActivityLog.DeleteWarehouseProductCategoryMapping".ToLower(),
                ResourceValue = "Deleted a warehouse product category mapping (ID = {0})"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "ActivityLog.AddNewWarehouseProductCategoryMapping".ToLower(),
                ResourceValue = "تم إضافة ربط قسم منتج بمخزن جديد (رقم = {0})"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "ActivityLog.EditWarehouseProductCategoryMapping".ToLower(),
                ResourceValue = "تم تعديل ربط قسم منتج بمخزن (رقم = {0})"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "ActivityLog.DeleteWarehouseProductCategoryMapping".ToLower(),
                ResourceValue = "تم مسح ربط قسم منتج بمخزن (رقم = {0})"
            });

            // Warehouse Category
            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "ActivityLog.AddNewWarehouseCategory".ToLower(),
                ResourceValue = "Added a new warehouse category (ID = {0})"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "ActivityLog.EditWarehouseCategory".ToLower(),
                ResourceValue = "Edited a warehouse category (ID = {0})"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "ActivityLog.DeleteWarehouseCategory".ToLower(),
                ResourceValue = "Deleted a warehouse category (ID = {0})"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "ActivityLog.AddNewWarehouseCategory".ToLower(),
                ResourceValue = "تم إضافة قسم مخزن جديد (رقم = {0})"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "ActivityLog.EditWarehouseCategory".ToLower(),
                ResourceValue = "تم تعديل قسم مخزن (رقم = {0})"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "ActivityLog.DeleteWarehouseCategory".ToLower(),
                ResourceValue = "تم مسح قسم مخزن (رقم = {0})"
            });

            #endregion

            #region Warehouse System Setup Page

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.StockOperations".ToLower(),
                ResourceValue = "Stock Operations"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.StockOperations".ToLower(),
                ResourceValue = "عمليات المخزن"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.SystemSetup.WarehouseStands".ToLower(),
                ResourceValue = "Warehouse Stands"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.SystemSetup.WarehouseStands".ToLower(),
                ResourceValue = "حوامل المخزن"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.SystemSetup.WarehouseStandsDesc".ToLower(),
                ResourceValue = "Set up and manage your warehouse stands efficiently to ensure optimal storage solutions."
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.SystemSetup.WarehouseStandsDesc".ToLower(),
                ResourceValue = "قم بإعداد وإدارة حوامل المستودع بكفاءة لضمان حلول تخزين مثالية."
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.SystemSetup.WarehouseStandsButton".ToLower(),
                ResourceValue = "Setup Stands"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.SystemSetup.WarehouseStandsButton".ToLower(),
                ResourceValue = "ضبط الحوامل"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.SystemSetup.WarehouseShelves".ToLower(),
                ResourceValue = "Warehouse Shelves"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.SystemSetup.WarehouseShelves".ToLower(),
                ResourceValue = "أرفف المخزن"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.SystemSetup.WarehouseShelvesDesc".ToLower(),
                ResourceValue = "Organize your warehouse shelving layout to optimize storage space and improve efficiency."
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.SystemSetup.WarehouseShelvesDesc".ToLower(),
                ResourceValue = "نظم تخطيط رفوف المستودع لتحقيق الاستفادة القصوى من مساحة التخزين وتحسين الكفاءة."
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.SystemSetup.WarehouseShelvesButton".ToLower(),
                ResourceValue = "Setup Shelves"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.SystemSetup.WarehouseShelvesButton".ToLower(),
                ResourceValue = "ضبط الأرفف"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.SystemSetup.WarehouseCategories".ToLower(),
                ResourceValue = "Warehouse Categories"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.SystemSetup.WarehouseCategories".ToLower(),
                ResourceValue = "أقسام المخزن"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.SystemSetup.WarehouseCategoriesDesc".ToLower(),
                ResourceValue = "Configure warehouse categories by integrating the system categories into the warehouse."
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.SystemSetup.WarehouseCategoriesDesc".ToLower(),
                ResourceValue = "قم بتكوين فئات المستودع عن طريق دمج فئات النظام في المستودع."
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.SystemSetup.WarehouseCategoriesButton".ToLower(),
                ResourceValue = "Setup Categories"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.SystemSetup.WarehouseCategoriesButton".ToLower(),
                ResourceValue = "ضبط الأقسام"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.SystemSetup.WarehouseProductCategories".ToLower(),
                ResourceValue = "Warehouse Product Categories"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.SystemSetup.WarehouseProductCategories".ToLower(),
                ResourceValue = "أقسام منتجات المخزن"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.SystemSetup.WarehouseProductCategoriesDesc".ToLower(),
                ResourceValue = "Manage your product categories by linking the system categories with the warehouse."
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.SystemSetup.WarehouseProductCategoriesDesc".ToLower(),
                ResourceValue = "قم بإدارة أقسام المنتجات الخاصة بك عن طريق ربط أقسام النظام بالمستودع"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.SystemSetup.WarehouseProductCategoriesButton".ToLower(),
                ResourceValue = "Setup Product Categories"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.SystemSetup.WarehouseProductCategoriesButton".ToLower(),
                ResourceValue = "ضبط أقسام المنتجات"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.SystemSetup.WarehouseProducts".ToLower(),
                ResourceValue = "Warehouse Products"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.SystemSetup.WarehouseProducts".ToLower(),
                ResourceValue = "منتجات المخزن"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.SystemSetup.WarehouseProductsDesc".ToLower(),
                ResourceValue = "Administer your warehouse products here."
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.SystemSetup.WarehouseProductsDesc".ToLower(),
                ResourceValue = "قم بإدارة منتجات المستودع الخاصة بك هنا."
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.SystemSetup.WarehouseProductsButton".ToLower(),
                ResourceValue = "Setup Warehouse Products"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.SystemSetup.WarehouseProductsButton".ToLower(),
                ResourceValue = "ضبط منتجات المخزن"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.SystemSetup.WarehouseProductCombinations".ToLower(),
                ResourceValue = "Warehouse Product Combinations"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.SystemSetup.WarehouseProductCombinations".ToLower(),
                ResourceValue = "متغيرات منتجات المخزن"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.SystemSetup.WarehouseProductCombinationsDesc".ToLower(),
                ResourceValue = "Display warehouse product Combinations."
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.SystemSetup.WarehouseProductCombinationsDesc".ToLower(),
                ResourceValue = "عرض متغيرات منتجات المستودع"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 1,
                ResourceName = "Admin.Warehouses.SystemSetup.WarehouseProductCombinationsButton".ToLower(),
                ResourceValue = "Display"
            });

            Insert.IntoTable(nameof(LocaleStringResource)).Row(new
            {
                LanguageId = 2,
                ResourceName = "Admin.Warehouses.SystemSetup.WarehouseProductCombinationsButton".ToLower(),
                ResourceValue = "عرض المتغيرات"
            });

            #endregion

        }

        public override void Down()
        {

        }
    }
}