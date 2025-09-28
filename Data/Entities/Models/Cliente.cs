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
    [Table("client")]
    [Index(nameof(Phone), IsUnique = true)]
    [Index(nameof(Email), IsUnique = true)]
    public class Cliente
    {
        [Key] public long Id { get; set; }

        [Required, MaxLength(20)]
        public string Phone { get; set; } = null!;

        [Required, MaxLength(120)]
        public string Email { get; set; } = null!;

        [Required, StringLength(60)]
        public string SenhaHash { get; set; } = null!;

        [MaxLength(120)]
        public string? Nome { get; set; }

        public bool OptIn { get; set; } = true;

        public ICollection<Subscription> Subscriptions { get; set; } = new List<Subscription>();
    }
}
