using FoodTime.Infrastructure.Models;
using FoodTime.Infrastructure.Data.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodTime.Infrastructure.Interfaces
{
    public interface IPastryRepository : IBaseRepository<Pastry>
    {
        ValueTask<IEnumerable<Pastry>> GetAllPastriesAsync();
        ValueTask<IEnumerable<PastryWithStock>> GetAllPastriesGroupForStockAsync();
        ValueTask<IEnumerable<Pastry>> GetPastriesByIdAsync(IEnumerable<int> ids);
        ValueTask<Pastry> GetPastriesByIdAsync(int id);
        ValueTask<IEnumerable<Pastry>> GetPastriesByNameAsync(IEnumerable<string> names);
        ValueTask<IEnumerable<Pastry>> GetPastriesByNameAsync(string name);
        ValueTask<IEnumerable<PastryWithStock>> GetPastriesByNameGroupByStockAsync(IEnumerable<string> names);
        ValueTask<IEnumerable<PastryWithStock>> GetPastriesByNameGroupByStockAsync(string name);
        ValueTask<IEnumerable<Pastry>> GetPastriesByPastryFillingAsync(IEnumerable<PastryFilling> pastryFillings);
        ValueTask<IEnumerable<Pastry>> GetPastriesByPastryFillingAsync(PastryFilling pastryFilling);
        ValueTask<IEnumerable<PastryWithStock>> GetPastriesByPastryFillingGroupForStockAsync(IEnumerable<PastryFilling> pastryFillings);
        ValueTask<IEnumerable<PastryWithStock>> GetPastriesByPastryFillingGroupForStockAsync(PastryFilling pastryFilling);
        ValueTask<IEnumerable<Pastry>> GetPastriesByPastryFillingAsync(IEnumerable<int> pastryFillings);
        ValueTask<IEnumerable<Pastry>> GetPastriesByPastryFillingAsync(int pastryFilling);
        ValueTask<IEnumerable<PastryWithStock>> GetPastriesByPastryFillingGroupForStockAsync(IEnumerable<int> pastryFillings);
        ValueTask<IEnumerable<PastryWithStock>> GetPastriesByPastryFillingGroupForStockAsync(int pastryFilling);
        ValueTask<IEnumerable<Pastry>> GetPastriesByPastryTypeAsync(IEnumerable<PastryDough> pastryTypes);
        ValueTask<IEnumerable<Pastry>> GetPastriesByPastryTypeAsync(PastryDough pastryType);
        ValueTask<IEnumerable<Pastry>> GetPastriesByPastryTypeAsync(IEnumerable<int> pastryTypes);
        ValueTask<IEnumerable<Pastry>> GetPastriesByPastryTypeAsync(int pastryType);
        ValueTask<IEnumerable<PastryWithStock>> GetPastriesByPastryTypeGroupForStockAsync(IEnumerable<int> pastryTypes);
        ValueTask<IEnumerable<PastryWithStock>> GetPastriesByPastryTypeGroupForStockAsync(int pastryType);
        ValueTask<IEnumerable<PastryWithStock>> GetPastriesByPastryTypeGroupForStockAsync(IEnumerable<PastryDough> pastryTypes);
        ValueTask<IEnumerable<PastryWithStock>> GetPastriesByPastryTypeGroupForStockAsync(PastryDough pastryType);
        ValueTask<IEnumerable<Pastry>> GetPastriesByPastryStockCompositeKey(PastryStockCompositeKey pastryCompositeKey);
        ValueTask<IEnumerable<Pastry>> GetPastriesByPriceAsync(decimal price);
        ValueTask<IEnumerable<Pastry>> GetPastriesByPriceAsync(IEnumerable<decimal> prices);
        ValueTask<IEnumerable<PastryWithStock>> GetPastriesByPriceGroupByStockAsync(decimal price);
        ValueTask<IEnumerable<PastryWithStock>> GetPastriesByPriceGroupByStockAsync(IEnumerable<decimal> prices);
    }
}