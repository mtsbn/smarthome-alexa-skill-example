namespace LazyBedroom.Models
{
    public class Header
    {
        public string Namespace { get; set; }
        public string Name { get; set; }
        public string MessageId { get; set; }
        public string PayloadVersion { get; set; }
        public string CorrelationToken { get; set; }

    }
}
