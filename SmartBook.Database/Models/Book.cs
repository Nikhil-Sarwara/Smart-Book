using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartBook.Database.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        [Required]
        public required string Title { get; set; }

        public required string ISBN { get; set; }

        public DateTime PublicationDate { get; set; }

        [ForeignKey("Publisher")]
        public int PublisherId { get; set; }
        public required Publisher Publisher { get; set; }

        public required ICollection<BookGenre> BookGenres { get; set; }
        public required ICollection<BookAuthor> BookAuthors { get; set; }
        public required ICollection<Loan> Loans { get; set; }
        public required ICollection<ReadingProgress> ReadingProgresses { get; set; }
        public required ICollection<Review> Reviews { get; set; }
    }
}
