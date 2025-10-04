using Data.Entities;
using Data.Entities.Models;
using Data.Enums;
using Microsoft.EntityFrameworkCore;
using Services.DTO.Request;
using Services.DTO.Response;
using Services.Extensions;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class MenuService : IMenuService
    {
        private readonly UaiMenuDbContext _dbContext;

        public MenuService(UaiMenuDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<MenuResponse> AddMenu(CreateMenu menuRequest)
        {
            
            Menu entityToAdd = menuRequest.ToEntity();
            await this._dbContext.Menus.AddAsync(entityToAdd);
            await this._dbContext.SaveChangesAsync();

            return entityToAdd.ToResponse();
        }

        public async Task<bool> DeletarMenu(long menuId)
        {
            var menuTodelete = await this._dbContext.Menus.FindAsync(menuId);
            if (menuTodelete == null) { return false; };

            this._dbContext.Menus.Remove(menuTodelete);
            await this._dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<MenuResponse?> EditMenu(EditMenu menuRequest)
        {
            var menu = await this._dbContext.Menus.FindAsync(menuRequest.Id);
            if (menu == null) { return null; };

            menu.MenuDate = menuRequest.DiaDaSemana;
            await this._dbContext.SaveChangesAsync();   

            return menu.ToResponse();
        }

        public async Task<IEnumerable<MenuWithItemsResponse>?> GetAllMenusWithItens(long restaurantId)
        {
            var restaurant = await this._dbContext.Restaurants
                .AsNoTracking()
                .Where(r => r.Id == restaurantId)
                .FirstOrDefaultAsync();
            if (restaurant is null) return null;

            var menusWithItensOfRestaurant = await this._dbContext.Menus
                .AsNoTracking()
                .Where(m => m.RestaurantId == restaurantId)
                .Include(m => m.Itens)
                .Select(m => m.ToFullResponse())
                .ToListAsync();

            return menusWithItensOfRestaurant;

        }


        public async Task<MenuWithItemsResponse?> GetMenuWithItensByDay(long restaurantId, Weekday weekday)
        {
            var restaurant = await this._dbContext.Restaurants
                .AsNoTracking()
                .FirstOrDefaultAsync(r => r.Id == restaurantId);
            if (restaurant is null) return null;

            var menus = await this._dbContext.Menus
                .AsNoTracking()
                .Where(m => m.RestaurantId == restaurantId && m.MenuDate == weekday)
                .Include (m => m.Itens)
                .Select(m => m.ToFullResponse())
                .FirstOrDefaultAsync();

            return menus ?? new MenuWithItemsResponse();
        }
        public async Task<IReadOnlyList<MenuResponse>?> GetMenusById(params long[] ids)
        {
            var menus = this._dbContext.Menus
                .AsNoTracking()
                .Where(m => ids.Contains(m.Id))
                .Select(m => m.ToResponse())
                .AsQueryable();

            if(menus is null) return null;
            
            return await menus.ToListAsync();
        }
    }
}
