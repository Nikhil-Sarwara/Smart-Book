using System;
using System.Collections.Generic;

namespace SmartBook.Api.Dtos.Requests
{
    public class UpdateBookRequestDto
    {
        public required string Title { get; set; }
        public required string ISBN { get; set; }
        public DateTime? PublicationDate { get; set; }
        public int? PublisherId { get; set; }
        public List<int>? AuthorIds { get; set; }
        public List<int>? GenreIds { get; set; }
    }
}