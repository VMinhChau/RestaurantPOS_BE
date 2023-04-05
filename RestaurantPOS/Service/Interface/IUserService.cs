using RestaurantPOS.Dtos.User.Request;
using RestaurantPOS.Dtos.User.Response;

namespace RestaurantPOS.Service.Interface
{
    public interface IUserService
    {
        Task<UserDto> CreateAsync(CreateUserDto input);
        Task<UserDto> UpdateAsync(Guid id, UpdateUserDto input);
        Task DeleteAsync(Guid id);
        Task<UserDto> GetAsync(Guid id);
        Task UploadImageAsync(Guid id, string path);
    }
}
