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
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == menuId);
            if (menu == null) { return null; }

            var menuItem = await this._dbContext.MenuItems.FindAsync(menuItemId);
            if (menuItem == null) { return null; };

            menuItem.MenuId = menuId;

            await this._dbContext.SaveChangesAsync();
            return menuItem.ToResponse();

        }

        public Task<MenuItemResponse> CreateMenuItem(MenuItemRequest menuItemRequest)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteMenuItem(long menuItemId)
        {
            throw new NotImplementedException();
        }

        public Task<MenuItemResponse?> EditMenuItem(long menuItemId, EditMenuItem editMenuItem)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<MenuItemResponse>?> GetMenuItensOfAMenu(long menuId)
        {
            throw new NotImplementedException();
        }
    }
}
