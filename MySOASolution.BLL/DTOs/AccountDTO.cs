namespace MySOASolution.BLL.DTOs
{
    public class AccountDTO
    {
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Address { get; set; }
    }
}
