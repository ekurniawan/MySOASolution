namespace MySOASolution.Domain
{
    public class Samurai
    {
        public int SamuraiId { get; set; }
        public string? Name { get; set; }
        public IEnumerable<Quote>? Quotes { get; set; }
    }
}
