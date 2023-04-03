namespace RestaurantPOS.Data.Entities
{
    public class Food
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public string AverageRating { get; set; }
        public int CategoryId { get; set; }
        public List<Comment> Comments { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}
