using Nop.Web.Framework.Models;

namespace Nop.Web.Areas.Admin.Models.Warehouses
{
    public record WarehouseProductDto : BaseNopEntityModel
    {
        public string Name { get; set; }
        public string Sku { get; set; }

    }
}
