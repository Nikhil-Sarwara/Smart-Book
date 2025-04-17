using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SmartBook.Api.Dtos.Requests;
using SmartBook.Api.Dtos.Responses;
using SmartBook.Domain.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SmartBook.Api.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;

        public AuthService(UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }
        public async Task<AuthResponseDto> RegisterAsync(RegisterRequestDto model)
        {
            var user = new ApplicationUser { UserName = model.Email, Email = model.Email, Name = model.Email, RegistrationDate = DateTime.Now };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                return GenerateJwtToken(user);
            }

            var errors = new Dictionary<string, string[]>();

            foreach (var error in result.Errors)
            {
                errors.Add(error.Code, new[] { error.Description });
            }

            return new AuthResponseDto
            {
                Errors = errors
            };
        }

        public async Task<AuthResponseDto> LoginAsync(LoginRequestDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                return GenerateJwtToken(user);
            }

            // Handle invalid login attempt (you might want to return a specific error response)
            return null;
        }

        private AuthResponseDto GenerateJwtToken(ApplicationUser user)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var key = Encoding.ASCII.GetBytes(jwtSettings["Secret"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(
                        ClaimTypes.Email,
                        value: user.Email),
                    new Claim(ClaimTypes.NameIdentifier, user.Id) // Optional: Include user ID
                    // You can add roles here if you implement roles later
                }),
                Expires = DateTime.UtcNow.AddHours(int.Parse(jwtSettings["ExpirationInHours"])),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = jwtSettings["Issuer"],
                Audience = jwtSettings["Audience"]
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var encryptedToken = tokenHandler.WriteToken(token);

            return new AuthResponseDto
            {
                Token = encryptedToken,
                Email = user.Email
            };
        }
    }
}