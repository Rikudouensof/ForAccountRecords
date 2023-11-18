using ForAccountRecords.Domain.Models.GeneralModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ForAccountRecords.Infrastructure.Helpers
{
  public class AsymetricEncryption : IAsymetricEncryption
  {
    private static RSACryptoServiceProvider csp = new();
    private RSAParameters _privateKey;
    private RSAParameters _publicKey;

    public AsymetricEncryption()
    {
      _privateKey = csp.ExportParameters(true);
      _publicKey = csp.ExportParameters(false);
    }

    public string GetPublicKey()
    {
      var sw = new StringWriter();
      var xs = new XmlSerializer(typeof(RSAParameters));
      xs.Serialize(sw, _publicKey);
      return sw.ToString();
    }

    public string Encrypt(string plainText)
    {
      csp = new RSACryptoServiceProvider();
      csp.ImportParameters(_publicKey);
      var data = Encoding.Unicode.GetBytes(plainText);
      var cyper = csp.Encrypt(data, false);
      return Convert.ToHexString(cyper);
    }

    public string Decrypt(string cypherText)
    {
      var databytes = Convert.FromHexString(cypherText);
      csp.ImportParameters(_privateKey);
      var plainText = csp.Decrypt(databytes, false);
      return Encoding.Unicode.GetString(plainText);
    }




  }
}
