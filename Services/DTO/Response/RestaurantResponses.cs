using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO.Response
{
    public record RestaurantResponse
    {
        public long Id { get; set; }

        [MaxLength(120)]
        public string Nome { get; set; } = string.Empty;

        [MaxLength(600)]
        public string? Descricao { get; set; }

      
    }
}
