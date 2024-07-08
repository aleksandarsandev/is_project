using FoodDeliveryApp.Domain.Domain.OtherApp;
using FoodDeliveryApp.Domain.Domain.OtherApp.dto;
using FoodDeliveryApp.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FoodDeliveryApp.Repository.Implementation
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly OtherAppDbContext _context;

        public ShoppingCartRepository(OtherAppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ShoppingCartDto>> GetAllShoppingCartsWithDetailsAsync()
        {
            var shoppingCarts = await _context.OtherAppShoppingCarts
                .Select(sc => new ShoppingCartDto
                {
                    Id = sc.Id,
                    OwnerId = sc.OwnerId,
                    Type = sc.Type,
                    VehicleName = sc.VehicleName,
                    VehicleColor = sc.VehicleColor,
                    CompanyName = sc.CompanyName,
                    Price = sc.Price,
                    VehicleParts = _context.OtherAppShoppingCartVehicleParts
                        .Where(scvp => scvp.ShoppingCartsId == sc.Id)
                        .Select(scvp => new VehiclePartDto
                        {
                            Id = scvp.ProductShoppingCarts.Id,
                            Name = scvp.ProductShoppingCarts.Name,
                            Price = scvp.ProductShoppingCarts.Price,
                            Description = scvp.ProductShoppingCarts.Description,
                            Manufacturer = scvp.ProductShoppingCarts.Manufacturer,
                            VehicleFormulaId = scvp.ProductShoppingCarts.VehicleFormulaId,
                            Image = scvp.ProductShoppingCarts.Image
                        })
                        .ToList()
                })
                .ToListAsync();

            return shoppingCarts;
        }
        public async Task<ShoppingCartDto> GetShoppingCartWithDetailsAsync(Guid id)
        {
            var shoppingCart = await _context.OtherAppShoppingCarts
                .Where(sc => sc.Id == id)
                .Select(sc => new ShoppingCartDto
                {
                    Id = sc.Id,
                    OwnerId = sc.OwnerId,
                    Type = sc.Type,
                    VehicleName = sc.VehicleName,
                    VehicleColor = sc.VehicleColor,
                    CompanyName = sc.CompanyName,
                    Price = sc.Price,
                    VehicleParts = _context.OtherAppShoppingCartVehicleParts
                        .Where(scvp => scvp.ShoppingCartsId == sc.Id)
                        .Select(scvp => new VehiclePartDto
                        {
                            Id = scvp.ProductShoppingCarts.Id,
                            Name = scvp.ProductShoppingCarts.Name,
                            Price = scvp.ProductShoppingCarts.Price,
                            Description = scvp.ProductShoppingCarts.Description,
                            Manufacturer = scvp.ProductShoppingCarts.Manufacturer,
                            VehicleFormulaId = scvp.ProductShoppingCarts.VehicleFormulaId,
                            Image = scvp.ProductShoppingCarts.Image
                        })
                        .ToList()
                })
                .FirstOrDefaultAsync();

            return shoppingCart;
        }
    }

}
