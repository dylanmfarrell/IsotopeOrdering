using IsotopeOrdering.Domain.Entities;
using IsotopeOrdering.Domain.Interfaces;
using IsotopeOrdering.Infrastructure.Options;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IsotopeOrdering.Infrastructure.Services {
    public class EmailService : IEmailService {
        private readonly IOptions<EmailOptions> _options;
        private readonly SmtpClient _smtpClient;

        public EmailService(IOptions<EmailOptions> options) {
            _options = options;
            _smtpClient = new SmtpClient {
                ServerCertificateValidationCallback = (s, c, h, e) => true
            };
        }

        public Task<Dictionary<int, bool>> SendNotifications(List<Notification> notifications) {
            throw new NotImplementedException();
        }

        public async Task<bool> SendNotification(Notification notification) {
            try {
                MimeMessage mimeMessage = GetMimeMessage(notification);
                if (_options.Value.Send) {
                    await _smtpClient.SendAsync(mimeMessage);
                }
                return true;
            }
            catch {
            }
            return false;
        }

        public async Task Connect() {
            await _smtpClient.ConnectAsync(_options.Value.Host, _options.Value.Port, SecureSocketOptions.Auto);
            _smtpClient.AuthenticationMechanisms.Remove("XOAUTH2");
        }

        public async ValueTask DisposeAsync() {
            if (_smtpClient.IsConnected) {
                await _smtpClient.DisconnectAsync(true);
            }
        }

        private MimeMessage GetMimeMessage(Notification notification) {
            MimeMessage mimeMessage = new MimeMessage();
            mimeMessage.From.Add(new MailboxAddress(_options.Value.SenderName, _options.Value.SenderEmail));
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
