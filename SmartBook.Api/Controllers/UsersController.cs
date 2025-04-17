using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartBook.Api.Dtos.Requests;
using SmartBook.Api.Dtos.Responses;
using SmartBook.Api.Repositories;
using SmartBook.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartBook.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize()] // Example: Only administrators can access these endpoints
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userRepository.GetAllAsync();
            var response = users.Select(u => new UserResponseDto
            {
                UserId = u.UserId,
                Username = u.Username,
                Email = u.Email,
                Name = u.Name,
                RegistrationDate = u.RegistrationDate
            });
            return Ok(response);
        }

        [HttpGet("{id}", Name = "GetUserById")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            var response = new UserResponseDto
            {
                UserId = user.UserId,
                Username = user.Username,
                Email = user.Email,
                Name = user.Name,
                RegistrationDate = user.RegistrationDate
            };

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequestDto model)
        {
            // Check if the username or email already exists
            var existingUserByUsername = await _userRepository.GetByUsernameAsync(model.Username);
            if (existingUserByUsername != null)
            {
                ModelState.AddModelError("Username", "Username already exists.");
                return BadRequest(ModelState);
            }

            var existingUserByEmail = await _userRepository.GetByEmailAsync(model.Email);
            if (existingUserByEmail != null)
            {
                ModelState.AddModelError("Email", "Email already exists.");
                return BadRequest(ModelState);
            }

            // Hash the password before saving (Important for security!)
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(model.Password);

            var newUser = new User
            {
                Username = model.Username,
                Email = model.Email,
                Password = hashedPassword, // Store the hashed password
                Name = model.Name,
                RegistrationDate = DateTime.UtcNow
            };

            await _userRepository.AddAsync(newUser);

            var response = new UserResponseDto
            {
                UserId = newUser.UserId,
                Username = newUser.Username,
                Email = newUser.Email,
                Name = newUser.Name,
                RegistrationDate = newUser.RegistrationDate
            };

            return CreatedAtAction(nameof(GetUserById), new { id = newUser.UserId }, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UpdateUserRequestDto model)
        {
            var existingUser = await _userRepository.GetByIdAsync(id);

            if (existingUser == null)
            {
                return NotFound();
            }

            // Check if the updated username or email already exists for a different user
            if (model.Username != existingUser.Username)
            {
                var existingUserByUsername = await _userRepository.GetByUsernameAsync(model.Username);
                if (existingUserByUsername != null && existingUserByUsername.UserId != id)
                {
                    ModelState.AddModelError("Username", "Username already exists.");
                    return BadRequest(ModelState);
                }
                existingUser.Username = model.Username;
            }

            if (model.Email != existingUser.Email)
            {
                var existingUserByEmail = await _userRepository.GetByEmailAsync(model.Email);
                if (existingUserByEmail != null && existingUserByEmail.UserId != id)
                {
                    ModelState.AddModelError("Email", "Email already exists.");
                    return BadRequest(ModelState);
                }
                existingUser.Email = model.Email;
            }

            existingUser.Name = model.Name;

            if (!string.IsNullOrEmpty(model.Password))
            {
                existingUser.Password = BCrypt.Net.BCrypt.HashPassword(model.Password);
            }

            _userRepository.Update(existingUser);

            return NoContent(); // Return 204 No Content for a successful update
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var userToDelete = await _userRepository.GetByIdAsync(id);

            if (userToDelete == null)
            {
                return NotFound();
            }

            var existingUser = await _userRepository.GetByNameAsync(userToDelete.Username);

            if (existingUser == null)
            {
                return NotFound();
            }

            _userRepository.Delete(userToDelete);

            return NoContent(); // Return 204 No Content for a successful deletion
        }
    }
}