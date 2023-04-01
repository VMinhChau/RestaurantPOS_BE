using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantPOS.Data.Entities
{
    [Table("FAVORITEFOOD")]
    public class FavoriteFood
    {
        [Key]
        [Column(name: "id")]
        public int Id { get; set; }

        [ForeignKey("Favorite-Food")]
        [Column(name: "foodId")]
        public int? FoodId { get; set; }
        public virtual Food Food { get; set; }

        [ForeignKey("Favorite-User")]
        [Column(name: "userId")]
        public int? UserId { get; set; }
        public virtual User User { get; set; }
    }
}
