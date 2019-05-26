using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JwtAuthenticationApi.Application.Interfaces.Services.Api;
using JwtAuthenticationApi.Contract.DTO;
using JwtAuthenticationApi.Contract.DTO.Request;
using JwtAuthenticationApi.Core.Helpers;
using JwtAuthenticationApi.Handler;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace JwtAuthenticationApi.Controllers
{
  [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        private IJWT _jwt;


        public UsersController(IUserService userService, IJWT jwt)
        {
            _userService = userService;
            _jwt = jwt;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]UserRequest request)
        {
            var user = _userService.Authenticate(request.Username, request.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            user  = _jwt.GenerateToken(user);

            return Ok(user);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users =  _userService.GetAll();
            return Ok(users);
        }
    }
}
