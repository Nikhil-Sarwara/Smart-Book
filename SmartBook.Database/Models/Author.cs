using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartBook.Database.Models
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }

        [Required]
        public required string Name { get; set; }

        public required string Biography { get; set; }

        public required ICollection<BookAuthor> BookAuthors { get; set; }
    }
}
