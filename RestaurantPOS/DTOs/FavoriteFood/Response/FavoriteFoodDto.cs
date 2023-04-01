using RestaurantPOS.Dtos.User.Response;

namespace RestaurantPOS.Dtos.FavoriteFood.Response
{
    public class FavoriteFoodDto
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public int FoodId { get; set; }
    }
}
