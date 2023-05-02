using Microsoft.AspNetCore.Mvc.Rendering;
using RestaurantPOS.Core.Enums;
using static RestaurantPOS.Common.EnumCommon;

namespace RestaurantPOS.Models
{
    public class UserVM
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        // public string ImageLink { get; set; }
        public bool Gender { get; set; }
        public DateTime Birthday { get; set; }
        public double Points { get; set; }
        public RankUser Ranking { get; set; }
        public Role Role { get; set; }
        public virtual List<SelectListItem> Genders {get; set;}

    }
}