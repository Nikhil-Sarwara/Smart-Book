using Microsoft.AspNetCore.Identity;

namespace SmartBook.Domain.Models
{
    public class ApplicationUser : IdentityUser
    {
        // Add any custom properties for your user here
        public required string Name { get; set; }
        public DateTime RegistrationDate { get; set; }
        // ... other properties
    }
}