using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Services.DTO.Request;
using Services.Interfaces;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {

        private readonly IMenuService _menuService;
        private readonly IMenuItemService _menuItemService;

        public MenuController(IMenuService menuService, IMenuItemService menuItemService)
        {
            _menuService = menuService;
            _menuItemService = menuItemService;
        }

        #region GetStuff

        [HttpGet]
        public async Task<IActionResult> GetMenuById(params long[] id)
        {
            var response = await this._menuService.GetMenusById(id);
            if (response == null) { return NotFound("No menu was found"); };

            return Ok(response);
        }

        [HttpGet]
        [Route("{menuId}/items")]
        public async Task<IActionResult> GetFullMenuWithItens(long menuId)
        {
            var response = await this._menuItemService.GetMenuItensOfAMenu(menuId);
            if (response == null) { return NotFound($"MenuID {menuId} wasnt found"); }

            return Ok(response);
        }

        #endregion


        #region PostStuff

        [HttpPost]
        public async Task<IActionResult> PostMenu(CreateMenu request)
        {
            var response = await this._menuService.AddMenu(request);

            return Ok(response);
        }

        [HttpPost]
        [Route("{menuId}/items/{menuItemId}")]
        public async Task<IActionResult> AddMenuItemToMeu(long menuId, long menuItemId)
        {
            var response = await this._menuItemService.AddMenuItemToMenu(menuItemId, menuId);
            if (response == null) { return NotFound($"Menu ({menuId}) or MenuItem ({menuItemId}) not found"); }
            
            return Ok(response);
        }
        #endregion



        #region RestOfStuff

        #region PatchRegion

        [HttpPatch]
        [Route("{menuId}")]
        public async Task<IActionResult> EditMenu(long menuId,EditMenu request)
        {
            var response = await this._menuService.EditMenu(request);
            if (response == null) { return NotFound($"Menu with id{menuId} was not found"); }

            return Ok(response);
        }

        #endregion

        #region DeleteRegion
        [HttpDelete]
        [Route("{menuId}")]
        public async Task<IActionResult> DeleteMenu(long menuId)
        {
            bool response = await this._menuService.DeletarMenu(menuId);
            return response ? Ok(response) : NotFound($"Menu with id {menuId} wasnt found");
        }
        
        [HttpDelete]
        [Route("{menuId}/items/{menuItemId}")]
        public async Task<IActionResult> UnlinkMenuItemOfAMenu(long menuId,long menuItemId)
        {
            var response = await this._menuItemService.RemoveMenuItemOfMenu(menuId, menuItemId);
            if (response == null) { return NotFound($"Menu ({menuId}) or/and menuItem ({menuItemId}) was not found"); }

            return Ok(response);
        }

        #endregion
        #endregion
    }
}
