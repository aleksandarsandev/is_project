using FoodDeliveryApp.Domain.Domain.OtherApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliveryApp.Service.Interface
{
    public interface IVehicleService
    {
        Task<IEnumerable<OtherAppVehicleFormula>> GetAllVehiclesAsync();
        Task<OtherAppVehicleFormula> GetVehicleByIdAsync(Guid id);
    }
}
