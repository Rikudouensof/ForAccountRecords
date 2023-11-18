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
      return new AppSettings()
      {

      };
    }

  }
}
