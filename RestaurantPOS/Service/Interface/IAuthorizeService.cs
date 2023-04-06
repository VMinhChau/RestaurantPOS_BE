using RestaurantPOS.DTOs.Token;

namespace RestaurantPOS.Service.Interface
{
    public interface IAuthorizeService
    {
        TokenDto Authorize(string userName, string pwd);
    }
}
