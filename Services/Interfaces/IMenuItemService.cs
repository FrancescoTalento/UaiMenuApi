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
        public Task<MenuItemResponse> CreateMenuItem(MenuItemRequest menuItemRequest);

//        Task<IReadOnlyList<MenuItemResponse>> GetMenuItemsByName(string name, long? restaurantId = null, long? menuId = null);
        public Task<MenuItemResponse> EditMenuItem(long menuItemId,EditMenuItem editMenuItem);

        public Task<bool> DeleteMenuItem(long menuItemId);

        public Task<MenuWithItemsResponse> AddMenuItemToMenu(long menuItemId, long menuId);

    }
}
