using System.Threading.Tasks;
using FamiliesWebApi.Models;

namespace FamiliesWebApi.Data.UserService
{
    public interface IUserService
    {
        Task<User> ValidateUserAsync(string userName, string passWord);
    }
}