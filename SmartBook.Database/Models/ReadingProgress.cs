using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartBook.Database.Models
{
    public class ReadingProgress
    {
        [Key]
        public int ProgressId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public required User User { get; set; }

        [ForeignKey("Book")]
        public int BookId { get; set; }
        public required Book Book { get; set; }

        public int CurrentPage { get; set; }
        public decimal PercentageCompleted { get; set; }
    }
}
