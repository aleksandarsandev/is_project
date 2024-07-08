using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliveryApp.Domain.Domain.OtherApp
{
    public class OtherAppVehicleFormula
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public int Engines { get; set; }
        public int Chassis { get; set; }
        public int Doors { get; set; }
        public int Wheels { get; set; }
        public string? Image { get; set; }

        public ICollection<OtherAppVehiclePart>? VehicleParts { get; set; }
    }
}
