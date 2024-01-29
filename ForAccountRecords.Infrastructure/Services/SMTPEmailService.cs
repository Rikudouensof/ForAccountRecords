using ForAccountRecords.Application.Helpers;
using ForAccountRecords.Application.Services;
using ForAccountRecords.Domain.Dtos.InnerDtos.ServiceDtos.EmailDtos.Request;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System.Net.Mime;
using System.Reflection;
using static NLog.LayoutRenderers.Wrappers.ReplaceLayoutRendererWrapper;


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
                var htmlBody = HtmlFromBody(input);
                var bodyBuilder = new BodyBuilder();
                bodyBuilder.HtmlBody = htmlBody;
                bodyBuilder.TextBody = input.EmailData.Body;
                message.Body = bodyBuilder.ToMessageBody();

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
                _logger.LogError(input.RequestId, $"Mail to {input.EmailData.RecipeientEmailAddress} was not sent successfully, {ex.Message}", input.Ip, methodName, ex);
            }


        }


        private string HtmlFromBody(EmailRequestDto input)
        {
            var methodName = $" {nameof(SMTPEmailService)}/{nameof(HtmlFromBody)}";
            try
            {
                //var filePath = Path.Combine(_env.WebRootPath, "");
                FileStream fileStream = new FileStream("Files/EmailTemplate.txt", FileMode.Open);

                using (StreamReader reader = new StreamReader(fileStream))
                {
                    string line = reader.ReadToEnd();
                   var addSubject =  line.Replace("{Title}", input.EmailData.Subject);
                   var addBody =   addSubject.Replace("{Body}", input.EmailData.Body);

                    return addBody;
                }
            }
            catch (Exception ex)
            {
                
                _logger.LogError(input.RequestId, $"Mail to {input.EmailData.RecipeientEmailAddress} was not converted successfully, {ex.Message}", input.Ip, methodName, ex);
                return String.Empty;
            }
           
        }




    }
}
