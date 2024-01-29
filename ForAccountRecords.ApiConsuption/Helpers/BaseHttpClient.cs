using ForAccountRecords.Application.Helpers;
using ForAccountRecords.Application.Services;
using ForAccountRecords.Domain.Constants;
using ForAccountRecords.Domain.Dtos.PresentationDtos.HelperDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ForAccountRecords.ApiConsuption.Helpers
{


    public class BaseHttpClient : IBaseHttpClient
    {

        private readonly ILogHelper _logger;
        private readonly string className = nameof(BaseHttpClient);
        readonly HttpClientCallFormats contentType = new HttpClientCallFormats();
        readonly HttpClientRequestTypes requestType = new HttpClientRequestTypes();
        readonly FormMultitypeFileTypes formFileTypes = new FormMultitypeFileTypes();
        public BaseHttpClient(ILogHelper logger)
        {
            _logger = logger;
        }


        public async Task<string> MakeHTTPRequest(HttpClientDto input)
        {
            var getmethodName = nameof(MakeHTTPRequest);
            var methodName = $"{className}/{getmethodName}";
            string response = " ";
            var acceptRequestType = contentType.GetSingleHttpClientCallFormat(input.HttpClientRequestAcceptTypeId);
            var sendRequestType = contentType.GetSingleHttpClientCallFormat(input.HttpClientRequestSendTypeId);
            var currentRequestType = requestType.GetSingleHttpClientRequestType(input.HttpClientCallFomatId);
            _logger.LogInformation(input.RequestId, $"New HttpClient {currentRequestType.Name} request for {input.RequestId} from {input.methodName}", input.HostIp, methodName);

            using HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(input.BaseUrl);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(acceptRequestType.Name));
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", sendRequestType.Name);
            if (!string.IsNullOrEmpty(input.token))
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", input.token);
            }

            if (input.Headers is not null)
            {
                foreach (var header in input.Headers)
                {
                    client.DefaultRequestHeaders.Add(header.Name, header.Value);
                }
            }


            if (input.HttpClientRequestSendTypeId == contentType.multipartFormData)
            {
                response = await MultipartData(client, input);

                _logger.LogInformation(input.RequestId, $" HttpClient {currentRequestType.Name} Response for {input.RequestId} for {input.methodName}::: Api response :{response}", input.HostIp, methodName);
            }
            else if (input.HttpClientRequestSendTypeId == contentType.applicationJson)
            {
                response = await JsonRequest(client, input);
                _logger.LogInformation(input.RequestId, $" HttpClient {currentRequestType.Name} Response for {input.RequestId} for {input.methodName}::: Api response :{response}", input.HostIp, methodName);
            }
            return response;
        }

        private async Task<string> JsonRequest(HttpClient client, HttpClientDto input)
        {
            var getmethodName = nameof(JsonRequest);
            var methodName = $"{className}/{getmethodName}";
            var currentRequestType = requestType.GetSingleHttpClientRequestType(input.HttpClientCallFomatId);
            string response = " ";

            _logger.LogInformation(input.RequestId, $"New JsonRequest {currentRequestType.Name} request for {input.RequestId} from {input.methodName}", input.HostIp, methodName);


            try
            {
                if (input.HttpClientCallFomatId == requestType.Get)
                {
                    var apiResponse = await client.GetAsync(input.PathUrl);
                    var apiResponseContent = await apiResponse.Content.ReadAsStringAsync();
                    response = apiResponseContent;
                }
                else if (input.HttpClientCallFomatId == requestType.Post)
                {
                    var stringContent = new StringContent(input.Request, Encoding.UTF8, "application/json");
                    var apiResponse = await client.PostAsync(input.PathUrl, stringContent);
                    var apiResponseContent = await apiResponse.Content.ReadAsStringAsync();
                    response = apiResponseContent;
                }



            }
            catch (Exception ex)
            {

                _logger.LogTrace(input.RequestId, $"Api call :  JsonRequest {currentRequestType.Name} request for {input.RequestId} from {input.methodName}", input.HostIp, methodName, ex);
            }
            return response;

        }

        private async Task<string> MultipartData(HttpClient client, HttpClientDto input)
        {
            var getmethodName = nameof(JsonRequest);
            var methodName = $"{className}/{getmethodName}";
            var currentRequestType = requestType.GetSingleHttpClientRequestType(input.HttpClientCallFomatId);
            string response = " ";
            _logger.LogInformation(input.RequestId, $"New MultipartData {currentRequestType.Name} request for {input.RequestId} from {input.methodName}", input.HostIp, methodName);
            using (var multipartFormDataContent = new MultipartFormDataContent())
            {
                try
                {
                    for (int counter = 0; counter < input.MultipartPair.Count; counter++)
                    {
                        var formData = input.MultipartPair[counter];
                        if (formData.FormContentTypeId == formFileTypes.StringTypeId)
                        {
                            multipartFormDataContent.Add(new StringContent(formData.FormContent.ToString()),
                               string.Format("\"{0}\"", formData.FormName));
                        }
                        else if (formData.FormContentTypeId == formFileTypes.ByteArrayTypeId && !string.IsNullOrEmpty(formData.FileName))
                        {
                            multipartFormDataContent.Add(new ByteArrayContent(new CoreConvertions().ObjectToByteArray(formData.FormContent)), formData.FileName);
                        }


                    }


                    if (input.HttpClientCallFomatId == requestType.Post)
                    {
                        var apiResponse = await client.PostAsync(input.PathUrl, multipartFormDataContent);
                        var apiResponseContent = await apiResponse.Content.ReadAsStringAsync();
                        response = apiResponseContent;
                    }

                }
                catch (Exception ex)
                {

                    _logger.LogTrace(input.RequestId, $"Api call :  MultipartData {currentRequestType.Name} request for {input.RequestId} from {input.methodName}", input.HostIp, methodName, ex);
                }





            }

            return response;
        }
    }
}
