using Microsoft.EntityFrameworkCore;
using RestaurantPOS.Controllers;
using RestaurantPOS.Data;
using RestaurantPOS.Data.Entities;
using RestaurantPOS.Models;
using RestaurantPOS.Models.Create;
using RestaurantPOS.Models.Update;
using RestaurantPOS.Service.Interface;

namespace RestaurantPOS.Service
{
    public class CRUDexample:ICRUDexample
    {
        private readonly RestaurantDbContext _dbContext;
        public CRUDexample(RestaurantDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Table> CreateTableAsync(CreateTableModel input)
        {
            var tableNew = new Table()
            {
                Name = input.Name,
                PeopleCount = input.PeopleCount,
            };
            await _dbContext.AddAsync(tableNew);
            await _dbContext.SaveChangesAsync();
            return tableNew;
        }
        public async Task<Table?> UpdateTableAsync(UpdateTableModel input)
        {
            var tableDB = await _dbContext.Table.FirstOrDefaultAsync(c => c.Id == input.Id);
            if (tableDB == null)
            {
                return null;
            }
            tableDB.Name=input.Name;
            tableDB.PeopleCount= input.PeopleCount;
            await _dbContext.SaveChangesAsync();
            return tableDB;
        }

        public async Task DeleteTablAsync(int id)
        {
            var tableDB = await _dbContext.Table.FirstOrDefaultAsync(c => c.Id == id);
            if (tableDB == null)
            {
                return;
            }
            _dbContext.Table.Remove(tableDB);
            await _dbContext.SaveChangesAsync();
            return;
        }

        public async Task<IEnumerable<TableViewModel>> GetAllTableAsync()
        {
            return await _dbContext.Table.Select(c=>new TableViewModel(){
                Name = c.Name,
                PeopleCount = c.PeopleCount,
                Id= c.Id
            }).ToListAsync();
        }
    }
}
