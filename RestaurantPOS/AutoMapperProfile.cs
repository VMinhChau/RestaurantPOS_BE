using AutoMapper;
using RestaurantPOS.Data.Entities;
using RestaurantPOS.Dtos.User.Response;

namespace RestaurantPOS
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            #region User
            CreateMap<User, UserDto>();
            #endregion
        }
    }
}
