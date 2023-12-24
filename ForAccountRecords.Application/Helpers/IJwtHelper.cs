using ForAccountRecords.Domain.Models.DatabaseModels;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ForAccountRecords.Application.Helpers
{
    public interface IJwtHelper
    {


        string GenerateToken(User user);
        

    }
}
