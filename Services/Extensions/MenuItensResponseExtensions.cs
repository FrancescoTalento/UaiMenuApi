using Data.Entities.Models;
using Services.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Extensions
{
    public static class MenuItensResponseExtensions
    {

        #region ToResponse
        public static MenuItemResponse ToResponse(this MenuItem entity)
        {
            return new MenuItemResponse
                (
                    Id: entity.Id,
                    MenuId: entity.MenuId,
                    Nome: entity.Nome,
                    Posicao: entity.Posicao,
                    Tipo: entity.Tipo
                );
        }
        #endregion
    }
}
