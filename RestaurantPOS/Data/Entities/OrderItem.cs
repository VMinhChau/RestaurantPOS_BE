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

        [ForeignKey("OrderItem-Order")]
        [Column(name: "orderId")]
        public int? OrderId { get; set; }
        public virtual Order Order { get; set; }

        [Column(name: "currrentPrice")]
        public float CurrrentPrice { get; set; }

        [Column(name: "quatity")]
        public int Quatity { get; set; }

        [ForeignKey("OrderItem-Food")]
        [Column(name: "foodId")]
        public virtual int? FoodId { get; set; }
        public virtual Food Food { get; set; }

        [Column(name: "status")]
        public Status Status { get; set; }
    }
}
