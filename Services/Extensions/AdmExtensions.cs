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
    public static class AdmExtensions
    {
        #region ToEntity
        public static Admin ToEntity(this AdmRequest request)
        {
            return new Admin()
            {
                RestaurantId = request.RestaurantId,
                Email = request.Email,
                SenhaHash = request.SenhaHash,
                CanManageAdmins = request.CanManageAdmins,
                CanManageMenus = request.CanManageMenus
            };
        }
        #endregion

        #region ToResponse
        public static AdmResponse ToResponse(this Admin admin)
        {
            return new AdmResponse()
            {
                Id = admin.Id,
                Email = admin.Email,
                RestaurantId = admin.RestaurantId,
                CanManageAdmins = admin.CanManageAdmins,
                CanManageMenus = admin.CanManageMenus
            };

            #endregion
        }
    }
}
