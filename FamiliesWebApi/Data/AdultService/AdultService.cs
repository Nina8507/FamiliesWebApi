using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FamiliesWebApi.Models;
using FamiliesWebApi.Persistance.FileContext;

namespace FamiliesWebApi.Data.AdultService
{
    public class AdultService:IAdultService
    {
        private string adultFile = "adult.json";
        private IList<Adult> _adults;
        private IFileContext _fileContext;

        public AdultService(IFileContext fileContext)
        {
          _fileContext = fileContext;
        }

        public async Task<IList<Adult>> GetAllAdultsAsync()
        {
            IList<Adult> adults = await _fileContext.GetAdultsAsync();
            return adults;
        }

        public async Task<Adult> GetAdultAsync(int id)
        {
            IList<Adult> adultsAsync = await _fileContext.GetAdultsAsync();
            Adult adultSearch = null;
            foreach (var adult in adultsAsync)
            {
                if (adult.Id == id)
                {
                    adultSearch = adult;
                }
            }

            if (adultSearch == null)
            {
                throw new Exception("Adult not found");
            }

            return adultSearch;
        }

        public async Task<Adult> AddAdultAsync(Adult adult)
        {
            _adults.Add(adult);
            await _fileContext.SaveChangesAsync();
            return adult;
        }

        public async Task<Adult> RemoveAdultAsync(int adultId)
        {
            Adult adultToRemove = _adults.First(a => a.Id == adultId);
            _adults.Remove(adultToRemove);
            await _fileContext.RemoveAdultAsync(adultId);
            await _fileContext.SaveChangesAsync();
            return adultToRemove;
        }

        public async Task<Adult> UpdateAdultAsync(Adult adult)
        {
            Adult adultToUpdate = _fileContext.GetAdultsAsync().Result.First(a => a.Id == adult.Id);
            if (adultToUpdate == null) throw new Exception($"Adult whit id: {adult.Id} not found");
            _adults.Remove(adultToUpdate);
            _adults.Add(adultToUpdate);
            await _fileContext.SaveChangesAsync();
            return adultToUpdate;
        }
    }
}