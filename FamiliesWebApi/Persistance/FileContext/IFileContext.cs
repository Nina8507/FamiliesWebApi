using System.Collections.Generic;
using System.Threading.Tasks;
using FamiliesWebApi.Models;

namespace FamiliesWebApi.Persistance.FileContext
{
    public interface IFileContext
    {
        Task SaveChangesAsync();
        Task<IList<Family>> GetFamiliesAsync();
        Task<IList<Adult>> GetAdultsAsync();
        Task RemoveAdultAsync(int adultId);
    }
}