using FoodDeliveryApp.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliveryApp.Repository.Interface
{
    public interface IRestaurantRepository : IRepository<Restaurant>
    {
        Task<Restaurant> GetDetailsAsync(Guid? id);
        IEnumerable<Restaurant> GetAll();

    }
}
