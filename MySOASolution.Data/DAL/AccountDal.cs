
using Microsoft.AspNetCore.Identity;
using MySOASolution.Data.DAL.Interface;

namespace MySOASolution.Data.DAL
{
    public class AccountDal : IAccount
    {
        private readonly UserManager<AppIdentityUser> _userManager;
        private readonly SamuraiContext _context;

        public AccountDal(UserManager<AppIdentityUser> userManager, SamuraiContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public Task<Task> AddRole(string role)
        {
            throw new NotImplementedException();
        }

        public Task<Task> AddUserToRole(string username, string role)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<Task> Register(AppIdentityUser appIdentityUser, string password)
        {
            try
            {
                //create user
                var result = await _userManager.CreateAsync(appIdentityUser, password);
                if (result.Succeeded)
                {
                    return Task.CompletedTask;
                }
                else
                {
                    throw new ArgumentException("User creation failed");
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
