namespace IsotopeOrdering.Infrastructure.Options {
    public class EmailOptions {
        public string Host { get; set; } = null!;
        public int Port { get; set; }
        public bool Send { get; set; }
        public string SenderName { get; set; } = null!;
        public string SenderAddress { get; set; } = null!;
    }
}
