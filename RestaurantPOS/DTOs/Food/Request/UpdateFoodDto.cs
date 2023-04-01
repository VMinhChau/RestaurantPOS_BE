namespace RestaurantPOS.Dtos.Food.Request
{
    public class UpdateFoodDto
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
    }
}
