// using Microsoft.AspNetCore.Mvc;
// using RestaurantPOS.Dtos.Category.Request;
// using RestaurantPOS.Dtos.Category.Response;
// using RestaurantPOS.Service.Interface;

// namespace RestaurantPOS.Controllers
// {
//     [Route("api/[controller]")]
//     [ApiController]
//     public class CategoryController : Controller
//     {
//         private readonly ICategoryService _service;
//         public CategoryController(ICategoryService service)
//         {
//             _service = service;
//         }

//         [HttpGet]
//         [Route("{id}")]
//         public async Task<CategoryDto> GetAsync([FromRoute] int id)
//         {
//             return await _service.GetAsync(id);
//         }

//         // [HttpGet]
//         // public async Task<IActionResult> Index()
//         // {
//         //     var cate =  await _service.GetAsync();
//         //     return View(cate);
//         // }
//         [HttpGet]
//         public async Task<List<CategoryDto>> GetAsync()
//         {
//             return await _service.GetAsync();
//         }

//         [HttpPost]
//         [Route("delete/{id}")]
//         public async Task<IActionResult> Delete([FromRoute] int id)
//         {
//             await _service.DeleteAsync(id);
//             return RedirectToAction(nameof(Index));
//         }

//         [HttpGet]
//         [Route("edit/{id}")]
//         public async Task<IActionResult> Edit([FromRoute] int id)
//         {
//             var cate = await _service.GetAsync(id);
//             return View(cate);
//         }

//         [HttpPost]
//         [Route("edit/{id}")]
//         public async Task<IActionResult> Edit([FromRoute] int id, [FromForm] UpdateCategoryDto input)
        
//         {
//             var cate = await _service.UpdateAsync(id, input);
//             return RedirectToAction(nameof(Index));
//         }

//         [HttpGet]
//         [Route("add_category")]
//         public IActionResult Add()
//         {
//             return View();
//         }

//         [HttpPost]
//         [Route("add_category")]
//         public async Task<IActionResult> Add([FromForm] CreateCategoryDto input)
//         {
//             await _service.CreateAsync(input);
//             return RedirectToAction(nameof(Index));
//         }
//     }
// }


using Microsoft.AspNetCore.Mvc;
using RestaurantPOS.Dtos.Category.Request;
using RestaurantPOS.Dtos.Category.Response;
using RestaurantPOS.Service.Interface;

namespace RestaurantPOS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
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



        // [HttpGet]
        // [Route("add_category")]
        // public IActionResult Add()
        // {
        //     return View();
        // }

        // [HttpPost]
        // [Route("add_category")]
        // public async Task<IActionResult> Add([FromForm] CreateCategoryDto input)
        // {
        //     await _service.CreateAsync(input);
        //     return RedirectToAction(nameof(Index));

        // }

        [HttpGet]
        [Route("categories")]
        public async Task<IActionResult> Index()
        {
            var cate =  await _service.GetAsync();
            return View(cate);
        }

        // [HttpPost]
        // [Route("delete/{id}")]
        // public async Task<IActionResult> Delete([FromRoute] int id)
        // {
        //     await _service.DeleteAsync(id);
        //     return RedirectToAction(nameof(Index));
        // }

        // [HttpGet]
        // [Route("edit/{id}")]
        // public async Task<IActionResult> Edit([FromRoute] int id)
        // {
        //     var cate = await _service.GetAsync(id);
        //     return View(cate);
        // }

        // [HttpPost]
        // [Route("edit/{id}")]
        // public async Task<IActionResult> Edit([FromRoute] int id, [FromForm] UpdateCategoryDto input)
        
        // {
        //     var cate = await _service.UpdateAsync(id, input);
        //     return RedirectToAction(nameof(Index));
        // }
    }
}
