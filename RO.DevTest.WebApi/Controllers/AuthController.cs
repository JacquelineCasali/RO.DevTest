using Microsoft.AspNetCore.Mvc;
using RO.DevTest.Application.Services;
using RO.DevTest.Application.DTOs;

namespace RO.DevTest.WebApi.Controllers
{
    public class AuthService : IAuthService
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest loginRequest)
        {
            var user = _authService.Authenticate(loginRequest.Username, loginRequest.Password);
            if (user == null)
                return Unauthorized("Invalid username or password.");

            var token = _authService.GenerateJwtToken(user);

            return Ok(new TokenResponse { Token = token });
        }
    }
}

}
