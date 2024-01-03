using ForAccountRecords.Application.Helpers;
using ForAccountRecords.Application.IConfiguration;
using ForAccountRecords.Domain.Models.DatabaseModels;
using ForAccountRecords.Domain.Models.GeneralModels;
using ForAccountRecords.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ForAccountRecords.Api.ApplicationTasks
{
    public class JwtOptionManager : IJwtOptionManager
    {

        private readonly IConfiguration _config;
        private readonly ApplicationDbContext _dbContext;
        public JwtOptionManager(IConfiguration configuration, ApplicationDbContext dbContext)
        {
            _config = configuration;
            _dbContext = dbContext;
        }

        public Claim[] GenerateClaims(User user)
        {
            string role = _dbContext.UserRoles.Where(m =>m.Id == user.UserRolesId).Select(m => m.Name).First();
            var claims = new Claim[]
            {
                new(JwtRegisteredClaimNames.Sid, user.Id.ToString()),
                new(JwtRegisteredClaimNames.Email, user.EmailAddress.ToString()),
                new(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new(JwtRegisteredClaimNames.Name, user.UserName),
                new Claim(ClaimTypes.Role, role)


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
