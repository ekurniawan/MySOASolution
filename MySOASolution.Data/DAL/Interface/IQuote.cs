using MySOASolution.Domain;

namespace MySOASolution.Data.DAL.Interface
{
    public interface IQuote : ICrud<Quote>
    {
        Task<IEnumerable<Quote>> GetWithSamuraiAsync();
        Task<IEnumerable<Quote>> GetByTextAsync(string text);
        Task<IEnumerable<Quote>> GetBySamuraiNameAsync(string name);
    }
}
