namespace RestaurantPOS.Data.Entities
{
    public class FavoriteFood
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public int FoodId { get; set; }
    }
}
