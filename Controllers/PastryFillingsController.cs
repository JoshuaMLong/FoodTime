using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FoodTime.API.Data.Models;
using FoodTime.API.Data.Interfaces;

namespace FoodTime.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PastryFillingsController : ControllerBase
    {
        public IPastryFillingRepository PastryFillingRepository { get; }

        public PastryFillingsController(IPastryFillingRepository pastryFillingRepository)
        {
            PastryFillingRepository = pastryFillingRepository;
        }

        // GET: api/PastryFillings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PastryFilling>>> GetPastryFilling()
        {
            return Ok(await PastryFillingRepository.GetPastryFillingsAsync());
        }

        // GET: api/PastryFillings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PastryFilling>> GetPastryFilling(int id)
        {
            PastryFilling pastryFilling = await PastryFillingRepository.GetPastryFillingsByIdAsync(id);

            if (pastryFilling == null)
            {
                return NotFound();
            }

            return pastryFilling;
        }
        // GET: api/PastryFillings/Cherry
        [HttpGet("{name}")]
        public async Task<ActionResult<IEnumerable<PastryFilling>>> GetPastryFillingsByName(string name)
        {
            IEnumerable<PastryFilling> pastryFilling = await PastryFillingRepository.GetPastryFillingsByNameAsync(name);

            if (pastryFilling == null)
            {
                return NotFound();
            }

            return Ok(pastryFilling);
        }
        // GET: api/PastryFillings/2.00M
        [HttpGet("{price}")]
        public async Task<ActionResult<IEnumerable<PastryFilling>>> GetPastryFillingsByPrice(decimal price)
        {
            IEnumerable<PastryFilling> pastryFilling = await PastryFillingRepository.GetPastryFillingsByPriceAsync(price);

            if (pastryFilling == null)
            {
                return NotFound();
            }

            return Ok(pastryFilling);
        }

        // PUT: api/PastryFillings/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPastryFilling(int id, PastryFilling pastryFilling)
        {
            if (id != pastryFilling.Id)
            {
                return BadRequest();
            }

            PastryFillingRepository.Update(pastryFilling);

            try
            {
                await PastryFillingRepository.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await PastryFillingExists(id))
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

        // POST: api/PastryFillings
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PastryFilling>> PostPastryFilling(PastryFilling pastryFilling)
        {
            PastryFillingRepository.Create(pastryFilling);
            await PastryFillingRepository.SaveChangesAsync();

            return CreatedAtAction("GetPastryFilling", new { id = pastryFilling.Id }, pastryFilling);
        }

        // DELETE: api/PastryFillings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PastryFilling>> DeletePastryFilling(int id)
        {
            PastryFilling pastryFilling = await PastryFillingRepository.GetPastryFillingsByIdAsync(id);
            if (pastryFilling == null)
            {
                return NotFound();
            }

            PastryFillingRepository.Delete(pastryFilling);
            await PastryFillingRepository.SaveChangesAsync();

            return pastryFilling;
        }

        private async Task<bool> PastryFillingExists(int id)
        {
            return await PastryFillingRepository.GetPastryFillingsByIdAsync(id) is object;
        }
    }
}
