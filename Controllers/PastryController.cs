using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FoodTime.API.Data;
using FoodTime.API.Data.Models;
using FoodTime.API.Data.Interfaces;
using FoodTime.API.Data.ViewModels;

namespace FoodTime.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PastryController : ControllerBase
    {

        public IPastryRepository PastryRepository { get; }

        public PastryController(IPastryRepository pastryRepository)
        {
            PastryRepository = pastryRepository;
        }

        // GET: api/Pastry
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pastry>>> GetPastry()
        {
            return Ok(await PastryRepository.GetAllPastriesAsync());
        }
        // GET: api/Pastry
        [HttpGet("GroupedForStock")]
        public async Task<ActionResult<IEnumerable<PastryWithStock>>> GetPastryGroupedForStock()
        {
            return Ok(await PastryRepository.GetAllPastriesGroupForStockAsync());
        }

        // GET: api/Pastry/5
        [HttpGet("ById/{id}")]
        public async Task<ActionResult<Pastry>> GetPastry(int id)
        {
            var pastry = await PastryRepository.GetPastriesByIdAsync(id);

            if (pastry == null)
            {
                return NotFound();
            }

            return pastry;
        }
        // GET: api/Pastry/Flaky Cherry Pastry
        [HttpGet("ByName/{name}")]
        public async Task<ActionResult<IEnumerable<Pastry>>> GetPastryByName(string name)
        {
            var pastry = await PastryRepository.GetPastriesByNameAsync(name);

            if (pastry == null)
            {
                return NotFound();
            }

            return Ok(pastry);
        }
        [HttpGet("GroupedForStock/{name}")]
        public async Task<ActionResult<IEnumerable<PastryWithStock>>> GetPastryByNameGroupedForStock(string name)
        {
            var pastry = await PastryRepository.GetPastriesByNameGroupByStockAsync(name);

            if (pastry == null)
            {
                return NotFound();
            }

            return Ok(pastry);
        }
        [HttpGet("GroupedForStock/ByPastryFilling/{id}")]
        public async Task<ActionResult<IEnumerable<Pastry>>> GetPastryByNameGroupedForStockByFilling(int id)
        {
            var pastry = await PastryRepository.GetPastriesByPastryFillingAsync(id);

            if (pastry == null)
            {
                return NotFound();
            }

            return Ok(pastry);
        }
        [HttpGet("GroupedForStock/ByPastryType/{id}")]
        public async Task<ActionResult<IEnumerable<Pastry>>> GetPastryByTypeGroupedForStockByFilling(int id)
        {
            var pastry = await PastryRepository.GetPastriesByPastryTypeAsync(id);

            if (pastry == null)
            {
                return NotFound();
            }

            return Ok(pastry);
        }
        [HttpGet("ByPastryStockCompositeKey/")]
        public async Task<ActionResult<IEnumerable<Pastry>>> GetPastryByPastryStockCompositeKey([FromQuery]PastryStockCompositeKey key)
        {
            var pastries = await PastryRepository.GetPastriesByPastryStockCompositeKey(key);

            if (pastries.Count() == 0)
            {
                return NotFound();
            }

            return Ok(pastries);
        }

        // PUT: api/Pastry/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPastry(int id, Pastry pastry)
        {
            if (id != pastry.Id)
            {
                return BadRequest();
            }

            PastryRepository.Update(pastry);

            try
            {
                await PastryRepository.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await PastryExists(id))
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

        // POST: api/Pastry
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Pastry>> PostPastry([FromBody] Pastry pastry)
        {
            PastryRepository.Create(pastry);
            await PastryRepository.SaveChangesAsync();

            return CreatedAtAction("GetPastry", new { id = pastry.Id }, pastry);
        }

        // DELETE: api/Pastry/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Pastry>> DeletePastry(int id)
        {
            var pastry = await PastryRepository.GetPastriesByIdAsync(id);
            if (pastry == null)
            {
                return NotFound();
            }

            PastryRepository.Delete(pastry);
            await PastryRepository.SaveChangesAsync();

            return pastry;
        }

        private async ValueTask<bool> PastryExists(int id)
        {
            return (await PastryRepository.GetPastriesByIdAsync(id)) is object;
        }
    }
}
