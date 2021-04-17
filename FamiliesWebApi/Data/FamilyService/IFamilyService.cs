using System.Collections.Generic;
using System.Threading.Tasks;
using FamiliesWebApi.Models;

namespace FamiliesWebApi.Data.FamilyService
{
    public interface IFamilyService
    {
        Task<IList<Family>> GetFamiliesAsync();
    }
}