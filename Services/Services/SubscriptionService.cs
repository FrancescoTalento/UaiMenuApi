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

        public async Task<SubscriptionResponse?> EditSubscriptionDays(EditSubscriptionDays editSubscriptionRequest)
        {
            var entityToEdit = await this._dbContext.Subscriptions.FindAsync(editSubscriptionRequest.SubscriptionId);

            if (entityToEdit == null) { return null; };
            entityToEdit.Days = editSubscriptionRequest.NewDays;

            await this._dbContext.SaveChangesAsync();

            return entityToEdit.ToResponse();
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

        public async Task<IReadOnlyList<MenuWithItemsResponse>?> GetMenusOfSubscription(long subscriptionId)
        {
            var subscription = await this._dbContext.Subscriptions
                .AsNoTracking()
                .Where(s => s.Id == subscriptionId)
                .Select(s => new { s.RestaurantId, s.Days })
                .FirstOrDefaultAsync();
            if (subscription == null) { return null; };

            if(subscription.Days is null || subscription.Days.Length == 0) 
            {
                return Array.Empty<MenuWithItemsResponse>(); 
            };

            var days = subscription.Days;
            var menuList = await this._dbContext.Menus
                .AsNoTracking()
                .Where(m => m.RestaurantId.Equals(subscription.RestaurantId) && days.Contains(m.MenuDate))
                .Include(m => m.Itens)
                .Select(m => m.ToFullResponse())
                .ToListAsync();

            return menuList;

        }

        public async Task<IReadOnlyList<SubscriptionResponse>?> GetSubscriptionByDay(long restaurantId, Weekday[] days)
        {
            var restaurant = await this._dbContext.Restaurants.AsNoTracking().FirstOrDefaultAsync(s => s.Id == restaurantId);
            if (restaurant == null) { return null; }

            var q = await this._dbContext.Subscriptions
                .AsNoTracking()
                .Where(s => s.Days.Any(d => days.Contains(d)))
                .Select(s => s.ToResponse())
                .ToListAsync();
            
            return q;
        }

        public async Task<SubscriptionResponse?> SubscribeTo(CreateSubscription subscriptionRequest)
        {
            var restaurant = await this._dbContext.Restaurants.AsNoTracking().FirstOrDefaultAsync(r => r.Id ==subscriptionRequest.RestaurantId);
            if (restaurant == null) return null;
            
            var client = await this._dbContext.Clients.AsNoTracking().FirstOrDefaultAsync(c => c.Id == subscriptionRequest.ClientId);
            if(client == null) return null;

            var entityToAdd = subscriptionRequest.ToEntity();
            await this._dbContext.Subscriptions.AddAsync(entityToAdd);
            await this._dbContext.SaveChangesAsync();

            return entityToAdd.ToResponse();
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
