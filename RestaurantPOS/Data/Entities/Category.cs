using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RestaurantPOS.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantPOS.Data.Entities
{
    [Table("CATEGORY")]
    public class Category
    {
        [Key]
        [Column(name: "id")]
        public int Id { get; set; }

        [StringLength(50)]
        [Column(name: "Name", TypeName = "nvarchar")]
        public EnumCommon.Category Name { get; set; }

        public virtual List<Food> Foods { get; set; }
    }
}
