using ForAccountRecords.Application.Services;
using ForAccountRecords.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForAccountRecords.Infrastructure.Dependencies
{
  public static class ForAccountRecordsCoreDependencies
  {

    public static IServiceCollection ImplementForAccountRecordsCoreDependencies(this IServiceCollection services)
    {

      //API
      //services.AddSingleton<IAccountInquiryAPIService, AccountInquiryAPIService>();
      

      //Services
      services.AddScoped<IEmailService, SMTPEmailService>();

      return services;
    }
  }
}
