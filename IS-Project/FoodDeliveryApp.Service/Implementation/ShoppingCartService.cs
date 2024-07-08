using FoodDeliveryApp.Domain.Domain.OtherApp;
using FoodDeliveryApp.Domain.Domain.OtherApp.dto;
using FoodDeliveryApp.Repository.Interface;
using FoodDeliveryApp.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliveryApp.Service.Implementation
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;

        public ShoppingCartService(IShoppingCartRepository shoppingCartRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
        }

        public async Task<List<ShoppingCartDto>> GetAllShoppingCartsWithDetailsAsync()
        {
            return await _shoppingCartRepository.GetAllShoppingCartsWithDetailsAsync();
        }

        public async Task<ShoppingCartDto> GetShoppingCartWithDetailsAsync(Guid id)
        {
            return await _shoppingCartRepository.GetShoppingCartWithDetailsAsync(id);
        }
    }


}
