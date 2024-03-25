namespace MySOASolution.Data.DAL.Interface
{
    public interface IAccount
    {
        Task<Task> Register(AppIdentityUser appIdentityUser, string password);
        Task<AppIdentityUser> GetUser(string username);
        Task<Task> AddRole(string role);
        Task<Task> AddUserToRole(string username, string role);

        Task<bool> Login(string username, string password);
    }
}
