using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;
using IsotopeOrdering.Domain.Entities;

namespace IsotopeOrdering.Infrastructure.IntegrationTests {
    public class AutoMoqDataAttribute : AutoDataAttribute {
        public static IFixture FixtureFactory() {
            var f = new Fixture();
            f.Behaviors.Remove(new ThrowingRecursionBehavior());
            f.Behaviors.Add(new OmitOnRecursionBehavior());
            f.Customize<Customer>(x => x.Without(x => x.ParentCustomer));
            f.Customize(new AutoMoqCustomization { ConfigureMembers = true });
            return f;
        }
         
        public AutoMoqDataAttribute() : base(FixtureFactory) { }
    }
}
