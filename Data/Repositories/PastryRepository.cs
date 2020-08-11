using FoodTime.Data.Interfaces;
using FoodTime.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FoodTime.Data.Repositories
{
    public class PastryRepository : BaseRepository<Pastry>, IPastryRepository
    {
        public PastryRepository(FoodTimeContext ctx) : base(ctx) { }

        public async ValueTask<IEnumerable<Pastry>> GetAllPastriesAsync()
        {
            return await Get().IncludeFillingAndTypeToListAsync();
        }

        public async ValueTask<IEnumerable<Pastry>> GetPastriesByPastryTypeAsync(PastryType pastryType)
        {
            return await Get(p => p.PastryType.Id == pastryType.Id).IncludeFillingAndTypeToListAsync();
        }
        public async ValueTask<IEnumerable<Pastry>> GetPastriesByPastryTypeAsync(IEnumerable<PastryType> pastryTypes)
        {
            return await Get(p => pastryTypes.Any(pt => pt.Id == p.PastryType.Id)).IncludeFillingAndTypeToListAsync();
        }
        public async ValueTask<IEnumerable<Pastry>> GetPastriesByPastryFillingAsync(PastryFilling pastryFilling)
        {
            return await Get(p => p.PastryFilling.Id == pastryFilling.Id).IncludeFillingAndTypeToListAsync();
        }
        public async ValueTask<IEnumerable<Pastry>> GetPastriesByPastryFillingAsync(IEnumerable<PastryFilling> pastryFillings)
        {
            return await Get(p => pastryFillings.Any(pf => pf.Id == p.PastryFilling.Id)).IncludeFillingAndTypeToListAsync();
        }
        public async ValueTask<Pastry> GetPastriesByIdAsync(int id)
        {
            return await Get(p => p.Id == id).IncludeFillingAndType().SingleAsync();
        }
        public async ValueTask<IEnumerable<Pastry>> GetPastriesByIdAsync(IEnumerable<int> ids)
        {
            return await Get(p => ids.Contains(p.Id)).IncludeFillingAndTypeToListAsync();
        }
        public async ValueTask<IEnumerable<Pastry>> GetPastriesByNameAsync(string name)
        {
            return await Get(p => p.Name == name).IncludeFillingAndTypeToListAsync();
        }
        public async ValueTask<IEnumerable<Pastry>> GetPastriesByNameAsync(IEnumerable<string> names)
        {
            return await Get(p => names.Contains(p.Name)).IncludeFillingAndTypeToListAsync();
        }
        public async ValueTask<IEnumerable<Pastry>> GetPastriesByPriceAsync(decimal price)
        {
            return await Get(p => p.Price == price).IncludeFillingAndTypeToListAsync();
        }
        public async ValueTask<IEnumerable<Pastry>> GetPastriesByPriceAsync(IEnumerable<decimal> prices)
        {
            return await Get(p => prices.Contains(p.Price)).IncludeFillingAndTypeToListAsync();
        }
    }
    public static class PastryExtensions
    {
        public static IQueryable<Pastry> IncludeFillingAndType(this IQueryable<Pastry> pastries)
        {
            return pastries.Include(p => p.PastryType)
                .Include(p => p.PastryFilling);
        }
        public static async Task<IEnumerable<Pastry>> IncludeFillingAndTypeToListAsync(this IQueryable<Pastry> pastries)
        {
            return await pastries.Include(p => p.PastryType)
                .Include(p => p.PastryFilling)
                .ToListAsync();
        }
        public static IEnumerable<Pastry> IncludeFillingAndTypeToList(this IQueryable<Pastry> pastries)
        {
            return pastries.Include(p => p.PastryType)
                .Include(p => p.PastryFilling)
                .ToList();
        }
    }
}
