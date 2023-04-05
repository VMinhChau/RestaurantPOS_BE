using Microsoft.AspNetCore.Mvc;
using RestaurantPOS.Dtos.Category.Request;
using RestaurantPOS.Dtos.Category.Response;
using RestaurantPOS.Service.Interface;

namespace RestaurantPOS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;
        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<CategoryDto> GetAsync([FromRoute] int id)
        {
            return await _service.GetAsync(id);
        }

        [HttpGet]
        public async Task<List<CategoryDto>> GetAsync()
        {
            return await _service.GetAsync();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task DeleteAsync([FromRoute] int id)
        {
            await _service.DeleteAsync(id);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<CategoryDto> UpdateAsync([FromRoute] int id, [FromBody] UpdateCategoryDto input)
        {
            return await _service.UpdateAsync(id, input);
        }

        [HttpPost]
        public async Task<CategoryDto> CreateAsync([FromBody] CreateCategoryDto input)
        {
            return await _service.CreateAsync(input);
        }
    }
}
