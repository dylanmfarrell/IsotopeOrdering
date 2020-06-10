using IsotopeOrdering.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace IsotopeOrdering.App.Models.Notifications {
    public class NotificationDto {
        private readonly EntityEvent _entityEvent;
        private readonly List<NotificationSubscription> _subscriptions;
        private readonly string _title;

        public NotificationDto(EntityEvent entityEvent, List<NotificationSubscription> subscriptions, string title) {
            _entityEvent = entityEvent;
            _subscriptions = subscriptions;
            _title = title;
        }
        public List<RecipientDto> Recipients { get; private set; } = new List<RecipientDto>();
        public string Subject => _title + " " + _entityEvent.Description;
        public string Body { get; set; } = null!;

        public List<Notification> ToNotifications() {
            List<Notification> notifications = new List<Notification>();
            foreach (RecipientDto recipient in Recipients) {
                notifications.Add(new Notification() {
                    Body = Body,
                    RecipientEmail = recipient.EmailAddress,
                    RecipientName = recipient.Name,
                    Subject = Subject
                });
            }
            return notifications;
        }

        public void AddRecipients(List<RecipientDto> recipientDtos, bool checkSubscription = true) {
            if (!checkSubscription) {
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
