using Azure.Core;
using ForAccountRecords.Api.ApplicationTasks;
using ForAccountRecords.Application.Helpers;
using ForAccountRecords.Application.Services;
using ForAccountRecords.Domain.Constants;
using ForAccountRecords.Domain.Dtos.ServiceDtos.UserManagementDtos.Request;
using ForAccountRecords.Domain.Dtos.ServiceDtos.UserManagementDtos.Response;
using ForAccountRecords.Domain.ViewModels.UserManagementViewModels;
using ForAccountRecords.Infrastructure.Helpers;
using ForAccountRecords.Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ForAccountRecords.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UserManagementController : ControllerBase
  {
    private readonly IUserManagementService _userMgmt;
    private readonly IAppSettingGenerator _appSetting;
    private readonly ILogHelper _logger;
    readonly string classname = nameof(UserManagementController);

    public UserManagementController(IUserManagementService userManagementService,
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

    [HttpPost("HashPassword")]
    public IActionResult HashPainTextPassword(string password)
    {
      var methodname = $"{classname}/{nameof(RegisterNewUser)}";
      var appSettings = _appSetting.Generate();
      var requestId = GeneralHelpers.GetNewRequestId();
      var Ip = Request.HttpContext.Connection.RemoteIpAddress.ToString();
      _logger.LogInformation(requestId, "New Process", Ip, methodname);
      return Ok( _userMgmt.HashPasswordTest(password, appSettings));
    }

  }
}
