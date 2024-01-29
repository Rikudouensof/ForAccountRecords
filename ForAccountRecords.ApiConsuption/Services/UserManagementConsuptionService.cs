using ForAccountRecords.Application.Helpers;
using ForAccountRecords.Application.Services;
using ForAccountRecords.Application.Services.ApiServices.EndpointConsumptionService;
using ForAccountRecords.Domain.Constants;
using ForAccountRecords.Domain.Dtos.InnerDtos.ServiceDtos.UserManagementDtos.Request;
using ForAccountRecords.Domain.Dtos.InnerDtos.ServiceDtos.UserManagementDtos.Response;
using ForAccountRecords.Domain.Dtos.PresentationDtos.HelperDtos;
using ForAccountRecords.Domain.Helpers;
using ForAccountRecords.Domain.Models.GeneralModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForAccountRecords.ApiConsuption.Services
{
    public class UserManagementConsuptionService : IUserManagementConsuptionService
    {

        private IBaseHttpClient _httpClient;
        private readonly ILogHelper _logger;
        readonly string classname = nameof(UserManagementConsuptionService);
        readonly HttpClientCallFormats contentType = new HttpClientCallFormats();
        readonly HttpClientRequestTypes requestType = new HttpClientRequestTypes();
        readonly FormMultitypeFileTypes formFileTypes = new FormMultitypeFileTypes();
        public UserManagementConsuptionService(ILogHelper logger, IBaseHttpClient httpClient)
        {
                _logger = logger;
            _httpClient = httpClient;
        }



        public ConfirmDeleteAccountResponseDto ConfirmDeleteAccount(ConfirmDeleteAccountRequestDto input)
        {

            throw new NotImplementedException();
            //var payload = new HttpClientDto()
            //{
            //    HttpClientCallFomatId = requestType.Get,
            //    BaseUrl = input.AppSettings.ForAccountRecordApiBaseUrl,
            //    Headers = new List<HttpClientHeaderParameter> { new HttpClientHeaderParameter()}
            //};
            //var response = JsonConvert.DeserializeObject<ConfirmDeleteAccountResponseDto>();
            //return response;
        }

        public ConfirmEmailResponseDto ConfirmEmail(ConfirmEmailRequestDto input)
        {
            throw new NotImplementedException();
        }

        public DeleteAccountResponseDto DeleteAccount(DeleteAccountRequestDto input)
        {
            throw new NotImplementedException();
        }

        public ForgotPasswordResponseDto ForgotPassword(ForgotPasswordRequestDto input)
        {
            throw new NotImplementedException();
        }

        public GetBasicUserInfoResponseDto GetBasicUserInfo(GetBasicUserInfoRequestDto input)
        {
            throw new NotImplementedException();
        }

        public GetUserDetailsResponseDto GetUserDetails(GetUserDetailsRequestDto input)
        {
            throw new NotImplementedException();
        }


        public string HashPassword(string password, AppSettings appSettings)
        {
            var response = SymentricEncyption.EncryptString(password, appSettings);
            return response;
        }

        public LoginResponseDto LoginUser(LoginRequestDto input)
        {
            throw new NotImplementedException();
        }

        public RegisterResponseDto RegisterUser(RegisterRequestDto input)
        {
            throw new NotImplementedException();
        }

        public ResetPasswordResponseDto ResetPassword(ResetPasswordRequestDto input)
        {
            throw new NotImplementedException();
        }

        //private HttpClientHeaderParameter GetJwtHttpClientHeaderParameter(AppSettings appSettings)
        //{

        //    return new HttpClientHeaderParameter()
        //    {
        //        Name
        //    };
        //}
    }
}
