using WebAPI.Helper;
using Microsoft.Extensions.Options;
using MimeKit;
using MailKit;
using MailKit.Net.Smtp;
using MailKit.Security;
using System.IO;
using System.Threading.Tasks;
using WebAPI.Service;

namespace firstapi.Service
{
  public class EmailService : IEmailService
  {
    private readonly EmailSettings emailSettings;
    public EmailService(IOptions<EmailSettings> options)
    {
      this.emailSettings = options.Value;
    }
    public async Task SendEmailAsync(Mailrequest mailrequest)
    {
      var email = new MimeMessage();
      email.Sender = MailboxAddress.Parse(emailSettings.Email);
      email.To.Add(MailboxAddress.Parse(mailrequest.ToEmail));
      email.Subject = mailrequest.Subject;
      var builder = new BodyBuilder();




      builder.HtmlBody = mailrequest.Body;
      email.Body = builder.ToMessageBody();

      using var smtp = new SmtpClient();
      smtp.Connect(emailSettings.Host, emailSettings.Port, SecureSocketOptions.StartTls);
      smtp.Authenticate(emailSettings.Email, emailSettings.Password);
      await smtp.SendAsync(email);
      smtp.Disconnect(true);
    }
  }
}
