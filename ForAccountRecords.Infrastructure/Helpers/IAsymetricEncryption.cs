namespace ForAccountRecords.Infrastructure.Helpers
{
  public interface IAsymetricEncryption
  {
    string Decrypt(string dataToDecrypt);
    string Encrypt(string plainText);
    
  }
}