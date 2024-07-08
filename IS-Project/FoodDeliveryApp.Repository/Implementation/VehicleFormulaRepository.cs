using FoodDeliveryApp.Domain.Domain.OtherApp;
using FoodDeliveryApp.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliveryApp.Repository.Implementation
{
    public class VehicleFormulaRepository : OtherAppRepository<OtherAppVehicleFormula>, IVehicleFormulaRepository
    {
        private readonly OtherAppDbContext _context;

        public VehicleFormulaRepository(OtherAppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OtherAppVehiclePart>> GetVehiclePartsByFormulaIdAsync(Guid vehicleFormulaId)
        {
            return await _context.OtherAppVehicleParts
                .Where(vp => vp.VehicleFormulaId == vehicleFormulaId)
                .ToListAsync();
        }
    }
}
