using IsotopeOrdering.Domain;
using System.Collections.Generic;
using Xunit;

namespace IsotopeOrdering.App.UnitTests.ManagerTests {
    public class EventManagerTests {
        [Fact]
        public void GetEventList() {
            Dictionary<string, string> events = Events.GetEvents();
            Assert.NotEmpty(events);
        }
    }
}
