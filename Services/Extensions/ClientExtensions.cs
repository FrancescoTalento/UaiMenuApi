using Data.Entities.Models;
using Services.DTO.Request;
using Services.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Extensions
{
    public static class ClientExtensions
    {
        #region ToEntity
        public static Cliente ToEntity(this ClientRequest request)
        {
            return new Cliente()
            {
                Phone = request.PhoneNumber,
                Email = request.Email,
                SenhaHash = request.SenhaHash,
                Nome= request.Nome,
                OptIn = true
            };
        }

        #endregion

        #region ToResponse
        public static ClientResponse ToResponse(this Cliente entity) 
        {
            return new ClientResponse
                (
                    Email: entity.Email,
                    id: entity.Id,
                    Nome: entity.Nome ?? null,
                    PhoneNumber: entity.Phone,
                    OptIn: entity.OptIn
                );
        }
        #endregion
    }
}
