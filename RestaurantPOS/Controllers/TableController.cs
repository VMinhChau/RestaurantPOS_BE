//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore.Metadata;
//using RestaurantPOS.Data.Entities;
//using RestaurantPOS.Models;
//using RestaurantPOS.Models.Create;
//using RestaurantPOS.Models.Update;
//using RestaurantPOS.Service.Interface;

//namespace RestaurantPOS.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class TableController : ControllerBase
//    {
//        private readonly IUserService _cRUDexample;
//        public TableController(IUserService cRUDexample)
//        {
//            _cRUDexample = cRUDexample;
//        }

//        [HttpGet]
//        public async Task<IEnumerable<UserViewModel>> GetAllTable() {
//            return await _cRUDexample.GetAllTableAsync();
//        }

//        [HttpDelete]
//        public async void DeleteTable(int id)
//        {
//            await _cRUDexample.DeleteTablAsync(id);
//        }

//        [HttpPut]
//        public async Task<Table?> UpdateTable(UpdateUserModel update)
//        {
//            return await _cRUDexample.UpdateTableAsync(update); 
//        }

//        [HttpPost]
//        public async Task<Table> CreateTable(CreateUserModel input)
//        {
//            return await _cRUDexample.CreateTableAsync(input);
//        }
//    }
//}
