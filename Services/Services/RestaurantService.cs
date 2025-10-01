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
    public class RestaurantService : IRestaurantService
    {
        private readonly UaiMenuDbContext _dbContext;

        public RestaurantService(UaiMenuDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<RestaurantResponse> AddRestaurant(CreateRestaurant restaurantRequest)
        {
            Restaurant restaurantToAdd = restaurantRequest.ToEntity();

            await this._dbContext.AddAsync(restaurantToAdd);
            await this._dbContext.SaveChangesAsync();

            return restaurantToAdd.ToResponse();
        }

        public async Task<bool> DeleteRestaurant(long idRestaurant)
        {
            var entity = await this._dbContext.Restaurants.FindAsync(idRestaurant);

            
            bool isDeleted = entity == null ? false : true;
            if (entity is not null)
            {
                this._dbContext.Restaurants.Remove(entity);
                await this._dbContext.SaveChangesAsync();
            }
            return isDeleted;
        }

        public async Task<RestaurantResponse>? EditarRestaurant(EditRestaurantRequest dto)
        {
            var entity = await this._dbContext.Restaurants.FindAsync(dto.Id);
            if (entity == null) return null;

            if (dto.Nome is not null) entity.Nome = dto.Nome;
            if (dto.Descricao is not null) entity.Descricao = dto.Descricao;

            await this._dbContext.SaveChangesAsync();

            return entity.ToResponse();
        }

        public async Task<RestaurantResponse>? GetRestaurantById(long id)
        {
            var entity = await this._dbContext.Restaurants.FindAsync(id);

            return entity == null ? null : entity.ToResponse();
        }

        public async Task<IEnumerable<RestaurantResponse>> GetRestaurants()
        {
            IQueryable<RestaurantResponse> restaurantResponses = this._dbContext.Restaurants
                .Select(r => r.ToResponse())
                .AsQueryable();
            return await restaurantResponses.ToListAsync();
        }
    }
}
