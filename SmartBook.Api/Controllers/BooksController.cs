using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartBook.Api.Dtos.Requests;
using SmartBook.Api.Dtos.Responses;
using SmartBook.Api.Repositories;
using SmartBook.Database.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartBook.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] // Require authentication for all actions in this controller
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        private readonly IPublisherRepository _publisherRepository; // To fetch publisher name
        private readonly IAuthorRepository _authorRepository;     // To fetch author details
        private readonly IGenreRepository _genreRepository;       // To fetch genre details

        public BooksController(IBookRepository bookRepository, IPublisherRepository publisherRepository, IAuthorRepository authorRepository, IGenreRepository genreRepository)
        {
            _bookRepository = bookRepository;
            _publisherRepository = publisherRepository;
            _authorRepository = authorRepository;
            _genreRepository = genreRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookResponseDto>>> GetAllBooks()
        {
            var books = await _bookRepository.GetAllAsync();
            var response = books.Select(book => new BookResponseDto
            {
                BookId = book.BookId,
                Title = book.Title,
                ISBN = book.ISBN,
                PublicationDate = book.PublicationDate,
                PublisherId = book.PublisherId,
                PublisherName = book.Publisher?.Name,
                Authors = book.BookAuthors?.Select(static ba => new AuthorResponseDto
                {
                    AuthorId = ba.AuthorId,
                    FirstName = ba.Author?.Name,
                }).ToList(),
                Genres = book.BookGenres?.Select(bg => new GenreResponseDto
                {
                    GenreId = bg.GenreId,
                    Name = bg.Genre?.Name
                }).ToList()
            });
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookResponseDto>> GetBookById(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            var response = new BookResponseDto
            {
                BookId = book.BookId,
                Title = book.Title,
                ISBN = book.ISBN,
                PublicationDate = book.PublicationDate,
                PublisherId = book.PublisherId,
                PublisherName = book.Publisher?.Name,
                Authors = book.BookAuthors?.Select(ba => new AuthorResponseDto
                {
                    AuthorId = ba.AuthorId,
                    FirstName = ba.Author?.Name,
                }).ToList(),
                Genres = book.BookGenres?.Select(bg => new GenreResponseDto
                {
                    GenreId = bg.GenreId,
                    Name = bg.Genre?.Name
                }).ToList()
            };

            return Ok(response);
        }

        // [HttpPost]
        // public async Task<ActionResult<BookResponseDto>> CreateBook([FromBody] CreateBookRequestDto model)
        // {
        //     if (!ModelState.IsValid)
        //     {
        //         return BadRequest(ModelState);
        //     }

        //     var publisherExists = await _publisherRepository.GetByIdAsync(model.PublisherId);
        //     if (publisherExists == null)
        //     {
        //         ModelState.AddModelError("PublisherId", "Invalid PublisherId.");
        //         return BadRequest(ModelState);
        //     }

        //     var newBook = new Book
        //     {
        //         Title = model.Title,
        //         ISBN = model.ISBN,
        //         PublicationDate = model.PublicationDate,
        //         PublisherId = model.PublisherId,
        //         // BookGenres = model.GenreIds?.Select(genreId => new BookGenre { GenreId = genreId }).ToList() ?? new List<BookGenre>(),
        //         // BookAuthors = model.AuthorIds?.Select(authorId => new BookAuthor { AuthorId = authorId }).ToList() ?? new List<BookAuthor>()
        //     };

        //     await _bookRepository.AddAsync(newBook);

        //     var response = new BookResponseDto
        //     {
        //         BookId = newBook.BookId,
        //         Title = newBook.Title,
        //         ISBN = newBook.ISBN,
        //         PublicationDate = newBook.PublicationDate,
        //         PublisherId = newBook.PublisherId
        //         // Note: Authors and Genres might not be fully populated here as they are added separately
        //     };

        //     return CreatedAtAction(nameof(GetBookById), new { id = newBook.BookId }, response);
        // }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] UpdateBookRequestDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingBook = await _bookRepository.GetByIdAsync(id);
            if (existingBook == null)
            {
                return NotFound();
            }

            if (model.PublisherId.HasValue)
            {
                var publisherExists = await _publisherRepository.GetByIdAsync(model.PublisherId.Value);
                if (publisherExists == null)
                {
                    ModelState.AddModelError("PublisherId", "Invalid PublisherId.");
                    return BadRequest(ModelState);
                }
                existingBook.PublisherId = model.PublisherId.Value;
            }

            existingBook.Title = model.Title ?? existingBook.Title;
            existingBook.ISBN = model.ISBN ?? existingBook.ISBN;
            if (model.PublicationDate.HasValue)
            {
                existingBook.PublicationDate = model.PublicationDate.Value;
            }

            // Logic to update BookGenres and BookAuthors would typically go here
            // This might involve clearing existing entries and adding new ones based on model.AuthorIds and model.GenreIds

            _bookRepository.Update(existingBook);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var bookToDelete = await _bookRepository.GetByIdAsync(id);
            if (bookToDelete == null)
            {
                return NotFound();
            }

            _bookRepository.Delete(bookToDelete);
            return NoContent();
        }
    }
}