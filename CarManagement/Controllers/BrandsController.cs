using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CarManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : Controller
    {
        IBrandService _brandService;
        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet]
        public ActionResult GetBrands()
        {
            var result = _brandService.GetBrands();
            return Ok(result);
        }


    }
}
