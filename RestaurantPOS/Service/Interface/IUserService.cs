using RestaurantPOS.Controllers;
using RestaurantPOS.Data.Entities;
using RestaurantPOS.Models;
using RestaurantPOS.Models.Create;
using RestaurantPOS.Models.Update;

namespace RestaurantPOS.Service.Interface
{
    public interface IUserService
    {
        Task<User?> UpdateUserAsync(UpdateUserModel input);
        Task<User> CreateUserAsync(CreateUserModel input);
        Task DeleteUserAsync(int id);
        Task<IEnumerable<UserViewModel>> GetAllUserAsync();
        Task<UserViewModel?> GetOneUserAsync(int id);
    }
}
