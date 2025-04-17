using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartBook.Database.Models
{
    public class Genre
    {
        [Key]
        public int GenreId { get; set; }

        [Required]
        public required string Name { get; set; }

        public required string Description { get; set; }

        public required ICollection<BookGenre> BookGenres { get; set; }
    }
}
