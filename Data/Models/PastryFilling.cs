﻿using System.ComponentModel.DataAnnotations;

namespace FoodTime.Data.Models
{
    public class PastryFilling
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}