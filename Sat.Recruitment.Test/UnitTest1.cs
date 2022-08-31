using System;
using Sat.Recruitment.Api.Controllers;
using Sat.Recruitment.Application.Enum;
using Sat.Recruitment.Application.Model;
using Sat.Recruitment.Application.Service;
using Sat.Recruitment.Services;
using Xunit;

namespace Sat.Recruitment.Test
{
    [CollectionDefinition("Tests", DisableParallelization = true)]
    public class UnitTest1
    {

        private readonly UsersController _controller;
        private readonly IUserService _userService;
        private readonly IUserProcess _userProcess;


        public UnitTest1()
        {
            _userProcess = new UserProcess();
            _userService = new UserService(_userProcess);
            _controller = new UsersController(_userService);
        }

        [Fact]
        public void Test1()
        {
            var user = new User
            {
                Name = "Mike",
                Email = "mike@gmail.com",
                Address = "Av. Juan G",
                Phone = "+349 1122354215",
                UserType = (UserTypeEnum)Enum.Parse(typeof(UserTypeEnum), "Normal"),
                Money = 124
            };
            var result = _controller.CreateUser(user).Result;
            Assert.True(result.IsSuccess);
            Assert.Equal("User Created", result.Errors);
        }

        [Fact]
        public void Test2()
        {
            var user = new User
            {
                Name = "Agustina",
                Email = "Agustina@gmail.com",
                Address = "Av. Juan G",
                Phone = "+349 1122354215",
                UserType = (UserTypeEnum)Enum.Parse(typeof(UserTypeEnum), "Normal"),
                Money = 124
            };
            var result = _controller.CreateUser(user).Result;
            Assert.True(result.IsSuccess);
            Assert.Equal("User Created", result.Errors);
        }

        [Fact]
        public void Test3Fail()
        {
            var user = new User
            {
                Name = "Agustina",
                Address = "Av. Juan G",
                Phone = "+349 1122354215",
                UserType = (UserTypeEnum)Enum.Parse(typeof(UserTypeEnum), "Normal"),
                Money = 124
            };
            var result = _controller.CreateUser(user).Result;
            Assert.False(result.IsSuccess);
            Assert.Equal("The email is required", result.Errors);
        }

        [Fact]
        public void Test4Duplicate()
        {
            var user = new User
            {
                Name = "Juan",
                Email = "Juan@marmol.com",
                Address = "Peru 2464",
                Phone = "+5491154762312",
                UserType = (UserTypeEnum)Enum.Parse(typeof(UserTypeEnum), "Normal"),
                Money = 1
            };
            var result = _controller.CreateUser(user).Result;
            Assert.False(result.IsSuccess);
            Assert.Equal("The user is duplicated", result.Errors);
        }
    }
}
