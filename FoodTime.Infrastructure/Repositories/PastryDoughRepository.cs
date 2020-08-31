using FoodTime.Infrastructure;
using FoodTime.Infrastructure.Interfaces;
using FoodTime.Infrastructure.Models;
using FoodTime.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTime.Infrastructure.Data.Repositories
{
    public class PastryDoughRepository : BaseRepository<PastryDough>, IPastryDoughRepository
    {
        public PastryDoughRepository(FoodTimeContext ctx) : base(ctx)
        {

        }

        public async ValueTask<IEnumerable<PastryDough>> GetPastryDoughsAsync()
        {
            return await Get().ToListAsync();
        }

        public async ValueTask<PastryDough> GetPastryDoughByIdAsync(int id)
        {
            return await Get(pt => pt.Id == id).SingleAsync();
        }

        public async ValueTask<IEnumerable<PastryDough>> GetPastryDoughsByIdAsync(IEnumerable<int> ids)
        {
            return await Get(pt => ids.Contains(pt.Id)).ToListAsync();
        }

        public async ValueTask<IEnumerable<PastryDough>> GetPastryDoughsByNameAsync(string name)
        {
            return await Get(pt => pt.Name == name).ToListAsync();
        }
        public async ValueTask<IEnumerable<PastryDough>> GetPastryDoughsByNameAsync(IEnumerable<string> names)
        {
            return await Get(pt => names.Contains(pt.Name)).ToListAsync();
        }
        public async ValueTask<IEnumerable<PastryDough>> GetPastryDoughsByPriceAsync(decimal price)
        {
            return await Get(pt => pt.Price == price).ToListAsync();
        }
        public async ValueTask<IEnumerable<PastryDough>> GetPastryDoughsByPriceAsync(IEnumerable<decimal> prices)
        {
            return await Get(pt => prices.Contains(pt.Price)).ToListAsync();
        }
    }
}
