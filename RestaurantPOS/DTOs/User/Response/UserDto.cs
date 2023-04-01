using RestaurantPOS.Core.Enums;

namespace RestaurantPOS.Dtos.User.Response
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImageLink { get; set; }
        public bool Gender { get; set; }
        public DateTime Birthday { get; set; }
        public double Points { get; set; }
        public RankUser Ranking { get; set; }
    }
}
