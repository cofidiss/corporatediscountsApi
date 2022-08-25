using corporatediscountsApi.CorporateDiscountsServices;
using Microsoft.AspNetCore.Mvc;

namespace corporatediscountsApi.Controllers
{
    [Route("api/{controller}")]
    [ApiController]
    public class CorporateDiscountsController : ControllerBase
    {

        CorporateDiscountsService _corporateDiscountsService { get; set; }
        public CorporateDiscountsController(CorporateDiscountsService corporateDiscountsService)
        {
            _corporateDiscountsService = corporateDiscountsService;
        }
        [HttpGet("/GetAllDiscounts")]
        public IActionResult GetAllDiscounts()
        {
           return  Ok(_corporateDiscountsService.GetAllDiscounts());


        }

        [HttpGet("/GetDiscountsByFilter")]
        public IActionResult GetDiscountsByFilter(string firmName)
        {
            return Ok(_corporateDiscountsService.GetDiscountsByFilter((x=>   x.FirmName.Equals(firmName) )));


        }
    }
}
