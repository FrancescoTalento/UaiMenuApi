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
    [Table("subscription")]
    [Index(nameof(ClientId), nameof(RestaurantId), IsUnique = true, Name = "uq_subscription")]
    public class Subscription
    {
        [Key] public long Id { get; set; }

        [ForeignKey(nameof(Client))]
        public long ClientId { get; set; }
        public Cliente Client { get; set; } = null!;

        [ForeignKey(nameof(Restaurant))]
        public long RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; } = null!;

        public TimeOnly HoraEnvioLocal { get; set; }


        [Required]
        public Weekday[] Days { get; set; } = Array.Empty<Weekday>();
    }

}
