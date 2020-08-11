using FoodTime.Data.Interfaces;
using FoodTime.Exceptions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodTime.Data.Models
{

    public class Pastry : Food
    {
        private int _id { get; set; }
        private string _name { get; set; }
        private string _description { get; set; }
        private byte[] _image { get; set; }
        private int _pastryTypeId { get; set; }
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
                if (PastryType is object)
                    return PastryType.Price;
                throw new PastryTypeNotIncludedException("Please include the Pastry Type object to get the price");
            }
            set
            {
                throw new PastryPriceCannotBeSetException("The price of a pastry is determined by combining the price of the dough and the price of the filling. To update the price of the Pastry please update the price of its members");
            }
        }
        public override byte[] Image { get => _image; set => _image = value; }
    }
}