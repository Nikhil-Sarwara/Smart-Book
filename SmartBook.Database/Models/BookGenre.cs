using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartBook.Database.Models
{
    public class BookGenre
    {
        [Key]
        public int BookGenreId { get; set; }

        [ForeignKey("Book")]
        public int BookId { get; set; }
        public required Book Book { get; set; }

        [ForeignKey("Genre")]
        public int GenreId { get; set; }
        public required Genre Genre { get; set; }
    }
}
