using IsotopeOrdering.Domain.Entities;
using IsotopeOrdering.Domain.Enums;
using IsotopeOrdering.Infrastructure.DataServices;
using System;
using Xunit;

namespace IsotopeOrdering.Infrastructure.IntegrationTests.DataServiceTests {
    public class EventServiceTests {
        [Theory, AutoMoqData]
        public async void Create_Event(EntityEventType type, int id, string eventDescription) {
            string instanceName = Guid.NewGuid().ToString();
            using (var context = TestUtilities.GetDbContext(instanceName)) {
                EventService service = new EventService(context);
                await service.CreateEvent(type, id, eventDescription);
            }
        }

        [Theory, AutoMoqData]
        public async void Get_Event_List(EntityEventType type, int id, string eventDescription) {
            string instanceName = Guid.NewGuid().ToString();
            using (var context = TestUtilities.GetDbContext(instanceName)) {
                context.EntityEvents.Add(new EntityEvent() {
                    EntityId = id,
                    Type = type,
                    Description = eventDescription
                });
                await context.SaveChangesAsync();
            }
            using (var context = TestUtilities.GetDbContext(instanceName)) {
                Assert.NotEmpty(await new EventService(context).GetEvents(id));
            }
        }
    }
}
