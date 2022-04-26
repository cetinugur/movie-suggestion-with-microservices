namespace Services.Email.Model
{
    public class MovieSuggestion
    {
        public int Id { get; set; }
        public DateTime RequestDate { get; set; }
        public int RequestUserId { get; set; }
        public EmailStatus EmailStatus { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        public string Receiver { get; set; }
        public string HtmlContent { get; set; }

    }
}
