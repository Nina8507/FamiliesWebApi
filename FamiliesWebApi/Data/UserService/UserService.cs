using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FamiliesWebApi.Models;
using FamiliesWebApi.Persistance.UserContext;

namespace FamiliesWebApi.Data.UserService
{
    public class UserService:IUserService
    {
        private readonly IUserContext _userContext; 

        public UserService(IUserContext userContext)
        {
            _userContext = userContext;
        }
        public async Task<User> ValidateUserAsync(string userName, string passWord)
        {
            Task<IList<User>> usersAsync = _userContext.GetUsersAsync();
            //IList<User> userList = usersAsync.GetAwaiter().GetResult();
            var loginUser = usersAsync.Result.First(u => u.UserName.Equals
                (userName) && u.Password.Equals(passWord));
            if (loginUser != null)
            {
                return loginUser;
            }
            else
            {
                throw new Exception("User not found");
            }

            
        }
    }
}