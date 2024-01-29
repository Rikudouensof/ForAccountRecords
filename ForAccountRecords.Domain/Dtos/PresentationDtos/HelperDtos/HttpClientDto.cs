using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ForAccountRecords.Domain.Dtos.PresentationDtos.HelperDtos
{
    public class HttpClientDto
    {

        public int HttpClientCallFomatId { get; set; }

        public int HttpClientRequestSendTypeId { get; set; }

        public int HttpClientRequestAcceptTypeId { get; set; }

        public List<HttpClientMultipartPair>? MultipartPair { get; set; }

        public List<HttpClientHeaderParameter>? Headers { get; set; }

        public string BaseUrl { get; set; }
        public string RequestId { get; set; }

       
        public string Request { get; set; }

        public string token { get; set; }

        public string HostIp { get; set; }

        public string methodName { get; set; }

        public string PathUrl { get; set; }
    }
}
