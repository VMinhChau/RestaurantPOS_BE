using Microsoft.AspNetCore.Identity;
using RestaurantPOS.Core.Enums;

namespace RestaurantPOS.Data.Entities
{
    public class User : IdentityUser<Guid>
    {
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