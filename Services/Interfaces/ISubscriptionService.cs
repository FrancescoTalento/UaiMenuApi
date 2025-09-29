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
        public Task<SubscriptionResponse> SubscribeTo(CreateSubscription subscriptionRequest);

        public Task<bool> Unsubscribe(long subscriptionId);

        public Task<SubscriptionResponse> EditSubscriptionDays(EditSubscriptionDays editSubscriptionRequest);

        public Task<IEnumerable<SubscriptionResponse>> GetSubscriptionByDay(long restaurantId,Weekday[] days);

        public Task<IEnumerable<ClientResponse>> GetClientsOfSubscriptionDay(long restaurantId, Weekday[] days);

        public Task<IReadOnlyList<MenuWithItemsResponse>> GetMenusOfSubscription(long subscriptionId);
        
        public Task<IReadOnlyList<MenuWithItemsResponse>> GetMenusOfSubscription(long subscriptionId, CancellationToken ct = default);


    }
}
