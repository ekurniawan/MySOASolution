using MySOASolution.BLL.DTOs;

namespace MySOASolution.BLL.Interface
{
    public interface IQuoteBLL
    {
        Task<IEnumerable<QuoteDTO>> ReadAsync();
        Task<QuoteDTO> ReadAsync(int id);
        Task<QuoteDTO> CreateAsync(QuoteCreateDTO quoteCreateDTO);
        Task<QuoteDTO> UpdateAsync(int id, QuoteUpdateDTO quoteUpdateDTO);
        Task<bool> DeleteAsync(int id);

        Task<IEnumerable<QuoteDTO>> GetWithSamuraiAsync();
        Task<IEnumerable<QuoteDTO>> GetByTextAsync(string text);
        Task<IEnumerable<QuoteDTO>> GetBySamuraiNameAsync(string name);
    }
}
