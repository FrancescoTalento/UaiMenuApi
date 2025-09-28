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
        [MaxLength(120)]
        public string Nome { get; set; } = string.Empty;

        [MaxLength(600)]
        public string? Descricao { get; set; }

        public IEnumerable<ImageResponse>? Images { get; set; }
    }
}
