using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartBook.Database.Models
{
    public class Publisher
    {
        [Key]
        public int PublisherId { get; set; }

        [Required]
        public required string Name { get; set; }

        public required string Location { get; set; }

        public required ICollection<Book> Books { get; set; }
    }
}
