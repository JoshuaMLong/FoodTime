using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodTime.API.Data.Interfaces;
using FoodTime.API.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodTime.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PastryTypeController : ControllerBase
    {
        public IPastryTypeRepository PastryTypeRepository { get; }

        public PastryTypeController(IPastryTypeRepository pastryTypeRepository)
        {
            PastryTypeRepository = pastryTypeRepository;
        }
        // GET: api/PastryType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> GetPastryTypes()
        {
            return Ok(await PastryTypeRepository.GetPastryTypesAsync());
        }

        // GET: api/PastryType/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PastryType>> GetPastryTypeById(int id)
        {
            PastryType pastryType = await PastryTypeRepository.GetPastryTypeByIdAsync(id);
            if(pastryType == null)
            {
                return NotFound();
            }
            return pastryType;
        }
        // GET: api/PastryType/Filo
        [HttpGet("{name}")]
        public async Task<ActionResult<IEnumerable<PastryType>>> GetPastryTypeById(string id)
        {
            IEnumerable<PastryType> pastryType = await PastryTypeRepository.GetPastryTypesByNameAsync(id);
            if(pastryType == null)
            {
                return NotFound();
            }
            return Ok(pastryType);
        }
        // GET: api/PastryType/7.00M
        [HttpGet("{price}")]
        public async Task<ActionResult<IEnumerable<PastryType>>> GetPastryTypeByPrice(decimal id)
        {
            IEnumerable<PastryType> pastryType = await PastryTypeRepository.GetPastryTypesByPriceAsync(id);
            if(pastryType == null)
            {
                return NotFound();
            }
            return Ok(pastryType);
        }

        // POST: api/PastryType
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PastryType pastryType)
        {
            PastryTypeRepository.Create(pastryType);
            await PastryTypeRepository.SaveChangesAsync();

            return CreatedAtAction("GetPastryTypeById", new { id = pastryType.Id }, pastryType);
        }

        // PUT: api/PastryType/5
        [HttpPut("{id}")]
        public async Task<ActionResult<PastryType>> Put(int id, [FromBody] PastryType pastryType)
        {
            if (id != pastryType.Id)
                return BadRequest();
            PastryTypeRepository.Update(pastryType);
            try
            {
                await PastryTypeRepository.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                if(!await PastryTypeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            PastryType pastryType = await PastryTypeRepository.GetPastryTypeByIdAsync(id);
            if (pastryType == null)
                return NotFound();
            PastryTypeRepository.Delete(pastryType);
            await PastryTypeRepository.SaveChangesAsync();
            return Ok();
        }

        private async ValueTask<bool> PastryTypeExists(int id)
        {
            return (await PastryTypeRepository.GetPastryTypeByIdAsync(id)) is object;
        }
    }
}
