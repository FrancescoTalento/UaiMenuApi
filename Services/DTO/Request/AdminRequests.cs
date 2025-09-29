using Data.Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO.Request
{
    public record AdmRequest
    {

        [Required]
        public long RestaurantId { get; set; }

        [Required, MaxLength(120)]
        public string Email { get; set; } = null!;

        [Required, StringLength(60)]
        public string SenhaHash { get; set; } = null!;

        public bool CanManageAdmins { get; set; } = false;
        public bool CanManageMenus { get; set; } = false;
    }

    public record AdmLoginRequest
    {
        [Required, MaxLength(120)]
        public string Email { get; set; } = null!;

        [Required, StringLength(60)]
        public string SenhaHash { get; set; } = null!;
    }

    public record AdmEditRequest
    {
     
        public string? Email { get; set; } 
        public string? SenhaHash { get; set; } 

        public bool? CanManageAdmins { get; set; } = false;
        public bool? CanManageMenus { get; set; } = false;
    }
}
