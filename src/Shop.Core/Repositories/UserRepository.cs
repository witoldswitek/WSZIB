using System;
using System.Collections.Generic;
using System.Text;
using Shop.Core.Domain;
using System.Linq;

namespace Shop.Core.Repositories
{
    class UserRepository : IUserRepository
    {
        private static readonly ISet<User> _users = new HashSet<User>()
        {
            new User("user@shop.com", "secret"),
            new User("admin@shop.com", "secret", Role.Admin)            
        };
        public void Add(User user)
            => _users.Add(user);

        public User Get(string email)
            => _users.SingleOrDefault(x => string
                                            .Equals(x.Email, email, StringComparison.InvariantCultureIgnoreCase));
        
    }
}
