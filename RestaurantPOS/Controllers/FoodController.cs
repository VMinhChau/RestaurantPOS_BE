using Microsoft.AspNetCore.Mvc;
using RestaurantPOS.Dtos.Food.Request;
using RestaurantPOS.Dtos.Food.Response;
using RestaurantPOS.Interface;

namespace RestaurantPOS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly IFoodService _service;
        public FoodController(IFoodService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<FoodDto> GetAsync([FromRoute] int id)
        {
            return await _service.GetAsync(id);
        }

        [HttpGet]
        [Route("suggest/{id}")]
        public async Task<List<FoodDto>> GetSuggestAsync([FromRoute] int id)
        {
            return await _service.GetSuggestAsync(id);
        }

        [HttpGet]
        [Route("favorite-foods/{userId}")]
        public async Task<List<FoodDto>> GetAsync([FromRoute] Guid userId)
        {
            return await _service.GetAsync(userId);
        }

        [HttpGet]
        public async Task<List<FoodDto>> GetAsync()
        {
            return await _service.GetAsync();
        }

        [HttpGet]
        [Route("promote_foods")]
        public async Task<List<FoodDto>> GetPromotionAsync()
        {
            return await _service.GetPromotionAsync();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task DeleteAsync([FromRoute] int id)
        {
            await _service.DeleteAsync(id);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<FoodDto> UpdateAsync([FromRoute] int id, [FromBody] UpdateFoodDto input)
        {
            return await _service.UpdateAsync(id, input);
        }

        [HttpPost]
        public async Task<FoodDto> CreateAsync([FromBody] CreateFoodDto input)
        {
            return await _service.CreateAsync(input);
        }

        [HttpPost]
        [Route("{id}/image")]
        public async Task<IActionResult> UploadImage([FromRoute] int id, IFormFile file)
        {
            // Save the image file to the file system
            var filename = Path.GetFileName(file.FileName);
            var directory = Path.Combine("Content", $"Food\\{id}");
            var path = Path.Combine(directory, filename);

            // Create the directory if it does not exist
            Directory.CreateDirectory(directory);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            await _service.UploadImageAsync(id, path);

            return Ok("Image uploaded successfully.");
        }
    }
}
