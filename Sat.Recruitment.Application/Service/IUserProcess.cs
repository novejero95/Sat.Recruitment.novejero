using Sat.Recruitment.Application.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Sat.Recruitment.Application.Service
{
    public interface IUserProcess
    {
        Result validarDatos(User userNew);
        List<User> ReadUsersFromFile();
        Result CreateUser(List<User> userFile, User User);

    }
}
