using Microsoft.AspNetCore.Mvc;
using RestaurantPOS.Dtos.Comment.Request;
using RestaurantPOS.Dtos.Comment.Response;
using RestaurantPOS.Interface;

namespace RestaurantPOS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _service;
        public CommentController(ICommentService service)
        {
            _service = service;
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task DeleteAsync([FromRoute] int id)
        {
            await _service.DeleteAsync(id);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<CommentDto> UpdateAsync([FromRoute] int id, [FromBody] UpdateCommentDto input)
        {
            return await _service.UpdateAsync(id, input);
        }

        [HttpPost]
        public async Task<CommentDto> CreateAsync([FromBody] CreateCommentDto input)
        {
            return await _service.CreateAsync(input);
        }
    }
}
