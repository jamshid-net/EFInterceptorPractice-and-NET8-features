using Application.Common.Interfaces;
using Domain.ModelViews;
using MailKit.Net.Smtp;
using MimeKit;

namespace Infrastructure.Persistence;
public class EmailService : IEmailService
{
    public async Task<bool> SendEmailAsync(EmailMessageDto messageDto, CancellationToken token = default)
    {
        using var emailMessage = new MimeMessage();

        emailMessage.From.Add(new MailboxAddress("", ""));
        emailMessage.To.Add(new MailboxAddress("", messageDto.email));
        emailMessage.Subject = messageDto.subject;
        emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
        {
            Text = messageDto.message
        };

        using (var client = new SmtpClient())
        {
            await client.ConnectAsync("smtp", 25, false);
            await client.AuthenticateAsync("", "password");
            await client.SendAsync(emailMessage);

            await client.DisconnectAsync(true);
        }

        return true;
    }
}
