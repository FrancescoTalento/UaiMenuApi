using Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO.Response
{
    public record MenuItemResponse(
        long Id,
        long? RestaurantId,
        string Nome,
        ItemTipo Tipo,
        int Posicao
    );

}
