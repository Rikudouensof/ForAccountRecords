using ForAccountRecords.Application.Helpers;
using ForAccountRecords.Domain.Models.DatabaseModels;
using ForAccountRecords.Domain.Models.GeneralModels;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ForAccountRecords.Api.ApplicationTasks
{
    public class JwtOptionManager : IJwtOptionManager
    {

        private readonly IConfiguration _config;
        
        public JwtOptionManager(IConfiguration configuration)
        {
            _config = configuration;
        }

        public Claim[] GenerateClaims(User user)
        {
            
            var claims = new Claim[]
            {
                new(JwtRegisteredClaimNames.Sid, user.Id.ToString()),
                new(JwtRegisteredClaimNames.Email, user.EmailAddress.ToString()),
                new(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new(JwtRegisteredClaimNames.Name, user.UserName),
             
                
            };
            return claims;
        }

        public JwtOptions GenerateJwtOptions()
        {
            var jwtOptions = new JwtOptions()
            {
                Audience = _config["JwtSettings:Audience"],
                Issuer = _config["JwtSettings:Issuer"],
                SecretKey = _config["JwtSettings:Key"],
                TokenExpiryIntervalInHours = int.Parse(_config["JwtSettings:IntervalsInHours"]),
            };
            return jwtOptions;
        }
    }
}
