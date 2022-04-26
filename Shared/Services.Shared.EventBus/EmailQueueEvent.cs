namespace Services.Shared.EventBus
{
    public class EmailQueueEvent
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreatedTime { get; set; } = DateTime.UtcNow;
        public Guid EmailId { get; set; }
    }
}