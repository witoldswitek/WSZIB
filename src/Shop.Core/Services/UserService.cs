using System;
using System.Collections.Generic;
using System.Text;
using Shop.Core.DTO;
using Shop.Core.Repositories;
using Shop.Core.Domain;

namespace Shop.Core.Services
{
    class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public void Login(string email, string password)
        {
            var user = _userRepository.Get(email);
            if (user == null)
            {
                throw new Exception($"User {user.Email} not found!");
            }
            if (user.Password != password)
            {
                throw new Exception($"Wrong password!!!");
            }
        }

        public void Register(string email, string password, RoleDto role)
        {
            var user = _userRepository.Get(email);
            if (user != null)
            {
                throw new Exception($"User {user.Email} already exist.");
            }
            var userRole = (Role) Enum.Parse(typeof(Role), role.ToString(), true);
            user = new User(email, password, userRole);
            _userRepository.Add(user);
        }
    }
}
