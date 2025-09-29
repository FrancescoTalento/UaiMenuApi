using Data.Enums;
using Services.DTO.Request;
using Services.DTO.Response;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class MenuService : IMenuService
    {
        public Task<MenuResponse> AddMenu(CreateMenu menuRequest)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletarMenu(long menuId)
        {
            throw new NotImplementedException();
        }

        public Task<MenuResponse> EditMenu(EditMenu menuRequest)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MenuWithItemsResponse>> GetMenusWithItens(long restaurantId)
        {
            throw new NotImplementedException();
        }

        public Task<MenuItemResponse> GetMenuWithItens(long restaurantId, Weekday weekday)
        {
            throw new NotImplementedException();
        }
    }
}
