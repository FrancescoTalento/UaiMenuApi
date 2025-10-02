using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DTO.Request;
using Services.Interfaces;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdmController : ControllerBase
    {

        private readonly IAdmService _admService;

        public AdmController(IAdmService admService)
        {
            this._admService = admService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAdm(AdmRequest clientRequest)
        {
            var response = await this._admService.CreateAdm(clientRequest);

            if (response == null) { return BadRequest($"Not Existing RestaurantId ${clientRequest.RestaurantId}"); }

            return Ok(response);

        }

        [HttpPatch]
        public async Task<IActionResult> EditAdm(AdmEditRequest request)
        {
            var response = await this._admService.EditAdm(request);
            if (response is null) return NotFound(request.Id);

            return Ok(response);
        }

        [HttpDelete]
        [Route("{admId}")]
        public async Task<IActionResult> DeleteAdm(long admId)
        {
            bool isDeleted = await this._admService.RemoveAdm(admId);
            return isDeleted ? Ok($"deleted {admId}") : NotFound($"Not Found adm {admId}");
        }
    }
}
