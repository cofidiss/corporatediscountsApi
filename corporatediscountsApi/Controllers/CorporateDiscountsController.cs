using corporatediscountsApi.CorporateDiscountsServices;
using corporatediscountsApi.Models;
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

        [HttpPost("/GetDiscountsByFilter")]
        public IActionResult GetDiscountsByFilter(DiscountSearchRequest discountSearchRequest)
        {
            return Ok(_corporateDiscountsService.GetDiscountsByFilter((x=>   x.FirmId.Equals(discountSearchRequest.FirmName) )));


        }
    }
}
