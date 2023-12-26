using ForAccountRecords.Application.Helpers;
using ForAccountRecords.Domain.Models.DatabaseModels;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ForAccountRecords.Infrastructure.Helpers
{
    public class JwtHelper : IJwtHelper
    {


        private readonly IJwtOptionManager _jwtOptionManager;
        
        public JwtHelper(IJwtOptionManager jwtOptionManager)
        {
            _jwtOptionManager = jwtOptionManager;
        }

        public string GenerateToken(User user)
        {
            var options = _jwtOptionManager.GenerateJwtOptions();
            
            var claims = _jwtOptionManager.GenerateClaims(user);
            var symentricKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.SecretKey));
            var algorithem = SecurityAlgorithms.HmacSha256;
            var signingKey = new SigningCredentials(symentricKey, algorithem);
            var token = new JwtSecurityToken(options.Issuer, options.Audience, claims, null, DateTime.UtcNow.AddHours(options.TokenExpiryIntervalInHours), signingKey);

            string tokenValue = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenValue;
        }
    }
}
