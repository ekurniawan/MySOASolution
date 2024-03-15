using AutoMapper;
using MySOASolution.BLL.DTOs;
using MySOASolution.BLL.Interface;
using MySOASolution.Data.DAL.Interface;
using MySOASolution.Domain;

namespace MySOASolution.BLL
{
    public class SamuraiBLL : ISamuraiBLL
    {
        private readonly ISamurai _samurai;
        private readonly IMapper _mapper;

        public SamuraiBLL(ISamurai samurai, IMapper mapper)
        {
            _samurai = samurai;
            _mapper = mapper;
        }

        public async Task<SamuraiDTO> CreateAsync(SamuraiCreateDTO samuraiCreateDTO)
        {
            try
            {
                var samurai = _mapper.Map<Samurai>(samuraiCreateDTO);
                var createdSamurai = await _samurai.CreateAsync(samurai);
                return _mapper.Map<SamuraiDTO>(createdSamurai);
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
                var samurai = _samurai.ReadAsync(id);
                if (samurai == null)
                {
                    throw new ArgumentException("Samurai not found");
                }
                return await _samurai.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<IEnumerable<SamuraiDTO>> ReadAsync()
        {
            var samurais = await _samurai.ReadAsync();
            return _mapper.Map<IEnumerable<SamuraiDTO>>(samurais);
        }

        public async Task<SamuraiDTO> ReadAsync(int id)
        {
            var samurai = await _samurai.ReadAsync(id);
            return _mapper.Map<SamuraiDTO>(samurai);
        }

        public async Task<IEnumerable<SamuraiDTO>> ReadWithQuotesAsync()
        {
            var samurais = await _samurai.ReadWithQuotesAsync();
            return _mapper.Map<IEnumerable<SamuraiDTO>>(samurais);
        }

        public async Task<SamuraiDTO> UpdateAsync(int id, SamuraiUpdateDTO samuraiUpdateDTO)
        {
            try
            {
                var samurai = _samurai.ReadAsync(id);
                if (samurai == null)
                {
                    throw new ArgumentException("Samurai not found");
                }
                var updateSamurai = _mapper.Map<Samurai>(samuraiUpdateDTO);
                var updatedSamurai = await _samurai.UpdateAsync(updateSamurai);
                return _mapper.Map<SamuraiDTO>(updatedSamurai);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
