using Microsoft.AspNetCore.Mvc;

namespace SmartBook.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PublishersController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("This is the Publishers controller.");
        }
    }
}

