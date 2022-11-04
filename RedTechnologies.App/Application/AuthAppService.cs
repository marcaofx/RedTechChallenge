using RedTechnologies.App.Command;
using System;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using RedTechnologies.Repository.Repository;
using RedTechnologies.Repository.Models;
using System.Threading.Tasks;
using AutoMapper;
using RedTechnologies.Shared;

namespace RedTechnologies.App.Application
{
    public class AuthAppService
    {
        private readonly AppSettings _appSettings;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public AuthAppService(AppSettings appSettings, IUserRepository userRepository, IMapper mapper)
        {
            this._appSettings = appSettings;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<bool> ValidateUserAsync(UserCommand userCommand)
        {
            var user = _mapper.Map<User>(userCommand);
            user.Password = Encrypt.EncryptValue(userCommand.Password);
            var userResult = await _userRepository.GetUserAsync(user);

            return userResult != null;
        }

        public string CreateTokenJWT()
        {
            var issuer = _appSettings.Issuer;
            var audience = _appSettings.Audience;
            var expiry = DateTime.UtcNow.AddHours(_appSettings.TokenExpirationDays);
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(issuer: issuer, audience: audience, expires: expiry, signingCredentials: credentials);
            var tokenHandler = new JwtSecurityTokenHandler();
            var stringToken = tokenHandler.WriteToken(token);
            return stringToken;
        }
    }
}
