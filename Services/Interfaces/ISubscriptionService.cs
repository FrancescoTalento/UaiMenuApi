using Data.Enums;
using Services.DTO.Request;
using Services.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ISubscriptionService
    {
        public SubscriptionResponse SubscriveTo(CreateSubscription subscriptionRequest);

        public bool Unsubscribe(long subscriptionId);

        public SubscriptionResponse EditSubscriptionDays(EditSubscriptionday editSubscriptionRequest);

        public IEnumerable<SubscriptionResponse> GetSubscriptionByDay(long restaurantId,Weekday[] days);

        public IEnumerable<ClientResponse> GetClientsOfSubscriptionDay(long restaurantId, Weekday[] days);

                

    }
}
