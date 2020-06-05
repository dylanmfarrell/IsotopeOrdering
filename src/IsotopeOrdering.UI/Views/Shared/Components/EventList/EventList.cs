using IsotopeOrdering.App.Interfaces;
using IsotopeOrdering.App.Models.Items;
using IsotopeOrdering.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsotopeOrdering.UI.Views.Shared.Components.EventList {
    public class EventList : ViewComponent {
        private readonly IEventManager _eventManager;

        public EventList(IEventManager eventManager) {
            _eventManager = eventManager;
        }

        public async Task<IViewComponentResult> InvokeAsync(EntityEventType eventType, int id) {
            EventListViewModel model = new EventListViewModel();
            model.Events = await _eventManager.GetEvents(eventType, id);
            model.Title = $"{eventType} History";
            return View(model);
        }
    }

    public class EventListViewModel {
        public List<EventItemModel> Events { get; set; } = new List<EventItemModel>();
        public string Title { get; set; } = string.Empty;
        public bool HasEvents => Events.Any();
    }
}
