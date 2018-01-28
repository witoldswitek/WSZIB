using AutoFixture;
using AutoMapper;
using Moq;
using Shop.Core.Domain;
using Shop.Core.DTO;
using Shop.Core.Repositories;
using Shop.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Shop.Tests.Services
{
    public class UserServiceTest
    {
        [Fact]
        public void GetShouldReturnUser()
        {

            //Arrange
            var userRepositoryMock = new Mock<IUserRepository>();
            var mapperMock = new Mock<IMapper>();

            var fixture = new Fixture();
            var user = fixture.Create<User>();
            var userDto = fixture.Create<UserDto>();

            //var email = "test@test.com";
            //var user = new User(email, "pass");

            userRepositoryMock.Setup(x => x.Get(user.Email)).Returns(user);
            mapperMock.Setup(x => x.Map<UserDto>(user)).Returns(new UserDto()
            {
                Id = user.Id,
                Email = user.Email
            });

            IUserService userService = new UserService(userRepositoryMock.Object, mapperMock.Object);

            //Act
            var expectedUser = userService.Get(user.Email);

            //Assert
            Assert.NotNull(expectedUser);
            Assert.Equal(expectedUser.Id, user.Id);


            userRepositoryMock.Verify(x => x.Get(user.Email), Times.Once);
            mapperMock.Verify(x => x.Map<UserDto>(user), Times.Once);
            //mapperMock.Verify(x => x.Map<UserDto>(user), Times.Never);
        }
    }
}
