using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;
using RestaurantPOS.Core.Enums;

namespace RestaurantPOS.Dtos.User.Request
{
    public class Create
    {
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImageLink { get; set; }
        public bool Gender { get; set; }
        public DateTime Birthday { get; set; }
        // [NotMapped]
        public virtual List<SelectListItem> Genders {get; set;}

    }
}