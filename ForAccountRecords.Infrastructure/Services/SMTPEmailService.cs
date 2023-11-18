using ForAccountRecords.Application.Helpers;
using ForAccountRecords.Application.Services;
using ForAccountRecords.Domain.Dtos.ServiceDtos.EmailDtos.Request;
using System.Net.Mail;
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
    public async Task SendMailAsync(EmailRequestDto message)
    {
      var methodName = $" {nameof(SMTPEmailService)}/{nameof(SendMailAsync)}";
      try
      {
        #region formatter
        string text = string.Format("{0}: {1}", message.EmailData.Subject, message.EmailData.Body);

        #endregion

        MailMessage msg = new MailMessage();
        msg.From = new MailAddress(message.AppSettings.SmtpEmailAddress);
        msg.To.Add(new MailAddress(message.EmailData.RecipeientEmailAddress));
        msg.Subject = message.EmailData.Subject;
        msg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(message.EmailData.Body, null, MediaTypeNames.Text.Html));
        msg.IsBodyHtml = true;
        SmtpClient smtpClient = new SmtpClient(message.AppSettings.SmtpEmailAddress, Convert.ToInt32(587));
        System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(message.AppSettings.SmtpEmailAddress, message.AppSettings.SmtpPassword);
        smtpClient.UseDefaultCredentials = false;
        smtpClient.Credentials = credentials;
        smtpClient.EnableSsl = false;
        smtpClient.Send(msg);
        _logger.LogInformation(message.RequestId, $"Mail to {message.EmailData.RecipeientEmailAddress} was sent successfully", message.Ip, methodName);
      }
      catch (Exception ex)
      {

        _logger.LogError(message.RequestId, $"Mail to {message.EmailData.RecipeientEmailAddress} was not sent successfully", message.Ip, methodName, ex);
      }


    }
  }
}
