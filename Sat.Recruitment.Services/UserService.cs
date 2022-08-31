using Sat.Recruitment.Application.Enum;
using Sat.Recruitment.Application.Helpers;
using Sat.Recruitment.Application.Model;
using Sat.Recruitment.Application.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sat.Recruitment.Services
{
    public class UserService : IUserService
    {
        private readonly IUserProcess _userProcess;
        public UserService(IUserProcess userProcess) 
        {
            _userProcess = userProcess;
        } 

        public async Task<Result> PostCreateUser(User User)
        {
            var result = _userProcess.validarDatos(User);
            if (result.IsSuccess == false)
            {
                return result;
            }

            switch (User.UserType)
            {
                case UserTypeEnum.Normal:
                    if (User.Money > 100)
                    {
                        var percentage = Convert.ToDecimal(0.12);
                        //If new user is normal and has more than USD100
                        var gif = User.Money * percentage;
                        User.Money = User.Money + gif;
                    }
                    if (User.Money < 100)
                    {
                        if (User.Money > 10)
                        {
                            var percentage = Convert.ToDecimal(0.8);
                            var gif = User.Money * percentage;
                            User.Money = User.Money + gif;
                        }
                    }
                    break;
                case UserTypeEnum.SuperUser:
                    if (User.Money > 100)
                    {
                        var percentage = Convert.ToDecimal(0.20);
                        var gif = User.Money * percentage;
                        User.Money = User.Money + gif;
                    }
                    break;
                case UserTypeEnum.Premium:
                    if (User.Money > 100)
                    {
                        var gif = User.Money * 2;
                        User.Money = User.Money + gif;
                    }
                    break;
            }

            var usersFile = _userProcess.ReadUsersFromFile();

            User.Email = Helper.normalizeEmail(User.Email);

            result = _userProcess.CreateUser(usersFile,User);

            return result;
        }
    }
}
