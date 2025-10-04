using Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO.Request
{
    public record CreateSubscription
    {
        [Required]
        public long RestaurantId { get; set; }

        [Required]
        public long ClientId { get; set; }

        public TimeOnly HoraEnvioLocal { get; set; } = new TimeOnly(10,0);

        [Required]
        public required Weekday[] Days { get; set; }

    }
    public record EditSubscriptionDays
    {
        [Required]
        public long SubscriptionId { get; set; }

        [Required]
        public Weekday[] NewDays { get; set; }
    }

}
