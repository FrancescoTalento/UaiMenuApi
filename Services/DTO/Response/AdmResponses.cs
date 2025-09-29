using Data.Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO.Response
{
    public record AdmResponse
    {
        public long Id { get; set; }
        public long RestaurantId { get; set; }
        public string Email { get; set; } 
        public bool CanManageAdmins { get; set; } = false;
        public bool CanManageMenus { get; set; } = false;
    }
}
