using FoodDeliveryApp.Domain.Domain;
using FoodDeliveryApp.Repository.Interface;
using FoodDeliveryApp.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliveryApp.Service.Implementation
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRepository<Restaurant> _restaurantRepository;

        public RestaurantService(IRepository<Restaurant> restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

        public void CreateNewRestaurant(Restaurant r)
        {
            _restaurantRepository.Insert(r);
        }

        public void DeleteRestaurant(Guid id)
        {
            Restaurant restaurant = _restaurantRepository.Get(id);
            _restaurantRepository.Delete(restaurant);
        }

        public List<Restaurant> GetAllRestaurants()
        {
            return _restaurantRepository.GetAll().ToList();
        }

        public Restaurant GetDetailsForRestaurant(Guid? id)
        {
            return _restaurantRepository.Get(id);
        }

        public void UpdateExistingRestaurant(Restaurant r)
        {
            _restaurantRepository.Update(r);
        }
    }
}
