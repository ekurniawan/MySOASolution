using Microsoft.EntityFrameworkCore;
using MySOASolution.Data.DAL.Interface;
using MySOASolution.Domain;

namespace MySOASolution.Data.DAL
{
    public class SamuraiDal : ISamurai
    {
        private readonly SamuraiContext _context;
        public SamuraiDal(SamuraiContext context)
        {
            _context = context;
        }

        public async Task<Samurai> CreateAsync(Samurai entity)
        {
            try
            {
                await _context.Samurais.AddAsync(entity);
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
                var samurai = await ReadAsync(id);
                _context.Samurais.Remove(samurai);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"{ex.Message}");
            }
        }

        public Task<Samurai> InsertSamuraiWithQoutes(Samurai samurai, List<Quote> quotes)
        {
            throw new NotImplementedException();
        }

        public async Task<Samurai> ReadAsync(int id)
        {
            var samurai = await _context.Samurais.FirstOrDefaultAsync(s => s.SamuraiId == id);
            if (samurai == null)
            {
                throw new ArgumentException("Samurai not found");
            }

            return samurai;
        }

        public async Task<IEnumerable<Samurai>> ReadAsync()
        {
            var samurais = await _context.Samurais.ToListAsync();
            return samurais;
        }

        public async Task<IEnumerable<Samurai>> ReadWithQuotesAsync()
        {
            var samurais = await _context.Samurais.Include(s => s.Quotes).ToListAsync();
            return samurais;
        }

        public async Task<Samurai> UpdateAsync(int id, Samurai entity)
        {
            try
            {
                var samurai = await _context.Samurais.FirstOrDefaultAsync(s => s.SamuraiId == id);
                if (samurai == null)
                {
                    throw new ArgumentException("Samurai not found");
                }
                samurai.Name = entity.Name;
                samurai.Origin = entity.Origin;
                await _context.SaveChangesAsync();
                return samurai;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
