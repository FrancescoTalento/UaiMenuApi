using Services.DTO.Request;
using Services.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IClientService
    {
        public Task<IReadOnlyList<ClientResponse>> GetClientsOfRestaurant(long restaurantId);

        public Task<ClientResponse>CreateClient(ClientRequest clientRequest);
       // public ClientResponse LoginIn(ClientLoginRequest clientRequest);

        public Task<ClientResponse> EditClient(ClientEditRequest clientRequest);

    }
}
