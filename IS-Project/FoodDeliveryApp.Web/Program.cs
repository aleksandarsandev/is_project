using FoodDeliveryApp.Domain.Identity;
using FoodDeliveryApp.Repository;
using FoodDeliveryApp.Repository.Implementation;
using FoodDeliveryApp.Repository.Interface;
using FoodDeliveryApp.Service.Implementation;
using FoodDeliveryApp.Service.Interface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// Add OtherAppDbContext
var otherAppConnectionString = builder.Configuration.GetConnectionString("OtherAppDatabase") ?? throw new InvalidOperationException("Connection string 'OtherAppDatabase' not found.");
builder.Services.AddDbContext<OtherAppDbContext>(options =>
    options.UseSqlServer(otherAppConnectionString));


// Register ETLService
builder.Services.AddTransient<ETLService>();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<Customer>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
builder.Services.AddScoped(typeof(IRestaurantRepository), typeof(RestaurantRepository));
builder.Services.AddScoped(typeof(IOtherAppRepository<>), typeof(OtherAppRepository<>)); // OtherAppRepository
builder.Services.AddScoped<IVehicleFormulaRepository, VehicleFormulaRepository>(); // VehicleFormulaRepository
builder.Services.AddScoped<IShoppingCartRepository, ShoppingCartRepository>(); // ShoppingCartRepository


builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IFoodItemService, FoodItemService>();
builder.Services.AddTransient<IRestaurantService, RestaurantService>(); 
builder.Services.AddTransient<IVehicleService, VehicleService>();   // VehicleService
builder.Services.AddTransient<IShoppingCartService, ShoppingCartService>();   // VehicleService
builder.Services.AddSingleton<BlobService>();

builder.Services.AddControllersWithViews().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
