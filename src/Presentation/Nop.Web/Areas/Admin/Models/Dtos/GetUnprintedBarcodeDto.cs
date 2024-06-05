using System.ComponentModel.DataAnnotations;

namespace Nop.Web.Areas.Admin.Models.Dtos
{
    public class GetUnprintedBarcodeDto
    {
        public int WarehouseId { get; set; }

        public string Sku { get; set; }

        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }
    }
}
