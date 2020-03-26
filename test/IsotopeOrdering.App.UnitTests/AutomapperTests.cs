using AutoMapper;
using IsotopeOrdering.App.Mappings;
using Xunit;

namespace IsotopeOrdering.App.UnitTests {
    public class AutomapperTests {
        [Fact]
        public void Test_Configurations_Are_Valid() {
            var config = new MapperConfiguration(c => {
                c.AddProfiles(new Profile[] {
                    new CustomerProfile(),
                    new FormProfile(),
                    new ItemProfile(),
                    new OrderProfile(),
                    new ShipmentProfile()
                });
            });
            config.AssertConfigurationIsValid();
        }
    }
}
