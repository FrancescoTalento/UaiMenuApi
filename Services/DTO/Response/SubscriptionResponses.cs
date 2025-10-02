using Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO.Response
{
    public record SubscriptionResponse
    {
        public long Id { get; set; }

        public long RestaurantId { get; set; }

        public long ClientId { get; set; }

        public TimeOnly HoraEnvioLocal { get; set; } = new TimeOnly(10, 0);

        public Weekday[] Days { get; set; } = Array.Empty<Weekday>();
    }
}
