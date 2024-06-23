using FoodDeliveryApp.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliveryApp.Domain.Domain
{
    public class DeliveryOrders:BaseEntity
    {
        public List<Order> Orders { get; set; }

    }
}
