using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopAdminApplication_2.Models
{
    public class Restaurant :BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Location { get; set; }

        public ICollection<FoodItem> FoodItems { get; set; } = new List<FoodItem>();
    }

}

