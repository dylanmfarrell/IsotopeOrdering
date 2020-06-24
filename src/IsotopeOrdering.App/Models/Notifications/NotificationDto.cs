using IsotopeOrdering.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace IsotopeOrdering.App.Models.Notifications {
    public class NotificationDto {
        private readonly List<NotificationSubscription> _subscriptions = new List<NotificationSubscription>();
        private readonly string _title;

        public NotificationDto(List<NotificationSubscription> subscriptions, string title) {
            _subscriptions = subscriptions;
            _title = title;
        }

        public NotificationDto(string title) {
            _title = title;
        }

        public List<RecipientDto> Recipients { get; private set; } = new List<RecipientDto>();
        public string Body { get; set; } = null!;

        public List<Notification> ToNotifications() {
            List<Notification> notifications = new List<Notification>();
            foreach (RecipientDto recipient in Recipients) {
                notifications.Add(new Notification() {
                    Body = Body,
                    RecipientEmail = recipient.EmailAddress,
                    RecipientName = recipient.Name,
                    Subject = _title
                });
            }
            return notifications;
        }

        public void AddRecipient(RecipientDto recipientDto) {
            AddRecipients(new List<RecipientDto>() { recipientDto });
        }

        public void AddRecipients(List<RecipientDto> recipientDtos) {
            if (!_subscriptions.Any()) {
                Recipients.AddRange(recipientDtos);
                return;
            }
            foreach (RecipientDto recipient in recipientDtos) {
                if (_subscriptions.Any(x => x.Customer.Contact.Email == recipient.EmailAddress)) {
                    Recipients.Add(recipient);
                }
            }
        }
    }
}
