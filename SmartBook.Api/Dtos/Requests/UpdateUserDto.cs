namespace SmartBook.Api.Dtos.Requests
{
    public class UpdateUserRequestDto
    {
        public required string Username { get; set; }
        public required string Email { get; set; }
        public string? Password { get; set; } // Password is optional for update
        public required string Name { get; set; }
    }
}