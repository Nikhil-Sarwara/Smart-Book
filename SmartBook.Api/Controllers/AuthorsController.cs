using Microsoft.AspNetCore.Mvc;

namespace SmartBook.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorsController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("This is the Authors controller.");
        }
    }
}

