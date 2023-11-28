using ForAccountRecords.Domain.Models.GeneralModels;

namespace ForAccountRecords.Api.ApplicationTasks
{
  public interface IAppSettingGenerator
  {
    AppSettings Generate();
  }

  public class AppSettingGenerator : IAppSettingGenerator
  {
    private readonly IConfiguration _config;
    public AppSettingGenerator(IConfiguration configuration)
    {
      _config = configuration;
    }


    public AppSettings Generate()
    {
      var appressings = new AppSettings()
      {
        //Encryption
        AsymetricEncryptPrivateKey = _config["Encryptions:AsymmentricKeys:PrivateKey"],
        AsymetricEncryptPublicKey = _config["Encryptions:AsymmentricKeys:PublicKey"],
        SymetricEncryptIV = _config["Encryptions:SymetricKeys:EncryptIV"],
        SymetricEncryptKey = _config["Encryptions:SymetricKeys:EncryptKey"],

        //Email
        SendGridEmailApiKey = _config["Email:SendGrid:APIKey"],
        SendGridSourceName = _config["Email:SendGrid:APIKey"],
        SmtpEmailAddress = _config["Email:SMTP:EmailAddress"],
        SmtpPassword = _config["Email:SMTP:Password"],

      };

      return appressings; 
    }

  }
}
