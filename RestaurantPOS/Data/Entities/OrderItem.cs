using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using static RestaurantPOS.Common.EnumCommon;

namespace RestaurantPOS.Data.Entities
{
    [Table("ORDERITEM")]
    public class OrderItem
    {
        [Key]
        [Column(name: "id")]
        public int Id { get; set; }

        [Column(name: "orderId")]
        [ForeignKey(nameof(OrderId))]
        public int OrderId { get; set; }
        public Order Order { get; set; }

        [Column(name: "currrentPrice")]
        public float CurrrentPrice { get; set; }

        [Column(name: "quatity")]
        public int Quatity { get; set; }

        [Column(name: "foodId")]
        [ForeignKey(nameof(FoodId))]
        public int FoodId { get; set; }
        public Food Food { get; set; }

        [Column(name: "status")]
        [StringLength(100)]
        public StatusOrderItem Status { get; set; }
    }
}
