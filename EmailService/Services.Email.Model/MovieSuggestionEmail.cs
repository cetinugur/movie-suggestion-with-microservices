namespace Services.Email.Model
{
    public class MovieSuggestionEmail
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime RequestDate { get; set; }
        public int RequestUserId { get; set; }
        public EmailStatus EmailStatus { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;

    }
}
