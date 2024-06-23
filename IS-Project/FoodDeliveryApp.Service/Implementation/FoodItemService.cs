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
    public class FoodItemService : IFoodItemService
    {
        private readonly IRepository<FoodItem> _foodsRepository;

        public FoodItemService(IRepository<FoodItem> foodsRepository)
        {
            _foodsRepository = foodsRepository;
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

        public void UpdateExistingFoodItem(FoodItem f)
        {
            _foodsRepository.Update(f);
        }
    }
}
