using FoodTime.Infrastructure.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTime.Infrastructure.Models
{
    public class PastryType : IAggregateRoot
    {
        public int PastryFillingId { get; set; }
        public int PastryDoughId { get; set; }
        public int Stock { get; set; }
        public byte[] Image { get; set; }

        public virtual PastryFilling PastryFilling { get; set; }
        public virtual PastryDough PastryDough { get; set; }
    }
}
