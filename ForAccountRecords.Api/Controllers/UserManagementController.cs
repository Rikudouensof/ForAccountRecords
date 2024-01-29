using ForAccountRecords.Api.ApplicationTasks;
using ForAccountRecords.Application.Helpers;
using ForAccountRecords.Application.Services.ApiServices.EndpointCreationService;
using ForAccountRecords.Domain.Constants;
using ForAccountRecords.Domain.Dtos.InnerDtos.ServiceDtos.UserManagementDtos.Request;
using ForAccountRecords.Domain.Helpers;
using ForAccountRecords.Domain.ViewModels.InternalViewModels.UserManagementViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ForAccountRecords.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserManagementController : ControllerBase
    {
        private readonly IUserManagementCreationService _userMgmt;
        private readonly IAppSettingGenerator _appSetting;
        private readonly ILogHelper _logger;
        readonly string classname = nameof(UserManagementController);

        public UserManagementController(IUserManagementCreationService userManagementService,
          IAppSettingGenerator appSettingGenerator,
          ILogHelper logger
          )
        {
            _userMgmt = userManagementService;
            _appSetting = appSettingGenerator;
            _logger = logger;
        }


        [HttpPost("Register")]
        public IActionResult RegisterNewUser(RegisterViewModel input)
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

        [HttpPost("Login")]
        public IActionResult LoginUser(LoginViewModel input)
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
            var payload = new LoginRequestDto()
            {
                AppSettings = appSettings,
                InputData = input,
                Ip = Ip,
                RequestId = requestId
            };
            var response = _userMgmt.LoginUser(payload);
            if (response.ResponseCode == GeneralResponse.sucessCode)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        [HttpPost("ConfirmEmailAddress")]
        public IActionResult ConfirmEmail(ConfirmEmailViewModel input)
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
            var payload = new ConfirmEmailRequestDto()
            {
                AppSettings = appSettings,
                InputData = input,
                Ip = Ip,
                RequestId = requestId
            };
            var response = _userMgmt.ConfirmEmail(payload);
            if (response.ResponseCode == GeneralResponse.sucessCode)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }


        [Authorize]
        [HttpPost("ConfirmDeleteAccount")]
        public IActionResult DeleteAccountConfirmation(ConfirmDeleteAccountViewModel input)
        {
            var methodname = $"{classname}/{nameof(DeleteAccountConfirmation)}";
            var appSettings = _appSetting.Generate();
            var requestId = GeneralHelpers.GetNewRequestId();
            var Ip = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            _logger.LogInformation(requestId, "New Process", Ip, methodname);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var payload = new ConfirmDeleteAccountRequestDto()
            {
                InputData = input,
                AppSettings = appSettings,
                Ip = Ip,
                RequestId = requestId
            };
            var response = _userMgmt.ConfirmDeleteAccount(payload);
            if (response.ResponseCode == GeneralResponse.sucessCode)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }

        }

        [Authorize]
        [HttpPost("DeleteAccount")]
        public IActionResult AccountDelete(UserByIdViewModel input)
        {
            var methodname = $"{classname}/{nameof(AccountDelete)}";
            var appSettings = _appSetting.Generate();
            var requestId = GeneralHelpers.GetNewRequestId();
            var Ip = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            _logger.LogInformation(requestId, "New Process", Ip, methodname);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var payload = new DeleteAccountRequestDto()
            {
                InputData = input,
                AppSettings = appSettings,
                Ip = Ip,
                RequestId = requestId
            };
            var response = _userMgmt.DeleteAccount(payload);
            if (response.ResponseCode == GeneralResponse.sucessCode)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }

        }



        [HttpPost("ForgotPassword")]
        public IActionResult ForgotPasswordSet(ForgotPasswordViewModel input)
        {
            var methodname = $"{classname}/{nameof(ForgotPasswordSet)}";
            var appSettings = _appSetting.Generate();
            var requestId = GeneralHelpers.GetNewRequestId();
            var Ip = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            _logger.LogInformation(requestId, "New Process", Ip, methodname);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var payload = new ForgotPasswordRequestDto()
            {
                InputData = input,
                AppSettings = appSettings,
                Ip = Ip,
                RequestId = requestId
            };
            var response = _userMgmt.ForgotPassword(payload);
            if (response.ResponseCode == GeneralResponse.sucessCode)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }

        }

        [Authorize]
        [HttpPost("GetBasicUserInfo")]
        public IActionResult BasicUserInfo(UserByIdViewModel input)
        {
            var methodname = $"{classname}/{nameof(BasicUserInfo)}";
            var appSettings = _appSetting.Generate();
            var requestId = GeneralHelpers.GetNewRequestId();
            var Ip = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            _logger.LogInformation(requestId, "New Process", Ip, methodname);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var payload = new GetBasicUserInfoRequestDto()
            {
                InputData = input,
                AppSettings = appSettings,
                Ip = Ip,
                RequestId = requestId
            };
            var response = _userMgmt.GetBasicUserInfo(payload);
            if (response.ResponseCode == GeneralResponse.sucessCode)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }

        }

        [Authorize]
        [HttpPost("GetUserDetails")]
        public IActionResult UserDetails(UserByIdViewModel input)
        {
            var methodname = $"{classname}/{nameof(BasicUserInfo)}";
            var appSettings = _appSetting.Generate();
            var requestId = GeneralHelpers.GetNewRequestId();
            var Ip = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            _logger.LogInformation(requestId, "New Process", Ip, methodname);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var payload = new GetUserDetailsRequestDto()
            {
                InputData = input,
                AppSettings = appSettings,
                Ip = Ip,
                RequestId = requestId
            };
            var response = _userMgmt.GetUserDetails(payload);
            if (response.ResponseCode == GeneralResponse.sucessCode)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }

        }

        [HttpPost("ResetPassword")]
        public IActionResult ResetUserPassword(ResetPasswordViewModel input)
        {
            var methodname = $"{classname}/{nameof(ResetUserPassword)}";
            var appSettings = _appSetting.Generate();
            var requestId = GeneralHelpers.GetNewRequestId();
            var Ip = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            _logger.LogInformation(requestId, "New Process", Ip, methodname);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var payload = new ResetPasswordRequestDto()
            {
                InputData = input,
                AppSettings = appSettings,
                Ip = Ip,
                RequestId = requestId
            };
            var response = _userMgmt.ResetPassword(payload);
            if (response.ResponseCode == GeneralResponse.sucessCode)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }

        }



        //TO remove before deployment
        [HttpPost("HashPassword")]
        public IActionResult HashPainTextPassword(string password)
        {
            var methodname = $"{classname}/{nameof(RegisterNewUser)}";
            var appSettings = _appSetting.Generate();
            var requestId = GeneralHelpers.GetNewRequestId();
            var Ip = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            _logger.LogInformation(requestId, "New Process", Ip, methodname);
            return Ok(_userMgmt.HashPasswordTest(password, appSettings));
        }
    }
}
