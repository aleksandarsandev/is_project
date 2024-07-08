using FoodDeliveryApp.Domain.Domain.OtherApp;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliveryApp.Repository
{
    public class OtherAppDbContext : DbContext
    {
        public OtherAppDbContext(DbContextOptions<OtherAppDbContext> options)
            : base(options)
        {
        }

        public DbSet<OtherAppOrder> OtherAppOrders { get; set; }
        public DbSet<OtherAppShoppingCart> OtherAppShoppingCarts { get; set; }
        public DbSet<OtherAppShoppingCartVehiclePart> OtherAppShoppingCartVehicleParts { get; set; }
        public DbSet<OtherAppVehicleFormula> OtherAppVehicleFormulas { get; set; }
        public DbSet<OtherAppVehiclePart> OtherAppVehicleParts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure mappings for OtherAppOrder
            modelBuilder.Entity<OtherAppOrder>(entity =>
            {
                entity.ToTable("Orders"); // Specify the table name
                entity.HasKey(e => e.Id);
                entity.Property(e => e.UserId).HasColumnName("UserId");
                entity.Property(e => e.ApplicationUserId).HasColumnName("ApplicationUserId");
                entity.Property(e => e.ShoppingCardId).HasColumnName("ShoppingCardId");
                entity.Property(e => e.ShoppingCartId).HasColumnName("ShoppingCartId");
                entity.Property(e => e.IsDone).HasColumnName("IsDone");
            });

            // Configure mappings for OtherAppShoppingCart
            modelBuilder.Entity<OtherAppShoppingCart>(entity =>
            {
                entity.ToTable("ShoppingCarts"); // Specify the table name
                entity.HasKey(e => e.Id);
                entity.Property(e => e.OwnerId).HasColumnName("OwnerId");
                entity.Property(e => e.Type).HasColumnName("Type");
                entity.Property(e => e.VehicleName).HasColumnName("VehicleName");
                entity.Property(e => e.VehicleColor).HasColumnName("VehicleColor");
                entity.Property(e => e.CompanyName).HasColumnName("CompanyName");
                entity.Property(e => e.Price).HasColumnName("Price");
            });

            modelBuilder.Entity<OtherAppShoppingCartVehiclePart>(entity =>
            {
                entity.ToTable("ShoppingCartVehicleParts"); // Specify the table name

                // Define composite key since you mentioned both ProductShoppingCartsId and ShoppingCartsId form the key
                entity.HasKey(e => new { e.ProductShoppingCartsId, e.ShoppingCartsId });

                // Map properties to correct column names
                entity.Property(e => e.ProductShoppingCartsId).HasColumnName("ProductShoppingCartsId");
                entity.Property(e => e.ShoppingCartsId).HasColumnName("ShoppingCartsId");

                // Define relationships
                entity.HasOne(e => e.ProductShoppingCarts) // Assuming this is the navigation property to OtherAppVehiclePart
                      .WithMany() // Adjust with .WithMany if it's a collection navigation property
                      .HasForeignKey(e => e.ProductShoppingCartsId);

                entity.HasOne(e => e.ShoppingCart) // Assuming this is the navigation property to OtherAppShoppingCart
                      .WithMany() // Adjust with .WithMany if it's a collection navigation property
                      .HasForeignKey(e => e.ShoppingCartsId);
            });

            // Configure mappings for OtherAppVehicleFormula
            modelBuilder.Entity<OtherAppVehicleFormula>(entity =>
            {
                entity.ToTable("VehicleFormulas"); // Specify the table name
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).HasColumnName("Name");
                entity.Property(e => e.Engines).HasColumnName("engines");
                entity.Property(e => e.Chassis).HasColumnName("chassis");
                entity.Property(e => e.Doors).HasColumnName("doors");
                entity.Property(e => e.Wheels).HasColumnName("wheels");
                entity.Property(e => e.Image).HasColumnName("image");
            });

            // Configure mappings for OtherAppVehiclePart
            modelBuilder.Entity<OtherAppVehiclePart>(entity =>
            {
                entity.ToTable("VehicleParts"); // Specify the table name
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).HasColumnName("Name");
                entity.Property(e => e.Price).HasColumnName("Price");
                entity.Property(e => e.Description).HasColumnName("Description");
                entity.Property(e => e.Manufacturer).HasColumnName("Manufacturer");
                entity.Property(e => e.VehicleFormulaId).HasColumnName("VehicleFormulaId");
                entity.Property(e => e.Image).HasColumnName("image");
            });
        }
    }
}
