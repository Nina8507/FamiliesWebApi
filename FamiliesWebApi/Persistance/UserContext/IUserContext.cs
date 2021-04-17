using System.Collections.Generic;
using System.Threading.Tasks;
using FamiliesWebApi.Models;

namespace FamiliesWebApi.Persistance.UserContext
{
    public interface IUserContext
    {
        Task SaveChangesAsync();
        Task<IList<User>> GetUsersAsync();
    }
}