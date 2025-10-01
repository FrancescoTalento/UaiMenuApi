using Services.DTO.Request;
using Services.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IAdmService
    {
        public Task<AdmResponse> CreateAdm(AdmRequest clientRequest);

        public Task<IReadOnlyList<AdmResponse>> GetAllAdm(int restaurantId);   
//        public AdmResponse LoginIn(AdmLoginRequest clientRequest);
        public Task<AdmResponse>EditAdm(long admId, AdmEditRequest clientRequest);

        public Task<bool> RemoveAdm(long admId);
    }
}
