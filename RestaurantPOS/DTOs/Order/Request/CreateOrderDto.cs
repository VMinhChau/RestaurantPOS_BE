using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RestaurantPOS.Data.Entities;
using static RestaurantPOS.Common.EnumCommon;

namespace RestaurantPOS.DTOs.Order.Request
{
    public class CreateOrderDto
    {
        public Guid UserId { get; set; }
        public Guid AdminId { get; set; }
        public StatusOrder Status { get; set; }
        public float TotalPrice { get; set; }
        public int? PurcharseId { get; set; }
    }
}
