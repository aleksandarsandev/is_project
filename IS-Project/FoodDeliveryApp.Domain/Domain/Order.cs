using FoodDeliveryApp.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliveryApp.Domain.Domain
{
    public class Order :BaseEntity
    {
        public Customer? customer { get; set; }
        public string? customerId { get; set; }
        public FoodItem? foodItem { get; set; }
        public Guid? foodItemId { get; set; }
        public int quantity { get; set; }
    }
}
