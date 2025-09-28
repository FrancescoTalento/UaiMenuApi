using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO.Response
{
    public record ImageResponse(long Id, string url, string fileName, string contentType, string? altText);


    
}
