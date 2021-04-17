using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using FamiliesWebApi.Models;
using System;
using System.Text.Json;

namespace FamiliesWebApi.Persistance.UserContext
{
    public class UserContext:IUserContext
    {
        public IList<User> Users { get; private set; }
        private readonly string usersFile = "users.json";

        public UserContext()
        {
            Users = File.Exists(usersFile) ? ReadData<User>(usersFile) : new List<User>();
        }

        private IList<T> ReadData<T>(string s)
        {
            using (var jsonReader = File.OpenText(s))
            {
                return JsonSerializer.Deserialize<List<T>>(jsonReader.ReadToEnd(), new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            }
        }

        public async Task SaveChangesAsync()
        {
            string jsonUsers = JsonSerializer.Serialize(Users, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            using (StreamWriter streamWriter = new StreamWriter(usersFile, false))
            {
                streamWriter.Write(jsonUsers);
            }
        }

        public async Task<IList<User>> GetUsersAsync()
        {
            return Users;
        }
    }
}