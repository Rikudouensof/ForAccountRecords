using ForAccountRecords.Domain.Models.GeneralModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ForAccountRecords.Domain.Helpers
{
    public static class SymentricEncyption
    {

        public static string EncryptString(string plainText, AppSettings appSettings)
        {
            byte[] encrypted;

            var key = ForAccountRecordsConvertions.stringToyByteArray(appSettings.SymetricEncryptKey + DateTime.Now.ToString("ddMMMyyyyHH"));
            var iv = ForAccountRecordsConvertions.stringToyByteArray(appSettings.SymetricEncryptIV + DateTime.Now.ToString("ddMMMyyyyHH"));


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

        public static string DecryptString(string cipherText, AppSettings appSettings)
        {
            try
            {
                var key = ForAccountRecordsConvertions.stringToyByteArray(appSettings.SymetricEncryptKey + DateTime.Now.ToString("ddMMMyyyyHH"));
                var iv = ForAccountRecordsConvertions.stringToyByteArray(appSettings.SymetricEncryptIV + DateTime.Now.ToString("ddMMMyyyyHH"));

                byte[] cipherBytes = Convert.FromHexString(cipherText);

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
            catch (Exception ex)
            {

                throw;
            }

        }

    }
}
