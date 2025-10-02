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


        #endregion

        public RestaurantController
            (
            IRestaurantService restaurantService,
            IAdmService admService, 
            IClientService clientService
            )
        {
            this._restaurantService = restaurantService;
            _admService = admService;
            _clientService = clientService;
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
            throw new NotImplementedException();
        }
       
        [HttpGet]
        [Route("{restaurantId}/menus/{weekday}")]
        public async Task<IActionResult> GetMenusOfRestaurantByWeekday(long restaurantId, Weekday weekday)
        {
            throw new NotImplementedException();
        }
        #endregion


        #region SubscriptionRelated
        [HttpGet]
        [Route("{restaurantId}/subscriptions/{weekday})")]
        public async Task<IActionResult> GetSubscriptionsByWeekday(long restaurantId, Weekday weekday)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("{restaurantId}/subscriptions/clients/{weekday})")]
        public async Task<IActionResult> GetClientsOfSubscriptionsByWeekday(long restaurantId, Weekday weekday)
        {
            throw new NotImplementedException();
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
