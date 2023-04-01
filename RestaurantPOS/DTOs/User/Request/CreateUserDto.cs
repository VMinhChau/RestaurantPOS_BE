using RestaurantPOS.Core.Enums;

namespace RestaurantPOS.Dtos.User.Request
{
    public class CreateUserDto
    {
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Gender { get; set; }
        public DateTime Birthday { get; set; }
    }
}
