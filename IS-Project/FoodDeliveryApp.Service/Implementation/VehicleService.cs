using FoodDeliveryApp.Domain.Domain.OtherApp;
using FoodDeliveryApp.Repository.Interface;
using FoodDeliveryApp.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliveryApp.Service.Implementation
{
 public class VehicleService : IVehicleService
    {
        private readonly IVehicleFormulaRepository _vehicleFormulaRepository;

        public VehicleService(IVehicleFormulaRepository vehicleFormulaRepository)
        {
            _vehicleFormulaRepository = vehicleFormulaRepository;
        }

        public async Task<IEnumerable<OtherAppVehicleFormula>> GetAllVehiclesAsync()
        {
            return await _vehicleFormulaRepository.GetAllAsync();
        }

        public async Task<OtherAppVehicleFormula> GetVehicleByIdAsync(Guid id)
        {
            var vehicle = await _vehicleFormulaRepository.GetByIdAsync(id);
            if (vehicle != null)
            {
                // Convert IEnumerable to ICollection
                vehicle.VehicleParts = new List<OtherAppVehiclePart>(await _vehicleFormulaRepository.GetVehiclePartsByFormulaIdAsync(id));
            }
            return vehicle;
        }
    }
}
