using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO.Request
{
    public record ClientRequest
    {
        [Required, MaxLength(20)]
        public string PhoneNumber { get; set; } = null!;

        [Required, MaxLength(120)]
        public string Email { get; set; } = null!;

        [Required, StringLength(60)]
        public string SenhaHash { get; set; } = null!;

        public string Nome { get; set; }
    }
    public record ClientEditRequest
    {
        [Required]
        public required long Id { get; set; }
        public string? PhoneNumber { get; set; } 
        public string? Email { get; set; } 
        public string? SenhaHash { get; set; } 
        public string? Nome { get; set; }
        public bool? OptIn { get; set; }
    }

    public record ClientLoginRequest
    {
        [Required, MaxLength(120)]
        public string Email { get; set; } = null!;
        
        [Required, StringLength(60)]
        public string SenhaHash { get; set; } = null!;

    }
}
