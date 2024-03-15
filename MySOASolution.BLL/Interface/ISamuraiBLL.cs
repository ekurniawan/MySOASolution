using MySOASolution.BLL.DTOs;

namespace MySOASolution.BLL.Interface
{
    public interface ISamuraiBLL
    {
        Task<IEnumerable<SamuraiDTO>> ReadAsync();
        Task<SamuraiDTO> ReadAsync(int id);
        Task<SamuraiDTO> CreateAsync(SamuraiCreateDTO samuraiCreateDTO);
        Task<SamuraiDTO> UpdateAsync(int id, SamuraiUpdateDTO samuraiUpdateDTO);
        Task<bool> DeleteAsync(int id);
    }
}
