using corporatediscountsApi.CorporateDiscountsAdminServices;
using corporatediscountsApi.CorporateDiscountsServices;
using corporatediscountsApi.Models;
using Microsoft.AspNetCore.Mvc;
namespace corporatediscountsApi.Controllers
{
    [Route("api/{controller}")]
    [ApiController]
    public class CorporateDiscountsAdminController:ControllerBase
    {
        CorporateDiscountsAdminService _corporateDiscountsAdminService { get; }
        public CorporateDiscountsAdminController(CorporateDiscountsAdminService corporateDiscountsAdminService)
        {
            _corporateDiscountsAdminService = corporateDiscountsAdminService;
        }

        [HttpPost(nameof(GetDiscountScopeLov))]
        public IActionResult GetDiscountScopeLov()

        {
            //throw new Exception("a");
            return Ok(_corporateDiscountsAdminService.GetDiscountScopeLov());


        }

        [HttpPost(nameof(GetFirmLov))]
        public IActionResult GetFirmLov()
        {
            return Ok(_corporateDiscountsAdminService.GetFirmLov());


        }

        [HttpPost(nameof(GetDiscountCategoryLov))]
        public IActionResult GetDiscountCategoryLov()
        {
            return Ok(_corporateDiscountsAdminService.GetDiscountCategoryLov());
            


        }
    }
}