using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using RestaurantPOS.Data.Entities;
using RestaurantPOS.Models;
using RestaurantPOS.Models.Create;
using RestaurantPOS.Models.Update;
using RestaurantPOS.Service.Interface;

namespace RestaurantPOS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableController : ControllerBase
    {
        private readonly ICRUDexample _cRUDexample;
        public TableController(ICRUDexample cRUDexample)
        {
            _cRUDexample = cRUDexample;
        }

        [HttpGet]
        public async Task<TableViewModel?> GetAllTable(int id) {
            return await _cRUDexample.GetAllTableAsync(id);
        }

        [HttpDelete]
        public void DeleteTable(int id)
        {
            _cRUDexample.DeleteTable(id);
        }

        [HttpPut]
        public async Task<Table?> UpdateTable(UpdateTableModel update)
        {
            return await _cRUDexample.UpdateTableAsync(update); 
        }

        [HttpPost]
        public async Task<Table> CreateTable(CreateTableModel input)
        {
            return await _cRUDexample.CreateTableAsync(input);
        }
    }
}
