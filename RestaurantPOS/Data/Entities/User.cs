using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using static RestaurantPOS.Common.EnumCommon;

namespace RestaurantPOS.Data.Entities
{
    [Table("USER")]
    public class User
    {
        [Key]
        [Column(name: "id")]
        public int Id { get; set; }

        [Column(name: "role")]
        [StringLength(50)]
        public Role Role { get; set; }

        [Column(name: "email")]
        [StringLength(100)]
        public string Email { get; set; } = "";

        [Column(name: "encryptedPassword")]
        [StringLength(200)]
        public string EncryptedPassword { get; set; } = "";

        [Column(name: "phoneNumber")]
        [StringLength(10)]
        public string PhoneNumber { get; set; } = "";

        [Column(name: "firstName")]
        [StringLength(50)]
        public string FirstName { get; set; } = "";

        [Column(name: "lastName")]
        [StringLength(50)]
        public string LastName { get; set; } = "";

        [Column(name: "gender")]
        [StringLength(10)]
        public Gender Gender { get; set; }

        [Column(name: "dateOfBirth")]
        [StringLength(8)]
        public string DateOfBirth { get; set; } = "";

        [Column(name: "points")]
        public int Points { get; set; }

        [Column(name: "rank")]
        [StringLength(50)]
        public Rank Rank { get; set; }

        [Column(name: "address")]
        [StringLength(200)]
        public string Address { get; set; } = "";

        public virtual List<FavoriteFood> FavoriteFoods { get; set; }
        public virtual List<Order> Orders { get; set; }
        public virtual List<Order> OrdersSecond { get; set; }
        public virtual List<Comment> Comments { get; set; }

    }
}
