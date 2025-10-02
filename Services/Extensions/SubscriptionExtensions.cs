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
    public static class SubscriptionExtensions
    {
        #region ToResponse
        public static SubscriptionResponse ToResponse(this Subscription entity)
        {
            return new SubscriptionResponse()
            {
                Id = entity.Id,
                ClientId = entity.ClientId,
                Days = entity.Days,
                HoraEnvioLocal = entity.HoraEnvioLocal,
                RestaurantId = entity.RestaurantId,
            };
        }
        #endregion
        #region ToEntity

        public static Subscription ToEntity(this CreateSubscription createSubscription) 
        {
            return new Subscription()
            {
                ClientId = createSubscription.ClientId,
                Days = createSubscription.Days,
                HoraEnvioLocal = createSubscription.HoraEnvioLocal,
                RestaurantId = createSubscription.RestaurantId,
            };
        }
        #endregion
    }
}
