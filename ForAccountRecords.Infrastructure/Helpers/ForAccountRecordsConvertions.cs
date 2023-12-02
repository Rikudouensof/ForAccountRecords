using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForAccountRecords.Infrastructure.Helpers
{
  public class ForAccountRecordsConvertions
  {

    public byte[] stringTOByteArray(string inputString)
    {
      return Encoding.ASCII.GetBytes(inputString);
    }

    public string GetStringDate(DateTime input)
    {
      return input.ToString("dddd dd/MM/yyyy HH:mm");
    }
  }
}
