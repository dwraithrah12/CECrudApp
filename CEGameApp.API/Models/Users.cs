using System;

namespace CEGameApp.API.Models
{
    public class Users
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public int AccessLevel { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        public string AvatarUrl { get; set; }

        public DateTime Created { get; set; }

        public DateTime LastActive { get; set; }

        public DateTime DateOfBirth { get; set; }

    }
}