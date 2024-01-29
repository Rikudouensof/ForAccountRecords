using ForAccountRecords.Application.Helpers;
using ForAccountRecords.Application.Services;
using ForAccountRecords.Domain.Dtos.InnerDtos.ServiceDtos.EmailDtos.Request;
using System.Net.Mail;
using System.Net.Mime;


namespace ForAccountRecords.Infrastructure.Services
{
    public class SendGridEmailService : IEmailService
  {
    private readonly ILogHelper _logger;
    public SendGridEmailService(ILogHelper logger)
    {
      _logger = logger;
    }


    public async Task SendMailAsync(EmailRequestDto emailInput)
    {
      var methodName = $" {nameof(SendGridEmailService)}/{ nameof(SendMailAsync)}";
      try
      {
       

        MailMessage msg = new MailMessage();
        msg.From = new MailAddress(emailInput.SourceName);
        msg.To.Add(new MailAddress(emailInput.EmailData.RecipeientEmailAddress));
        msg.Subject = emailInput.EmailData.Subject;
        msg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(emailInput.EmailData.Body, null, MediaTypeNames.Text.Html));
        msg.IsBodyHtml = true;
        

        SmtpClient smtpClient = new SmtpClient("smtp.sendgrid.net", Convert.ToInt32(587));
        System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("apikey", emailInput.AppSettings.SendGridEmailApiKey);
        smtpClient.UseDefaultCredentials = false;
        smtpClient.Credentials = credentials;
        smtpClient.EnableSsl = true;
        smtpClient.Send(msg);
        _logger.LogInformation(emailInput.RequestId, $"Mail to {emailInput.EmailData.RecipeientEmailAddress} was sent successfully", emailInput.Ip, methodName);
      }
      catch (Exception ex)
      {

        _logger.LogError(emailInput.RequestId, $"Mail to {emailInput.EmailData.RecipeientEmailAddress} was not sent successfully", emailInput.Ip, methodName,ex);
      }
     
    }
  }
}
