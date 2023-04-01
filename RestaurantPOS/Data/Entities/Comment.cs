using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantPOS.Data.Entities
{
    [Table("COMMENT")]
    public class Comment
    {
        [Key]
        [Column(name: "id")]
        public int Id { get; set; }

        [Column(name: "rating")]
        public float Rating { get; set; }

        [Column(name: "content")]
        public string Content { get; set; } = "";

        [ForeignKey("Comment-Food")]
        [Column(name: "foodId")]
        public int? FoodId { get; set; }
        public virtual Food Food { get; set; }

        [ForeignKey("Comment-User")]
        [Column(name: "userId")]
        public int? UserId { get; set; }
        public virtual User User { get; set; }
    }
}
