using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliveryApp.Repository
{
    public class OtherAppDbContextFactory : IDesignTimeDbContextFactory<OtherAppDbContext>
    {
        public OtherAppDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<OtherAppDbContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("OtherAppDatabase"));

            return new OtherAppDbContext(optionsBuilder.Options);
        }
    }
}
