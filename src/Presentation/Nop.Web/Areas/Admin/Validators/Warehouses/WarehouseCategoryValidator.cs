using FluentValidation;
using Nop.Core.Domain.Warehouses;
using Nop.Data.Mapping;
using Nop.Services.Localization;
using Nop.Web.Areas.Admin.Models.Warehouses;
using Nop.Web.Framework.Validators;

namespace Nop.Web.Areas.Admin.Validators.Warehouses
{
    public partial class WarehouseCategoryValidator : BaseNopValidator<WarehouseCategoryModel>
    {
        public WarehouseCategoryValidator(ILocalizationService localizationService, IMappingEntityAccessor mappingEntityAccessor)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessageAwait(localizationService.GetResourceAsync("Admin.Configuration.Warehouses.WarehouseCategory.Fields.Name.Required"));
            RuleFor(x => x.Description).NotEmpty().WithMessageAwait(localizationService.GetResourceAsync("Admin.Configuration.Warehouses.WarehouseCategory.Fields.Description.Required"));

            SetDatabaseValidationRules<WarehouseCategory>(mappingEntityAccessor);
        }
    }
}
