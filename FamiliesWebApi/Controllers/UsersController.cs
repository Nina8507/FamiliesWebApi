using System;
using System.Threading.Tasks;
using FamiliesWebApi.Data.UserService;
using FamiliesWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FamiliesWebApi.Controllers
{
    [ApiController] 
    [Route("[controller]")]
    public class UsersController:ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<User>> ValidateUserAsync([FromQuery] string username,
            [FromQuery] string password)
        {
            try
            {
                var user = await _userService.ValidateUserAsync(username, password);
                return Ok(user);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return BadRequest(e.Message);
            }
        }
    }
}