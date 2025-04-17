using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartBook.Database.Models
{
    public class Publisher
    {
        [Key]
        public int PublisherId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Location { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
