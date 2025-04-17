
namespace SmartBook.Api.Dtos.Responses
{
    public class AuthResponseDto
    {
        public string Token { get; set; }
        public string Email { get; set; }
        public Dictionary<string, string[]>? Errors { get; internal set; }
    }
}