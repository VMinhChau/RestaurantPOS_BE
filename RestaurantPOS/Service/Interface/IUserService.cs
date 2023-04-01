using RestaurantPOS.Dtos.User.Request;
using RestaurantPOS.Dtos.User.Response;

namespace RestaurantPOS.Service.Interface
{
    public interface IUserService
    {
        Task<UserDto> CreateAsync(CreateUserDto input);
        Task<UserDto> UpdateAsync(int id, UpdateUserDto input);
        Task DeleteAsync(int id);
        Task<UserDto> GetAsync(int id);
    }
}
