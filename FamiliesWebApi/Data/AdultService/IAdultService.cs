using System.Collections.Generic;
using System.Threading.Tasks;
using FamiliesWebApi.Models;

namespace FamiliesWebApi.Data.AdultService
{
    public interface IAdultService
    {
        Task<IList<Adult>> GetAllAdultsAsync();
        Task<Adult> GetAdultAsync(int id);
        Task<Adult> AddAdultAsync(Adult adult);
        Task <Adult>RemoveAdultAsync(int adultId);
        Task<Adult> UpdateAdultAsync(Adult adult);
    }
}