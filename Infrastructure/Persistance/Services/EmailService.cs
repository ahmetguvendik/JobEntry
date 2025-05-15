using JobEntry.Application.Services;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace JobEntry.Persistance.Services;

public class EmailService  : IEmailService
{
    
    public async Task SendApplyAppEmailAsync(string emailAdress, string body)
    {
        var email = new MimeMessage();
        email.From.Add(MailboxAddress.Parse("ahmetguvendik011348@gmail.com"));
        email.To.Add(MailboxAddress.Parse(emailAdress));
        email.Subject = "JobEntry Basvurusu";
        email.Body = new TextPart(TextFormat.Plain) { Text = body };
        using var smtp = new SmtpClient();
        smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
        smtp.Authenticate("ahmetguvendik011348@gmail.com", "luru ibvj teip ocfw");
        smtp.Send(email);
        smtp.Disconnect(true);
    }

    public async Task SendSeenAppEmailAsync(string emailAdress, string body)
    {
        var email = new MimeMessage();
        email.From.Add(MailboxAddress.Parse("ahmetguvendik011348@gmail.com"));
        email.To.Add(MailboxAddress.Parse(emailAdress));
        email.Subject = "JobEntry Basvurusu";
        email.Body = new TextPart(TextFormat.Plain) { Text = body };
        using var smtp = new SmtpClient();
        smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
        smtp.Authenticate("ahmetguvendik011348@gmail.com", "luru ibvj teip ocfw");
        smtp.Send(email);
        smtp.Disconnect(true);
    }
}