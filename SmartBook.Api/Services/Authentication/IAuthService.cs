using SmartBook.Api.Dtos.Requests;
using SmartBook.Api.Dtos.Responses;
using SmartBook.Domain.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace SmartBook.Api.Services
{
    public interface IAuthService
    {
        Task<AuthResponseDto> RegisterAsync(RegisterRequestDto model);
        Task<AuthResponseDto> LoginAsync(LoginRequestDto model);
    }
}