using RestaurantPOS.DTOs.Order.Request;
using RestaurantPOS.DTOs.Order.Response;

namespace RestaurantPOS.Service.Interface
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDto>> GetOrdersAsync(Guid id);
        Task<OrderDto> UpdateOrderAsync(UpdateOrderDto updateOrder);
        Task DeleteOrderAsync(int id);
        Task<OrderDto> CreateOrderAsync(CreateOrderDto createOrder);
        Task<List<OrderDto>> GetOrders();
    }
}
