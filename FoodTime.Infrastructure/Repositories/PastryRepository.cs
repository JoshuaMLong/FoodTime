using FoodTime.Domain;
using FoodTime.Domain.Data.ViewModels;
using FoodTime.Domain.Interfaces;
using FoodTime.Domain.Models;
using FoodTime.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FoodTime.Infrastructure.Data.Repositories
{
    public class PastryRepository : BaseRepository<Pastry>, IPastryRepository
    {
        public PastryRepository(FoodTimeContext ctx) : base(ctx) { }

        public async ValueTask<IEnumerable<Pastry>> GetAllPastriesAsync()
        {
            return await Get().IncludeFillingAndTypeToListAsync();
        }
        public async ValueTask<IEnumerable<Pastry>> GetAllPastriesGroupForStockAsync()
        {
            return await Get().IncludeFillingAndType().GroupPastriesByPastryStockCompositeKeyToListAsync(Ctx.PastryStock);
        }

        public async ValueTask<IEnumerable<Pastry>> GetPastriesByPastryTypeAsync(PastryType pastryType)
        {
            return await Get(p => p.PastryType.Id == pastryType.Id).IncludeFillingAndTypeToListAsync();
        }
        public async ValueTask<IEnumerable<Pastry>> GetPastriesByPastryTypeAsync(IEnumerable<PastryType> pastryTypes)
        {
            return await Get(p => pastryTypes.Any(pt => pt.Id == p.PastryType.Id)).IncludeFillingAndTypeToListAsync();
        }
        public async ValueTask<IEnumerable<Pastry>> GetPastriesByPastryTypeGroupForStockAsync(PastryType pastryType)
        {
            return await Get(p => p.PastryType.Id == pastryType.Id).IncludeFillingAndType().GroupPastriesByPastryStockCompositeKeyToListAsync(Ctx.PastryStock);
        }
        public async ValueTask<IEnumerable<Pastry>> GetPastriesByPastryTypeGroupForStockAsync(IEnumerable<PastryType> pastryTypes)
        {
            return await Get(p => pastryTypes.Any(pt => pt.Id == p.PastryType.Id)).IncludeFillingAndType().GroupPastriesByPastryStockCompositeKeyToListAsync(Ctx.PastryStock);
        }
        public async ValueTask<IEnumerable<Pastry>> GetPastriesByPastryFillingAsync(PastryFilling pastryFilling)
        {
            return await Get(p => p.PastryFilling.Id == pastryFilling.Id).IncludeFillingAndTypeToListAsync();
        }
        public async ValueTask<IEnumerable<Pastry>> GetPastriesByPastryFillingAsync(IEnumerable<PastryFilling> pastryFillings)
        {
            return await Get(p => pastryFillings.Any(pf => pf.Id == p.PastryFilling.Id)).IncludeFillingAndTypeToListAsync();
        }
        public async ValueTask<IEnumerable<Pastry>> GetPastriesByPastryFillingGroupForStockAsync(PastryFilling pastryFilling)
        {
            return await Get(p => p.PastryFilling.Id == pastryFilling.Id).IncludeFillingAndType().GroupPastriesByPastryStockCompositeKeyToListAsync(Ctx.PastryStock);
        }
        public async ValueTask<IEnumerable<Pastry>> GetPastriesByPastryFillingGroupForStockAsync(IEnumerable<PastryFilling> pastryFillings)
        {
            return await Get(p => pastryFillings.Any(pf => pf.Id == p.PastryFilling.Id)).IncludeFillingAndType().GroupPastriesByPastryStockCompositeKeyToListAsync(Ctx.PastryStock);
        }
        public async ValueTask<IEnumerable<Pastry>> GetPastriesByPastryFillingAsync(IEnumerable<int> pastryFillingIds)
        {
            return await Get(p => pastryFillingIds.Contains(p.PastryFilling.Id)).IncludeFillingAndTypeToListAsync();
        }

        public async ValueTask<IEnumerable<Pastry>> GetPastriesByPastryFillingAsync(int pastryFillingId)
        {
            return await Get(p => p.PastryFilling.Id == pastryFillingId).IncludeFillingAndTypeToListAsync();
        }

        public async ValueTask<IEnumerable<Pastry>> GetPastriesByPastryFillingGroupForStockAsync(IEnumerable<int> pastryFillings)
        {
            return await Get(p => pastryFillings.Contains(p.PastryFilling.Id)).IncludeFillingAndType().GroupPastriesByPastryStockCompositeKeyToListAsync(Ctx.PastryStock);
        }

        public async ValueTask<IEnumerable<Pastry>> GetPastriesByPastryFillingGroupForStockAsync(int pastryFilling)
        {
            return await Get(p => p.PastryFilling.Id == pastryFilling).IncludeFillingAndType().GroupPastriesByPastryStockCompositeKeyToListAsync(Ctx.PastryStock);
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
        public async ValueTask<IEnumerable<Pastry>> GetPastriesByNameGroupByStockAsync(string name)
        {
            return await Get(p => p.Name == name).IncludeFillingAndType().GroupPastriesByPastryStockCompositeKeyToListAsync(Ctx.PastryStock);
        }
        public async ValueTask<IEnumerable<Pastry>> GetPastriesByNameGroupByStockAsync(IEnumerable<string> names)
        {
            return await Get(p => names.Contains(p.Name)).IncludeFillingAndType().GroupPastriesByPastryStockCompositeKeyToListAsync(Ctx.PastryStock);
        }
        public async ValueTask<IEnumerable<Pastry>> GetPastriesByPriceAsync(decimal price)
        {
            return await Get(p => p.Price == price).IncludeFillingAndTypeToListAsync();
        }
        public async ValueTask<IEnumerable<Pastry>> GetPastriesByPriceAsync(IEnumerable<decimal> prices)
        {
            return await Get(p => prices.Contains(p.Price)).IncludeFillingAndTypeToListAsync();
        }
        public async ValueTask<IEnumerable<Pastry>> GetPastriesByPriceGroupByStockAsync(decimal price)
        {
            return await Get(p => p.Price == price).IncludeFillingAndType().GroupPastriesByPastryStockCompositeKeyToListAsync(Ctx.PastryStock);
        }
        public async ValueTask<IEnumerable<Pastry>> GetPastriesByPriceGroupByStockAsync(IEnumerable<decimal> prices)
        {
            return await Get(p => prices.Contains(p.Price)).IncludeFillingAndType().GroupPastriesByPastryStockCompositeKeyToListAsync(Ctx.PastryStock);
        }

        public async ValueTask<IEnumerable<Pastry>> GetPastriesByPastryTypeAsync(IEnumerable<int> pastryTypeIds)
        {
            return await Get(p => pastryTypeIds.Contains(p.PastryType.Id)).IncludeFillingAndTypeToListAsync();
        }

        public async ValueTask<IEnumerable<Pastry>> GetPastriesByPastryTypeAsync(int pastryTypeId)
        {
            return await Get(p => p.PastryType.Id == pastryTypeId).IncludeFillingAndTypeToListAsync();
        }

        public async ValueTask<IEnumerable<Pastry>> GetPastriesByPastryTypeGroupForStockAsync(IEnumerable<int> pastryTypeIds)
        {
            return await Get(p => pastryTypeIds.Contains(p.PastryType.Id)).IncludeFillingAndType().GroupPastriesByPastryStockCompositeKeyToListAsync(Ctx.PastryStock);
        }

        public async ValueTask<IEnumerable<Pastry>> GetPastriesByPastryTypeGroupForStockAsync(int pastryType)
        {
            return await Get(p => p.PastryType.Id == pastryType).IncludeFillingAndType().GroupPastriesByPastryStockCompositeKeyToListAsync(Ctx.PastryStock);
        }

        public async ValueTask<IEnumerable<Pastry>> GetPastriesByPastryStockCompositeKey(PastryStockCompositeKey pastryCompositeKey)
        {
            return await Get(p => p.PastryFillingId == pastryCompositeKey.pfid && p.PastryTypeId == pastryCompositeKey.ptid).IncludeFillingAndTypeToListAsync();
        }
    }
    public static class PastryExtensions
    {
        public static IEnumerable<PastryWithStock> GroupPastriesByFillingAndType(this IQueryable<Pastry> pastries)
        {
            return pastries.GroupBy(p => new PastryStockCompositeKey { ptid = p.PastryType.Id, pfid = p.PastryFilling.Id }).Select(p => new PastryWithStock { Pastry = p.First(), Stock = p.Count() });
        }
        
        //this will be used a lot in this repository so I figured i'd make an extension method
        public static async ValueTask<IEnumerable<Pastry>> GroupPastriesByPastryStockCompositeKeyToListAsync(this IQueryable<Pastry> pastrties, IQueryable<PastryStock> pastryStockDbSet)
        {
            return await (from a in pastrties
                  join b in pastryStockDbSet on new { PastryTypeId = a.PastryTypeId, PastryFillingId = a.PastryFillingId } equals new { PastryTypeId = b.PastryTypeId, PastryFillingId = b.PastryFillingId }
                  select new Pastry { Description = a.Description, PastryFillingId = a.PastryFillingId, PastryFilling = a.PastryFilling, PastryType = a.PastryType, PastryTypeId = a.PastryTypeId, Name = a.Name, Stock = b.Stock }).Distinct().ToListAsync();
        }

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
