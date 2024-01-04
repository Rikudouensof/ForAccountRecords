using ForAccountRecords.Application.Helpers;
using ForAccountRecords.Application.Services;
using ForAccountRecords.Domain.Dtos.ServiceDtos.EmailDtos.Request;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

using System.Net.Mime;


namespace ForAccountRecords.Infrastructure.Services
{
    public class SMTPEmailService : IEmailService
    {
        private readonly ILogHelper _logger;
        public SMTPEmailService(ILogHelper logger)
        {
            _logger = logger;
        }
        public async Task SendMailAsync(EmailRequestDto input)
        {
            var methodName = $" {nameof(SMTPEmailService)}/{nameof(SendMailAsync)}";
            try
            {



                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("For Account Records",input.AppSettings.SmtpEmailAddress));
                message.To.Add(new MailboxAddress("Recipient",input.EmailData.RecipeientEmailAddress));
                message.Subject = input.EmailData.Subject;
                message.Body = new TextPart("plain") { Text = input.EmailData.Body };

                using (var client = new SmtpClient())
                {
                    client.Connect("foraccountrecords.com", 465, SecureSocketOptions.Auto);
                    client.Authenticate(input.AppSettings.SmtpEmailAddress, input.AppSettings.SmtpPassword);

                    client.Send(message);
                    client.Disconnect(true);
                }
                _logger.LogInformation(input.RequestId, $"Mail to {input.EmailData.RecipeientEmailAddress} was sent successfully", input.Ip, methodName);
            }
            catch (Exception ex)
            {

                _logger.LogError(input.RequestId, $"Mail to {input.EmailData.RecipeientEmailAddress} was not sent successfully", input.Ip, methodName, ex);
            }


        }




    }
}
