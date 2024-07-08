using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliveryApp.Domain.Domain.OtherApp
{
    public class OtherAppShoppingCart
    {
        public Guid Id { get; set; }
        public String? OwnerId { get; set; }
        public string? Type { get; set; }
        public string? VehicleName { get; set; }
        public string? VehicleColor { get; set; }
        public string? CompanyName { get; set; }
        public int? Price { get; set; }

        public ICollection<OtherAppShoppingCartVehiclePart> ShoppingCartVehicleParts { get; set; }
    }
}
