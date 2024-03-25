using MySOASolution.BLL.DTOs;
using MySOASolution.BLL.Interface;
using MySOASolution.Data;
using MySOASolution.Data.DAL.Interface;

namespace MySOASolution.BLL
{
    public class AccountBLL : IAccountBLL
    {
        private readonly IAccount _accountDal;
        public AccountBLL(IAccount accountDal)
        {
            _accountDal = accountDal;
        }

        public async Task<Task> AddRole(RoleCreateDTO roleCreateDTO)
        {
            try
            {
                await _accountDal.AddRole(roleCreateDTO.RoleName);
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<AccountDTO> Login(LoginDTO loginDTO)
        {
            var checklogin = await _accountDal.Login(loginDTO.Username, loginDTO.Password);
            if (checklogin)
            {
                var user = await _accountDal.GetUser(loginDTO.Username);
                return new AccountDTO
                {
                    Username = user.UserName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    Firstname = user.Firstname,
                    Lastname = user.Lastname,
                    Address = user.Address
                };
            }
            throw new ArgumentException("Login failed !");
        }

        public async Task<Task> Register(AccountCreateDTO accountCreateDTO)
        {
            try
            {
                var identityUser = new AppIdentityUser
                {
                    UserName = accountCreateDTO.Username,
                    Email = accountCreateDTO.Email,
                    PhoneNumber = accountCreateDTO.PhoneNumber,
                    Firstname = accountCreateDTO.Firstname,
                    Lastname = accountCreateDTO.Lastname,
                    Address = accountCreateDTO.Address
                };
                await _accountDal.Register(identityUser, accountCreateDTO.Password);
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
