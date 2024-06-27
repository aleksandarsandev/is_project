using EShopAdminApplication_2.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace EShopAdminApplication_2.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly HttpClient _httpClient;

        public RestaurantController()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:5165/"),
                DefaultRequestHeaders =
                {
                    Accept = { new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json") }
                }
            };
        }

        public async Task<IActionResult> Index()
        {
            List<Restaurant> restaurants = new List<Restaurant>();
            HttpResponseMessage response = await _httpClient.GetAsync("api/Management/GetRestaurants");
            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                restaurants = JsonConvert.DeserializeObject<List<Restaurant>>(jsonResponse);
            }
            return View(restaurants);
        }
        // GET: Restaurant/Edit/{id}
        public async Task<IActionResult> Edit(Guid id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Management/GetRestaurant/{id}");
            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                var restaurant = JsonConvert.DeserializeObject<Restaurant>(jsonResponse);
                return View(restaurant);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Restaurant restaurant)
        {
            if (id != restaurant.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    string apiUrl = $"api/Management/UpdateRestaurant/{id}";
                    string json = JsonConvert.SerializeObject(restaurant);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await _httpClient.PutAsync(apiUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index"); // Successfully updated, redirect to index
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Failed to update restaurant.");
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "An error occurred: " + ex.Message);
                }
            }
            return View(restaurant);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Prepare HttpClient and URL
                    using (var client = new HttpClient())
                    {
                        string apiUrl = "http://localhost:5165/api/Management/SaveRestaurant";

                        // Serialize restaurant object to JSON
                        string json = JsonConvert.SerializeObject(restaurant);
                        var content = new StringContent(json, Encoding.UTF8, "application/json");

                        // Send POST request
                        HttpResponseMessage response = client.PostAsync(apiUrl, content).Result;

                        // Check response status
                        if (response.IsSuccessStatusCode)
                        {
                            // Optionally, you can handle a successful response here
                            return RedirectToAction("Index"); // Redirect to order index or any other action
                        }
                        else
                        {
                            // Handle unsuccessful response
                            ModelState.AddModelError(string.Empty, "Failed to save restaurant.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle exception if any
                    ModelState.AddModelError(string.Empty, "An error occurred: " + ex.Message);
                }
            }
            return View(restaurant);
        }
        // GET: Restaurant/Delete/{id}
        public async Task<IActionResult> Delete(Guid id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Management/GetRestaurant/{id}");
            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                var restaurant = JsonConvert.DeserializeObject<Restaurant>(jsonResponse);
                return View(restaurant);
            }
            else
            {
                return RedirectToAction("Index"); // Handle error: restaurant not found
            }
        }


        // POST: Restaurant/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync($"api/Management/DeleteRestaurant/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index"); // Successfully deleted, redirect to index
            }
            else
            {
                // Handle unsuccessful delete
                HttpResponseMessage getResponse = await _httpClient.GetAsync($"api/Management/GetRestaurant/{id}");
                if (getResponse.IsSuccessStatusCode)
                {
                    string jsonResponse = await getResponse.Content.ReadAsStringAsync();
                    var restaurant = JsonConvert.DeserializeObject<Restaurant>(jsonResponse);
                    ModelState.AddModelError(string.Empty, "Failed to delete restaurant.");
                    return View("Delete", restaurant); // Return to the Delete view with the model
                }
                else
                {
                    return RedirectToAction("Index"); // Handle error: restaurant not found
                }
            }
        }
        // GET: Restaurant/Details/{id}
        public async Task<IActionResult> Details(Guid id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Management/GetRestaurant/{id}");
            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                var restaurant = JsonConvert.DeserializeObject<Restaurant>(jsonResponse);
                return View(restaurant);
            }
            else
            {
                return RedirectToAction("Index"); // Handle error: restaurant not found
            }
        }

        // GET: Restaurant/AddFoodItem/{restaurantId}
        public async Task<IActionResult> AddFoodItem(Guid restaurantId)
        {
            var restaurant = await GetRestaurantById(restaurantId);
            if (restaurant == null)
            {
                return RedirectToAction("Index");
            }

            var model = new FoodItem
            {
                RestaurantId = restaurantId
            };

            return View(model);
        }

        // POST: Restaurant/AddFoodItem/{restaurantId}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddFoodItem(Guid restaurantId, FoodItem foodItem)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Set the restaurant ID in the food item
                    foodItem.RestaurantId = restaurantId;

                    // Serialize the food item to JSON
                    string json = JsonConvert.SerializeObject(foodItem);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    // Send POST request to add food item
                    string apiUrl = $"api/Management/AddFoodItem/{restaurantId}";
                    HttpResponseMessage response = await _httpClient.PostAsync(apiUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Details", new { id = restaurantId }); // Redirect to restaurant details
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Failed to add food item.");
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "An error occurred: " + ex.Message);
                }
            }

            // If ModelState is invalid or adding food item failed, return to the view with the model
            return View(foodItem);
        }



        private async Task<Restaurant> GetRestaurantById(Guid restaurantId)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Management/GetRestaurant/{restaurantId}");
            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Restaurant>(jsonResponse);
            }
            return null;
        }
    }
}
