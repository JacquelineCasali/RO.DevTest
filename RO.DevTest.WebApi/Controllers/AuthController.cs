using Microsoft.AspNetCore.Mvc;
using RO.DevTest.WebApi.Models;
using RO.DevTest.WebApi.Services;

namespace RO.DevTest.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest login)
        {
            var user = _authService.ValidateUser(login.Username, login.Password);
            if (user == null) return Unauthorized("Usuário ou senha inválidos.");

            var token = _authService.GenerateJwtToken(user);
            return Ok(new { token });
        }
    }

    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
