using RestaurantPOS.DTOs.OrderItem.Request;
using RestaurantPOS.DTOs.OrderItem.Response;
using System.Transactions;

namespace RestaurantPOS.Interface
{
    public interface IOrderItemService
    {
        Task<IEnumerable<OrderItemDto>> GetOrderItemsAsync(int orderId);
        Task<OrderItemDto> UpdateOrderItemAsync(UpdateOrderItemDto updateOrderItem);
        Task DeleteOrderItemAsync(int id);
        Task<OrderItemDto> CreateOrderItemAsync(CreateOrderItemDto createOrderItem);
        Task DeleteAllOrderItemByOrderIdAsync(int orderId);
    }
}
