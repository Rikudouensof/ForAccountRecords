using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForAccountRecords.Domain.Helpers
{
    public class GeneralHelpers
    {

        public static string GetNewRequestId()
        {
            Random rnd = new Random();
            int myRandomNo = rnd.Next(100000000, 999999999);
            var requestId = $"Req{myRandomNo}";
            return requestId;
        }
    }
}
