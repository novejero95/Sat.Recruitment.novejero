using System;
using System.Collections.Generic;
using System.Text;

namespace Sat.Recruitment.Application.Model
{
    public class Result
    {
        public bool IsSuccess { get; set; } = true;
        public string Errors { get; set; }
    }
}
