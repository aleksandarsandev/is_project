using FoodDeliveryApp.Domain.Domain.OtherApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliveryApp.Repository.Interface
{
    public interface IVehicleFormulaRepository : IOtherAppRepository<OtherAppVehicleFormula>
    {
        Task<IEnumerable<OtherAppVehiclePart>> GetVehiclePartsByFormulaIdAsync(Guid vehicleFormulaId);
    }
}
