namespace ForAccountRecords.Infrastructure.Helpers
{
  public interface IAsymetricEncryption
  {
    string Decrypt(string cypherText);
    string Encrypt(string plainText);
    string GetPublicKey();
  }
}