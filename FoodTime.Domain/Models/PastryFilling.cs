using FoodTime.Domain.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace FoodTime.Domain.Models
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