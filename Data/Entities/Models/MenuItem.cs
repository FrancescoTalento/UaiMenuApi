using Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.Models
{
    [Table("menu_item")]
    public class MenuItem
    {
        [Key] public long Id { get; set; }

        [ForeignKey(nameof(Menu))]
        public long MenuId { get; set; }
        public Menu Menu { get; set; } = null!;

        [Required, MaxLength(15)]
        public ItemTipo Tipo { get; set; }

        [Required, MaxLength(100)]
        public string Nome { get; set; } = null!;

        public int Posicao { get; set; } = 1;

        public ICollection<ImageFile> Images { get; set; }
    }
}
