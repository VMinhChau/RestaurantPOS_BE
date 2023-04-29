using RestaurantPOS.Dtos.Food.Response;

namespace RestaurantPOS.Dtos.Category.Response
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<FoodDto>? Foods { get; set; }

        internal CategoryDto Where(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }

        public static explicit operator CategoryDto(List<CategoryDto> v)
        {
            throw new NotImplementedException();
        }
    }
}
