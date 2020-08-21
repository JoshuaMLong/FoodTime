using FoodTime.API.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodTime.API.Data.Interfaces
{
    public interface IPastryTypeRepository : IBaseRepository<PastryType>
    {
        ValueTask<PastryType> GetPastryTypeByIdAsync(int id);
        ValueTask<IEnumerable<PastryType>> GetPastryTypesAsync();
        ValueTask<IEnumerable<PastryType>> GetPastryTypesByIdAsync(IEnumerable<int> ids);
        ValueTask<IEnumerable<PastryType>> GetPastryTypesByNameAsync(IEnumerable<string> names);
        ValueTask<IEnumerable<PastryType>> GetPastryTypesByNameAsync(string name);
        ValueTask<IEnumerable<PastryType>> GetPastryTypesByPriceAsync(decimal price);
        ValueTask<IEnumerable<PastryType>> GetPastryTypesByPriceAsync(IEnumerable<decimal> prices);
    }
}