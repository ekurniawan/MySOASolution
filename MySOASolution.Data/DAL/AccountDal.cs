
using Microsoft.AspNetCore.Identity;
using MySOASolution.Data.DAL.Interface;

namespace MySOASolution.Data.DAL
{
    public class AccountDal : IAccount
    {
        private readonly UserManager<AppIdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SamuraiContext _context;

        public AccountDal(UserManager<AppIdentityUser> userManager,
           RoleManager<IdentityRole> roleManager, SamuraiContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        public async Task<Task> AddRole(string role)
        {
            try
            {
                //add role
                var roleExist = await _roleManager.RoleExistsAsync(role);
                if (!roleExist)
                {
                    var result = await _roleManager.CreateAsync(new IdentityRole(role));
                    if (result.Succeeded)
                    {
                        return Task.CompletedTask;
                    }
                    else
                    {
                        throw new ArgumentException("Role creation failed");
                    }
                }
                else
                {
                    throw new ArgumentException("Role already exists");
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<Task> AddUserToRole(string username, string role)
        {
            try
            {
                //add user to role
                var user = await _userManager.FindByNameAsync(username);
                if (user != null)
                {
                    var roleExist = await _roleManager.RoleExistsAsync(role);
                    if (!roleExist)
                    {
                        throw new ArgumentException("Role not found");
                    }

                    var result = await _userManager.AddToRoleAsync(user, role);
                    if (result.Succeeded)
                    {
                        return Task.CompletedTask;
                    }
                    else
                    {
                        throw new ArgumentException("User role creation failed");
                    }
                }
                else
                {
                    throw new ArgumentException("User not found");
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<IEnumerable<string>> GetRolesFromUser(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user != null)
            {
                //get roles
                var roles = await _userManager.GetRolesAsync(user);
                return roles;
            }
            throw new ArgumentException("User not found");
        }

        public async Task<AppIdentityUser> GetUser(string username)
        {
            //get user
            var user = await _userManager.FindByNameAsync(username);
            if (user != null)
            {
                return user;
            }
            throw new ArgumentException("User not found");
        }

        public async Task<bool> Login(string username, string password)
        {
            //user login
            var user = await _userManager.FindByNameAsync(username);
            if (user != null && await _userManager.CheckPasswordAsync(user, password))
            {
                return true;
            }
            return false;
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
