using Microsoft.AspNetCore.Mvc;

namespace SmartBook.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenresController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            // In a real application, you would implement logic here
            return Ok("This is the Genres controller.");
        }

        // Add more actions (e.g., GetById, Post, Put, Delete) as needed
    }
}

