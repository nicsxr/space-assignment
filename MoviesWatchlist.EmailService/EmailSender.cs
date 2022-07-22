using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace MoviesWatchlist.EmailService;

public class EmailSender : IEmailSender
{
    private readonly EmailConfiguration _emailConfig;
    
    public EmailSender(EmailConfiguration emailConfig)
    {
        _emailConfig = emailConfig;
    }
    
    public async Task SendEmail(string body, string receiver) // default email
    {
        var email = new MimeMessage();

        email.From.Add(MailboxAddress.Parse(_emailConfig.Username));
        email.To.Add(MailboxAddress.Parse(receiver));
        email.Subject = "Unwatched movie reminder";
        email.Body = new BodyBuilder { HtmlBody = body }.ToMessageBody();

        using var smtp = new SmtpClient();
        await smtp.ConnectAsync(_emailConfig.SmtpServer, _emailConfig.Port, SecureSocketOptions.StartTls);
        await smtp.AuthenticateAsync(_emailConfig.Username, _emailConfig.Password);
        await smtp.SendAsync(email);
        await smtp.DisconnectAsync(true);
    }
}