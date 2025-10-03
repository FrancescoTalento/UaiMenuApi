using Data.Entities;
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
    public class MenuItemService : IMenuItemService
    {
        private readonly UaiMenuDbContext _dbContext;

        public MenuItemService(UaiMenuDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<MenuWithItemsResponse?> AddMenuItemToMenu(long menuItemId, long menuId)
        {
            var menu = await this._dbContext.Menus
                .Include(m=> m.Itens)
                .FirstOrDefaultAsync(m => m.Id == menuId);
            if (menu == null) { return null; }

            var menuItem = await this._dbContext.MenuItems.FindAsync(menuItemId);
            if (menuItem == null) { return null; };


            if(menuItem.RestaurantId != menu.RestaurantId)
            {
                return null;
            }
            
            if(!menu.Itens.Any(i => i.Id ==menuItem.Id)) 
            { 
                menu.Itens.Add(menuItem);  
            }

            await this._dbContext.SaveChangesAsync();

            return menu.ToFullResponse();

        }

        public async Task<MenuItemResponse?> CreateMenuItem(MenuItemRequest menuItemRequest)
        {
            var restaurant = await this._dbContext.Restaurants
                .AsNoTracking()
                .AsQueryable()
                .FirstOrDefaultAsync(r => r.Id == menuItemRequest.RestaurantId);

            if (restaurant == null) { return null; };
            var entityToAdd = menuItemRequest.ToEntity();

            await this._dbContext.MenuItems.AddAsync(entityToAdd);
            await this._dbContext.SaveChangesAsync();

            return entityToAdd.ToResponse();
        }

        public async Task<bool> DeleteMenuItem(long menuItemId)
        {
            var menuItemTodelete = await this._dbContext.MenuItems.FindAsync(menuItemId);
            bool wasFound = menuItemTodelete is null ? false : true;

            if (wasFound) 
            {
                this._dbContext.MenuItems.Remove(menuItemTodelete);
                await this._dbContext.SaveChangesAsync();
            }

            return wasFound;
        }

        public async Task<MenuItemResponse?> EditMenuItem(EditMenuItem menuItemEditRequest)
        {
            var menuItemToEdit = await this._dbContext.MenuItems.FindAsync(menuItemEditRequest.Id);
            if (menuItemToEdit is null) { return null; };

            if(menuItemEditRequest.Nome is not null) menuItemEditRequest.Nome = menuItemToEdit.Nome;
            if(menuItemEditRequest.Tipo is not null) menuItemEditRequest.Tipo = menuItemToEdit.Tipo;
            if(menuItemEditRequest.Posicao is not null) menuItemEditRequest.Posicao = menuItemToEdit.Posicao;

            await this._dbContext.SaveChangesAsync();

            return menuItemToEdit.ToResponse();
        }

        public async Task<IReadOnlyList<MenuItemResponse>?> GetMenuItensOfAMenu(long menuId)
        {
            bool exists = await this._dbContext.Menus
                .AsNoTracking()
                .AnyAsync(m => m.Id == menuId);
            if(!exists) return null;

            

            var menuItems = await this._dbContext.Menus
                .AsNoTracking()
                .Where(m => m.Id == menuId)
                .SelectMany(m => m.Itens)
                .OrderBy(i => i.Posicao)
                .Select(i => i.ToResponse())
                .ToListAsync();
            return menuItems;
            
        }

        public async Task<IReadOnlyList<MenuItemResponse>?> GetMenuItensOfARestaurant(long restaurantId)
        {
            var exists = await this._dbContext.Restaurants
                .AsNoTracking()
                .AnyAsync(r => r.Id == restaurantId);
            if(!exists) return null;

            return await this._dbContext.MenuItems
                .AsNoTracking()
                .Where(i => i.RestaurantId == restaurantId)
                .OrderBy(i => i.Posicao)
                .Select(i => i.ToResponse())
                .ToListAsync();
        }

        public async Task<MenuWithItemsResponse?> RemoveMenuItemOfMenu(long menuItemId, long menuId)
        {
            var menu = await this._dbContext.Menus
                .Include(m => m.Itens)
                .FirstAsync(m => m.Id == menuId);

            if(menu is null) return null;

            var menuItem = menu.Itens.FirstOrDefault(i => i.Id == menuItemId);
            if(menuItem is null) return menu.ToFullResponse();

            menu.Itens.Remove(menuItem);
            await this._dbContext.SaveChangesAsync();

            return menu.ToFullResponse();
        }

   
    }
}
