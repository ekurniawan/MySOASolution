namespace MySOASolution.BLL.DTOs
{
    public class SamuraiWithQuotesDTO
    {
        public int SamuraiId { get; set; }
        public string? Name { get; set; }
        public string? Origin { get; set; }

        public IEnumerable<QuoteDTO>? Quotes { get; set; }
    }
}
