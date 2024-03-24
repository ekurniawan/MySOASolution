namespace MySOASolution.Domain
{
    public class Quote
    {
        public int QuoteId { get; set; }
        public string? Text { get; set; }
        public int SamuraiId { get; set; }
        public Samurai? Samurai { get; set; }
    }
}
