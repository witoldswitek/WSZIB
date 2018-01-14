using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Core.Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Role  Role { get; set; }
        public User(string email, string password, Role role = Role.User)
        {
            Id = Guid.NewGuid();
            Email = email.ToLowerInvariant();
            Password = password;
            Role = role;
        }
    }
}
