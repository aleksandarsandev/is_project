using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliveryApp.Repository.Interface
{
    public interface IOtherAppRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(Guid id);
    }
}
