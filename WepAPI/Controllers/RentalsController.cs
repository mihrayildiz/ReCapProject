using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        IRentalService _rentalService;

        public RentalsController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpPost("add")]
        public IActionResult Post(Rental rental)
        {
           var result =  _rentalService.AddRental(rental);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        } 
        
        
        [HttpGet("getall")]
        public IActionResult Get()
        {
            var result = _rentalService.GetAllRental();

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
