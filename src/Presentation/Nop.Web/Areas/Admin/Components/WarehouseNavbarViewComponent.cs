using Microsoft.AspNetCore.Mvc;

namespace Nop.Web.Areas.Admin.Components
{
    public class WarehouseNavbarViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(int id)
        {
            // You can pass a model to your view if needed
            var x = id;
            return View(x);
        }
    }
}
