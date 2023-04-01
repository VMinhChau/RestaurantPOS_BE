namespace RestaurantPOS.Dtos.Comment.Request
{
    public class CreateCommentDto
    {
        public int Rating { get; set; }
        public string Content { get; set; }
        public Guid UserId { get; set; }
        public int FoodId { get; set; }
    }
}
