using FoodDeliveryApp.Domain.Domain.OtherApp;
using FoodDeliveryApp.Domain.Domain.OtherApp.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliveryApp.Service.Interface
{
    public interface IShoppingCartService
    {
        Task<List<ShoppingCartDto>> GetAllShoppingCartsWithDetailsAsync();
        Task<ShoppingCartDto> GetShoppingCartWithDetailsAsync(Guid id);
    }
}
