using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTime.API.Data.Models
{
    public class PastryStock
    {
        public int PastryFillingId { get; set; }
        public int PastryTypeId { get; set; }
        public int Stock { get; set; }

        public virtual PastryFilling PastryFilling { get; set; }
        public virtual PastryType PastryType { get; set; }
    }
}
