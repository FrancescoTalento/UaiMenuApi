using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.Models
{

    [Table("admin")]
    [Index(nameof(Email), IsUnique = true)]
    public class Admin
    {
        [Key] public long Id { get; set; }

        [ForeignKey(nameof(Restaurant))]
        public long RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; } = null!;

        [Required, MaxLength(120)]
        public string Email { get; set; } = null!;

        [Required, StringLength(60)]
        public string SenhaHash { get; set; } = null!;

        public bool CanManageAdmins { get; set; } = false;
        public bool CanManageMenus { get; set; } = false;
    }

}
