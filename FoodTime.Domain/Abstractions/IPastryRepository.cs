using FoodTime.Domain.Models;
using FoodTime.Domain.Data.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodTime.Domain.Interfaces
{
    public interface IPastryRepository : IBaseRepository<Pastry>
    {
        ValueTask<IEnumerable<Pastry>> GetAllPastriesAsync();
        ValueTask<IEnumerable<Pastry>> GetAllPastriesGroupForStockAsync();
        ValueTask<IEnumerable<Pastry>> GetPastriesByIdAsync(IEnumerable<int> ids);
        ValueTask<Pastry> GetPastriesByIdAsync(int id);
        ValueTask<IEnumerable<Pastry>> GetPastriesByNameAsync(IEnumerable<string> names);
        ValueTask<IEnumerable<Pastry>> GetPastriesByNameAsync(string name);
        ValueTask<IEnumerable<Pastry>> GetPastriesByNameGroupByStockAsync(IEnumerable<string> names);
        ValueTask<IEnumerable<Pastry>> GetPastriesByNameGroupByStockAsync(string name);
        ValueTask<IEnumerable<Pastry>> GetPastriesByPastryFillingAsync(IEnumerable<PastryFilling> pastryFillings);
        ValueTask<IEnumerable<Pastry>> GetPastriesByPastryFillingAsync(PastryFilling pastryFilling);
        ValueTask<IEnumerable<Pastry>> GetPastriesByPastryFillingGroupForStockAsync(IEnumerable<PastryFilling> pastryFillings);
        ValueTask<IEnumerable<Pastry>> GetPastriesByPastryFillingGroupForStockAsync(PastryFilling pastryFilling);
        ValueTask<IEnumerable<Pastry>> GetPastriesByPastryFillingAsync(IEnumerable<int> pastryFillings);
        ValueTask<IEnumerable<Pastry>> GetPastriesByPastryFillingAsync(int pastryFilling);
        ValueTask<IEnumerable<Pastry>> GetPastriesByPastryFillingGroupForStockAsync(IEnumerable<int> pastryFillings);
        ValueTask<IEnumerable<Pastry>> GetPastriesByPastryFillingGroupForStockAsync(int pastryFilling);
        ValueTask<IEnumerable<Pastry>> GetPastriesByPastryTypeAsync(IEnumerable<PastryType> pastryTypes);
        ValueTask<IEnumerable<Pastry>> GetPastriesByPastryTypeAsync(PastryType pastryType);
        ValueTask<IEnumerable<Pastry>> GetPastriesByPastryTypeAsync(IEnumerable<int> pastryTypes);
        ValueTask<IEnumerable<Pastry>> GetPastriesByPastryTypeAsync(int pastryType);
        ValueTask<IEnumerable<Pastry>> GetPastriesByPastryTypeGroupForStockAsync(IEnumerable<int> pastryTypes);
        ValueTask<IEnumerable<Pastry>> GetPastriesByPastryTypeGroupForStockAsync(int pastryType);
        ValueTask<IEnumerable<Pastry>> GetPastriesByPastryTypeGroupForStockAsync(IEnumerable<PastryType> pastryTypes);
        ValueTask<IEnumerable<Pastry>> GetPastriesByPastryTypeGroupForStockAsync(PastryType pastryType);
        ValueTask<IEnumerable<Pastry>> GetPastriesByPastryStockCompositeKey(PastryStockCompositeKey pastryCompositeKey);
        ValueTask<IEnumerable<Pastry>> GetPastriesByPriceAsync(decimal price);
        ValueTask<IEnumerable<Pastry>> GetPastriesByPriceAsync(IEnumerable<decimal> prices);
        ValueTask<IEnumerable<Pastry>> GetPastriesByPriceGroupByStockAsync(decimal price);
        ValueTask<IEnumerable<Pastry>> GetPastriesByPriceGroupByStockAsync(IEnumerable<decimal> prices);
    }
}