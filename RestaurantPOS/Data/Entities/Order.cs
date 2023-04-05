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

        [ForeignKey(nameof(UserId))]
        [Column(name: "userId")]
        public Guid UserId { get; set; }
        public User User { get; set; }

        [ForeignKey(nameof(AdminId))]
        [InverseProperty("admin-order")]
        [Column(name: "adminId")]
        public Guid? AdminId { get; set; }
        public  User Admin { get; set; }

        [Column(name: "status")]
        [StringLength(50)]
        public StatusOrder Status { get; set; }

        [Column(name: "totalPrice")]
        public float TotalPrice { get; set; }


        [Column(name: "purcharseId")]
        public int? PurcharseId { get; set; }

        [Column(name: "createAt",TypeName ="datetime2")]
        public DateTime CreateAt { get; set; }

        [Column(name: "updateAt", TypeName = "datetime2")]
        public DateTime? UpdateAt { get; set; }

        public virtual List<OrderItem> OrderItems { get; set; }

    }
}
