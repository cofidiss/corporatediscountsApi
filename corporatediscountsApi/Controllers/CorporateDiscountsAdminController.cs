using corporatediscountsApi.CorporateDiscountsAdminServices;
using corporatediscountsApi.CorporateDiscountsServices;
using corporatediscountsApi.Models;
using Microsoft.AspNetCore.Mvc;
namespace corporatediscountsApi.Controllers
{
    [Route("api/[controller]")]
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
        [HttpPost(nameof(FilterDiscounts))]
        public IActionResult FilterDiscounts(DiscountSearchRequest discountSearchRequest)
        {
            //throw new Exception("");

            return Ok(_corporateDiscountsAdminService.FilterDiscounts(discountSearchRequest));


        }

        [HttpPost(nameof(SaveFirms))]
        public IActionResult SaveFirms(SaveFirmRequest saveFirmRequest)
        {
            return Ok(_corporateDiscountsAdminService.SaveFirms(saveFirmRequest));


        }
        [HttpPost(nameof(SaveDiscounts))]
        public IActionResult SaveDiscounts(SaveDiscountsRequest saveDiscountsRequest)
        {
            return Ok(_corporateDiscountsAdminService.SaveDiscounts(saveDiscountsRequest));


        }
    }
}
