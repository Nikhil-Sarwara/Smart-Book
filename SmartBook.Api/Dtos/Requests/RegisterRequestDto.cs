using System.ComponentModel.DataAnnotations;

namespace SmartBook.Api.Dtos.Requests
{
    public class RegisterRequestDto
    {
        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public required string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        [DataType(DataType.Password)]
        public required string ConfirmPassword { get; set; }
    }
}