using AutoMapper;
using RestaurantPOS.Data.Entities;
using RestaurantPOS.Dtos.Banner.Response;
using RestaurantPOS.Dtos.Category.Response;
using RestaurantPOS.Dtos.Comment.Response;
using RestaurantPOS.Dtos.FavoriteFood.Response;
using RestaurantPOS.Dtos.Food.Response;
using RestaurantPOS.Dtos.User.Request;
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
            CreateMap<User, UserDto>();
            CreateMap<CreateUserDto, User>();
            #endregion

            #region Food
            CreateMap<Food, FoodDto>()
                .ForMember(p => p.AverageRating, o => o.MapFrom(s => s.Comments.Count == 0 ? 0 : s.Comments.Average(x => x.Rating)));
            #endregion

            #region Comment
            CreateMap<Comment, CommentDto>()
                .ForMember(p => p.FirstName, o => o.MapFrom(s => s.User.FirstName))
                .ForMember(p => p.LastName, o => o.MapFrom(s => s.User.LastName))
                .ForMember(p => p.ImageLink, o => o.MapFrom(s => s.User.ImageLink));
            #endregion

            #region Category
            CreateMap<Category, CategoryDto>();
            #endregion

            #region FavoriteFood
            CreateMap<FavoriteFood, FavoriteFoodDto>();
            #endregion

            #region Banner
            CreateMap<Banner, BannerDto>();
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
