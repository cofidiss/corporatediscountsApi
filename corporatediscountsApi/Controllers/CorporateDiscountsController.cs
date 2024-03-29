﻿using corporatediscountsApi.CorporateDiscountsServices;
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
        [HttpPost("/GetAllDiscounts")]
        public IActionResult GetAllDiscounts()
        {
           return Ok(_corporateDiscountsService.GetDiscountsByFilter(new DiscountSearchRequest()));


        }

        [HttpPost("/GetDiscountsByFilter")]
        public IActionResult GetDiscountsByFilter(DiscountSearchRequest discountSearchRequest)
        {
            return Ok(_corporateDiscountsService.GetDiscountsByFilter(discountSearchRequest));


        }

        [HttpPost("/GetDiscountScopeLov")]
        public IActionResult GetDiscountScopeLov()
        {
            return Ok(_corporateDiscountsService.GetDiscountScopeLov());


        }

        [HttpPost("/SaveDiscounts")]
        public IActionResult SaveDiscounts(SaveDiscountsRequest saveDiscountsRequest)
        {
            return Ok(_corporateDiscountsService.SaveDiscounts(saveDiscountsRequest));


        }


        [HttpPost("/FirmSelectLov")]
        public IActionResult FirmSelectLov()
        {
            return Ok(_corporateDiscountsService.FirmSelectLov());


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
