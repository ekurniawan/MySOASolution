using MySOASolution.Domain;

namespace MySOASolution.Data.DAL.Interface
{
    public interface ISamurai : ICrud<Samurai>
    {
        Task<IEnumerable<Samurai>> ReadWithQuotesAsync();
        Task<Samurai> InsertSamuraiWithQoutes(Samurai samurai, List<Quote> quotes);
    }
}
