using ForAccountRecords.Application.Services;
using ForAccountRecords.Domain.Dtos.ServiceDtos;
using System.Net.Mail;
using System.Net.Mime;


namespace ForAccountRecords.Infrastructure.Services
{
  public class SendGridEmailService : IEmailService
  {
    public async Task SendMailAsync(EmailRequestDto emailInput)
    {
      #region formatter
      string text = string.Format("{0}: {1}", emailInput.EmailData.Subject, emailInput.EmailData.Body);

      #endregion

      MailMessage msg = new MailMessage();
      msg.From = new MailAddress(emailInput.SourceName);
      msg.To.Add(new MailAddress(emailInput.EmailData.RecipeientEmailAddress));
      msg.Subject = emailInput.EmailData.Subject;
      msg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(emailInput.EmailData.Body, null, MediaTypeNames.Text.Html));
      msg.IsBodyHtml = true;
      //  msg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(html, null, MediaTypeNames.Text.Html));

      SmtpClient smtpClient = new SmtpClient("smtp.sendgrid.net", Convert.ToInt32(587));
      System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("apikey", emailInput.AppSettings.SendGridEmailApiKey);
      smtpClient.UseDefaultCredentials = false;
      smtpClient.Credentials = credentials;
      smtpClient.EnableSsl = true;
      smtpClient.Send(msg);
    }
  }
}
