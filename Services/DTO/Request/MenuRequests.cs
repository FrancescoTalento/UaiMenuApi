using Data.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO.Request
{
    public record CreateMenu
    {        
        [Required]
        public Weekday DiaDaSemana { get; set; }

        [Required]
        public long RestaurantId { get; set; }
    }

    public record EditMenu
    {
        public long Id { get; set; }

        public Weekday? DiaDaSemana { get; set; }

    }
}
