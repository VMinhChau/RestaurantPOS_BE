namespace RestaurantPOS.Data.Entities
{
    public class FavoriteFood
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int FoodId { get; set; }
    }
}
