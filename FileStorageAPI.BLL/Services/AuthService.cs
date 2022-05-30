using AutoMapper;
using FileStorageAPI.BLL.Configs;
using FileStorageAPI.BLL.Exeptions;
using FileStorageAPI.BLL.Helpers;
using FileStorageAPI.BLL.Models;
using FileStorageAPI.DAL.Entity;
using FileStorageAPI.DAL.Repositories;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace FileStorageAPI.BLL.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _map;

        public AuthService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _map = mapper;
        }

        public async Task<string> GetToken(UserModel user)
        {
            var claims = new List<Claim> {
                new Claim(ClaimTypes.Name, user.Name ),
                new Claim(ClaimTypes.UserData, user.Id.ToString())
            };

            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.Issuer,
                    audience: AuthOptions.Audience,
                    claims: claims,
                    expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        public async Task<UserModel> GetUserForLogin(string name, string pass)
        {
            User foundUser = await _userRepository.GetUserByName(name);
            if (foundUser == null || foundUser.Name == null ||
                !PasswordHash.ValidatePassword(pass, foundUser.Password))
            {
                throw new NotFoundExeption("Invalid username or password entered");
            }
            if (foundUser.IsDeleted)
            {
                throw new NotFoundExeption("User not found or deleted");
            }

            UserModel user = _map.Map<UserModel>(foundUser);
            return user;
        }
    }
}
