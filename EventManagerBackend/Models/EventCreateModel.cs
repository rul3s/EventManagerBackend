namespace EventManagerBackend.Models
{
    public class EventCreateModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Place { get; set; }
        public DateTime StartDateTime { get; set; }
        public string EventType { get; set; }
    }
}
