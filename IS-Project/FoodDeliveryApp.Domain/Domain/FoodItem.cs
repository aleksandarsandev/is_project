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
        public int Quantity { get; set; }
        public List<Restaurant>? Restaurants { get; set; }

    }
}
