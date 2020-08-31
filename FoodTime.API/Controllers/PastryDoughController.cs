using System.Collections.Generic;
using System.Threading.Tasks;
using FoodTime.Infrastructure.Interfaces;
using FoodTime.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodTime.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PastryDoughController : ControllerBase
    {
        public IPastryDoughRepository PastryDoughRepository { get; }

        public PastryDoughController(IPastryDoughRepository pastryDoughRepository)
        {
            PastryDoughRepository = pastryDoughRepository;
        }
        // GET: api/PastryType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> GetPastryDoughs()
        {
            return Ok(await PastryDoughRepository.GetPastryDoughsAsync());
        }

        // GET: api/PastryDough/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PastryDough>> GetPastryDoughById(int id)
        {
            PastryDough pastryDough = await PastryDoughRepository.GetPastryDoughByIdAsync(id);
            if(pastryDough == null)
            {
                return NotFound();
            }
            return pastryDough;
        }
        // GET: api/PastryDough/Filo
        [HttpGet("{name}")]
        public async Task<ActionResult<IEnumerable<PastryDough>>> GetPastryDoughById(string id)
        {
            IEnumerable<PastryDough> pastryDough = await PastryDoughRepository.GetPastryDoughsByNameAsync(id);
            if(pastryDough == null)
            {
                return NotFound();
            }
            return Ok(pastryDough);
        }
        // GET: api/PastryDough/7.00M
        [HttpGet("{price}")]
        public async Task<ActionResult<IEnumerable<PastryDough>>> GetPastryDoughByPrice(decimal id)
        {
            IEnumerable<PastryDough> pastryDough = await PastryDoughRepository.GetPastryDoughsByPriceAsync(id);
            if(pastryDough == null)
            {
                return NotFound();
            }
            return Ok(pastryDough);
        }

        // POST: api/PastryDough
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PastryDough pastryDough)
        {
            PastryDoughRepository.Create(pastryDough);
            await PastryDoughRepository.SaveChangesAsync();

            return CreatedAtAction("GetPastryDoughById", new { id = pastryDough.Id }, pastryDough);
        }

        // PUT: api/PastryDough/5
        [HttpPut("{id}")]
        public async Task<ActionResult<PastryDough>> Put(int id, [FromBody] PastryDough pastryDough)
        {
            if (id != pastryDough.Id)
                return BadRequest();
            PastryDoughRepository.Update(pastryDough);
            try
            {
                await PastryDoughRepository.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                if(!await PastryDoughExists(id))
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
            PastryDough pastryDough = await PastryDoughRepository.GetPastryDoughByIdAsync(id);
            if (pastryDough == null)
                return NotFound();
            PastryDoughRepository.Delete(pastryDough);
            await PastryDoughRepository.SaveChangesAsync();
            return Ok();
        }

        private async ValueTask<bool> PastryDoughExists(int id)
        {
            return (await PastryDoughRepository.GetPastryDoughByIdAsync(id)) is object;
        }
    }
}
