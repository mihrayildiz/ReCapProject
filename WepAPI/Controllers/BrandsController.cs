using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpPost("add")]

        public IActionResult Add(Brand brand)
        {
            var result = _brandService.GetBrandAdd(brand);
            if (result.Success)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
