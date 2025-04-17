using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartBook.Api.Dtos.Requests;
using SmartBook.Api.Dtos.Responses;
using SmartBook.Database.Models;
using SmartBook.Api.Repositories;

namespace SmartBook.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] // Require authentication for all actions in this controller
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorsController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorResponseDto>>> GetAllAuthors()
        {
            var authors = await _authorRepository.GetAllAsync();
            var response = authors.Select(author => new AuthorResponseDto
            {
                AuthorId = author.AuthorId,
                FirstName = author.Name,
            });
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorResponseDto>> GetAuthorById(int id)
        {
            var author = await _authorRepository.GetByIdAsync(id);

            if (author == null)
            {
                return NotFound();
            }

            var response = new AuthorResponseDto
            {
                AuthorId = author.AuthorId,
                FirstName = author.Name,
            };

            return Ok(response);
        }

        // [HttpPost]
        // public async Task<ActionResult<AuthorResponseDto>> CreateAuthor([FromBody] CreateAuthorRequestDto model)
        // {
        //     if (!ModelState.IsValid)
        //     {
        //         return BadRequest(ModelState);
        //     }

        //     var newAuthor = new Author
        //     {
        //         Name = model.FirstName,
        //     };

        //     await _authorRepository.AddAsync(newAuthor);

        //     var response = new AuthorResponseDto
        //     {
        //         AuthorId = newAuthor.AuthorId,
        //         FirstName = newAuthor.Name,
        //     };

        //     return CreatedAtAction(nameof(GetAuthorById), new { id = newAuthor.AuthorId }, response);
        // }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAuthor(int id, [FromBody] UpdateAuthorRequestDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingAuthor = await _authorRepository.GetByIdAsync(id);
            if (existingAuthor == null)
            {
                return NotFound();
            }

            existingAuthor.Name = model.FirstName ?? existingAuthor.Name;

            _authorRepository.Update(existingAuthor);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var authorToDelete = await _authorRepository.GetByIdAsync(id);
            if (authorToDelete == null)
            {
                return NotFound();
            }

            _authorRepository.Delete(authorToDelete);
            return NoContent();
        }
    }
}