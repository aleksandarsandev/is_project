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
        public Restaurant GetDetailsForRestaurant(Guid? id);
        public Task<Restaurant> GetDetailsForRestaurantAsync(Guid? id);
        void CreateNewRestaurant(Restaurant r);
        void UpdateExistingRestaurant(Restaurant r);
        void DeleteRestaurant(Guid id);
        public Task<FoodItem> AddFoodItemAsync(Guid restaurantId, FoodItem foodItem);
        Task<bool> DeleteFoodItemAsync(Guid restaurantId, Guid foodItemId);
    }
}
