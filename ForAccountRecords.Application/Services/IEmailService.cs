using ForAccountRecords.Domain.Dtos.ServiceDtos.EmailDtos.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForAccountRecords.Application.Services
{
    public interface IEmailService
  {

    Task SendMailAsync(EmailRequestDto message);
  }
}
