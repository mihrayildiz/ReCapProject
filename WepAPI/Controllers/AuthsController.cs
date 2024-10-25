using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController : ControllerBase
    {
        IAuthService _authService;

        public AuthsController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userLogin = _authService.Login(userForLoginDto);
            if (!userLogin.Success)
            {
                return BadRequest(userLogin.Message);
            }

            var result = _authService.CreateAccessToken(userLogin.Data);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);

        }

        [HttpPost("register")]
        public IActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var userToCheck = _authService.UserExists(userForRegisterDto.Email);
            if (userToCheck != null)
            {
                return BadRequest(userToCheck.Message);
            }

            var registerUser = _authService.Register(userForRegisterDto, userForRegisterDto.Password);
            var accessToken = _authService.CreateAccessToken(registerUser.Data);
            if (accessToken.Success)
            {
                return Ok(accessToken.Data);
            }

            return BadRequest(accessToken.Message);

        }

    }



}
