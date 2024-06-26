using FoodDeliveryApp.Domain.Domain;
using FoodDeliveryApp.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FoodDeliveryApp.Web.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagementController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;
        private readonly IFoodItemService _foodItemService;

        public ManagementController(IRestaurantService restaurantService, IFoodItemService foodItemService)
        {
            _restaurantService = restaurantService;
            _foodItemService = foodItemService;
        }

        // GET: api/Management/GetRestaurants
        [HttpGet("GetRestaurants")]
        public IActionResult GetRestaurants()
        {
            try
            {
                var restaurants = _restaurantService.GetAllRestaurants();
                return Ok(restaurants);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/Management/GetRestaurant/{id}
        [HttpGet("GetRestaurant/{id}")]
        public async Task<IActionResult> GetRestaurant(Guid id)
        {
            try
            {
                var restaurant = await _restaurantService.GetDetailsForRestaurantAsync(id);

                if (restaurant == null)
                {
                    return NotFound();
                }

                return Ok(restaurant);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        // POST: api/Management/SaveRestaurant
        [HttpPost("SaveRestaurant")]
        public IActionResult SaveRestaurant(Restaurant restaurant)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _restaurantService.CreateNewRestaurant(restaurant);
                    return Ok();
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT: api/Management/UpdateRestaurant/{id}
        [HttpPut("UpdateRestaurant/{id}")]
        public IActionResult UpdateRestaurant(Guid id, Restaurant restaurant)
        {
            try
            {
                if (id != restaurant.Id)
                {
                    return BadRequest("Restaurant ID mismatch.");
                }

                if (ModelState.IsValid)
                {
                    _restaurantService.UpdateExistingRestaurant(restaurant);
                    return Ok();
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // DELETE: api/Management/DeleteRestaurant/{id}
        [HttpDelete("DeleteRestaurant/{id}")]
        public IActionResult DeleteRestaurant(Guid id)
        {
            try
            {
                var restaurant = _restaurantService.GetDetailsForRestaurant(id);
                if (restaurant == null)
                {
                    return NotFound();
                }

                _restaurantService.DeleteRestaurant(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
            // POST: api/Management/AddFoodItem/{restaurantId}
        [HttpPost("AddFoodItem/{restaurantId}")]
        public async Task<IActionResult> AddFoodItem(Guid restaurantId, [FromBody] FoodItem foodItem)
        {
            try
            {
                foodItem = new FoodItem(foodItem.Name, foodItem.Weight, foodItem.Price, restaurantId);
                var addedFoodItem = await _restaurantService.AddFoodItemAsync(restaurantId, foodItem);
                return Ok(addedFoodItem); // Return the added food item if successful
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to add food item: {ex.Message}");
            }
        }
        // GET: api/FoodItem/GetFoodItem/{foodItemId}
        [HttpGet("GetFoodItem/{id}")]
        public IActionResult GetFoodItem(Guid id)
        {
            try
            {
                var foodItem = _foodItemService.GetDetailsForFoodItem(id);
                if (foodItem == null)
                {
                    return NotFound();
                }
                return Ok(foodItem);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // DELETE: api/Management/DeleteFoodItem/{restaurantId}/{foodItemId}
        [HttpDelete("DeleteFoodItem/{foodItemId}")]
        public async Task<IActionResult> DeleteFoodItem(Guid foodItemId)
        {
            try
            {
                var foodItem = _foodItemService.GetDetailsForFoodItem(foodItemId);
                if(foodItem == null)
                {
                    return NotFound("Food item not found.");
                }
                var result = await _restaurantService.DeleteFoodItemAsync(foodItem.RestaurantId, foodItemId);
                if (result)
                {
                    return Ok("Food item deleted successfully.");
                }
                else
                {
                    return NotFound("Food item not found.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        // PUT: api/Management/UpdateFoodItem
        [HttpPut("UpdateFoodItem")]
        public IActionResult UpdateFoodItem([FromBody] FoodItem foodItem)
        {
            try
            {
                if (foodItem == null)
                {
                    return BadRequest("Food item is null.");
                }

                var existingFoodItem = _foodItemService.GetDetailsForFoodItem(foodItem.Id);
                if (existingFoodItem == null)
                {
                    return NotFound("Food item not found.");
                }

                // Update the entity through the service method
                _foodItemService.UpdateExistingFoodItem(foodItem);

                return Ok(foodItem);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}