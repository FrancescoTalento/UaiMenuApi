using Data.Entities.Models;
using Services.DTO.Request;
using Services.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Extensions
{
    public static class MenuItensExtensions
    {

        #region ToResponse
        public static MenuItemResponse ToResponse(this MenuItem entity)
        {
            return new MenuItemResponse
                (
                    Id: entity.Id,
                    RestaurantId: entity.RestaurantId,
                    Nome: entity.Nome,
                    Posicao: entity.Posicao,
                    Tipo: entity.Tipo
                );
        }
        #endregion

        #region ToEntity
        public static MenuItem ToEntity(this MenuItemRequest request) 
        {
            return new MenuItem()
            {
                Nome = request.Nome,
                Posicao = request.Posicao,
                Tipo = request.TipoDoMenuItem,
                RestaurantId = request.RestaurantId,
            };
        }
        #endregion
    }
}
