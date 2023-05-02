using RestaurantPOS.Dtos.User.Request;
using RestaurantPOS.Dtos.User.Response;
using RestaurantPOS.Models;

namespace RestaurantPOS.Service.Interface
{
    public interface IUserService
    {
        Task<UserDto> CreateAsync(CreateUserDto input);
        Task<UserDto> UpdateAsync(Guid id, UpdateUserDto input);
        Task DeleteAsync(Guid id);
        Task<UserDto> GetAsync(Guid id);
        Task UploadImageAsync(Guid id, string path);
        Task<List<UserDto>> GetAsync();
        Task<List<UserVM>> GetUsers();
    }
}
