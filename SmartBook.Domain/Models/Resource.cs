using System.Collections.Generic;

namespace SmartBook.Domain.Models
{
    public class Resource
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string Type { get; set; } // Meeting Room, Desk, Lab, etc.
        public bool IsActive { get; set; } = true;
        // Add other relevant properties like capacity, location, etc.

        public required ICollection<Booking> Bookings { get; set; }
    }
}
