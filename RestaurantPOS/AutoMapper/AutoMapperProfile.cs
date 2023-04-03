using AutoMapper;
using RestaurantPOS.Data.Entities;
using RestaurantPOS.Dtos.User.Response;
using RestaurantPOS.DTOs.Order.Request;
using RestaurantPOS.DTOs.Order.Response;
using RestaurantPOS.DTOs.OrderItem.Request;
using RestaurantPOS.DTOs.OrderItem.Response;

namespace RestaurantPOS
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            #region User
            #endregion

            #region Order_OrderItem
            CreateMap<Order, OrderDto>();
            CreateMap<OrderItem, OrderItemDto>();
            CreateMap<UpdateOrderDto, Order>();
            CreateMap<CreateOrderDto, Order>();
            CreateMap<UpdateOrderItemDto, OrderItem>().ForAllMembers(o => o.PreCondition((src, dest, value) => value != null));
            CreateMap<CreateOrderItemDto, OrderItem>();
            #endregion
        }
    }
}
