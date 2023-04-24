using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;
using RestaurantPOS.Dtos.Category.Response;

namespace RestaurantPOS.Data.Entities
{
    public class Food
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public bool IsPromotion { get; set; }
        public string Description { get; set; }
        public string ImageLink { get; set; }
        public int CategoryId { get; set; }
        public List<Comment> Comments { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        // [NotMapped]
        public virtual Category CategoryNavigation {get; set;}
        public virtual List<CategoryDto> Categories {get; set;}
        
        
    }
}
