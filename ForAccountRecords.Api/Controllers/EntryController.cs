using ForAccountRecords.Api.ApplicationTasks;
using ForAccountRecords.Application.Helpers;
using ForAccountRecords.Application.Services;
using ForAccountRecords.Domain.Constants;
using ForAccountRecords.Domain.Dtos.ServiceDtos.UserManagementDtos.Request;
using ForAccountRecords.Domain.Models.GeneralModels;
using ForAccountRecords.Domain.ViewModels.UserManagementViewModels;
using ForAccountRecords.Infrastructure.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ForAccountRecords.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntryController : ControllerBase
    {
        private readonly IUserManagementService _userMgmt;
        private readonly IAppSettingGenerator _appSetting;
        private readonly ILogHelper _logger;
        readonly string classname = nameof(EntryController);

        public EntryController(IUserManagementService userManagementService,
          IAppSettingGenerator appSettingGenerator,
          ILogHelper logger
          )
        {
            _userMgmt = userManagementService;
            _appSetting = appSettingGenerator;
            _logger = logger;
        }




        [HttpPost("GetTransactionTypes")]
        public IActionResult GetAllTransactionTypes(RegisterViewModel input)
        {
            var methodname = $"{classname}/{nameof(RegisterNewUser)}";
            var appSettings = _appSetting.Generate();
            var requestId = GeneralHelpers.GetNewRequestId();
            var Ip = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            _logger.LogInformation(requestId, "New Process", Ip, methodname);
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var registerUserPayload = new RegisterRequestDto()
            {
                InputData = input,
                AppSettings = appSettings,
                RequestId = requestId,
                Ip = Ip
            };
            var response = _userMgmt.RegisterUser(registerUserPayload);
            if (response.ResponseCode == GeneralResponse.sucessCode)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }
    }
}
