using RestaurantPOS.Dtos.Comment.Response;
using RestaurantPOS.Dtos.Category.Response;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RestaurantPOS.Dtos.Food.Response
{
    public class FoodDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public bool IsPromotion { get; set; }
        public string Description { get; set; }
        public string ImageLink { get; set; }
        public double AverageRating { get; set; }
        public int CategoryId { get; set; }
        public List<CommentDto> Comments { get; set; }
        public virtual CategoryDto CategoryNavigation {get; set;}
        public virtual List<CategoryDto> Categories {get; set;}
        public IFormFile ImageFile {get; set;}
    }
}
