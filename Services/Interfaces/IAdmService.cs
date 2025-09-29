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
        public AdmResponse CreateAdm(AdmRequest clientRequest);
//        public AdmResponse LoginIn(AdmLoginRequest clientRequest);
        public AdmResponse EditAdm(AdmEditRequest clientRequest);
    }
}
