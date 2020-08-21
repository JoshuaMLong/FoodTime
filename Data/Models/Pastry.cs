using FoodTime.API.Data.Interfaces;
using FoodTime.API.Exceptions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodTime.API.Data.Models
{

    public class Pastry : Food
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
                if (PastryType is object && PastryFilling is object)
                    return PastryType.Price + PastryFilling.Price;
                throw new PastryTypeNotIncludedException("Please include the Pastry Type object to get the price");
            }
            set
            {
                throw new PastryPriceCannotBeSetException("The price of a pastry is determined by combining the price of the dough and the price of the filling. To update the price of the Pastry please update the price of its members");
            }
        }
        [NotMapped]
        public int Stock { get; set; }
    }
}