using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
       ICarImageService _carImageService;

        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm] IFormFile file, [FromForm] int carId)
        {
            CarImage carImage = new CarImage{ CarId = carId };

            var result = _carImageService.Add(file, carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update([FromForm] IFormFile file, [FromForm] int id)
        {
            CarImage oldImage = _carImageService.GetById(id).Data;  //hangi resim update edilecek o resmi buldum.

            var result = _carImageService.Update(file, oldImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete( CarImage carImage)
        {
            var result = _carImageService.Delete( carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}


//file bir form-data olduğu için : [] yapısı kullanıldı.
//IFormFile bir form-data parçasıdır ve bu nedenle başına [FromForm] koyulması gerekir.