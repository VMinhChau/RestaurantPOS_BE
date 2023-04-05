using Newtonsoft.Json.Linq;
using RestaurantPOS.Data.Entities;

namespace RestaurantPOS.Service.Interface
{
    public interface IAuthorizeService
    {
        string Authenticate(string userName, string pwd);
    }
}
