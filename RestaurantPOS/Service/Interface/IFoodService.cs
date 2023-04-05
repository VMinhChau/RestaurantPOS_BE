using RestaurantPOS.Dtos.Food.Request;
using RestaurantPOS.Dtos.Food.Response;

namespace RestaurantPOS.Service.Interface
{
    public interface IFoodService
    {
        Task<FoodDto> CreateAsync(CreateFoodDto input);
        Task<FoodDto> UpdateAsync(int id, UpdateFoodDto input);
        Task DeleteAsync(int id);
        Task<FoodDto> GetAsync(int id);
        Task<List<FoodDto>> GetSuggestAsync(int id);
        Task<List<FoodDto>> GetAsync();
        Task<List<FoodDto>> GetPromotionAsync();
        Task<List<FoodDto>> GetAsync(Guid userId);
        Task UploadImageAsync(int id, string path);
    }
}
