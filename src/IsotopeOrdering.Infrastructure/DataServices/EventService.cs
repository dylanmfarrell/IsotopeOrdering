using AutoMapper;
using IsotopeOrdering.Domain.Entities;
using IsotopeOrdering.Domain.Enums;
using IsotopeOrdering.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsotopeOrdering.Infrastructure.DataServices {
    public class EventService : IEventService {
        private readonly IsotopeOrderingDbContext _context;
        private readonly IMapper _mapper;

        public EventService(IsotopeOrderingDbContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateEvent(EntityEventType type, int id, string eventDescription) {
            _context.EntityEvents.Add(new EntityEvent() {
                EntityId = id,
                Type = type,
                Description = eventDescription
            });
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetEvents<T>(int entityId, EntityEventType type) {
            return await _mapper.ProjectTo<T>(
                _context.EntityEvents.Where(x => x.EntityId == entityId && x.Type == type).OrderBy(x => x.EventDateTime)
            ).ToListAsync();
        }

        public async Task<List<EntityEvent>> GetEvents(string eventDescription, DateTime? startDate) {
            return await _context.EntityEvents
                .Where(x => x.Description == eventDescription && x.EventDateTime > startDate.GetValueOrDefault(DateTime.Now.AddMinutes(-10)))
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
