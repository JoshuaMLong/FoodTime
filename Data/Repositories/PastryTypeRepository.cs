using FoodTime.Data.Interfaces;
using FoodTime.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTime.Data.Repositories
{
    public class PastryTypeRepository : BaseRepository<PastryType>, IPastryTypeRepository
    {
        public PastryTypeRepository(FoodTimeContext ctx) : base(ctx)
        {

        }

        public async Task<IEnumerable<PastryType>> GetPastryTypesAsync()
        {
            return await Get().ToListAsync();
        }

        public async Task<PastryType> GetPastryTypeByIdAsync(int id)
        {
            return await Get(pt => pt.Id == id).SingleAsync();
        }

        public async Task<IEnumerable<PastryType>> GetPastryTypesByIdAsync(IEnumerable<int> ids)
        {
            return await Get(pt => ids.Contains(pt.Id)).ToListAsync();
        }

        public async Task<IEnumerable<PastryType>> GetPastryTypesByNameAsync(string name)
        {
            return await Get(pt => pt.Name == name).ToListAsync();
        }
        public async Task<IEnumerable<PastryType>> GetPastryTypesByNameAsync(IEnumerable<string> names)
        {
            return await Get(pt => names.Contains(pt.Name)).ToListAsync();
        }
        public async Task<IEnumerable<PastryType>> GetPastryTypesByPriceAsync(decimal price)
        {
            return await Get(pt => pt.Price == price).ToListAsync();
        }
        public async Task<IEnumerable<PastryType>> GetPastryTypesByPriceAsync(IEnumerable<decimal> prices)
        {
            return await Get(pt => prices.Contains(pt.Price)).ToListAsync();
        }
    }
}
