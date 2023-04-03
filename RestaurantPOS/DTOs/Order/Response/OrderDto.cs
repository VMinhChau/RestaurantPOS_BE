using static RestaurantPOS.Common.EnumCommon;

namespace RestaurantPOS.DTOs.Order.Response
{
    public class OrderDto
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public Guid AdminId { get; set; }
        public StatusOrder Status { get; set; }
        public float TotalPrice { get; set; }
        public int? PurcharseId { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
    }
}
