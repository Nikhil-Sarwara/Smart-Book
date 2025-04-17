namespace SmartBook.Api.Dtos.Responses
{
    public class UserResponseDto
    {
        public int UserId { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Name { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}