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
    public class AdmService : IAdmService
    {
        private readonly UaiMenuDbContext _dbcontext;

        public AdmService(UaiMenuDbContext dbContext)
        {
            this._dbcontext = dbContext;
        }

        public async Task<AdmResponse> CreateAdm(AdmRequest clientRequest)
        {
            Admin adminToAdd = clientRequest.ToEntity();
            
            await this._dbcontext.Admins.AddAsync(adminToAdd);

            await this._dbcontext.SaveChangesAsync();
            return adminToAdd.ToResponse();
        }

        public async Task<AdmResponse>? EditAdm(AdmEditRequest admEditRequest)
        {
            var entity = await this._dbcontext.Admins.FindAsync(admEditRequest.Id);
            if (entity == null) { return null; }
            
            if(admEditRequest.Email is not null) entity.Email = admEditRequest.Email;
            if(admEditRequest.SenhaHash is not null) entity.SenhaHash = admEditRequest.SenhaHash;
            if(admEditRequest.CanManageMenus is not null) entity.CanManageMenus = Convert.ToBoolean(admEditRequest.CanManageMenus);
            if (admEditRequest.CanManageAdmins is not null) entity.CanManageAdmins = Convert.ToBoolean(admEditRequest.CanManageAdmins);

            await this._dbcontext.SaveChangesAsync();
            return entity.ToResponse();

        }

        public async Task<IReadOnlyList<AdmResponse>?> GetAllAdm(int restaurantId)
        {
            var restaurant = await this._dbcontext.Restaurants
                .Include(r => r.Admins)
                .AsNoTracking()
                .FirstOrDefaultAsync(r => r.Id == restaurantId);
                
            if (restaurant is null) return null;

            return restaurant.Admins.Select(x => x.ToResponse()).ToList();
        }

        public async Task<bool> RemoveAdm(long admId)
        {
            var admToDelete = await this._dbcontext.Admins.FindAsync(admId);
            if (admToDelete is null) return false;

            this._dbcontext.Admins.Remove(admToDelete);
            await this._dbcontext.SaveChangesAsync();
            return true;
        }
    }
}
