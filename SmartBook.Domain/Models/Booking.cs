using System;

namespace SmartBook.Domain.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public required string UserId { get; set; } // Foreign key to ApplicationUser
        public int ResourceId { get; set; } // Foreign key to Resource
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime BookingDate { get; set; } = DateTime.UtcNow;
        public string Status { get; set; } = "Pending"; // Pending, Confirmed, Cancelled, Expired

        // Navigation properties
        public required ApplicationUser User { get; set; }
        public required Resource Resource { get; set; }
    }
}
