using RestaurantPOS.Dtos.User.Response;
using RestaurantPOS.Dtos.Food.Response;
namespace RestaurantPOS.Dtos.Comment.Response
{
    public class CommentDto
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string Content { get; set; }
        public Guid UserId { get; set; }
        public int FoodId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        // public string ImageLink { get; set; }
        public virtual FoodDto FoodNavigation {get; set;}
    }
}
