namespace RestaurantPOS.Dtos.User.Request
{
    public class UpdateUserDto
    {
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Gender { get; set; }
        public DateTime Birthday { get; set; }
    }
}
