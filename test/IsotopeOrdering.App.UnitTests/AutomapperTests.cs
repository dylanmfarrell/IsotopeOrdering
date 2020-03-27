using AutoMapper;
using IsotopeOrdering.App.Mappings;
using Xunit;

namespace IsotopeOrdering.App.UnitTests {
    public class AutomapperTests {
        [Fact]
        public void Test_Configurations_Are_Valid() {
            var config = new MapperConfiguration(c => {
                c.AddMaps(typeof(CustomerProfile).Assembly);
            });
            config.AssertConfigurationIsValid();
        }
    }
}
