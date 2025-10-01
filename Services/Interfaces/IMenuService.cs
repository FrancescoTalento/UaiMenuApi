using Data.Enums;
using Services.DTO.Request;
using Services.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IMenuService
    {
        public Task<MenuResponse> AddMenu(CreateMenu menuRequest);

        public Task<MenuResponse> EditMenu(long id, EditMenu menuRequest);

        public Task<bool> DeletarMenu(long menuId);

        public Task<IEnumerable<MenuWithItemsResponse>> GetAllMenusWithItens(long restaurantId);

        public Task<MenuItemResponse> GetMenuWithItensByDay(long restaurantId, Weekday weekday);
    }
}
