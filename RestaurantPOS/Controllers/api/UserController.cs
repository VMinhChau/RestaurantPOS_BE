using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RestaurantPOS.Core.Enums;
using RestaurantPOS.Dtos.User.Request;
using RestaurantPOS.Dtos.User.Response;
using RestaurantPOS.Service.Interface;

namespace RestaurantPOS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // [Authorize(Roles = "AdminOnly")]
    public class UserController : Controller
    {
        private readonly IUserService _service;
        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var users = await _service.GetAsync();
            return View(users);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<UserDto> GetAsync([FromRoute] Guid id)
        {
            return await _service.GetAsync(id);
        }

        // [HttpDelete]
        // [Route("{id}")]
        // public async Task DeleteAsync([FromRoute] Guid id)
        // {
        //     await _service.DeleteAsync(id);
        // }

        [HttpPost]
        [Route("delete_user/{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] Guid id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<UserDto> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateUserDto input)
        {
            return await _service.UpdateAsync(id, input);
        }

        // [HttpPost]
        // public async Task<UserDto> CreateAsync([FromBody] CreateUserDto input)
        // {
        //     return await _service.CreateAsync(input);
        // }

        [HttpGet]
        [Route("add_user")]
        public async Task<IActionResult> AddUser()
        {
            // var genders =  _service.GetCate();
            var model = new CreateUserDto();
            model.Genders = new List<SelectListItem>
            {
                new SelectListItem {Text = "Male", Value = "true"},
                new SelectListItem {Text = "Female", Value = "false"}
            };
            // model.Genders = GenderUser;
            return View(model);
        }

        [HttpPost]
        [Route("add_user")]
        public async Task<IActionResult> AdUser([FromForm] CreateUserDto input)
        {
            await _service.CreateAsync(input);
            return RedirectToAction(nameof(Index));
            // return View(input);
        }

        [HttpPost]
        [Route("{id}/image")]
        public async Task<IActionResult> UploadImage([FromRoute] Guid id, IFormFile file)
        {
            // Save the image file to the file system
            var filename = Path.GetFileName(file.FileName);
            var directory = Path.Combine("Content", $"Images\\{id}");
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
