using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using static RestaurantPOS.Common.EnumCommon;

namespace RestaurantPOS.Data.Entities
{
    [Table("ORDER")]
    public class Order
    {
        [Key]
        [Column(name: "id")]
        public int Id { get; set; }

        [ForeignKey("Order-User")]
        [Column(name: "userId")]
        public int? UserId { get; set; }
        public virtual User User { get; set; }

        [ForeignKey("Order-Admin")]
        [InverseProperty("admin-order")]
        [Column(name: "adminId")]
        public int? AdminId { get; set; }
        public virtual User UserAdmin { get; set; }

        [Column(name: "status")]
        [StringLength(50)]
        public Status Status { get; set; }

        [Column(name: "totalPrice")]
        public float TotalPrice { get; set; }


        [Column(name: "purcharseId")]
        public int? PurcharseId { get; set; }

        [Column(name: "createAt")]
        public string CreateAt { get; set; } = "";

        [Column(name: "updateAt")]
        public string UpdateAt { get; set; } = "";


        public virtual List<OrderItem> OrderItems { get; set; }

    }
}
