using ForAccountRecords.Domain.Models.GeneralModels;

namespace ForAccountRecords.Infrastructure.Helpers
{
    public interface IInnerEncryption
    {
        string Decrypt(string dataToDecrypt, AppSettings appSettings);
        string Encrypt(string plainText, AppSettings appSettings);

        string PasswordEncrypt(string plainPassword, string saltString);

    }
}