using System.Collections.Generic;
using Nop.Core.Domain.Warehouses;
using Nop.Services.Helpers;

namespace Nop.Web.Areas.Admin.Models.Warehouses
{
    public class WarehouseItemViewModel
    {
        public int WarehouseId { get; set; }
        public IList<WarehouseItemGroup> Groups { get; set; }
        public IList<WarehouseItem> SelectedItems { get; set; }
    }
}
