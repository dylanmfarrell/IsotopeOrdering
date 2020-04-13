namespace IsotopeOrdering.Infrastructure.Options {
    public class OpenIdOptions {
        public string CookieName { get; set; } = null!;
        public string Authority { get; set; } = null!;
        public string ClientId { get; set; } = null!;
        public string ClientSecret { get; set; } = null!;
    }
}
