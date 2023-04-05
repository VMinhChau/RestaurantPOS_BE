using RestaurantPOS.Dtos.Category.Request;
using RestaurantPOS.Dtos.Category.Response;

namespace RestaurantPOS.Service.Interface
{
    public interface ICategoryService
    {
        Task<CategoryDto> CreateAsync(CreateCategoryDto input);
        Task<CategoryDto> UpdateAsync(int id, UpdateCategoryDto input);
        Task DeleteAsync(int id);
        Task<CategoryDto> GetAsync(int id);
        Task<List<CategoryDto>> GetAsync();
    }
}
