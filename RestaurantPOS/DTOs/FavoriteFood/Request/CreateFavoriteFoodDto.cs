namespace RestaurantPOS.Dtos.FavoriteFood.Request
{
    public class CreateFavoriteFoodDto
    {
        public Guid UserId { get; set; }
        public int FoodId { get; set; }
    }
}
