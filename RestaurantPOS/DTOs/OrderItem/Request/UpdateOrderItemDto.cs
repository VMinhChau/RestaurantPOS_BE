using static RestaurantPOS.Common.EnumCommon;

namespace RestaurantPOS.DTOs.OrderItem.Request
{
    public class UpdateOrderItemDto
    {
        public int Id { get; set; }
        public int? OrderId { get; set; }
        public int? Quatity { get; set; }
        public int? FoodId { get; set; }
        public StatusOrderItem? Status { get; set; }
    }
}
