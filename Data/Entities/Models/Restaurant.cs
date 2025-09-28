using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.Models
{
    [Table("restaurant")]
    public class Restaurant
    {
        [Key] public long Id { get; set; }

        [Required, MaxLength(120)]
        public string Nome { get; set; } = null!;

        [MaxLength(600)]
        public string Descricao { get; set; }

        public ICollection<Admin> Admins { get; set; } = new List<Admin>();
        public ICollection<Subscription> Subscriptions { get; set; } = new List<Subscription>();
        public ICollection<Menu> Menus { get; set; } = new List<Menu>();
        public ICollection<ImageFile> Images { get; set; }
    }
}
