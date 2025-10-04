using Data.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DTO.Request;
using Services.DTO.Response;
using Services.Interfaces;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        #region DbServices
        private readonly IRestaurantService _restaurantService;
        private readonly IAdmService _admService;
        private readonly IClientService _clientService;
        private readonly ISubscriptionService _subscriptionService;
        private readonly IMenuService _menuService;
        private readonly IMenuItemService _menuItemService;

        #endregion

        public RestaurantController
            (
            IRestaurantService restaurantService,
            IAdmService admService,
            IClientService clientService,
            ISubscriptionService subscriptionService,
            IMenuService menuService,
            IMenuItemService menuItemService)
        {
            this._restaurantService = restaurantService;
            _admService = admService;
            _clientService = clientService;
            _subscriptionService = subscriptionService;
            _menuService = menuService;
            _menuItemService = menuItemService;
        }

        #region GetStuff

        #region RestaurantRelated
        [HttpGet]
        [Route("")] // done and working
        public async Task<IActionResult> GetAllRestaurants()
        {
            IEnumerable<RestaurantResponse>? entities = await this._restaurantService.GetRestaurants();
            if(entities == null)
            {
                return Problem();
            }

            return Ok(entities);
        }

        [HttpGet]
        [Route("{restaurantId}")] //done and working
        public async Task<IActionResult> GetRestaurantById(long restaurantId)
        {
            RestaurantResponse? response = await this._restaurantService.GetRestaurantById(restaurantId);
            if (response == null) return NotFound(restaurantId);

            return Ok(response);
        }
        #endregion

        #region AdmRelated
        [HttpGet]
        [Route("{restaurantId}/admins")]
        public async Task<IActionResult> GetAdmOfRestaurant(long restaurantId)
        {
            var response = await this._admService.GetAllAdmOfRestaurant(restaurantId);
            if (response == null) return NotFound($"Invalid restaurantId {restaurantId}");

            return Ok(response);
        }
        #endregion

        #region ClientRelated
        [HttpGet]
        [Route("{restaurantId}/clients")]
        public async Task<IActionResult> GetClientsOfRestaurant(long restaurantId)
        {
            var response = await this._clientService.GetClientsOfRestaurant(restaurantId);
            if(response == null) return NotFound($"Invalid restaurantId {restaurantId}");
            
            return Ok(response);
        }

        #endregion

        #region MenuRelated
        [HttpGet]
        [Route("{restaurantId}/menus")]
        public async Task<IActionResult> GetMenusOfRestaurant(long restaurantId)
        {
            var response = await this._menuService.GetAllMenusWithItens(restaurantId);
            if (response == null) return NotFound($"Restaurant id {restaurantId} wasnt found");

            return Ok(response);
        }
       
        [HttpGet]
        [Route("{restaurantId}/menus/{weekday}")]
        public async Task<IActionResult> GetMenusOfRestaurantByWeekday(long restaurantId, Weekday weekday)
        {
            var response = await this._menuService.GetMenuWithItensByDay(restaurantId, weekday);
            if (response == null) return NotFound($"Restaurant id {restaurantId} wasnt found");

            return Ok(response);
        }
        #endregion

        #region MenuItemRelated
        [HttpGet]
        [Route("{restaurantId}/menu-itens")]
        public async Task<IActionResult> GetMenuItensOfRestaurant(long restaurantId)
        {
            var response = await this._menuItemService.GetMenuItensOfARestaurant(restaurantId);
            if (response is null) return NotFound($"RestaurantId {restaurantId} was not found");
            
            return Ok(response);
        }

        #endregion

        #region SubscriptionRelated
        [HttpGet]
        [Route("{restaurantId}/subscriptions/{weekday}")]
        public async Task<IActionResult> GetSubscriptionsByWeekday(long restaurantId, Weekday weekday)
        {
            var responsse = await this._subscriptionService.GetSubscriptionByDay(restaurantId, new Weekday[] { weekday });


            if(responsse == null) return NotFound($"Restaurant id {restaurantId} was not found");

            return Ok(responsse);
        }

        [HttpGet]
        [Route("{restaurantId}/subscriptions/clients)")]
        public async Task<IActionResult> GetClientsOfSubscriptionsByWeekday(long restaurantId,[FromQuery] Weekday weekdays)
        {
//            var filter = (weekdays is null || weekdays.Length == 0)
  //              ? Enum.GetValues<Weekday>()
    //            : weekdays;

           var response = await this._subscriptionService.GetClientsOfSubscriptionDay(restaurantId,new Weekday[] { weekdays });
            if(response is null) return NotFound($"RestaurantId Invalid {restaurantId}");

            return Ok(response);
        }
        #endregion

        

        #endregion


        #region RestOfEndPoints


        #region PostStuff

        [HttpPost]
        [Route("")] //done and working
        public async Task<IActionResult> CreateRestaurant(CreateRestaurant restaurantRequest)
        {
            RestaurantResponse? response = await this._restaurantService.AddRestaurant(restaurantRequest);
            if (response == null) return Problem();

            return new JsonResult(response);
        }

        

        #endregion

        #region PatchStuff

        [HttpPatch]
        [Route("")] //done and working
        public async Task<IActionResult> UpdateRestaurant(EditRestaurantRequest request)
        {
            var entity = await this._restaurantService.EditarRestaurant(request);
            if (entity == null) return NotFound(request.Id);

            return Ok(entity);
        }

        #endregion

        #region DeleteStuff
        [HttpDelete]
        [Route("{restaurantId}")] // done and working
        public async Task<IActionResult> DeleleteRestaurant(long restaurantId)
        {
            bool isDeleted = await this._restaurantService.DeleteRestaurant(restaurantId);

            return isDeleted ? Ok($"Entity with id {restaurantId} was deleted") : NotFound("Entity not found");
        }

        #endregion

        #endregion
    }
}
