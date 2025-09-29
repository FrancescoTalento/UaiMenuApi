using Services.DTO.Request;
using Services.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IMenuItemService
    {
        public Task<MenuItemResponse>CreateMenuItem(MenuItemRequest menuItemRequest);

        public Task<bool> DeleteMenuItem(long menuItemId);

        public Task<IEnumerable<MenuItemResponse>> GetMenuItemByName(long menuItemId);

        public Task<MenuWithItemsResponse> AddMenuItemToMenu(long menuItem, long menuId);

        public Task<MenuItemResponse> EditMenuItem(EditMenuItem editMenuItem);
    }
}
