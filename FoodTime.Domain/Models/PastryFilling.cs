using FoodTime.Infrastructure.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace FoodTime.Infrastructure.Models
{
    public class PastryFilling : IAggregateRoot
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}