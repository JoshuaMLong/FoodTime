using FoodTime.Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodTime.Infrastructure.Interfaces
{
    public interface IPastryFillingRepository : IBaseRepository<PastryFilling>
    {
        ValueTask<IEnumerable<PastryFilling>> GetPastryFillingsAsync();
        ValueTask<IEnumerable<PastryFilling>> GetPastryFillingsByIdAsync(IEnumerable<int> ids);
        ValueTask<PastryFilling> GetPastryFillingsByIdAsync(int id);
        ValueTask<IEnumerable<PastryFilling>> GetPastryFillingsByNameAsync(IEnumerable<string> names);
        ValueTask<IEnumerable<PastryFilling>> GetPastryFillingsByNameAsync(string name);
        ValueTask<IEnumerable<PastryFilling>> GetPastryFillingsByPriceAsync(decimal price);
        ValueTask<IEnumerable<PastryFilling>> GetPastryFillingsByPriceAsync(IEnumerable<decimal> prices);
    }
}