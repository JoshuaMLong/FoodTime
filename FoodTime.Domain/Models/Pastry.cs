using FoodTime.Domain.Abstractions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FoodTime.Domain.Interfaces;

namespace FoodTime.Domain.Models
{

    public class Pastry : Food, IAggregateRoot
    {
        private int _id;
        private string _name;
        private string _description;
        private int _pastryTypeId;
        private int _pastryFillingId;
        public int PastryTypeId { get => _pastryTypeId; set => _pastryTypeId = value; }
        public int PastryFillingId { get => _pastryFillingId; set => _pastryFillingId = value; }
        [Required]
        public PastryType PastryType { get; set; }
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
               return PastryType.Price + PastryFilling.Price;
            }
            set
            {
            }
        }
        [NotMapped]
        public int Stock { get; set; }
    }
}