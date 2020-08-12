using FoodTime.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTime.Data.ViewModels
{
    public class PastryWithStock
    {
        public Pastry Pastry { get; set; }
        public int Stock { get; set; }
    }
}
