using Drivio.Service.Abstractions.ServiceContracts;
using Drivio.Shared.Settings;
using MailKit.Net.Smtp;
using MimeKit;

namespace Drivio.Infrastructure.Services.Services;

public class EmailService : IEmailService
{
    private readonly EmailSettings _emailSettings;

    public EmailService(EmailSettings emailSettings)
    {
        _emailSettings = emailSettings;
    }

    public async Task SendEmail(Message message)
    {
        var mailMessage = CreateEmailMessage(message);
        using var client = new SmtpClient();
        await client.ConnectAsync(_emailSettings.SmtpServer, _emailSettings.Port, true);
        client.AuthenticationMechanisms.Remove("XOAUTH2");
        await client.AuthenticateAsync(_emailSettings.UserName, _emailSettings.Password);
        await client.SendAsync(mailMessage);
        await client.DisconnectAsync(true);
    }
    
    private MimeMessage CreateEmailMessage(Message message)
    {
        var emailMessage = new MimeMessage();
        emailMessage.From.Add(new MailboxAddress(string.Empty, _emailSettings.From));
        emailMessage.To.AddRange(message.To);
        emailMessage.Subject = message.Subject;
        emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = message.Content };
        return emailMessage;
    }
}