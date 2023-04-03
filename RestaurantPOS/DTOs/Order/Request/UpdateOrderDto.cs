using static RestaurantPOS.Common.EnumCommon;

namespace RestaurantPOS.DTOs.Order.Request
{
    public class UpdateOrderDto
    {
        public int Id { get; set; }
        public Guid? UserId { get; set; }
        public Guid? AdminId { get; set; }
        public StatusOrder? Status { get; set; }
        public int? PurcharseId { get; set; }
    }
}
