﻿using System.ComponentModel.DataAnnotations;

namespace FoodTime.API.Data.Models
{
    public class PastryType
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}