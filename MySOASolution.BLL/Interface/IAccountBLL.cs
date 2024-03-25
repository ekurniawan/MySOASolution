using MySOASolution.BLL.DTOs;

namespace MySOASolution.BLL.Interface
{
    public interface IAccountBLL
    {
        Task<Task> Register(AccountCreateDTO accountCreateDTO);
        Task<AccountDTO> Login(LoginDTO loginDTO);
    }
}
