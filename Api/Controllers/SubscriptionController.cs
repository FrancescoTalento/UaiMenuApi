using Data.Entities.Models;
using Data.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DTO.Request;
using Services.Interfaces;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionController : ControllerBase
    {
        private readonly ISubscriptionService _subscriptionService;

        public SubscriptionController(ISubscriptionService subscriptionService)
        {
            _subscriptionService = subscriptionService;
        }

        [HttpGet]
        [Route("{subscriptionId}/menus")]
        public async Task<IActionResult> GetMenusOfSubcription(long subscriptionId) 
        {
            var response = await this._subscriptionService.GetMenusOfSubscription(subscriptionId);
            if(response is null) return NotFound($"SubscriptionId {subscriptionId} was not found");

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubscription(CreateSubscription request)
        {
            var response = await this._subscriptionService.SubscribeTo(request);
            if (response == null) { return NotFound($"Client was not found {request.ClientId}"); }
            return Ok(response);
        }

        [HttpPatch]
        [Route("{subscriptionId}/days")]
        public async Task<IActionResult> PatchDaysSubscriptions(long subscriptionId, EditSubscriptionDays request) 
        {
            var response = await this._subscriptionService.EditSubscriptionDays(request);
            if (response == null) { return NotFound($"SubscriptionId {subscriptionId} was not found"); }
            return Ok(response);
        }

        [HttpDelete]
        [Route("{subscriptionId}")]
        public async Task<IActionResult> DeleteSubscription(long subscriptionId)
        {
            bool wasDeleted = await this._subscriptionService.Unsubscribe(subscriptionId);
            return wasDeleted ? Ok() : NotFound($"subscriptionId {subscriptionId} wasnt found");
        }

//GET / api / subscriptions /{ subscriptionId: long}/ menus
    }
}
