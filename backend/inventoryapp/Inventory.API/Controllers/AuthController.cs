using Inventory.Application.Services;
using Inventory.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using BCrypt.Net;

namespace Inventory.API.Controllers
{
    //[ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _service;

        public AuthController(IUserService service)
        {
            _service = service;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            var result =
                await _service.RegisterAsync(user);

            return Ok(result);
        }

        //[HttpPost("login")]
        //public async Task<IActionResult> Login([FromBody] User user)
        //{
        //    var token =
        //        await _service.LoginAsync(user);

        //    if (token == null)
        //        return Unauthorized("Invalid username or password");

        //    return Ok(new
        //    {
        //        token
        //    });
        //}

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] User user)
        {
            if (string.IsNullOrEmpty(user.Username) ||
                string.IsNullOrEmpty(user.PasswordHash))
            {
                return BadRequest("Username and Password are required");
            }

            var token = await _service.LoginAsync(user);

            if (token == null)
                return Unauthorized("Invalid username or password");

            return Ok(new { token });
        }

    }
}
