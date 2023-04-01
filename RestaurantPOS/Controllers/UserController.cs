using Microsoft.AspNetCore.Mvc;
using RestaurantPOS.Dtos.User.Request;
using RestaurantPOS.Dtos.User.Response;
using RestaurantPOS.Interface;

namespace RestaurantPOS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<UserDto> GetAsync([FromRoute] Guid id)
        {
            return await _service.GetAsync(id);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task DeleteAsync([FromRoute] Guid id)
        {
            await _service.DeleteAsync(id);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<UserDto> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateUserDto input)
        {
            return await _service.UpdateAsync(id, input);
        }

        [HttpPost]
        public async Task<UserDto> CreateAsync([FromBody] CreateUserDto input)
        {
            return await _service.CreateAsync(input);
        }
    }
}
