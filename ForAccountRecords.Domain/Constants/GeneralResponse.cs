using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForAccountRecords.Domain.Constants
{
  public static class GeneralResponse
  {
    public const string sucessCode = "00";
    public const string sucessMessage = "sucessfull";
    public const string failureCode = "01";
    public const string failureMessage = "Process failed";
    public const string timeoutCode = "02";
    public const string timeoutMessage = "Service Timedout";
  }
}
