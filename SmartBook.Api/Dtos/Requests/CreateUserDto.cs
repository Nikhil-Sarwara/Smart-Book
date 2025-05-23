namespace SmartBook.Api.Dtos.Requests
{
    public class CreateUserRequestDto
    {
        public required string Username { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string Name { get; set; }
    }
}