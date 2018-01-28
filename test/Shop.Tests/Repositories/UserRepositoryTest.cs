using AutoFixture;
using Shop.Core.Domain;
using Shop.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Shop.Tests.Repositories
{
    public class UserRepositoryTest
    {
        [Fact]
        public void AddingTheUserShouldSucceedd()
        {
            // Arrange
            IUserRepository userRepository = new UserRepository();
            Fixture fixture = new Fixture();
            var user = fixture.Create<User>();

            //Act

            userRepository.Add(user);

            //Assert
            var expectedUser = userRepository.Get(user.Id);
            
            Assert.NotNull(expectedUser);
            Assert.IsType(user.GetType(), expectedUser);            
            Assert.Equal(expectedUser.Id, user.Id);
            Assert.Equal(expectedUser.Email, user.Email);

            var expectedUser2 = userRepository.Get(user.Email);

            Assert.NotNull(expectedUser2);
            Assert.IsType(user.GetType(), expectedUser2);
            Assert.Equal(expectedUser2.Id, user.Id);
            Assert.Equal(expectedUser2.Email, user.Email);

            Assert.IsType(expectedUser.GetType(), expectedUser2);
            Assert.Equal(expectedUser.Email, expectedUser2.Email);
            Assert.Equal(expectedUser.Id, expectedUser2.Id);            
        }
    }
}
