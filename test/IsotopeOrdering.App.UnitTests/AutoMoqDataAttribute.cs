using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;

namespace IsotopeOrdering.App.UnitTests {
    public class AutoMoqDataAttribute : AutoDataAttribute {
        public static IFixture FixtureFactory() {
            var f = new Fixture();
            f.Behaviors.Remove(new ThrowingRecursionBehavior());
            f.Behaviors.Add(new OmitOnRecursionBehavior());
            f.Customize(new AutoMoqCustomization { ConfigureMembers = true });
            return f;
        }

        public AutoMoqDataAttribute() : base(FixtureFactory) { }
    }
}
