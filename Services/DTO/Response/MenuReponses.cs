using Data.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO.Response
{
    public record MenuReponse
    {
        public long Id { get; set; }

        public Weekday DiaDaSemana { get; set; }

        public long RestaurantId { get; set; }
    }
    public record MenuWithItensReponse
    {
        public long Id { get; set; }

        public Weekday DiaDaSemana { get; set; }

        public long RestaurantId { get; set; }

        IReadOnlyList<MenuItemResponse> ItemResponses { get; set; }
    } 
}
