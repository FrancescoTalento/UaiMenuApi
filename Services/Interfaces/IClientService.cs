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
        public IReadOnlyList<ClientResponse> GetClientsOfRestaurant(long restaurantId);
        public ClientResponse CreateClient(ClientRequest clientRequest);
       // public ClientResponse LoginIn(ClientLoginRequest clientRequest);
        public ClientResponse EditClient(ClientEditRequest clientRequest);

        public IReadOnlyList<ClientResponse> GetClientOfRestaurant();
    }
}
