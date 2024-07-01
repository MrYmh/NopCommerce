using System.Collections.Generic;
using Nop.Core.Domain.Warehouses;

namespace Nop.Services.Helpers
{
    public class WarehouseItemGroup
    {
        public string Sku { get; set; }
        public int ItemCount { get; set; }
        public List<WarehouseItem> Items { get; set; }
    }

}
