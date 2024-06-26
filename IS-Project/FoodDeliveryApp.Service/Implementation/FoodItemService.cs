using FoodDeliveryApp.Domain.Domain;
using FoodDeliveryApp.Repository;
using FoodDeliveryApp.Repository.Interface;
using FoodDeliveryApp.Service.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliveryApp.Service.Implementation
{
    public class FoodItemService : IFoodItemService
    {
        private readonly IRepository<FoodItem> _foodsRepository;
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly ApplicationDbContext _context;


        public FoodItemService(IRepository<FoodItem> foodsRepository, IRestaurantRepository restaurantRepository, ApplicationDbContext context)
        {
            _foodsRepository = foodsRepository;
            _restaurantRepository = restaurantRepository;
            _context = context;
        }

        public void CreateNewFoodItem(FoodItem f)
        {
            _foodsRepository.Insert(f);
        }

        public void DeleteFoodItem(Guid id)
        {
            FoodItem food = _foodsRepository.Get(id);
            _foodsRepository.Delete(food);
        }

        public List<FoodItem> GetAllFoodItems()
        {
            return _foodsRepository.GetAll().ToList();
        }

        public FoodItem GetDetailsForFoodItem(Guid? id)
        {
            return _foodsRepository.Get(id);
        }

        public void UpdateExistingFoodItem(FoodItem foodItem)
        {
            var existingFoodItem = _foodsRepository.Get(foodItem.Id);

            if (existingFoodItem == null)
            {
                throw new ArgumentException("Food item not found");
            }

            // Update properties of the existing entity
            existingFoodItem.Name = foodItem.Name;
            existingFoodItem.Price = foodItem.Price;
            existingFoodItem.Weight = foodItem.Weight;

            // Mark the existing entity as modified
            _context.Entry(existingFoodItem).State = EntityState.Modified;

            _context.SaveChanges();
        }

    }
}
