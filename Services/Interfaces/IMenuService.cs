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
        public MenuReponse AddMenu(CreateMenu menuRequest);

        public MenuReponse EditMenu(CreateMenu menuRequest);

        public bool DeletarMenu(int menuId);

        public MenuWithItensReponse GetMenuWithItens{ get; set; }
    }
}
