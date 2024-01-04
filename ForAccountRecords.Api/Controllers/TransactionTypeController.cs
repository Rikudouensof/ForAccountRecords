using ForAccountRecords.Api.ApplicationTasks;
using ForAccountRecords.Application.Helpers;
using ForAccountRecords.Application.IConfiguration;
using ForAccountRecords.Domain.Dtos.EndPointDtos.TransactionTypeEndpointDtos;
using ForAccountRecords.Domain.Models.DatabaseModels;
using ForAccountRecords.Domain.Models.GeneralModels;
using ForAccountRecords.Infrastructure.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ForAccountRecords.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class TransactionTypeController : ControllerBase
    {

        private IUnitOfWork _unitOfWork;
        private readonly IAppSettingGenerator _appSetting;
        private readonly ILogHelper _logger;
        readonly string classname = nameof(TransactionTypeController);

        public TransactionTypeController(
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
        public async Task<IActionResult> GetAll()
        {
            var methodname = $"{classname}/{nameof(GetAll)}";
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
                var response = await _unitOfWork.TransactionTypes.All(baseRequestData);
                _logger.LogInformation(requestId, "Process Sucessful", Ip, methodname);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(requestId, "Process Failed", Ip, methodname, ex);
                return BadRequest("Failed");
            }


        }




        [HttpPost("GetSingle")]
        public async Task<IActionResult> GetSingle([FromBody] TransactionTypeEndpointSingleDto input)
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
                var response = await _unitOfWork.TransactionTypes.GetById(input.Id, baseRequestData);

                _logger.LogInformation(requestId, "Process Sucessful", Ip, methodname);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(requestId, "Process Failed", Ip, methodname, ex);
                return BadRequest("Failed");
            }
        }


        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] TransactionTypeEendpointDataDto input)
        {
            var methodname = $"{classname}/{nameof(Add)}";
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
                var payload = new TransactionType()
                {
                    Id = input.Id,
                    Name = input.Name

                };
                var response = await _unitOfWork.TransactionTypes.Add(payload, baseRequestData);
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


        [HttpPost("Edit")]
        public async Task<IActionResult> Edit([FromBody] TransactionTypeEendpointDataDto input)
        {
            var methodname = $"{classname}/{nameof(Edit)}";
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
                var payload = new TransactionType()
                {
                    Id = input.Id,
                    Name = input.Name

                };
                var response = await _unitOfWork.TransactionTypes.Update(payload, baseRequestData);
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


        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromBody] TransactionTypeEndpointSingleDto input)
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

                var response = await _unitOfWork.TransactionTypes.Delete(input.Id, baseRequestData);
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

    }
}
