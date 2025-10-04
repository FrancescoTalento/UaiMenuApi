using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DTO.Request;
using Services.Interfaces;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemController : ControllerBase
    {
        private readonly IMenuItemService _menuItemService;

        public MenuItemController(IMenuItemService menuItemService)
        {
            _menuItemService = menuItemService;
        }

        [HttpPost]
        public async Task<IActionResult> PostMenuItem(MenuItemRequest request)
        {
            var response = await this._menuItemService.CreateMenuItem(request);
            if (response == null) { return NotFound($"RestaurantId {request.RestaurantId} was not found"); }
            return Ok(response);
        }

        [HttpPatch]
        [Route("{menuItemId}")]
        public async Task<IActionResult> EditMenuItem(EditMenuItem request,long menuItemId)
        {
            var response = await this._menuItemService.EditMenuItem(request);
            if (response == null) { return NotFound($"MenuItemId {request.Id} was not found"); }
            return Ok(response);
        }

        [HttpDelete]
        [Route("{menuItemId}")]
        public async Task<IActionResult> DeleteMenuItem(long menuItemId)
        {
            bool response = await this._menuItemService.DeleteMenuItem(menuItemId);

            return response ? Ok(response) : NotFound($"MenuItemId {menuItemId} was not found");
        }
    }
}
