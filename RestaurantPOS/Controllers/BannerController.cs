using Microsoft.AspNetCore.Mvc;
using RestaurantPOS.Dtos.Banner.Request;
using RestaurantPOS.Dtos.Banner.Response;
using RestaurantPOS.Interface;

namespace RestaurantPOS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannerController : ControllerBase
    {
        private readonly IBannerService _service;
        public BannerController(IBannerService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<BannerDto> GetAsync([FromRoute] int id)
        {
            return await _service.GetAsync(id);
        }
        
        [HttpGet]
        public async Task<List<BannerDto>> GetAsync()
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
        public async Task<BannerDto> UpdateAsync([FromRoute] int id, [FromBody] UpdateBannerDto input)
        {
            return await _service.UpdateAsync(id, input);
        }

        [HttpPost]
        public async Task<BannerDto> CreateAsync([FromBody] CreateBannerDto input)
        {
            return await _service.CreateAsync(input);
        }

        [HttpPost]
        [Route("{id}/image")]
        public async Task<IActionResult> UploadImage([FromRoute] int id, IFormFile file)
        {
            // Save the image file to the file system
            var filename = Path.GetFileName(file.FileName);
            var directory = Path.Combine("Content", $"Banner\\{id}");
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
