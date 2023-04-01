using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantPOS.Data.Entities
{
    [Table("FOOD")]
    public class Food
    {
        [Key]
        [Column(name:"id")]
        public int Id { get; set; }

        [Column(name: "name",TypeName = "nvarchar")]
        [StringLength(50)]
        public string Name { get; set; } = "";

        [Column(name: "price", TypeName = "decimal")]
        public float Price { get; set; }

        [Column(name: "description", TypeName = "nvarchar")]
        [StringLength(2000)]
        public string Description { get; set; } = "";


        [Column(name: "image", TypeName = "nvarchar")]
        [StringLength(200)]
        public string Image { get; set; } = "";

        [Column(name: "averageRating")]
        public float AverageRating { get; set; }

        [Column(name: "isPromote",TypeName ="bit")]
        public bool IsPromote { get; set; }

        [ForeignKey("Food-Category")]
        [Column(name: "categoryId")]
        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public virtual List<Comment> Comments { get; set; }
        public virtual List<FavoriteFood> FavoriteFoods { get; set; }
        public virtual List<OrderItem> OrderItems { get; set; }
    }
}
