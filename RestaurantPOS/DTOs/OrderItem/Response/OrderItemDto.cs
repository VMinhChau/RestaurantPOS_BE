using RestaurantPOS.Data.Entities;
using static RestaurantPOS.Common.EnumCommon;

namespace RestaurantPOS.DTOs.OrderItem.Response
{
    public class OrderItemDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public float CurrrentPrice { get; set; }
        public int Quatity { get; set; }
        public int FoodId { get; set; }
        public StatusOrderItem Status { get; set; }
    }
}
