using ForAccountRecords.Application.Services;
using ForAccountRecords.Domain.Dtos.ServiceDtos;
using System.Net.Mail;
using System.Net.Mime;


namespace ForAccountRecords.Infrastructure.Services
{
  public class SMTPEmailService : IEmailService
  {
    public async Task SendMailAsync(EmailRequestDto message)
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
      SmtpClient smtpClient = new SmtpClient("Kigoo.properties", Convert.ToInt32(587));
      System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(message.AppSettings.SmtpEmailAddress, message.AppSettings.SmtpPassword);
      smtpClient.UseDefaultCredentials = false;
      smtpClient.Credentials = credentials;
      smtpClient.EnableSsl = false;
      smtpClient.Send(msg);
    }
  }
}
