using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTime.Infrastructure.Data.ViewModels
{
    public class PastryFillingPastryTypeGroupByWithCount
    {
        public PastryStockCompositeKey PastryClusteredKey { get; set; }
        public int Count { get; set; }
    }
}
