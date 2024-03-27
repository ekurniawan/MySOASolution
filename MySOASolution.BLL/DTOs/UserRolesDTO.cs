namespace MySOASolution.BLL.DTOs
{
    public class UserRolesDTO
    {
        public string Username { get; set; } = null!;
        public List<string> Roles { get; set; } = null!;
    }
}