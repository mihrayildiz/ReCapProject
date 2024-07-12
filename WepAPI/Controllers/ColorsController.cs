using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Entities.Concrete;
using System.Reflection.Metadata.Ecma335;


namespace WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {

        IColorService _colorservice;

        public ColorsController(IColorService colorservice)
        {
            _colorservice = colorservice;
        }

        [HttpGet("getall")]
        public IActionResult Get()
        {
            var result = _colorservice.GetColorList();
            
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
           
        }
          
        
        
        [HttpPost("addcolor")]

        public IActionResult Post(Color color)
        {
            var result = _colorservice.GetColorAdd(color);    
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
