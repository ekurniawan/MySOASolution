using Microsoft.AspNetCore.Identity;

namespace MySOASolution.Data
{
    public class AppIdentityUser : IdentityUser
    {
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Address { get; set; }
    }
}
