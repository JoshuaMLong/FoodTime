using FoodTime.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodTime.Data.Interfaces
{
    public interface IPastryRepository : IBaseRepository<Pastry>
    {
        ValueTask<IEnumerable<Pastry>> GetAllPastriesAsync();
        ValueTask<IEnumerable<Pastry>> GetPastriesByIdAsync(IEnumerable<int> ids);
        ValueTask<Pastry> GetPastriesByIdAsync(int id);
        ValueTask<IEnumerable<Pastry>> GetPastriesByNameAsync(IEnumerable<string> names);
        ValueTask<IEnumerable<Pastry>> GetPastriesByNameAsync(string name);
        ValueTask<IEnumerable<Pastry>> GetPastriesByPastryFillingAsync(IEnumerable<PastryFilling> pastryFillings);
        ValueTask<IEnumerable<Pastry>> GetPastriesByPastryFillingAsync(PastryFilling pastryFilling);
        ValueTask<IEnumerable<Pastry>> GetPastriesByPastryTypeAsync(IEnumerable<PastryType> pastryTypes);
        ValueTask<IEnumerable<Pastry>> GetPastriesByPastryTypeAsync(PastryType pastryType);
        ValueTask<IEnumerable<Pastry>> GetPastriesByPriceAsync(decimal price);
        ValueTask<IEnumerable<Pastry>> GetPastriesByPriceAsync(IEnumerable<decimal> prices);
    }
}