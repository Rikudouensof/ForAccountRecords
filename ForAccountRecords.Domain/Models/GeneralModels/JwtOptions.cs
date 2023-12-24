using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForAccountRecords.Domain.Models.GeneralModels
{
    public class JwtOptions
    {

        public string Issuer { get; set; }
        public string Audience { get; set; }

        public string SecretKey { get; set; }

        public int TokenExpiryIntervalInHours { get; set; }
    }
}
