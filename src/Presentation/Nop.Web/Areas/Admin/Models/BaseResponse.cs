namespace Nop.Web.Areas.Admin.Models
{
    public class BaseResponse
    {
        public bool Success { get; set; } = true;
        public string Message { get; set; }
    }
}
