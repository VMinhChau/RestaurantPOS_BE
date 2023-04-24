using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantPOS.DTOs.Order.Request;
using RestaurantPOS.DTOs.Order.Response;
using RestaurantPOS.Service.Interface;

namespace RestaurantPOS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)=>_orderService= orderService;

        // [HttpGet]
        // public async Task<IActionResult> Index()
        // {
        //     var orders = await _orderService.GetOrders();
        //     return View(orders);
        // }

        [HttpGet]
        public async Task<IEnumerable<OrderDto>> GetOrdersAync(Guid userId)
            => await _orderService.GetOrdersAsync(userId);

        [HttpPost]
        public async Task<OrderDto> CreateOrderAsync(CreateOrderDto createOrder)
            =>await _orderService.CreateOrderAsync(createOrder);

        [HttpDelete]
        public async Task DeleteOrder(int id) => await _orderService.DeleteOrderAsync(id);

        [HttpPut]
        public async Task<OrderDto> UpdateOrderAsync(UpdateOrderDto updateOrder)
            =>await _orderService.UpdateOrderAsync(updateOrder);


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var orders = await _orderService.GetOrders();
            return View(orders);
        }
    }
}
