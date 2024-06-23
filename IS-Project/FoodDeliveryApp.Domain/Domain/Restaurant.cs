using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliveryApp.Domain.Domain
{
    public class Restaurant :BaseEntity
    {
        [Required]
        public String Name { get; set; }
        [Required]
        public String Location { get; set; }
        public List<FoodItem>? foodItems { get; set; }

    }
}
