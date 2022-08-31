using Sat.Recruitment.Application.Model;
using System.Threading.Tasks;

namespace Sat.Recruitment.Application.Service
{
    public interface IUserService
    {
        Task<Result> PostCreateUser(User User);
    }
}
