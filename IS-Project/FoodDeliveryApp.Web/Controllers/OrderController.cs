﻿using FoodDeliveryApp.Domain.Domain;
using FoodDeliveryApp.Domain.Identity;
using FoodDeliveryApp.Service.Implementation;
using FoodDeliveryApp.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace FoodDeliveryApp.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IFoodItemService _foodItemService;
        private readonly IRestaurantService _restaurantService;
        private readonly UserManager<Customer> _userManager;
        private readonly IOrderService _orderService;

        public OrderController(IFoodItemService foodItemService, IRestaurantService restaurantService, UserManager<Customer> userManager, IOrderService orderService)
        {
            _foodItemService = foodItemService;
            _restaurantService = restaurantService;
            _userManager = userManager;
            _orderService = orderService;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Order(Guid foodItemId)
        {
            var foodItem = _foodItemService.GetDetailsForFoodItem(foodItemId);

            if (foodItem == null)
            {
                return NotFound();
            }

            return View(foodItem);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Order(Guid Id, int quantity)
        {
            var foodItem = _foodItemService.GetDetailsForFoodItem(Id);

            if (foodItem == null)
            {
                return NotFound();
            }

            var user = await _userManager.GetUserAsync(User);

            // Ensure DeliveryOrder is loaded
            user = _userManager.Users
                .Include(u => u.DeliveryOrder)
                .ThenInclude(o => o.Orders)
                .FirstOrDefault(u => u.Id == user.Id);

            if (user == null || user.DeliveryOrder == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var order = new Order
            {
                DeliveryOrderId = user.DeliveryOrder.Id,
                FoodItemId = Id,
                Quantity = quantity,
                FoodItem = foodItem // Ensure FoodItem is associated with the Order
            };

            user.DeliveryOrder.Orders.Add(order);

            user.DeliveryOrder.TotalAmount += foodItem.Price * order.Quantity;
            await _userManager.UpdateAsync(user);

            //_orderService.CreateNewOrder(order);

            return RedirectToAction("Index", "Home"); // Redirect to home or other page after ordering
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Orders()
        {
            var user = await _userManager.GetUserAsync(User);

            // Ensure DeliveryOrder is loaded
            user = _userManager.Users
                .Include(u => u.DeliveryOrder)
                .ThenInclude(o => o.Orders)
                .ThenInclude(order => order.FoodItem)
                .FirstOrDefault(u => u.Id == user.Id);

            if (user == null || user.DeliveryOrder == null)
            {
                return NotFound();
            }

            return View(user.DeliveryOrder);
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> OrderConfirmation()
        {
            var user = await _userManager.GetUserAsync(User);

            // Ensure DeliveryOrder is loaded
            user = _userManager.Users
                .Include(u => u.DeliveryOrder)
                .FirstOrDefault(u => u.Id == user.Id);

            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            return View(user.DeliveryOrder);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ConfirmOrder()
        {
            var user = await _userManager.GetUserAsync(User);

            user = _userManager.Users
                .Include(u => u.DeliveryOrder)
                .FirstOrDefault(u => u.Id == user.Id);

            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            user.DeliveryOrder.OrderDate = DateTime.Now;

            // Reset the user's delivery order after confirming
            user.DeliveryOrder = new DeliveryOrder();
            await _userManager.UpdateAsync(user);

            return RedirectToAction("Index", "Home"); // Redirect to home or other page after confirming the order
        }
    }
}