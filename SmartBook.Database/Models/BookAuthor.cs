using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartBook.Database.Models
{
    public class BookAuthor
    {
        [Key]
        public int BookAuthorId { get; set; }

        [ForeignKey("Book")]
        public int BookId { get; set; }
        public required Book Book { get; set; }

        [ForeignKey("Author")]
        public int AuthorId { get; set; }
        public required Author Author { get; set; }
    }
}
