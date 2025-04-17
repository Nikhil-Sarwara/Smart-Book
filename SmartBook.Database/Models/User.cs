using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartBook.Database.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public required string Username { get; set; }

        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        [Required]
        public required string Password { get; set; } // Consider hashing in a real application

        public required string Name { get; set; }

        public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;

        public required ICollection<Loan> Loans { get; set; }
        public required ICollection<ReadingProgress> ReadingProgresses { get; set; }
        public required ICollection<Review> Reviews { get; set; }
    }
}
