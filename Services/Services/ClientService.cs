using Data.Entities;
using Data.Entities.Models;
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
    public class ClientService : IClientService
    {
        private readonly UaiMenuDbContext _dbContext;

        public ClientService(UaiMenuDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<ClientResponse> CreateClient(ClientRequest clientRequest)
        {
            Cliente clienteToAdd = clientRequest.ToEntity();
            await this._dbContext.Clients.AddAsync(clienteToAdd);

            await this._dbContext.SaveChangesAsync();

            return clienteToAdd.ToResponse();
        }

        public async Task<bool> DeleteClient(long clientId)
        {
            var clientToDelte = await this._dbContext.Clients.FindAsync(clientId);

            bool exists = clientToDelte is null ? false : true;
            if (exists) 
            {
                this._dbContext.Remove(clientToDelte);
                await this._dbContext.SaveChangesAsync();
            }

            return exists;
        }

        public async Task<ClientResponse?> EditClient(ClientEditRequest clientRequest)
        {
            Cliente? clientToEdit = await this._dbContext.Clients.FindAsync(clientRequest.Id);

            if (clientToEdit == null) { return null; }

            if(clientRequest.OptIn is not null) clientToEdit.OptIn = Convert.ToBoolean(clientRequest.OptIn);
            if(clientRequest.Email is not null) clientToEdit.Email = clientRequest.Email;
            if(clientRequest.SenhaHash is not null) clientToEdit.SenhaHash = clientRequest.SenhaHash;
            if(clientRequest.Nome is not null) clientToEdit.Nome = clientRequest.Nome;
            if(clientRequest.PhoneNumber is not null) clientToEdit.Phone = clientRequest.PhoneNumber;

            await this._dbContext.SaveChangesAsync();

            return clientToEdit.ToResponse();
        }

        public async Task<IReadOnlyList<ClientResponse>?> GetClientsOfRestaurant(long restaurantId)
        {
            var restaurant = await this._dbContext.Restaurants
                .AsNoTracking()
                .FirstOrDefaultAsync(r => r.Id == restaurantId);
            if (restaurant == null) { return null; }

            var clients = await this._dbContext.Subscriptions
                .AsNoTracking()
                .Where(s => s.RestaurantId == restaurantId)
                .Select(s => s.Client)
                    .Distinct()
                    .Select(c => c.ToResponse())
                .ToListAsync();
            return clients ?? new List<ClientResponse>() { };
        }

    }
}
