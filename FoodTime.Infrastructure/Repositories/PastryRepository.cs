using FoodTime.Infrastructure;
using FoodTime.Infrastructure.Data.ViewModels;
using FoodTime.Infrastructure.Interfaces;
using FoodTime.Infrastructure.Models;
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
            return await Get().IncludeFillingAndType().ToListAsync();
        }
        public async ValueTask<IEnumerable<PastryWithStock>> GetAllPastriesGroupForStockAsync()
        {
            return await Get().IncludeFillingAndType().GroupPastriesByPastryStockCompositeKeyAsync(Ctx.PastryType);
        }

        public async ValueTask<IEnumerable<Pastry>> GetPastriesByPastryTypeAsync(PastryDough pastryType)
        {
            return await Get(p => p.PastryDough.Id == pastryType.Id).IncludeFillingAndType().ToListAsync();
        }
        public async ValueTask<IEnumerable<Pastry>> GetPastriesByPastryTypeAsync(IEnumerable<PastryDough> pastryTypes)
        {
            return await Get(p => pastryTypes.Any(pt => pt.Id == p.PastryDough.Id)).IncludeFillingAndType().ToListAsync();
        }
        public async ValueTask<IEnumerable<PastryWithStock>> GetPastriesByPastryTypeGroupForStockAsync(PastryDough pastryType)
        {
            return await Get(p => p.PastryDough.Id == pastryType.Id).IncludeFillingAndType().GroupPastriesByPastryStockCompositeKeyAsync(Ctx.PastryType);
        }
        public async ValueTask<IEnumerable<PastryWithStock>> GetPastriesByPastryTypeGroupForStockAsync(IEnumerable<PastryDough> pastryTypes)
        {
            return await Get(p => pastryTypes.Any(pt => pt.Id == p.PastryDough.Id)).IncludeFillingAndType().GroupPastriesByPastryStockCompositeKeyAsync(Ctx.PastryType);
        }
        public async ValueTask<IEnumerable<Pastry>> GetPastriesByPastryFillingAsync(PastryFilling pastryFilling)
        {
            return await Get(p => p.PastryFilling.Id == pastryFilling.Id).IncludeFillingAndType().ToListAsync();
        }
        public async ValueTask<IEnumerable<Pastry>> GetPastriesByPastryFillingAsync(IEnumerable<PastryFilling> pastryFillings)
        {
            return await Get(p => pastryFillings.Any(pf => pf.Id == p.PastryFilling.Id)).IncludeFillingAndType().ToListAsync();
        }
        public async ValueTask<IEnumerable<PastryWithStock>> GetPastriesByPastryFillingGroupForStockAsync(PastryFilling pastryFilling)
        {
            return await Get(p => p.PastryFilling.Id == pastryFilling.Id).IncludeFillingAndType().GroupPastriesByPastryStockCompositeKeyAsync(Ctx.PastryType);
        }
        public async ValueTask<IEnumerable<PastryWithStock>> GetPastriesByPastryFillingGroupForStockAsync(IEnumerable<PastryFilling> pastryFillings)
        {
            return await Get(p => pastryFillings.Any(pf => pf.Id == p.PastryFilling.Id)).IncludeFillingAndType().GroupPastriesByPastryStockCompositeKeyAsync(Ctx.PastryType);
        }
        public async ValueTask<IEnumerable<Pastry>> GetPastriesByPastryFillingAsync(IEnumerable<int> pastryFillingIds)
        {
            return await Get(p => pastryFillingIds.Contains(p.PastryFilling.Id)).IncludeFillingAndType().ToListAsync();
        }

        public async ValueTask<IEnumerable<Pastry>> GetPastriesByPastryFillingAsync(int pastryFillingId)
        {
            return await Get(p => p.PastryFilling.Id == pastryFillingId).IncludeFillingAndType().ToListAsync();
        }

        public async ValueTask<IEnumerable<PastryWithStock>> GetPastriesByPastryFillingGroupForStockAsync(IEnumerable<int> pastryFillings)
        {
            return await Get(p => pastryFillings.Contains(p.PastryFilling.Id)).IncludeFillingAndType().GroupPastriesByPastryStockCompositeKeyAsync(Ctx.PastryType);
        }

        public async ValueTask<IEnumerable<PastryWithStock>> GetPastriesByPastryFillingGroupForStockAsync(int pastryFilling)
        {
            return await Get(p => p.PastryFilling.Id == pastryFilling).IncludeFillingAndType().GroupPastriesByPastryStockCompositeKeyAsync(Ctx.PastryType);
        }
        public async ValueTask<Pastry> GetPastriesByIdAsync(int id)
        {
            return await Get(p => p.Id == id).IncludeFillingAndType().SingleAsync();
        }
        public async ValueTask<IEnumerable<Pastry>> GetPastriesByIdAsync(IEnumerable<int> ids)
        {
            return await Get(p => ids.Contains(p.Id)).IncludeFillingAndType().ToListAsync();
        }
        public async ValueTask<IEnumerable<Pastry>> GetPastriesByNameAsync(string name)
        {
            return await Get(p => p.Name == name).IncludeFillingAndType().ToListAsync();
        }
        public async ValueTask<IEnumerable<Pastry>> GetPastriesByNameAsync(IEnumerable<string> names)
        {
            return await Get(p => names.Contains(p.Name)).IncludeFillingAndType().ToListAsync();
        }
        public async ValueTask<IEnumerable<PastryWithStock>> GetPastriesByNameGroupByStockAsync(string name)
        {
            return await Get(p => p.Name == name).IncludeFillingAndType().GroupPastriesByPastryStockCompositeKeyAsync(Ctx.PastryType);
        }
        public async ValueTask<IEnumerable<PastryWithStock>> GetPastriesByNameGroupByStockAsync(IEnumerable<string> names)
        {
            return await Get(p => names.Contains(p.Name)).IncludeFillingAndType().GroupPastriesByPastryStockCompositeKeyAsync(Ctx.PastryType);
        }
        public async ValueTask<IEnumerable<Pastry>> GetPastriesByPriceAsync(decimal price)
        {
            return await Get(p => p.Price == price).IncludeFillingAndType().ToListAsync();
        }
        public async ValueTask<IEnumerable<Pastry>> GetPastriesByPriceAsync(IEnumerable<decimal> prices)
        {
            return await Get(p => prices.Contains(p.Price)).IncludeFillingAndType().ToListAsync();
        }
        public async ValueTask<IEnumerable<PastryWithStock>> GetPastriesByPriceGroupByStockAsync(decimal price)
        {
            return await Get(p => p.Price == price).IncludeFillingAndType().GroupPastriesByPastryStockCompositeKeyAsync(Ctx.PastryType);
        }
        public async ValueTask<IEnumerable<PastryWithStock>> GetPastriesByPriceGroupByStockAsync(IEnumerable<decimal> prices)
        {
            return await Get(p => prices.Contains(p.Price)).IncludeFillingAndType().GroupPastriesByPastryStockCompositeKeyAsync(Ctx.PastryType);
        }

        public async ValueTask<IEnumerable<Pastry>> GetPastriesByPastryTypeAsync(IEnumerable<int> pastryTypeIds)
        {
            return await Get(p => pastryTypeIds.Contains(p.PastryDough.Id)).IncludeFillingAndType().ToListAsync();
        }

        public async ValueTask<IEnumerable<Pastry>> GetPastriesByPastryTypeAsync(int pastryTypeId)
        {
            return await Get(p => p.PastryDough.Id == pastryTypeId).IncludeFillingAndType().ToListAsync();
        }

        public async ValueTask<IEnumerable<PastryWithStock>> GetPastriesByPastryTypeGroupForStockAsync(IEnumerable<int> pastryTypeIds)
        {
            return await Get(p => pastryTypeIds.Contains(p.PastryDough.Id)).IncludeFillingAndType().GroupPastriesByPastryStockCompositeKeyAsync(Ctx.PastryType);
        }

        public async ValueTask<IEnumerable<PastryWithStock>> GetPastriesByPastryTypeGroupForStockAsync(int pastryType)
        {
            return await Get(p => p.PastryDough.Id == pastryType).IncludeFillingAndType().GroupPastriesByPastryStockCompositeKeyAsync(Ctx.PastryType);
        }

        public async ValueTask<IEnumerable<Pastry>> GetPastriesByPastryStockCompositeKey(PastryStockCompositeKey pastryCompositeKey)
        {
            return await Get(p => p.PastryFillingId == pastryCompositeKey.pfid && p.PastryDoughId == pastryCompositeKey.ptid).IncludeFillingAndType().ToListAsync();
        }
    }
    public static class PastryExtensions
    {
        public static IEnumerable<PastryWithStock> GroupPastriesByFillingAndType(this IQueryable<Pastry> pastries)
        {
            return pastries.GroupBy(p => new PastryStockCompositeKey { ptid = p.PastryDough.Id, pfid = p.PastryFilling.Id }).Select(p => new PastryWithStock { Pastry = p.First(), Stock = p.Count() });
        }

        //this will be used a lot in this repository so I figured i'd make an extension method
        public static async ValueTask<IQueryable<PastryWithStock>> GroupPastriesByPastryStockCompositeKeyAsync(this IQueryable<Pastry> pastrties, IQueryable<PastryType> pastryStockDbSet)
        {
            return await Task.FromResult((from a in pastrties
                                          join b in pastryStockDbSet on new { PastryDoughId = a.PastryDoughId, PastryFillingId = a.PastryFillingId } equals new { PastryDoughId = b.PastryDoughId, PastryFillingId = b.PastryFillingId }
                                          select new PastryWithStock
                                          {
                                              Pastry = new Pastry
                                              { 
                                                  Description = a.Description,
                                                  PastryFillingId = a.PastryFillingId,
                                                  PastryFilling = a.PastryFilling,
                                                  PastryDough = a.PastryDough,
                                                  PastryDoughId = a.PastryDoughId,
                                                  Name = a.Name 
                                              },
                                              Stock = b.Stock,
                                              Image = b.Image
                                          }).Distinct());
        }

        public static IQueryable<Pastry> IncludeFillingAndType(this IQueryable<Pastry> pastries)
        {
            return pastries.Include(p => p.PastryDough)
                .Include(p => p.PastryFilling);
        }
        //public static async Task<IEnumerable<Pastry>> IncludeFillingAndTypeToListAsync(this IQueryable<Pastry> pastries)
        //{
        //    return await pastries.Include(p => p.PastryDough)
        //        .Include(p => p.PastryFilling)
        //        .ToListAsync();
        //}
        //public static IEnumerable<Pastry> IncludeFillingAndTypeToList(this IQueryable<Pastry> pastries)
        //{
        //    return pastries.Include(p => p.PastryDough)
        //        .Include(p => p.PastryFilling)
        //        .ToList();
        //}
    }
}
