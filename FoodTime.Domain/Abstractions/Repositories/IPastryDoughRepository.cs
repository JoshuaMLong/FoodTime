using FoodTime.Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodTime.Infrastructure.Interfaces
{
    public interface IPastryDoughRepository : IBaseRepository<PastryDough>
    {
        ValueTask<PastryDough> GetPastryDoughByIdAsync(int id);
        ValueTask<IEnumerable<PastryDough>> GetPastryDoughsAsync();
        ValueTask<IEnumerable<PastryDough>> GetPastryDoughsByIdAsync(IEnumerable<int> ids);
        ValueTask<IEnumerable<PastryDough>> GetPastryDoughsByNameAsync(IEnumerable<string> names);
        ValueTask<IEnumerable<PastryDough>> GetPastryDoughsByNameAsync(string name);
        ValueTask<IEnumerable<PastryDough>> GetPastryDoughsByPriceAsync(decimal price);
        ValueTask<IEnumerable<PastryDough>> GetPastryDoughsByPriceAsync(IEnumerable<decimal> prices);
    }
}