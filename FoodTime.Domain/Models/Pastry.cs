using FoodTime.Infrastructure.Abstractions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FoodTime.Infrastructure.Interfaces;

namespace FoodTime.Infrastructure.Models
{

    public class Pastry : Food, IAggregateRoot
    {
        private int _id;
        private string _name;
        private string _description;
        private int _pastryDoughId;
        private int _pastryFillingId;
        public int PastryDoughId { get => _pastryDoughId; set => _pastryDoughId = value; }
        public int PastryFillingId { get => _pastryFillingId; set => _pastryFillingId = value; }
        [Required]
        public PastryDough PastryDough { get; set; }
        [Required]
        public PastryFilling PastryFilling { get; set; }
        public override int Id { get => _id; set => _id = value; }
        public override string Name { get => _name; set => _name = value; }
        public override string Description { get => _description; set => _description = value; }
        [NotMapped]
        public override decimal Price
        {
            get
            {
               return PastryDough.Price + PastryFilling.Price;
            }
            set
            {
            }
        }

    }
}