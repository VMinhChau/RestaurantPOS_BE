using RestaurantPOS.Dtos.Banner.Request;
using RestaurantPOS.Dtos.Banner.Response;

namespace RestaurantPOS.Interface
{
    public interface IBannerService
    {
        Task<BannerDto> CreateAsync(CreateBannerDto input);
        Task<BannerDto> UpdateAsync(int id, UpdateBannerDto input);
        Task DeleteAsync(int id);
        Task<BannerDto> GetAsync(int id);
        Task<List<BannerDto>> GetAsync();
        Task UploadImageAsync(int id, string path);
    }
}
