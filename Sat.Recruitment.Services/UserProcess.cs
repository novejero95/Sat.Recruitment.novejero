using Sat.Recruitment.Application.Enum;
using Sat.Recruitment.Application.Helpers;
using Sat.Recruitment.Application.Model;
using Sat.Recruitment.Application.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Sat.Recruitment.Services
{
    public class UserProcess : IUserProcess
    {
        public Result validarDatos(User userNew)
        {
            var result = new Result();

            if (userNew.Name == null)
                //Validate if Name is null
                result = Helper.setearError("The name is required",false);

            if (userNew.Email == null)
                //Validate if Email is null
                result = Helper.setearError("The email is required",false);
            if (userNew.Address == null)
                //Validate if Address is null
                result = Helper.setearError("The address is required",false);

            if (userNew.Phone == null)
                //Validate if Phone is null
                result = Helper.setearError(" The phone is required",false);

            return result;
        }

        public List<User> ReadUsersFromFile()
        {
            List<User> _users = new List<User>();

            var path = Directory.GetCurrentDirectory() + "/Files/Users.txt";

            FileStream fileStream = new FileStream(path, FileMode.Open);

            StreamReader reader = new StreamReader(fileStream);

            while (reader.Peek() >= 0)
            {
                var line = reader.ReadLineAsync().Result;
                var user = new User
                {
                    Name = line.Split(',')[0].ToString(),
                    Email = line.Split(',')[1].ToString(),
                    Phone = line.Split(',')[2].ToString(),
                    Address = line.Split(',')[3].ToString(),
                    UserType = (UserTypeEnum)Enum.Parse(typeof(UserTypeEnum), line.Split(',')[4].ToString()),
                    Money = decimal.Parse(line.Split(',')[5].ToString()),
                };
                _users.Add(user);
            }
            reader.Close();

            return _users;
        }

        public Result CreateUser(List<User> userFile, User User)
        {
            var result = new Result();
            bool isDuplicated = false;
            try
            {
                isDuplicated = userFile.Exists(x => x.Name == User.Name 
                && x.Email == User.Email 
                && x.Address == User.Address 
                && x.Phone == User.Phone
                && x.Money == User.Money
                && x.UserType == User.UserType);

                if (!isDuplicated)
                {
                    result = Helper.setearError("User Created",true);
                }
                else
                {
                    result = Helper.setearError("The user is duplicated", false);
                }
            }
            catch
            {
                result = Helper.setearError("The user is duplicated", false);
            }

            return result;
        }



    }
}
