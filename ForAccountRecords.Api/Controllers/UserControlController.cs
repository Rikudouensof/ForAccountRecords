using ForAccountRecords.Api.ApplicationTasks;
using ForAccountRecords.Application.Helpers;
using ForAccountRecords.Application.IConfiguration;
using ForAccountRecords.Domain.Dtos.EndPointDtos.EntryEndpointDtos;
using ForAccountRecords.Domain.Dtos.EndPointDtos.UserContactEndpointDtos;
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
    [Authorize]
    public class UserControlController : ControllerBase
    {

        private IUnitOfWork _unitOfWork;
        private readonly IAppSettingGenerator _appSetting;
        private readonly ILogHelper _logger;
        readonly string classname = nameof(UserControlController);

        public UserControlController(
          IAppSettingGenerator appSettingGenerator,
          ILogHelper logger,
          IUnitOfWork unitOfWork
          )
        {

            _appSetting = appSettingGenerator;
            _logger = logger;
            _unitOfWork = unitOfWork;
        }



        [HttpGet("GetAllEntry")]
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
                var response = await _unitOfWork.Entries.All(baseRequestData);
                _logger.LogInformation(requestId, "Process Sucessful", Ip, methodname);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(requestId, "Process Failed", Ip, methodname, ex);
                return BadRequest("Failed");
            }


        }




        [HttpPost("GetSingleEntry")]
        public async Task<IActionResult> GetSingleEntry([FromBody] EntryEndpointSingleDto input)
        {
            var methodname = $"{classname}/{nameof(GetSingleEntry)}";
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
                var response = await _unitOfWork.Entries.GetById(input.Id, baseRequestData);

                _logger.LogInformation(requestId, "Process Sucessful", Ip, methodname);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(requestId, "Process Failed", Ip, methodname, ex);
                return BadRequest("Failed");
            }
        }


        [HttpPost("AddEntry")]
        public async Task<IActionResult> AddEntry([FromBody] EntryEndpointDataDto input)
        {
            var methodname = $"{classname}/{nameof(AddEntry)}";
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
                var payload = new Entry()
                {
                    Id = input.Id,
                    Name = input.Name,
                    Amount = input.Amount,
                    Description = input.Description,
                    Date = input.Date,
                    EntryTypeId = input.EntryTypeId,
                    RefrenceNumber = input.RefrenceNumber,
                    SubTransactionClassificationId = input.SubTransactionClassificationId,
                    UserId = input.UserId,
                    Units = input.Units
                };
                var response = await _unitOfWork.Entries.Add(payload, baseRequestData);
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


        [HttpPost("EditEntry")]
        public async Task<IActionResult> EditEntry([FromBody] EntryEndpointDataDto input)
        {
            var methodname = $"{classname}/{nameof(EditEntry)}";
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
                var payload = new Entry()
                {
                    Id = input.Id,
                    Name = input.Name,
                    Amount = input.Amount,
                    Description = input.Description,
                    Date = input.Date,
                    EntryTypeId = input.EntryTypeId,
                    RefrenceNumber = input.RefrenceNumber,
                    SubTransactionClassificationId = input.SubTransactionClassificationId,
                    UserId = input.UserId,
                    Units = input.Units
                };
                var response = await _unitOfWork.Entries.Update(payload, baseRequestData);
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


        [HttpPost("DeleteEntry")]
        public async Task<IActionResult> DeleteEntry([FromBody] EntryEndpointSingleDto input)
        {
            var methodname = $"{classname}/{nameof(DeleteEntry)}";
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

                var response = await _unitOfWork.Entries.Delete(input.Id, baseRequestData);
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


        [HttpGet("GetAllEntryType")]
        public async Task<IActionResult> GetAllEntryType()
        {
            var methodname = $"{classname}/{nameof(GetAllEntryType)}";
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
                var response = await _unitOfWork.EntryTypes.All(baseRequestData);
                _logger.LogInformation(requestId, "Process Sucessful", Ip, methodname);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(requestId, "Process Failed", Ip, methodname, ex);
                return BadRequest("Failed");
            }


        }

        [HttpGet("GetAllSubTransactionCalassification")]
        public async Task<IActionResult> GetAllSubTransactionCalassification()
        {
            var methodname = $"{classname}/{nameof(GetAllSubTransactionCalassification)}";
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
                var response = await _unitOfWork.SubTransactionClassifications.All(baseRequestData);
                _logger.LogInformation(requestId, "Process Sucessful", Ip, methodname);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(requestId, "Process Failed", Ip, methodname, ex);
                return BadRequest("Failed");
            }


        }

        [HttpGet("GetAllTransactionClassification")]
        public async Task<IActionResult> GetAllTransactionClassification()
        {
            var methodname = $"{classname}/{nameof(GetAllTransactionClassification)}";
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
                var response = await _unitOfWork.TransactionClassifications.All(baseRequestData);
                _logger.LogInformation(requestId, "Process Sucessful", Ip, methodname);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(requestId, "Process Failed", Ip, methodname, ex);
                return BadRequest("Failed");
            }
        }


        [HttpGet("GetAllTransactionType")]
        public async Task<IActionResult> GetAllTransactionType()
        {
            var methodname = $"{classname}/{nameof(GetAllTransactionType)}";
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




        [HttpGet("GetAllUserContact")]
        public async Task<IActionResult> GetAllUserContact()
        {
            var methodname = $"{classname}/{nameof(GetAllUserContact)}";
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
                var response = await _unitOfWork.UserContacts.All(baseRequestData);
                _logger.LogInformation(requestId, "Process Sucessful", Ip, methodname);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(requestId, "Process Failed", Ip, methodname, ex);
                return BadRequest("Failed");
            }


        }


        [HttpPost("GetSingleUserContact")]
        public async Task<IActionResult> GetSingleUserContact([FromBody] UserContactEndpointSingleDto input)
        {
            var methodname = $"{classname}/{nameof(GetSingleUserContact)}";
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
                var response = await _unitOfWork.UserContacts.GetById(input.Id, baseRequestData);

                _logger.LogInformation(requestId, "Process Sucessful", Ip, methodname);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(requestId, "Process Failed", Ip, methodname, ex);
                return BadRequest("Failed");
            }
        }


        [HttpPost("AddUserContact")]
        public async Task<IActionResult> AddUserContact([FromBody] UserContactEndpointDataDto input)
        {
            var methodname = $"{classname}/{nameof(AddUserContact)}";
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
                var payload = new UserContact()
                {
                    Id = input.Id,
                    facbookUrl = input.facbookUrl,
                    Address = input.Address,
                    FullName = input.FullName,
                    EmailAddress = input.EmailAddress,
                    linkedInUrl = input.linkedInUrl,
                    PhoneNumber = input.PhoneNumber,
                    SecondPhoneNumber = input.SecondPhoneNumber,
                    ThirdPhoneNumber = input.ThirdPhoneNumber,
                    UserContactsCategoryId = input.UserContactsCategoryId,
                    UserId = input.UserId,
                    XUrl = input.XUrl,
                    Website = input.Website

                };
                var response = await _unitOfWork.UserContacts.Add(payload, baseRequestData);
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


        [HttpPost("EditUserContact")]
        public async Task<IActionResult> EditUserContact([FromBody] UserContactEndpointDataDto input)
        {
            var methodname = $"{classname}/{nameof(EditUserContact)}";
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
                var payload = new UserContact()
                {
                    Id = input.Id,
                    facbookUrl = input.facbookUrl,
                    Address = input.Address,
                    FullName = input.FullName,
                    EmailAddress = input.EmailAddress,
                    linkedInUrl = input.linkedInUrl,
                    PhoneNumber = input.PhoneNumber,
                    SecondPhoneNumber = input.SecondPhoneNumber,
                    ThirdPhoneNumber = input.ThirdPhoneNumber,
                    UserContactsCategoryId = input.UserContactsCategoryId,
                    UserId = input.UserId,
                    XUrl = input.XUrl,
                    Website = input.Website

                };
                var response = await _unitOfWork.UserContacts.Update(payload, baseRequestData);
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


        [HttpPost("DeleteUserContact")]
        public async Task<IActionResult> DeleteUserContact([FromBody] UserContactEndpointSingleDto input)
        {
            var methodname = $"{classname}/{nameof(DeleteUserContact)}";
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

                var response = await _unitOfWork.UserContacts.Delete(input.Id, baseRequestData);
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



        [HttpGet("GetAllUserContactsCategory")]
        public async Task<IActionResult> GetAllUserContactsCategory()
        {
            var methodname = $"{classname}/{nameof(GetAllUserContactsCategory)}";
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
                var response = await _unitOfWork.UserContactsCategories.All(baseRequestData);
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
