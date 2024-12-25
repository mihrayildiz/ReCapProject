using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }


        [HttpGet("getall")]
        public IActionResult Get()
        {
            var result = _carService.GetAll();
            
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
        
        [HttpGet("getcarsbybrandid")]
        public IActionResult GetCarsByBrandId(int brandId)
        {
            var result = _carService.GetCarsByBrandId(brandId);
            
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
        [HttpGet("getcarsbycolorid")]
        public IActionResult GetCarsByColorId(int colorId)
        {
            var result = _carService.GetCarsByColorId(colorId);
            
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        /*Anasayfada branname ve colorıd nin name olarak gelmesi gerekşyrdu bu yüzden
         dtodan nesnesi ile eşleştirildi.*/
        [HttpGet("getcarsdtobycolorid")]
        public IActionResult GetCarsDtoByColorId(int colorId)
        {
            var result = _carService.GetCarsByColor(colorId);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getcardetails")]
        public IActionResult GetCarDetails()
        {
            var result = _carService.GetCarDetails();

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("getdeletebyid")]
        public IActionResult Get(int id)
        {
            var result = _carService.GetDeleteById(id);
            
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
