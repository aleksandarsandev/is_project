using FoodDeliveryApp.Domain.Domain;
using FoodDeliveryApp.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliveryApp.Repository.Implementation
{
    public class RestaurantRepository : Repository<Restaurant>, IRestaurantRepository
    {
        private DbSet<Restaurant> entities;
        public RestaurantRepository(ApplicationDbContext context) : base(context)
        {
            entities = context.Set<Restaurant>();
        }

        public async Task<Restaurant> GetDetailsAsync(Guid? id)
        {
            return await context.Restaurants
                                .Include(r => r.FoodItems) 
                                .FirstOrDefaultAsync(r => r.Id == id);
        }
        public IEnumerable<Restaurant> GetAll()
        {
            return entities.Include(r => r.FoodItems).AsEnumerable();
        }
    }
}
