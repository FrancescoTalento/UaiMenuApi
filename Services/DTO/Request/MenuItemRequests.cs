using Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO.Request
{
    public record MenuItemRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public ItemTipo TipoDoMenuItem { get; set; }

    }

    public record EditMenuItem
    {
        [Required]
        public long MenuItemId { get; set; }

        public string? Nome { get; set; }
        
        public ItemTipo? Tipo { get; set; }

        public int Posicao { get; set; }
    }
}
