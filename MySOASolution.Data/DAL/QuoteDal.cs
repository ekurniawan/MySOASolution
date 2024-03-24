using Microsoft.EntityFrameworkCore;
using MySOASolution.Data.DAL.Interface;
using MySOASolution.Domain;

namespace MySOASolution.Data.DAL
{
    public class QuoteDal : IQuote
    {
        private readonly SamuraiContext _context;
        public QuoteDal(SamuraiContext context)
        {
            _context = context;
        }

        public async Task<Quote> CreateAsync(Quote entity)
        {
            try
            {
                await _context.Quotes.AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"{ex.Message}");
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var quoteDelete = await ReadAsync(id);
                if (quoteDelete == null)
                {
                    throw new ArgumentException("Quote not found");
                }
                _context.Quotes.Remove(quoteDelete);
                return true;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<IEnumerable<Quote>> GetBySamuraiNameAsync(string name)
        {
            var quotes = await _context.Quotes.Include(s => s.Samurai)
                .Where(q => q.Samurai.Name.Contains(name))
                .OrderBy(q => q.Text).ToListAsync();
            return quotes;
        }

        public async Task<IEnumerable<Quote>> GetByTextAsync(string text)
        {
            var quotes = await _context.Quotes.Include(s => s.Samurai)
                .Where(q => q.Text.Contains(text))
                .OrderBy(q => q.Text).ToListAsync();
            return quotes;
        }

        public async Task<IEnumerable<Quote>> GetWithSamuraiAsync()
        {
            var quotes = await _context.Quotes.Include(q => q.Samurai).OrderBy(q => q.Text).ToListAsync();
            return quotes;
        }

        public async Task<Quote> ReadAsync(int id)
        {
            var quote = await _context.Quotes.Include(q => q.Samurai).FirstOrDefaultAsync(q => q.QuoteId == id);
            if (quote == null)
            {
                throw new ArgumentException("Quote not found");
            }
            return quote;
        }

        public async Task<IEnumerable<Quote>> ReadAsync()
        {
            var quotes = await _context.Quotes.OrderBy(o => o.Text).ToListAsync();
            return quotes;
        }

        public async Task<Quote> UpdateAsync(int id, Quote entity)
        {
            try
            {
                var quote = await ReadAsync(id);
                if (quote == null)
                {
                    throw new ArgumentException("Quote not found");
                }
                quote.Text = entity.Text;
                quote.SamuraiId = entity.SamuraiId;
                await _context.SaveChangesAsync();
                return quote;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
