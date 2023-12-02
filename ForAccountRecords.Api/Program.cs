using ForAccountRecords.Api.ApplicationTasks;
using ForAccountRecords.Application.Helpers;
using ForAccountRecords.Application.Services;
using ForAccountRecords.Infrastructure.Data;
using ForAccountRecords.Infrastructure.Helpers;
using ForAccountRecords.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using NLog.Extensions.Logging;

namespace ForAccountRecords.Api
{
  public class Program
  {
    public static void Main(string[] args)
    {

      NLogProviderOptions nlpopts = new NLogProviderOptions
      {
        IgnoreEmptyEventId = true,
        CaptureMessageTemplates = true,
        CaptureMessageProperties = true,
        ParseMessageTemplates = true,
        IncludeScopes = true,
        ShutdownOnDispose = true
      };


      var builder = WebApplication.CreateBuilder(args);

      // Add services to the container.

      builder.Services.AddControllers();
      // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
      builder.Services.AddEndpointsApiExplorer();
      builder.Services.AddSwaggerGen();


      //Add Database
      var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
      builder.Services.AddDbContext<ApplicationDbContext>(options =>
         options.UseSqlServer(connectionString));

      //AddLogs
      builder.Services.AddSingleton<ILogHelper, LogHelper>();
      builder.Services.AddLogging(
               builder =>
               {
                 builder.AddConsole().SetMinimumLevel(LogLevel.Trace);
                 builder.SetMinimumLevel(LogLevel.Trace);
                 builder.AddNLog(nlpopts);
               });
      builder.Host.ConfigureLogging(logging =>
      {
        logging.ClearProviders();
        logging.AddNLog();
      });

      //Impelement Dependency Injections
      builder.Services.AddScoped<IEmailService, SMTPEmailService>();
      builder.Services.AddScoped<IUserManagementService, UserManagementService>();
      builder.Services.AddScoped<IAppSettingGenerator, AppSettingGenerator>();
      builder.Services.AddScoped<IAsymetricEncryption, AsymetricEncryption>();


      //Build Service
      var app = builder.Build();

      // Configure the HTTP request pipeline.
      if (app.Environment.IsDevelopment())
      {
        app.UseSwagger();
        app.UseSwaggerUI();
      }

      app.UseHttpsRedirection();

      app.UseAuthorization();


      app.MapControllers();

      app.Run();
    }
  }
}
