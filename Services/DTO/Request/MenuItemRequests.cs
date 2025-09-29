using Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO.Request
{
    public record MenuItemRequest
    {
        public string Name { get; set; }
        public ItemTipo TipoDoMenuItem { get; set; }

    }
}
