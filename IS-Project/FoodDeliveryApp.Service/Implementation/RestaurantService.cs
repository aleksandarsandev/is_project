using FoodDeliveryApp.Domain.Domain;
using FoodDeliveryApp.Repository;
using FoodDeliveryApp.Repository.Interface;
using FoodDeliveryApp.Service.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliveryApp.Service.Implementation
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IRepository<FoodItem> _foodItemRepository;
        private readonly ApplicationDbContext _context;

        public RestaurantService(
                IRestaurantRepository restaurantRepository,
                IRepository<FoodItem> foodItemRepository,
                ApplicationDbContext context)
        {
            _restaurantRepository = restaurantRepository;
            _foodItemRepository = foodItemRepository;
            _context = context;
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

        public async Task<Restaurant> GetDetailsForRestaurantAsync(Guid? id)
        {
            return await _restaurantRepository.GetDetailsAsync(id);
        }

        public void UpdateExistingRestaurant(Restaurant r)
        {
            _restaurantRepository.Update(r);
        }
        public async Task<FoodItem> AddFoodItemAsync(Guid restaurantId, FoodItem foodItem)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    var restaurant = await _restaurantRepository.GetDetailsAsync(restaurantId);

                    if (restaurant == null)
                    {
                        throw new ArgumentException($"Restaurant with ID {restaurantId} not found.");
                    }

                    foodItem.RestaurantId = restaurantId;
                    _foodItemRepository.Insert(foodItem);

                    restaurant.FoodItems.Add(foodItem);
                    _restaurantRepository.Update(restaurant);

                    await _context.SaveChangesAsync(); // Save changes to database

                    await transaction.CommitAsync(); // Commit transaction

                    return foodItem;
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync(); // Rollback transaction on error
                    throw new Exception("Failed to add food item", ex);
                }
            }
        }

        Restaurant IRestaurantService.GetDetailsForRestaurant(Guid? id)
        {
            return _restaurantRepository.Get(id);
        }

        public async Task<bool> DeleteFoodItemAsync(Guid restaurantId, Guid foodItemId)
        {
            try
            {
                var restaurant = await _restaurantRepository.GetDetailsAsync(restaurantId);

                if (restaurant == null)
                {
                    throw new ArgumentException($"Restaurant with ID {restaurantId} not found.");
                }

                var foodItem = restaurant.FoodItems.FirstOrDefault(fi => fi.Id == foodItemId);

                if (foodItem == null)
                {
                    throw new ArgumentException($"Food item with ID {foodItemId} not found in restaurant.");
                }

                restaurant.FoodItems.Remove(foodItem);
                _foodItemRepository.Delete(foodItem); 

                await _context.SaveChangesAsync(); 

                return true; 
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to delete food item", ex);
            }
        }


    }
}
