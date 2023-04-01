using RestaurantPOS.Controllers;
using RestaurantPOS.Data.Entities;
using RestaurantPOS.Models;
using RestaurantPOS.Models.Create;
using RestaurantPOS.Models.Update;

namespace RestaurantPOS.Service.Interface
{
    public interface ICRUDexample
    {
        Task<Table> CreateTableAsync(CreateTableModel input);
        Task<Table?> UpdateTableAsync(UpdateTableModel input);
        void DeleteTable(int id);
        Task<TableViewModel?> GetAllTableAsync(int id);
    }
}
