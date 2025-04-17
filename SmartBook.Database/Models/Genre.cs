using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartBook.Database.Models
{
    public class Genre
    {
        [Key]
        public int GenreId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<BookGenre> BookGenres { get; set; }
    }
}
