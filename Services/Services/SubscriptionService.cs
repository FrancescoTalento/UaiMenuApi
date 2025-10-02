using Data.Entities;
using Data.Enums;
using Microsoft.EntityFrameworkCore;
using Services.DTO.Request;
using Services.DTO.Response;
using Services.Extensions;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly UaiMenuDbContext _dbContext;

        public SubscriptionService(UaiMenuDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<SubscriptionResponse> EditSubscriptionDays(EditSubscriptionDays editSubscriptionRequest)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ClientResponse>?> GetClientsOfSubscriptionDay(long restaurantId, Weekday[] days)
        {
            
            var restaurant = await this._dbContext.Restaurants
                .AsNoTracking()
                .FirstOrDefaultAsync(r => r.Id == restaurantId);
            if (restaurant == null) { return null; }

            var q = this._dbContext.Subscriptions
                .AsNoTracking()
                .Where(s => s.RestaurantId == restaurantId)
                .Where(s => s.Days.Any(d => days.Contains(d)))
                .OrderBy(s => s.Days);

            var clients = await q   

                .Select(s => s.Client)
                .Distinct()
                .Select(c => c.ToResponse())
                .ToListAsync();

            return clients;
        }

        public Task<IReadOnlyList<MenuWithItemsResponse>> GetMenusOfSubscription(long subscriptionId)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<SubscriptionResponse>> GetSubscriptionByDay(long restaurantId, Weekday[] days)
        {
            throw new NotImplementedException();
        }

        public Task<SubscriptionResponse> SubscribeTo(CreateSubscription subscriptionRequest)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Unsubscribe(long subscriptionId)
        {
            var subscription = await this._dbContext.Subscriptions.FindAsync(subscriptionId);

            bool exists = subscription is null ? false : true;

            if (exists)
            {
                this._dbContext.Remove(subscription);
                await this._dbContext.SaveChangesAsync();
            }

            return exists;
        }
    }
}
