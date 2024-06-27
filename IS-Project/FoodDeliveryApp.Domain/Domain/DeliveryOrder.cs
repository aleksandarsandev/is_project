using FoodDeliveryApp.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliveryApp.Domain.Domain
{ 
    public class DeliveryOrder : BaseEntity
    {
        public DateTime OrderDate { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();  
        public double TotalAmount { get; set; }
        public string? Location { get; set; }
    }
}
