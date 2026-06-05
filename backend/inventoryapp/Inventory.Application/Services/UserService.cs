using Inventory.Application.Interface;
using Inventory.Application.Services;
using Inventory.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Inventory.API.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IConfiguration _config;

        public UserService(
            IUserRepository repository,
            IConfiguration config)
        {
            _repository = repository;
            _config = config;
        }

        //public async Task<User> RegisterAsync(User user)
        //{
        //    user.PasswordHash =
        //        BCrypt.Net.BCrypt.HashPassword(user.PasswordHash);

        //    user.CreatedAt = DateTime.Now;

        //    await _repository.CreateAsync(user);

        //    return user;
        //}

        public async Task<User> RegisterAsync(User user)
        {
            user.PasswordHash =
                BCrypt.Net.BCrypt.HashPassword(user.PasswordHash);

            user.CreatedAt = DateTime.Now;
            user.IsActive = true;

            if (string.IsNullOrEmpty(user.Role))
                user.Role = "User";

            await _repository.CreateAsync(user);

            return user;
        }

        public async Task<string> LoginAsync(User user)
        {
            var existingUser =
                await _repository.GetByUsernameAsync(user.Username);

            if (existingUser == null)
                return null;

            bool isValid =
                BCrypt.Net.BCrypt.Verify(
                    user.PasswordHash,   // this is actually plain password
                    existingUser.PasswordHash);

            if (!isValid)
                return null;

            return GenerateJwt(existingUser);
        }

        //public async Task<string> LoginAsync(User user)
        //{
        //    var existingUser =
        //        await _repository.GetByUsernameAsync(user.Username);

        //    if (existingUser == null)
        //        return null;

        //    bool isValid =
        //        BCrypt.Net.BCrypt.Verify(
        //            user.PasswordHash,
        //            existingUser.PasswordHash);

        //    if (!isValid)
        //        return null;

        //    return GenerateJwt(existingUser);
        //}

        private string GenerateJwt(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim("UserId", user.Id.ToString()),
                new Claim("Role", user.Role)
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(
                    _config["Jwt:Key"]));

            var creds = new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler()
                .WriteToken(token);
        }
    }
}