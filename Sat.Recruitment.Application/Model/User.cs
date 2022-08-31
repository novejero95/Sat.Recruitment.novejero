using Sat.Recruitment.Application.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sat.Recruitment.Application.Model
{
    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public UserTypeEnum UserType { get; set; }
        public decimal Money { get; set; }
    }
}
