using Microsoft.AspNetCore.Mvc;
using SmartBook.Api.Dtos.Requests;
using SmartBook.Api.Services;
using System.Threading.Tasks;

namespace SmartBook.Api.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _authService.RegisterAsync(model);

            if (result == null)
            {
                return BadRequest(new ValidationProblemDetails
                {
                    Title = "Registration failed",
                    Detail = "Please check the registration details and try again.",
                    Errors = new Dictionary<string, string[]>
                    {
                        { "Registration", new[] { "Registration failed. Please check the registration details and try again." } }
                    }
                });
            }

            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _authService.LoginAsync(model);

            if (result == null)
            {
                return Unauthorized("Invalid login credentials"); // Improve error handling
            }

            return Ok(result);
        }
    }
}