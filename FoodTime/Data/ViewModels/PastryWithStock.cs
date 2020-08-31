using FoodTime.Infrastructure.Models;

namespace FoodTime.API.Data.ViewModels
{
    public class PastryWithStock
    {
        public Pastry Pastry { get; set; }
        public int Stock { get; set; }
    }
}
