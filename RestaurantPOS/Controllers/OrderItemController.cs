using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantPOS.DTOs.OrderItem.Request;
using RestaurantPOS.DTOs.OrderItem.Response;
using RestaurantPOS.Service.Interface;

namespace RestaurantPOS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderItemController : ControllerBase
    {
        private readonly IOrderItemService _orderItemService;
        public OrderItemController(IOrderItemService orderItemService) => _orderItemService = orderItemService;

        [HttpGet]
        public async Task<IEnumerable<OrderItemDto>> GetOrderItemsAync(int orderId)
            => await _orderItemService.GetOrderItemsAsync(orderId);

        [HttpPost]
        public async Task<OrderItemDto> CreateOrderItemAsync(CreateOrderItemDto createOrderItem)
            =>await _orderItemService.CreateOrderItemAsync(createOrderItem);

        [HttpDelete]
        public async Task DeleteOrderItem(int id)=>await _orderItemService.DeleteOrderItemAsync(id);

        [HttpPut]
        public async Task<OrderItemDto> UpdateOrderItemAsync(UpdateOrderItemDto updateOrderItem) 
            => await _orderItemService.UpdateOrderItemAsync(updateOrderItem);
    }
}
