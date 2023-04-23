using System.ComponentModel.DataAnnotations.Schema;
using RestaurantPOS.Dtos.Category.Response;

namespace RestaurantPOS.Dtos.Food.Request
{
    public class CreateFoodDto
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public bool IsPromotion { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        // [NotMapped]
        // public virtual List<CategoryDto> Categories {get; set;}
        // public virtual CategoryDto CategoryNavigation {get; set;}
        public IFormFile ImageFile {get; set;}
    }
}
