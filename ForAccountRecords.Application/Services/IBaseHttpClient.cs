using ForAccountRecords.Domain.Dtos.PresentationDtos.HelperDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForAccountRecords.Application.Services
{
    public interface IBaseHttpClient
    {
        Task<string> MakeHTTPRequest(HttpClientDto input);
    }
}
