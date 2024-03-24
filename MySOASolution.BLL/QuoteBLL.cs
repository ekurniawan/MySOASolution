using AutoMapper;
using MySOASolution.BLL.DTOs;
using MySOASolution.BLL.Interface;
using MySOASolution.Data.DAL.Interface;
using MySOASolution.Domain;

namespace MySOASolution.BLL
{
    public class QuoteBLL : IQuoteBLL
    {
        private readonly IQuote _quoteDal;
        private readonly IMapper _mapper;

        public QuoteBLL(IQuote quoteDal, IMapper mapper)
        {
            _quoteDal = quoteDal;
            _mapper = mapper;
        }

        public async Task<IEnumerable<QuoteDTO>> ReadAsync()
        {
            var quotes = await _quoteDal.GetWithSamuraiAsync();
            var quotesDto = _mapper.Map<IEnumerable<QuoteDTO>>(quotes);
            return quotesDto;
        }

        public async Task<QuoteDTO> ReadAsync(int id)
        {
            var quote = await _quoteDal.ReadAsync(id);
            var quoteDto = _mapper.Map<QuoteDTO>(quote);
            return quoteDto;
        }

        public async Task<QuoteDTO> CreateAsync(QuoteCreateDTO quoteCreateDTO)
        {
            try
            {
                var quote = _mapper.Map<Quote>(quoteCreateDTO);
                var quoteResult = await _quoteDal.CreateAsync(quote);
                var quoteDto = _mapper.Map<QuoteDTO>(quoteResult);
                return quoteDto;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<QuoteDTO> UpdateAsync(int id, QuoteUpdateDTO quoteUpdateDTO)
        {
            try
            {
                var quote = _mapper.Map<Quote>(quoteUpdateDTO);
                var quoteResult = await _quoteDal.UpdateAsync(id, quote);
                var quoteDto = _mapper.Map<QuoteDTO>(quoteResult);
                return quoteDto;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                return await _quoteDal.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<IEnumerable<QuoteDTO>> GetWithSamuraiAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<QuoteDTO>> GetByTextAsync(string text)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<QuoteDTO>> GetBySamuraiNameAsync(string name)
        {
            throw new NotImplementedException();
        }
    }
}
