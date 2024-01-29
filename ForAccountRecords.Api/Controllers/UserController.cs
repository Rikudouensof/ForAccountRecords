using ForAccountRecords.Api.ApplicationTasks;
using ForAccountRecords.Application.Helpers;
using ForAccountRecords.Application.IConfiguration;
using ForAccountRecords.Domain.Dtos.InnerDtos.EndPointDtos.UserEndpointDto;
using ForAccountRecords.Domain.Helpers;
using ForAccountRecords.Domain.Models.DatabaseModels;
using ForAccountRecords.Domain.Models.GeneralModels;
using ForAccountRecords.Infrastructure.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;

namespace ForAccountRecords.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class UserController : ControllerBase
    {

        private IUnitOfWork _unitOfWork;
        private readonly IAppSettingGenerator _appSetting;
        private readonly ILogHelper _logger;
        readonly string classname = nameof(UserController);

        public UserController(
          IAppSettingGenerator appSettingGenerator,
          ILogHelper logger,
          IUnitOfWork unitOfWork
          )
        {

            _appSetting = appSettingGenerator;
            _logger = logger;
            _unitOfWork = unitOfWork;
        }




        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllEntry()
        {
            var methodname = $"{classname}/{nameof(GetAllEntry)}";
            var requestId = GeneralHelpers.GetNewRequestId();
            var Ip = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            _logger.LogInformation(requestId, "New Process", Ip, methodname);
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {

                var baseRequestData = new BaseRequestModel()
                {
                    Ip = Ip,
                    RequestId = requestId
                };
                var response = await _unitOfWork.Users.All(baseRequestData);
                if (!response.Any())
                {
                    return Ok("{Response message: No Records found}");
                }
                var outputData = new List<UserDetailEndpointOutputDto>();
                foreach (var item in response)
                {
                    var inneritem = await GetUserOutputData(item, baseRequestData);
                    outputData.Add(inneritem);
                }


                _logger.LogInformation(requestId, "Process Sucessful", Ip, methodname);
                return Ok(outputData);
            }
            catch (Exception ex)
            {
                _logger.LogError(requestId, "Process Failed", Ip, methodname, ex);
                return BadRequest("Failed");
            }


        }




        [HttpPost("GetSingle")]
        public async Task<IActionResult> GetSingle([FromBody] UserSingleEndpointDto input)
        {
            var methodname = $"{classname}/{nameof(GetSingle)}";
            var requestId = GeneralHelpers.GetNewRequestId();
            var Ip = Request.HttpContext.Connection.RemoteIpAddress.ToString();

            try
            {
                _logger.LogInformation(requestId, "New Process", Ip, methodname);
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                var baseRequestData = new BaseRequestModel()
                {
                    Ip = Ip,
                    RequestId = requestId
                };
                var response = await _unitOfWork.Users.GetById(input.Id, baseRequestData);
                if (response is null)
                {
                    return Ok("{Response message: No Records found}");
                }
                var outputData = GetUserOutputData(response,baseRequestData);
                _logger.LogInformation(requestId, "Process Sucessful", Ip, methodname);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(requestId, "Process Failed", Ip, methodname, ex);
                return BadRequest("Failed");
            }
        }








        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromBody] UserSingleEndpointDto input)
        {
            var methodname = $"{classname}/{nameof(Delete)}";
            var requestId = GeneralHelpers.GetNewRequestId();
            var Ip = Request.HttpContext.Connection.RemoteIpAddress.ToString();

            try
            {
                _logger.LogInformation(requestId, "New Process", Ip, methodname);
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                var baseRequestData = new BaseRequestModel()
                {
                    Ip = Ip,
                    RequestId = requestId
                };

                var userContacts = _unitOfWork.UserContacts.AllByUserId(input.Id, baseRequestData);
                foreach (var item in userContacts)
                {
                    await _unitOfWork.UserContacts.Delete(item.Id, baseRequestData);
                }
                var userEntries = _unitOfWork.Entries.AllByUserId(input.Id, baseRequestData);
                foreach (var item in userEntries)
                {
                    await _unitOfWork.Entries.Delete(item.Id, baseRequestData);
                }

                var response = await _unitOfWork.Users.Delete(input.Id, baseRequestData);
                await _unitOfWork.CompleteAsync();

                if (response)
                {
                    _logger.LogInformation(requestId, "Process Sucessful", Ip, methodname);
                    return Ok("Successful");
                }
                _logger.LogInformation(requestId, "Process Not Truly Sucessful", Ip, methodname);
                return Ok("Failed");
            }
            catch (Exception ex)
            {
                _logger.LogError(requestId, "Process Failed", Ip, methodname, ex);
                return BadRequest("Failed");
            }
        }




        private async Task<UserDetailEndpointOutputDto> GetUserOutputData(User user, BaseRequestModel baseRequestModel)
        {
            var innerData = new UserDetailEndpointOutputDto()
            {
                EmailAddress = user.EmailAddress,
                FirstName = user.FirstName,
                Id = user.Id,
                IsEmailConfirmed = user.IsEmailConfirmed,
                IsNewsLetter = user.IsNewsLetter,
                LastName = user.LastName,
                LastOnline = user.LastOnline,
                MiddleName = user.MiddleName,
                PhoneNumber = user.PhoneNumber,
                UserName = user.UserName
            };
            var role = await _unitOfWork.UserRoles.GetById(user.UserRolesId, baseRequestModel);
            innerData.Role = role.Name;
            return innerData;
        }
    }
}
