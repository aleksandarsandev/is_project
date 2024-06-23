using FoodDeliveryApp.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliveryApp.Service.Interface
{
    public interface IRestaurantService
    {
        List<Restaurant> GetAllRestaurants();
        Restaurant GetDetailsForRestaurant(Guid? id);
        void CreateNewRestaurant(Restaurant r);
        void UpdateExistingRestaurant(Restaurant r);
        void DeleteRestaurant(Guid id);
    }
}
