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
    public static class RestaurantExtensions
    {
        #region ToEntity
        public static Restaurant ToEntity(this CreateRestaurant createRestaurant)
        {
            return new Restaurant()
            {
                Nome = createRestaurant.Nome,
                Descricao = createRestaurant.Descricao
            };
        }

        #endregion

        #region ToResponse


        public static RestaurantResponse ToResponse(this Restaurant restaurant)
        {
            return new RestaurantResponse()
            {
                Id = restaurant.Id,
                Descricao = restaurant.Descricao,
                Nome = restaurant.Nome
            };
            #endregion
        }
    }
}
