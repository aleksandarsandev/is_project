using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliveryApp.Domain.Domain
{
    public class FoodItem : BaseEntity
    {
        [Required]
        public String Name { get; set; }
        [Required]
        public int Weight { get; set; }
        [Required]

        public double Price { get; set; }
        public Guid RestaurantId { get; set; }
        public Restaurant? Restaurant { get; set; }

        public FoodItem()
        {
        }

        public FoodItem(string name, int quantity, double price, Guid restaurantId)
        {
            Name = name;
            Weight = quantity;
            Price = price;
            RestaurantId = restaurantId;
        }
    }
}
