using FoodDeliveryApp.Domain.Domain.OtherApp.dto;
using FoodDeliveryApp.Service.Implementation;
using FoodDeliveryApp.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FoodDeliveryApp.Web.Controllers.OtherAppControllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCartService _shoppingCartService;

        public ShoppingCartController(IShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }

        // GET: ShoppingCart/Index
        public async Task<IActionResult> Index()
        {
            var shoppingCarts = await _shoppingCartService.GetAllShoppingCartsWithDetailsAsync();
            return View(shoppingCarts);
        }

        // GET: ShoppingCart/Details/{id}
        public async Task<IActionResult> Details(Guid id)
        {
            var shoppingCart = await _shoppingCartService.GetShoppingCartWithDetailsAsync(id);
            if (shoppingCart == null)
            {
                return NotFound();
            }

            return View(shoppingCart);
        }
    }
}
