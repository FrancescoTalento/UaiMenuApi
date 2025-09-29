using Microsoft.AspNetCore.Http;
using Services.DTO.Response;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO.Request
{
    public record CreateRestaurant
    {
        [Required, MaxLength(120)]
        public string Nome { get; set; } = string.Empty;

        [MaxLength(600)]
        public string? Descricao { get; set; }
            }

    public record EditRestaurantRequest
    {
        [Required]
        public long Id { get; set; }

        [MaxLength(120)]
        public string? Nome { get; set; } 

        [MaxLength(600)]
        public string? Descricao { get; set; }

    }


}
