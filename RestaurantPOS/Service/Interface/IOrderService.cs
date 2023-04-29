using RestaurantPOS.DTOs.Order.Request;
using RestaurantPOS.DTOs.Order.Response;
using static RestaurantPOS.Common.EnumCommon;

namespace RestaurantPOS.Service.Interface
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDto>> GetOrdersAsync(Guid id);
        Task<OrderDto> UpdateOrderAsync(UpdateOrderDto updateOrder);
        Task DeleteOrderAsync(int id);
        Task<OrderDto> CreateOrderAsync(CreateOrderDto createOrder);
        Task<IEnumerable<OrderDto>> GetOrdersAsync(Guid userId, StatusOrder status);
    }
}
