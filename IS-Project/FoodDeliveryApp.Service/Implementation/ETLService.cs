using FoodDeliveryApp.Domain.Domain;
using FoodDeliveryApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliveryApp.Service.Implementation
{
    public class ETLService
    {
        private readonly ApplicationDbContext _mainDbContext;
        private readonly OtherAppDbContext _otherAppDbContext;

        public ETLService(ApplicationDbContext mainDbContext, OtherAppDbContext otherAppDbContext)
        {
            _mainDbContext = mainDbContext;
            _otherAppDbContext = otherAppDbContext;
        }

        public void ExtractTransformLoad()
        {
            //// Extract data from the other database
            //var otherAppOrders = _otherAppDbContext.OtherAppOrders.ToList();
            //var otherAppShoppingCarts = _otherAppDbContext.OtherAppShoppingCarts.ToList();
            //var otherAppShoppingCartVehicleParts = _otherAppDbContext.OtherAppShoppingCartVehicleParts.ToList();
            //var otherAppVehicleFormulas = _otherAppDbContext.OtherAppVehicleFormulas.ToList();
            //var otherAppVehicleParts = _otherAppDbContext.OtherAppVehicleParts.ToList();

            //// Transform data if necessary (e.g., map to main database entities)
            ////var transformedOrders = otherAppOrders.Select(o => new Order
            ////{
            ////    // Map properties accordingly
            ////    OrderDetails = o.OrderDetails,
            ////    // Other properties
            ////}).ToList();

            //// Load data into the main database
            //_mainDbContext.Orders.AddRange(transformedOrders);
            //_mainDbContext.SaveChanges();
        }
    }
}
