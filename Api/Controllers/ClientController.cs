using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DTO.Request;
using Services.Interfaces;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            this._clientService = clientService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateClient(ClientRequest request)
        {
            var response = await this._clientService.CreateClient(request);


            return Ok(response);
        }
        [HttpPatch]
        public async Task<IActionResult> EditClient(ClientEditRequest request)
        {
            var response = await this._clientService.EditClient(request);
            if(response is null) return NotFound(request.Id);

            return Ok(response);
        }

        [HttpDelete]
        [Route("{clientId}")]
        public async Task<IActionResult> DeleteClient(long clientId)
        {
            bool isDeleted = await this._clientService.DeleteClient(clientId);
            if(isDeleted) return NotFound(clientId);

            return Ok(isDeleted);
        }
    }
}
