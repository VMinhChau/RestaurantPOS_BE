using static RestaurantPOS.Common.EnumCommon;

namespace RestaurantPOS.DTOs.OrderItem.Request
{
    public class CreateOrderItemDto
    {
        public int OrderId { get; set; }
        public int Quatity { get; set; }
        public int FoodId { get; set; }
    }
}
