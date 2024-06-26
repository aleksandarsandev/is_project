using EShopAdminApplication_2.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace EShopAdminApplication_2.Controllers
{
    public class FoodItemController : Controller
    {
        private readonly HttpClient _httpClient;

        public FoodItemController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://localhost:5165/");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }
        public IActionResult Index()
        {
            return View();
        }
        // GET: FoodItem/Delete/{restaurantId}/{foodItemId}
        [HttpGet("Delete/{foodItemId}")]
        public async Task<IActionResult> Delete(Guid restaurantId, Guid foodItemId)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.DeleteAsync($"api/Management/DeleteFoodItem/{foodItemId}");

                if (response.IsSuccessStatusCode)
                {
                    // Handle success
                    return RedirectToAction("Details", "Restaurant", new { id = restaurantId });
                }
                else
                {
                    // Handle failure
                    return RedirectToAction("Details", "Restaurant", new { id = restaurantId, error = "Failed to delete food item." });
                }
            }
            catch (Exception ex)
            {
                // Handle exception
                return RedirectToAction("Details", "Restaurant", new { id = restaurantId, error = "Error: " + ex.Message });
            }
        }
        // GET: FoodItem/Details/{id}
        public async Task<IActionResult> Details(Guid id)
        {
            var response = await _httpClient.GetAsync($"api/Management/GetFoodItem/{id}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var foodItem = JsonConvert.DeserializeObject<FoodItem>(content);
                return View(foodItem);
            }
            else
            {
                // Handle error
                return RedirectToAction("Index", "Restaurant"); // Redirect to restaurant list or error page
            }
        }
        // GET: FoodItem/Edit/{id}
        public async Task<IActionResult> Edit(Guid id)
        {
            var response = await _httpClient.GetAsync($"api/Management/GetFoodItem/{id}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var foodItem = JsonConvert.DeserializeObject<FoodItem>(content);
                return View(foodItem);
            }
            else
            {
                // Handle error
                return RedirectToAction("Index", "Restaurant"); // Redirect to restaurant list or error page
            }
        }

        // POST: FoodItem/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Price,Weight,RestaurantId")] FoodItem foodItem)
        {
            if (id != foodItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var response = await _httpClient.PutAsJsonAsync($"api/Management/UpdateFoodItem", foodItem);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Details", "Restaurant", new { id = foodItem.RestaurantId });
                }
                else
                {
                    // Handle error
                    ModelState.AddModelError(string.Empty, "An error occurred while updating the food item.");
                }
            }

            return View(foodItem);
        }



    }
}
