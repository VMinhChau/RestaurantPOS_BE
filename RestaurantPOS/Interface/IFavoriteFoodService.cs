using RestaurantPOS.Dtos.FavoriteFood.Request;
using RestaurantPOS.Dtos.FavoriteFood.Response;

namespace RestaurantPOS.Interface
{
    public interface IFavoriteFoodService
    {
        Task<FavoriteFoodDto> CreateAsync(CreateFavoriteFoodDto input);
        Task<List<FavoriteFoodDto>> GetByUserIdAsync(Guid userId);
        Task DeleteAsync(int id);
    }
}
