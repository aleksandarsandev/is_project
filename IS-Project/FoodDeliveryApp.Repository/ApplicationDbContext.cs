using FoodDeliveryApp.Domain.Domain;
using FoodDeliveryApp.Domain.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;

namespace FoodDeliveryApp.Repository
{
    public class ApplicationDbContext : IdentityDbContext<Customer>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Restaurant> Restaurants { get; set; }
        public virtual DbSet<FoodItem> FoodItems { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<DeliveryOrders> DeliveryOrders { get; set; }
    }
}
