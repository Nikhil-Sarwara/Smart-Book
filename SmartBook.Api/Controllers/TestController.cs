using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SmartBook.Api.Controllers
{
    [ApiController]
    [Route("api/testauth")]
    public class TestController : ControllerBase
    {
        [HttpGet("public")]
        public IActionResult PublicEndpoint()
        {
            return Ok("This endpoint is public and does not require authentication.");
        }

        [Authorize]
        [HttpGet("protected")]
        public IActionResult ProtectedEndpoint()
        {
            // You can access user information from the User property if needed
            var userEmail = User.Identity?.Name; // Or User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            return Ok($"This endpoint is protected. You are authenticated as: {userEmail}");
        }

        // If you have defined roles, you can add an endpoint like this:
        // [Authorize(Roles = "Admin")]
        // [HttpGet("admin")]
        // public IActionResult AdminEndpoint()
        // {
        //     return Ok("This endpoint is only accessible to users with the 'Admin' role.");
        // }
    }
}