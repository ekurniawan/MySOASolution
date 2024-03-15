using AutoMapper;
using MySOASolution.BLL.DTOs;
using MySOASolution.BLL.Interface;
using MySOASolution.Data.DAL.Interface;

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

        public Task<SamuraiDTO> CreateAsync(SamuraiCreateDTO samuraiCreateDTO)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<SamuraiDTO>> ReadAsync()
        {
            var samurais = await _samurai.ReadAsync();
            return _mapper.Map<IEnumerable<SamuraiDTO>>(samurais);
        }

        public Task<SamuraiDTO> ReadAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<SamuraiDTO> UpdateAsync(int id, SamuraiUpdateDTO samuraiUpdateDTO)
        {
            throw new NotImplementedException();
        }
    }
}
