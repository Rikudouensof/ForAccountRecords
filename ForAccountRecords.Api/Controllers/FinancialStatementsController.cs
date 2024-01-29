using ForAccountRecords.Api.ApplicationTasks;
using ForAccountRecords.Application.Helpers;
using ForAccountRecords.Application.IConfiguration;
using ForAccountRecords.Application.Services;
using ForAccountRecords.Domain.Dtos.ServiceDtos.FinancialStatementsDtos.Request;
using ForAccountRecords.Domain.Models.GeneralModels;
using ForAccountRecords.Domain.ViewModels.InternalViewModels.FinaincialStatementViewModels;
using ForAccountRecords.Infrastructure.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ForAccountRecords.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FinancialStatementsController : ControllerBase
    {

        private IFinancialStatementService _finStatementService;
        private readonly IAppSettingGenerator _appSetting;
        private readonly ILogHelper _logger;
        readonly string classname = nameof(FinancialStatementsController);

        public FinancialStatementsController(
          IAppSettingGenerator appSettingGenerator,
          ILogHelper logger,
          IFinancialStatementService finStatementService
          )
        {

            _appSetting = appSettingGenerator;
            _logger = logger;
            _finStatementService = finStatementService;
        }

        [HttpGet("GetIncomeStatement")]
        public async Task<IActionResult> GetIncomeStatement(FinancialStatementRequestViewModel input)
        {
            var methodname = $"{classname}/{nameof(GetIncomeStatement)}";
            var requestId = GeneralHelpers.GetNewRequestId();
            var Ip = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            var appsetings = _appSetting.Generate();
            _logger.LogInformation(requestId, "New Process", Ip, methodname);
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
               
                var userId = long.Parse(User.FindFirst("Sid").Value);
                var payload = new IncomeStatementRequestDto()
                {
                    AppSettings = appsetings,
                    Ip = Ip,
                    RequestId = requestId,
                    InputData = input,
                    UserId = userId
                };
                var response = _finStatementService.IncomeStatement(payload);
                _logger.LogInformation(requestId, "Process Sucessful", Ip, methodname);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(requestId, "Process Failed", Ip, methodname, ex);
                return BadRequest("Failed");
            }


        }

    }
}
