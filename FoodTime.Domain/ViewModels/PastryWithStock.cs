using FoodTime.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTime.Domain.Data.ViewModels
{
    public class PastryWithStock
    {
        public Pastry Pastry { get; set; }
        public int Stock { get; set; }
    }
}
