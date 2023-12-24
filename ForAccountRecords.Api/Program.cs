using ForAccountRecords.Api.ApplicationTasks;
using ForAccountRecords.Application.Helpers;
using ForAccountRecords.Application.Services;
using ForAccountRecords.Infrastructure.Data;
using ForAccountRecords.Infrastructure.Helpers;
using ForAccountRecords.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NLog.Extensions.Logging;
using System.Text;

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
            //Get AppSettings
            IConfiguration config = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json")
                            .Build();

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
            builder.Services.AddScoped<IInnerEncryption, InnerEncryption>();
            builder.Services.AddTransient<IJwtOptionManager, JwtOptionManager>();
            builder.Services.AddTransient<IJwtHelper, JwtHelper>();


            //Jwt
            builder.Services.AddAuthentication(authSetting =>
            {
                authSetting.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authSetting.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                authSetting.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(jwtSetting =>
            {
                jwtSetting.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    ValidIssuer = config["JwtSettings:Issuer"],
                    ValidAudience = config["JwtSettings:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JwtSettings:Key"]!)),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true
                };
            });
            builder.Services.AddAuthorization();




            //Build Service
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
