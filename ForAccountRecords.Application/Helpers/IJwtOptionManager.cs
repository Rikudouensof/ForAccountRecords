using ForAccountRecords.Domain.Models.DatabaseModels;
using ForAccountRecords.Domain.Models.GeneralModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ForAccountRecords.Application.Helpers
{
    public interface IJwtOptionManager
    {

        JwtOptions GenerateJwtOptions();
        Claim[] GenerateClaims(User user);
    }
}
