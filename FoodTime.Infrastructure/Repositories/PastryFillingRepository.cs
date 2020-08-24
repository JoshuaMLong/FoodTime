using FoodTime.Domain;
using FoodTime.Domain.Interfaces;
using FoodTime.Domain.Models;
using FoodTime.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTime.Infrastructure.Data.Repositories
{
    public class PastryFillingRepository : BaseRepository<PastryFilling>, IPastryFillingRepository
    {
        public PastryFillingRepository(FoodTimeContext ctx) : base(ctx)
        {

        }

        public async ValueTask<IEnumerable<PastryFilling>> GetPastryFillingsAsync()
        {
            return await Get().ToListAsync();
        }
        public async ValueTask<PastryFilling> GetPastryFillingsByIdAsync(int id)
        {
            return await Get(pf => pf.Id == id).SingleAsync();
        }
        public async ValueTask<IEnumerable<PastryFilling>> GetPastryFillingsByIdAsync(IEnumerable<int> ids)
        {
            return await Get(pf => ids.Contains(pf.Id)).ToListAsync();
        }
        public async ValueTask<IEnumerable<PastryFilling>> GetPastryFillingsByNameAsync(string name)
        {
            return await Get(pf => pf.Name == name).ToListAsync();
        }
        public async ValueTask<IEnumerable<PastryFilling>> GetPastryFillingsByNameAsync(IEnumerable<string> names)
        {
            return await Get(pf => names.Contains(pf.Name)).ToListAsync();
        }
        public async ValueTask<IEnumerable<PastryFilling>> GetPastryFillingsByPriceAsync(decimal price)
        {
            return await Get(pf => pf.Price == price).ToListAsync();
        }
        public async ValueTask<IEnumerable<PastryFilling>> GetPastryFillingsByPriceAsync(IEnumerable<decimal> prices)
        {
            return await Get(pf => prices.Contains(pf.Price)).ToListAsync();
        }
    }
}
