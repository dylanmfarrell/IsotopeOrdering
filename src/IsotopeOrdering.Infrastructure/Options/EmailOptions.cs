namespace IsotopeOrdering.Infrastructure.Options {
    public class EmailOptions {
        public string SenderEmail { get; set; } = null!;
        public string SenderName { get; set; } = null!;
        public int Port { get; set; }
        public string Host { get; set; } = null!;
        public bool Send { get; set; }
    }
}
