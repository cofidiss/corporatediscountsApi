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

        [HttpPost(nameof(IsAdmin))]
        public IActionResult IsAdmin()

        {
            //throw new Exception("a");
            return Ok(true);


        }

        
        [HttpPost(nameof(GetUserInfo))]
        public IActionResult GetUserInfo()

        {
            //throw new Exception("a");
            return Ok(new {userName="sinan",isAdmin=false});


        }
        [HttpPost(nameof(Login))]
        public IActionResult Login()

        {
            //throw new Exception("a");
            return Ok(true);


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
        [HttpPost(nameof(GetFirms))]
        public IActionResult GetFirms()
        {
            return Ok(_corporateDiscountsAdminService.GetFirms());


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
        [HttpPost(nameof(UpdateFirm))]
        public IActionResult UpdateFirm(UpdateFirmRequest updateFirmRequest)
        {

            try { _corporateDiscountsAdminService.UpdateFirm(updateFirmRequest); }
            catch (Exception e)
            {
                Response.StatusCode = 500;
                return Content("firma güncellenemedi");

            }

            return Ok("firma Güncellendi");



        }
        [HttpPost(nameof(AddFirm))]
        public IActionResult AddFirm(AddFirmRequest addFirmRequest)
        {

            try { _corporateDiscountsAdminService.AddFirm(addFirmRequest); }
            catch (Exception e)
            {
                Response.StatusCode = 500;
                return Content("firma eklenemdi");

            }

            return Ok("firma eklendi");
        }
        [HttpPost(nameof(DeleteFirm))]
        public IActionResult DeleteFirm([FromBody] int firmId)
        {

            try { _corporateDiscountsAdminService.DeleteFirm(firmId); }
            catch (Exception e)
            {
                Response.StatusCode = 500;
                return Content("firma silinemdi");

            }

            return Ok("firma silindi");
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

        [HttpPost(nameof(UpdateDiscounts))]
        public IActionResult UpdateDiscounts(UpdatedDiscountRow updateDiscountsRequest)
        {
            try { _corporateDiscountsAdminService.UpdateDiscounts(updateDiscountsRequest); }
            catch (Exception e)
            {
                Response.StatusCode = 500;
                return Content("İndirim kayıt edilemedi");

            }
          
            return Ok("İndirim Güncellendi");


        }

        [HttpPost(nameof(DeleteDiscount))]
        public IActionResult DeleteDiscount([FromBody] long discountId)
        {
            try { _corporateDiscountsAdminService.DeleteDiscount(discountId); }
            catch (Exception e)
            {
                Response.StatusCode = 500;
                return Content("İndirim silinemedi edilemedi");

            }

            return Ok("İndirim Silindi");


        }

        [HttpPost(nameof(AddDiscount))]
        public IActionResult AddDiscount(InsertedDiscountRow insertedDiscountRow)
        {
            try { _corporateDiscountsAdminService.AddDiscount(insertedDiscountRow); }
            catch (Exception e)
            {
               
                Response.StatusCode = 500;
                
                return Content("İndirim eklenemdi edilemedi");

            }

            return Ok("İndirim Eklendi");


        }
        [HttpPost(nameof(GetCategories))]
        public IActionResult GetCategories()
        {
            try { 
            var categories=  _corporateDiscountsAdminService.GetCategories();
                return Ok(categories);
            }
            catch ( Exception e)
            {
                Response.StatusCode = 500;

                return Content("Kategoriler indirilemedi.");


            }



   


        }

        [HttpPost(nameof(UpdateCategory))]
        public IActionResult UpdateCategory(UpdateCategoryRequest updateCategory)
        {
            try { _corporateDiscountsAdminService.UpdateCategory(updateCategory); }
            catch (Exception e )
            {
                Response.StatusCode = 500;

                return Content("Kategori güncellenemdi.");


            }
  

            return Ok("Kategori güncellendi");


        }

        [HttpPost(nameof(AddCategory))]
        public IActionResult AddCategory(AddCategoryRequest addCategory)
        {
            try { _corporateDiscountsAdminService.AddCategory(addCategory); }
            catch (Exception e)
            {
                Response.StatusCode = 500;

                return Content("Kategori eklenemedi.");


            }


            return Ok("Kategori eklendi");


        }


        [HttpPost(nameof(DeleteCategory))]
        public IActionResult DeleteCategory([FromBody] int categoryId)
        {
            try { _corporateDiscountsAdminService.DeleteCategory(categoryId); }
            catch (Exception e)
            {





                Response.StatusCode = 500;





                return Content("Kategori silinemdei.");


            }


            return Ok("Kategori silindi");


        }
    }
}
