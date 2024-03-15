using MySOASolution.Domain;

namespace MySOASolution.Data.DAL.Interface
{
    public interface ISamurai : ICrud<Samurai>
    {
        Task<IEnumerable<Samurai>> ReadWithQuotesAsync();
    }
}
