using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RestaurantPOS.Dtos.Category.Response;
using RestaurantPOS.Dtos.Food.Request;
using RestaurantPOS.Dtos.Food.Response;
using RestaurantPOS.Service.Interface;

namespace RestaurantPOS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : Controller
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
        public async Task<IActionResult> Index()
        {
            var foods = await _service.GetAsync();
            return View(foods);
        }

        [HttpGet]
        [Route("promote_foods")]
        public async Task<List<FoodDto>> GetPromotionAsync()
        {
            return await _service.GetPromotionAsync();
        }

        // [HttpGet]
        // [Route("delete_food/{id}")]
        // public IActionResult DeleteFood()
        // {
        //     return View();
        // }

        [HttpPost]
        [Route("delete_food/{id}")]
        public async Task<IActionResult> DeleteFood([FromRoute] int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Route("edit_food/{id}")]
        public async Task<IActionResult> EditFood([FromRoute] int id)
        {
            var food = await _service.GetAsync(id);
            var categories =  _service.GetCate();
            // var model = new FoodDto();
            food.Categories = categories;
            return View(food);
        }

        [HttpPost]
        [Route("edit_food/{id}")]
        public async Task<IActionResult> EditFood([FromRoute] int id, [FromForm] UpdateFoodDto input)
        {
            var food = await _service.UpdateAsync(id, input);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Route("add_food")]
        public async Task<IActionResult> AddFood()
        {
            // ViewData["CategoryId"] = new SelectList(_context.Set<Category>(), "CategoryId", "Name",model.CategoryId);
            var categories =  _service.GetCate();
            var model = new FoodDto();
            model.Categories = categories;
            // model.Categories = new SelectList((System.Collections.IEnumerable)categories, "Id", "Name");
            // SelectList list = new SelectList((System.Collections.IEnumerable)categories, "Id", "Name");
            // ViewBag.categories = list;
            return View(model);
        }

        [HttpPost]
        [Route("add_food")]
        public async Task<IActionResult> AddFood([FromForm] CreateFoodDto input)
        {
            
            
            await _service.CreateAsync(input);

            return RedirectToAction(nameof(Index));
            
        }

        [HttpPost]
        [Route("edit_food/{id}/image")]
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
