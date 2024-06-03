namespace EventManagerBackend.Models
{
    public class EventModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Place { get; set; }
        public DateTime StartDateTime { get; set; }
        public string EventType { get; set; }
        public byte[] Image { get; set; }
    }
}
