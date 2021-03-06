﻿using AutoMapper;
using IsotopeOrdering.App.Models.Items;
using IsotopeOrdering.Domain.Entities;
using IsotopeOrdering.Domain.Enums;
using IsotopeOrdering.Infrastructure.DataServices;
using System;
using Xunit;

namespace IsotopeOrdering.Infrastructure.IntegrationTests.DataServiceTests {
    public class EventServiceTests {
        private readonly IMapper _mapper = TestUtilities.GetMapper();

        [Theory, AutoMoqData]
        public async void Create_Event(EntityEventType type, int id, string eventDescription) {
            string instanceName = Guid.NewGuid().ToString();
            using var context = TestUtilities.GetDbContext(instanceName);
            EventService service = new EventService(context, _mapper);
            await service.CreateEvent(type, id, eventDescription);
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
                Assert.NotEmpty(await new EventService(context, _mapper).GetEvents<EventItemModel>(id, type));
            }
        }
    }
}
