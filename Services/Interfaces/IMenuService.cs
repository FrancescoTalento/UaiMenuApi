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

        public Task<MenuResponse> EditMenu(EditMenu menuRequest);

        public Task<bool> DeletarMenu(long menuId);

        public Task<IEnumerable<MenuWithItemsResponse>> GetMenusWithItens(long restaurantId);

        public Task<MenuItemResponse> GetMenuWithItens(long restaurantId, Weekday weekday);
    }
}
