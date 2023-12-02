using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForAccountRecords.Infrastructure.Helpers
{
  public static class ForAccountRecordsConvertions
  {

    public static byte[] stringToyByteArray(string inputString)
    {
      return Encoding.ASCII.GetBytes(inputString);
    }

    public static string byteArrayToString(byte[] inputByte)
    {
      return Encoding.ASCII.GetString(inputByte);
    }

    public static string GetStringDate(DateTime input)
    {
      return input.ToString("dddd dd/MM/yyyy HH:mm");
    }
  }
}
