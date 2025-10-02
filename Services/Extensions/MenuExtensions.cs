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
    public static class MenuExtensions
    {
        #region ToResponse

        public static MenuWithItemsResponse ToFullResponse(this Menu entity)
        {
            return new MenuWithItemsResponse()
            {
                Id = entity.Id,
                RestaurantId = entity.RestaurantId,
                DiaDaSemana = entity.MenuDate,
                ItemResponses = entity.Itens.Select(i => i.ToResponse()).ToList()
            };
        }

        public static MenuResponse ToResponse(this Menu entity)
        {
            return new MenuResponse()
            {
                Id = entity.Id,
                DiaDaSemana = entity.MenuDate,
                RestaurantId = entity.RestaurantId
            };
        }
        #endregion

        #region ToEntity

        public static Menu ToEntity(this CreateMenu createMenuRequest) 
        {
            return new Menu()
            {
                RestaurantId = createMenuRequest.RestaurantId,
                MenuDate = createMenuRequest.DiaDaSemana,
            };
        }
        #endregion
    }
}
