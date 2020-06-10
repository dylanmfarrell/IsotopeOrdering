using IsotopeOrdering.Domain.Entities;
using IsotopeOrdering.Domain.Interfaces;
using IsotopeOrdering.Infrastructure.Options;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IsotopeOrdering.Infrastructure.Services {
    public class EmailService : IEmailService {
        private readonly EmailOptions _options;
        private readonly SmtpClient _smtpClient;

        public EmailService(EmailOptions options) {
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
                if (_options.Send) {
                    await _smtpClient.SendAsync(mimeMessage);
                }
                return true;
            }
            catch (Exception ex) {
                //_logger.LogError(ex, "Error processing notification");
            }
            return false;
        }

        public async Task Connect() {
            await _smtpClient.ConnectAsync(_options.Host, _options.Port, SecureSocketOptions.Auto);
            _smtpClient.AuthenticationMechanisms.Remove("XOAUTH2");
        }

        public async ValueTask DisposeAsync() {
            if (_smtpClient.IsConnected) {
                await _smtpClient.DisconnectAsync(true);
            }
        }

        private MimeMessage GetMimeMessage(Notification notification) {
            MimeMessage mimeMessage = new MimeMessage();
            mimeMessage.From.Add(new MailboxAddress(_options.SenderName, _options.SenderEmail));
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
