using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FamiliesWebApi.Data.FamilyService;
using FamiliesWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FamiliesWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FamilyController:ControllerBase 
    {
        private readonly IFamilyService _familyService;

        public FamilyController(IFamilyService familyService)
        {
            this._familyService = familyService;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Family>>> GetFamiliesAsync()
        {
            try
            {
                IList<Family> families = await _familyService.GetFamiliesAsync();
                return Ok(families);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return StatusCode(500, e.Message);
            }
            
        }
    }
}