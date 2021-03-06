using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FamiliesWebApi.Data.AdultService;
using FamiliesWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FamiliesWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdultController:ControllerBase
    {
        private readonly IAdultService _adultService;

        public AdultController(IAdultService adultService)
        {
            _adultService = adultService;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Adult>>> GetAdultsAsync()
        {
            try
            {
                IList<Adult> adults = await _adultService.GetAllAdultsAsync();
                return Ok(adults);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task DeleteAdultAsync([FromRoute] int id)
        {
            try
            {
                await _adultService.RemoveAdultAsync(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Adult>> AddAdultAsync([FromBody] Adult adult)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Adult adultAdded = await _adultService.AddAdultAsync(adult);
                return Created($"/{adultAdded.Id}", adultAdded);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPatch]
        [Route("{id:int}")]
        public async Task<ActionResult<Adult>> UpdateAdultAsync([FromBody] Adult adult)
        {
            try
            {
                Adult adultToUpdate = await _adultService.UpdateAdultAsync(adult);
                return Ok(adultToUpdate);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Adult>> GetAdultAsync([FromRoute] int id)
        {
            try
            {
                Adult adultAsync = await _adultService.GetAdultAsync(id);
                return Ok(adultAsync);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }
        
    }
}