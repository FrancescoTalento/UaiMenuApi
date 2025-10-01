using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO.Response
{
    public record ClientResponse(long id,string PhoneNumber, string Email,string Nome, bool? OptIn);
    
}
