using FoodDeliveryApp.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliveryApp.Service.Interface
{
    public interface IFoodItemService
    {
        List<FoodItem> GetAllFoodItems();
        FoodItem GetDetailsForFoodItem(Guid? id);
        void CreateNewFoodItem(FoodItem f);
        void UpdateExistingFoodItem(FoodItem f);
        void DeleteFoodItem(Guid id);
    }
}
