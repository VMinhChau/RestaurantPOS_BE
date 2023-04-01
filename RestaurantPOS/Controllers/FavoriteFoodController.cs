using Microsoft.AspNetCore.Mvc;
using RestaurantPOS.Dtos.FavoriteFood.Request;
using RestaurantPOS.Dtos.FavoriteFood.Response;
using RestaurantPOS.Interface;

namespace RestaurantPOS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteFoodController : ControllerBase
    {
        private readonly IFavoriteFoodService _service;
        public FavoriteFoodController(IFavoriteFoodService service)
        {
            _service = service;
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task DeleteAsync([FromRoute] int id)
        {
            await _service.DeleteAsync(id);
        }

        [HttpPost]
        public async Task<FavoriteFoodDto> CreateAsync([FromBody] CreateFavoriteFoodDto input)
        {
            return await _service.CreateAsync(input);
        }
    }
}
