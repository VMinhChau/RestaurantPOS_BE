﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantPOS.DTOs.OrderItem.Request;
using RestaurantPOS.DTOs.OrderItem.Response;
using RestaurantPOS.Service.Interface;

namespace RestaurantPOS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // [Authorize]
    public class OrderItemController : ControllerBase
    {
        private readonly IOrderItemService _orderItemService;
        public OrderItemController(IOrderItemService orderItemService) => _orderItemService = orderItemService;

        [HttpGet]
        // [Route("getorderitems")]
        public async Task<IEnumerable<OrderItemDto>> GetOrderItemsAync(int orderId)
            => await _orderItemService.GetOrderItemsAsync(orderId);

        [HttpPost]
        // [Route("create")]
        public async Task<OrderItemDto> CreateOrderItemAsync([FromBody] CreateOrderItemDto createOrderItem)
            => await _orderItemService.CreateOrderItemAsync(createOrderItem);

        [HttpDelete]
        // [Route("delete")]
        public async Task DeleteOrderItem(int id) => await _orderItemService.DeleteOrderItemAsync(id);

        [HttpPut]
        //  [Route("update")]
        public async Task<OrderItemDto> UpdateOrderItemAsync(UpdateOrderItemDto updateOrderItem)
            => await _orderItemService.UpdateOrderItemAsync(updateOrderItem);


        // [HttpGet]
        // [Route("{Id}")]
        // public async Task<List<OrderItemDto>> GetOrderItemsAsync([FromRoute] int Id)
        // {
        //     return await _orderItemService.GetOrderItemsAsync(Id);

        // }
        // [HttpGet]
        // [Route("{Id}")]
        // public async Task<IActionResult> Index([FromRoute] int Id)
        // {
        //     var orderItems = await _orderItemService.GetOrderItemsAsync(Id);
        //     return View(orderItems);
        // }

    }
}
