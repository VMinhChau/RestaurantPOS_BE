namespace RestaurantPOS.Data.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string Content { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }
        public int FoodId { get; set; }
    }
}
