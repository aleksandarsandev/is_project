using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliveryApp.Domain.Domain.OtherApp.dto
{
    public class VehiclePartDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public double? Price { get; set; }
        public string? Description { get; set; }
        public string? Manufacturer { get; set; }
        public Guid? VehicleFormulaId { get; set; }
        public string? Image { get; set; }
    }
}
