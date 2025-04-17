using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartBook.Database.Models
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Biography { get; set; }

        public ICollection<BookAuthor> BookAuthors { get; set; }
    }
}
