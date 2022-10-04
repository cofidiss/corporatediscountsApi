using corporatediscountsApi.CorporateDiscountsServices;
using corporatediscountsApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace corporatediscountsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CorporateDiscountsController : ControllerBase
    {

        CorporateDiscountsService _corporateDiscountsService { get; set; }
        public CorporateDiscountsController(CorporateDiscountsService corporateDiscountsService)
        {
            _corporateDiscountsService = corporateDiscountsService;
        }


        [HttpPost(nameof(FilterDiscounts))]
        public IActionResult FilterDiscounts(DiscountSearchRequest discountSearchRequest)
        {
            throw new Exception("");
           
            return Ok(_corporateDiscountsService.FilterDiscounts(discountSearchRequest));


        }

        [HttpPost(nameof(DiscountScopeLov))]
        public IActionResult DiscountScopeLov()
        
        {
            //throw new Exception("a");
            return Ok(_corporateDiscountsService.GetDiscountScopeLov());


        }

        //[HttpPost("/SaveDiscounts")]
        //public IActionResult SaveDiscounts(SaveDiscountsRequest saveDiscountsRequest)
        //{
        //    return Ok(_corporateDiscountsService.SaveDiscounts(saveDiscountsRequest));


        //}


        [HttpPost(nameof(FirmLov))]
        public IActionResult FirmLov()
        {
            return Ok(_corporateDiscountsService.FirmLov());


        }

        [HttpPost(nameof(DiscountCategoryLov))]
        public IActionResult DiscountCategoryLov()
        {
            return Ok(_corporateDiscountsService.DiscountCategoryLov());


        }


        [HttpPost("/GetFirms")]
        public IActionResult GetFirms()
        {
            return Ok(_corporateDiscountsService.GetFirms());


        }


        [HttpPost("/SaveFirms")]
        public IActionResult SaveFirms(SaveFirmRequest saveFirmRequest)
        {
            return Ok(_corporateDiscountsService.SaveFirms(saveFirmRequest));


        }

    }
}
