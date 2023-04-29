using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantPOS.DTOs.Order.Request;
using RestaurantPOS.DTOs.Order.Response;
using RestaurantPOS.Service.Interface;
using static RestaurantPOS.Common.EnumCommon;

namespace RestaurantPOS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService) => _orderService = orderService;

        [HttpGet]
        // [Route("get")]
        public async Task<IEnumerable<OrderDto>> GetOrdersAync(Guid userId)
            => await _orderService.GetOrdersAsync(userId);

        [HttpGet]
        [Route("GetOrdersStatus")]
        public async Task<IEnumerable<OrderDto>> GetOrdersStatusAync(Guid userId, StatusOrder status)
            => await _orderService.GetOrdersAsync(userId, status);

        [HttpPost]
        // [Route("create")]
        public async Task<OrderDto> CreateOrderAsync(CreateOrderDto createOrder)
            => await _orderService.CreateOrderAsync(createOrder);

        [HttpDelete]
        // [Route("delete")]
        public async Task DeleteOrder(int id) => await _orderService.DeleteOrderAsync(id);

        [HttpPut]
        // [Route("update")]
        public async Task<OrderDto> UpdateOrderAsync(UpdateOrderDto updateOrder)
            => await _orderService.UpdateOrderAsync(updateOrder);


        // [HttpGet]
        // [Route("orders")]
        // public async Task<IActionResult> Index()
        // {
        //     var orders = await _orderService.GetOrders();
        //     return View(orders);
        // }
    }
}
