using IsotopeOrdering.Domain.Entities;
using IsotopeOrdering.Domain.Interfaces;
using IsotopeOrdering.Infrastructure.Options;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsotopeOrdering.Infrastructure.Services {
    public class EmailService : IEmailService {
        private readonly IOptions<EmailOptions> _emailOptions;

        public EmailService(IOptions<EmailOptions> emailOptions) {
            _emailOptions = emailOptions;
        }

        public async Task<bool> Send(Notification notification) {
            return (await Send(new List<Notification>() { notification })).First().Value;
        }

        public async Task<Dictionary<int, bool>> Send(List<Notification> notifications) { 
            Dictionary<int, bool> results = new Dictionary<int, bool>();
            using SmtpClient client = new SmtpClient { ServerCertificateValidationCallback = (s, c, h, e) => true };
            client.AuthenticationMechanisms.Remove("XOAUTH2");
            await client.ConnectAsync(_emailOptions.Value.Host, _emailOptions.Value.Port, SecureSocketOptions.Auto);
            foreach (Notification notification in notifications) {
                results.Add(notification.Id, await Send(client, notification));
            }
            if (client.IsConnected) {
                await client.DisconnectAsync(true);
            }
            return results;
        }

        private async Task<bool> Send(SmtpClient client, Notification notification) {
            MimeMessage message = GetMimeMessage(notification);
            try {
                if (_emailOptions.Value.Send) {
                    await client.SendAsync(message);
                }
                return true;
            }
            catch {
                return false;
            }
        }

        private MimeMessage GetMimeMessage(Notification notification) {
            MimeMessage mimeMessage = new MimeMessage();
            mimeMessage.From.Add(new MailboxAddress(_emailOptions.Value.SenderName, _emailOptions.Value.SenderAddress));
            mimeMessage.To.Add(new MailboxAddress(notification.RecipientName, notification.RecipientEmail));
            mimeMessage.Subject = notification.Subject;
            BodyBuilder builder = new BodyBuilder {
                HtmlBody = notification.Body
            };
            mimeMessage.Body = builder.ToMessageBody();
            return mimeMessage;
        }
    }
}
