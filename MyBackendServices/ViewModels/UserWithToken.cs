﻿namespace MyBackendServices.ViewModels
{
    public class UserWithToken
    {
        public string? Username { get; set; }
        public string Email { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Address { get; set; }

        public string? Token { get; set; }
    }
}
