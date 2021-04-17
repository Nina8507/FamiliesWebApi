using System.Collections.Generic;
using System.Threading.Tasks;
using FamiliesWebApi.Models;
using FamiliesWebApi.Persistance.FileContext;

namespace FamiliesWebApi.Data.FamilyService
{
    public class FamilyService:IFamilyService
    {
        private string familiesFile = "families.json";
        private IFileContext fileContext;

        public FamilyService(IFileContext fileContext)
        {
            this.fileContext = fileContext;
        }
        
        public async Task<IList<Family>> GetFamiliesAsync()
        {
            IList<Family> familiesAsync = await fileContext.GetFamiliesAsync();
            return familiesAsync;
        }
    }
}