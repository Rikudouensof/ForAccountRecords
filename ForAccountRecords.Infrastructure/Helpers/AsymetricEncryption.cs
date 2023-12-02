using ForAccountRecords.Domain.Models.GeneralModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static System.Net.Mime.MediaTypeNames;

namespace ForAccountRecords.Infrastructure.Helpers
{
  public class AsymetricEncryption : IAsymetricEncryption
  {
    private static RSACryptoServiceProvider csp = new RSACryptoServiceProvider();
    readonly string _publicKey = "";
    readonly string _privateKey = "";

    public AsymetricEncryption()
    {
      _privateKey = csp.ToXmlString(true);
      _publicKey = csp.ToXmlString(false);
    }

   
    public string Encrypt(string plainText)
    {
      // Convert the text to an array of bytes   
      UnicodeEncoding byteConverter = new UnicodeEncoding();
      byte[] dataToEncrypt = byteConverter.GetBytes(plainText);

      // Create a byte array to store the encrypted data in it   
      byte[] encryptedData;
      using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
      {
        // Set the rsa pulic key   
        rsa.FromXmlString(_publicKey);

        // Encrypt the data and store it in the encyptedData Array   
        encryptedData = rsa.Encrypt(dataToEncrypt, false);
      }
      // Save the encypted data array into a file   
      return ForAccountRecordsConvertions.byteArrayToString(encryptedData);


    }

    public string Decrypt(string input)
    {
      byte[] dataToDecrypt = ForAccountRecordsConvertions.stringToyByteArray(input);
      // Create an array to store the decrypted data in it   
      byte[] decryptedData;
      using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
      {
        // Set the private key of the algorithm   
        rsa.FromXmlString(_privateKey);
        decryptedData = rsa.Decrypt(dataToDecrypt, false);
      }

      // Get the string value from the decryptedData byte array   
      UnicodeEncoding byteConverter = new UnicodeEncoding();
      return byteConverter.GetString(decryptedData);
    }




  }
}
