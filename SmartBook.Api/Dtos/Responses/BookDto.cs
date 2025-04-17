using System;
using System.Collections.Generic;

namespace SmartBook.Api.Dtos.Responses
{
    public class BookResponseDto
    {
        public int BookId { get; set; }
        public required string Title { get; set; }
        public required string ISBN { get; set; }
        public DateTime PublicationDate { get; set; }
        public int PublisherId { get; set; }
        public string? PublisherName { get; set; } // Optional: Include publisher name
        public List<AuthorResponseDto>? Authors { get; set; } // Optional: Include authors
        public List<GenreResponseDto>? Genres { get; set; }   // Optional: Include genres
    }
}