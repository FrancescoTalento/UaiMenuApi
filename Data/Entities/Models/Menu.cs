using Data.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Data.Entities.Models
{
    [Table("menu")]
    [Index(nameof(RestaurantId), nameof(MenuDate), IsUnique = true, Name = "uq_menu_rest_dow")]
    public class Menu
    {
        [Key] public long Id { get; set; }

        [ForeignKey(nameof(Restaurant))]
        public long RestaurantId { get; set; }
        
        public Restaurant Restaurant { get; set; } = null!;

        // ENUM dia da semana — armazenado como string: 'dom','seg','ter','qua','qui','sex','sab'
        [Required, MaxLength(3)]
        public Weekday MenuDate { get; set; }

        //[Required]
        //public DateTime MenuDateFor {  get; set; }

        //[MaxLength(255)]
        //public string? Notas { get; set; }
            
        public ICollection<MenuItem> Itens { get; set; } = new List<MenuItem>();
        public ICollection<ImageFile> Images { get; set; } = new List<ImageFile>();
    }
}
