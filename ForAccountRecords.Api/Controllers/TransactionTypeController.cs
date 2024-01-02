using ForAccountRecords.Api.ApplicationTasks;
using ForAccountRecords.Application.Helpers;
using ForAccountRecords.Application.IConfiguration;
using ForAccountRecords.Domain.Models.DatabaseModels;
using ForAccountRecords.Domain.Models.GeneralModels;
using ForAccountRecords.Infrastructure.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ForAccountRecords.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
                var response = await _unitOfWork.TransactionTypes.All(baseRequestData);
                
                return Ok(response);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }


        }




        [HttpPost("GetSingle")]
        public async Task<IActionResult> GetSingle([FromBody] int Id)
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
                var response = await _unitOfWork.TransactionTypes.GetById(Id, baseRequestData);
                

                return Ok(response);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] TransactionType input)
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
                var response = await _unitOfWork.TransactionTypes.Add(input, baseRequestData);
                await _unitOfWork.CompleteAsync();
                if (response)
                {
                    return Ok("Successful");
                }
                return Ok("Failed");

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        [HttpPost("Edit")]
        public async Task<IActionResult> Edit([FromBody] TransactionType input)
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
                var response = await _unitOfWork.TransactionTypes.Update(input, baseRequestData);
                 await _unitOfWork.CompleteAsync();

                if (response)
                {
                    return Ok("Successful");
                }
                return Ok("Failed");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromBody] TransactionType input)
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
                var response = await _unitOfWork.TransactionTypes.Update(input, baseRequestData);
                await _unitOfWork.CompleteAsync();

                if (response)
                {
                    return Ok("Successful");
                }
                return Ok("Failed");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

    }
}
