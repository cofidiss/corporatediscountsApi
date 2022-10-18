using Microsoft.AspNetCore.Mvc;

namespace corporatediscountsApi.Areas.Admin.Controllers
{
    [Route("api/Admin/[controller]")]
    [ApiController]
    public class WorkOrderController : Controller
    {
        [HttpGet(nameof(Index))]
        public IActionResult Index()
        {
            return  Content("abc"); 
        }
    }
}
