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
    public class InnerEncryption : IInnerEncryption
    {

        public string Encrypt(string plainText, AppSettings appSettings)
        {
            byte[] encrypted;

            var key = ForAccountRecordsConvertions.stringToyByteArray(appSettings.InnerSymetricEncryptKey);
            var iv = ForAccountRecordsConvertions.stringToyByteArray(appSettings.InnerSymetricEncryptIV);


            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (var ms = new System.IO.MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        using (var sw = new System.IO.StreamWriter(cs))
                        {
                            sw.Write(plainText);
                        }

                        encrypted = ms.ToArray();
                    }
                }
            }

            return Convert.ToHexString(encrypted);
        }

        public string Decrypt(string dataToDecrypt, AppSettings appSettings)
        {

            var key = ForAccountRecordsConvertions.stringToyByteArray(appSettings.InnerSymetricEncryptKey);
            var iv = ForAccountRecordsConvertions.stringToyByteArray(appSettings.InnerSymetricEncryptIV);

            byte[] cipherBytes = Convert.FromHexString(dataToDecrypt);

            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;

                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (var ms = new System.IO.MemoryStream(cipherBytes))
                {
                    using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    {
                        using (var sr = new System.IO.StreamReader(cs))
                        {
                            return sr.ReadToEnd();
                        }
                    }
                }
            }
        }

        public string PasswordEncrypt(string plainPassword, string saltString)
        {
            byte[] salt = ForAccountRecordsConvertions.stringToyByteArray(saltString);
            new RNGCryptoServiceProvider().GetBytes(salt);
            var pbkdf2 = new Rfc2898DeriveBytes(plainPassword, salt);
            byte[] hash = pbkdf2.GetBytes(20);
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);
            return Convert.ToBase64String(hashBytes);
        }
    }
}
