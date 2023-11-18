using ForAccountRecords.Application.Helpers;
using ForAccountRecords.Application.Services;
using ForAccountRecords.Domain.Constants;
using ForAccountRecords.Domain.Dtos.ServiceDtos.EmailDtos.Request;
using ForAccountRecords.Domain.Dtos.ServiceDtos.UserManagementDtos.Request;
using ForAccountRecords.Domain.Dtos.ServiceDtos.UserManagementDtos.Response;
using ForAccountRecords.Domain.Models.DatabaseModels;
using ForAccountRecords.Infrastructure.Data;
using ForAccountRecords.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForAccountRecords.Infrastructure.Services
{
  public class UserManagementService : IUserManagementService
  {
    private readonly ILogHelper _logger;
    readonly string classname = nameof(SendGridEmailService);
    private readonly ApplicationDbContext _db;
    private readonly IAsymetricEncryption _encypt;
    private readonly IEmailService _emailService;
    public UserManagementService(ILogHelper logger,
      ApplicationDbContext dbcontext,
      IAsymetricEncryption encypt,
      IEmailService emailService
      )
    {
      _logger = logger;
      _db = dbcontext;
      _encypt = encypt;
      _emailService = emailService;
    }

    public ConfirmEmailResponseDto ConfirmEmail(ConfirmEmailRequestDto input)
    {
      var methodname = $"{classname}/{nameof(ConfirmEmail)}";
      var response = new ConfirmEmailResponseDto();
      _logger.LogInformation(input.RequestId, "New Process", input.Ip, methodname);
      try
      {
        var payload = input.InputData;
        var user = _db.Users.Where(m => m.EmailAddress.Equals(payload.EmailAddress)).First();
        if (user.ConfirmationCodeDate < DateTime.Now.AddHours(1))
        {
          _logger.logWarning(input.RequestId, "Process Faild, token expired", input.Ip, methodname);
          response.ResponseCode = GeneralResponse.failureCode;
          response.ResponseMessage = GeneralResponse.failureMessage;
          response.Response = "Token has expired please request for new token";
          return response;
        }
        var inputCode = SymentricEncyption.DecryptString(payload.Code, input.AppSettings);
        var userCode = SymentricEncyption.DecryptString(user.ConfirmationCode, input.AppSettings);
        if (inputCode != userCode)
        {
          _logger.logWarning(input.RequestId, "Process Faild, wrong token", input.Ip, methodname);
          response.ResponseCode = GeneralResponse.failureCode;
          response.ResponseMessage = GeneralResponse.failureMessage;
          response.Response = "Invalid Token";
          return response;
        }
        user.IsEmailConfirmed = true;
        _db.Update(user);
        _db.SaveChanges();
        response.ResponseCode = GeneralResponse.sucessCode;
        response.ResponseMessage = GeneralResponse.sucessMessage;
        response.Response = "Email confirmed, Please login";
        _logger.LogInformation(input.RequestId, "Process Sucessful", input.Ip, methodname);
      }
      catch (TimeoutException ex)
      {
        _logger.LogError(input.RequestId, "Process Faild", input.Ip, methodname, ex);
        response.ResponseCode = GeneralResponse.timeoutCode;
        response.ResponseMessage = GeneralResponse.timeoutMessage;
        response.Response = "Could not confirm email at this time";
      }
      catch (Exception ex)
      {

        _logger.LogError(input.RequestId, "Process Faild", input.Ip, methodname, ex);
        response.ResponseCode = GeneralResponse.failureCode;
        response.ResponseMessage = GeneralResponse.failureMessage;
        response.Response = "Could not confirm email at this time";

      }
      return response;
    }

    public LoginResponseDto LoginUser(LoginRequestDto input)
    {
      var methodname = $"{classname}/{nameof(LoginUser)}";
      var response = new LoginResponseDto();
      _logger.LogInformation(input.RequestId, "New Process", input.Ip, methodname);
      try
      {
        var payload = input.InputData;
        var user = _db.Users.Where(m => m.EmailAddress.Equals(payload.UserIdentity) || m.UserName.Equals(payload.UserIdentity)).First();
        var inputCode = SymentricEncyption.DecryptString(payload.Password, input.AppSettings);
        var encryptedPassword = _encypt.Encrypt(inputCode);
        if (encryptedPassword != user.Password)
        {
          _logger.logWarning(input.RequestId, $"Login Failed for {payload.UserIdentity}: Invalid Password", input.Ip, methodname);
          response.ResponseCode = GeneralResponse.failureCode;
          response.ResponseMessage = GeneralResponse.failureMessage;
          response.Response = "Login Failed, please check the login credentials";
          return response;
        }
        if (!user.IsEmailConfirmed)
        {
          _logger.logWarning(input.RequestId, $"Login Failed for {payload.UserIdentity}: Email not confirmed", input.Ip, methodname);
          response.ResponseCode = GeneralResponse.failureCode;
          response.ResponseMessage = GeneralResponse.failureMessage;
          response.Response = "Login Failed, please confirm your email first";
          return response;
        }
        //JWT Code

        user.LastOnline = DateTime.Now;
        _db.Update(user);
        response.ResponseCode = GeneralResponse.sucessCode;
        response.ResponseMessage = GeneralResponse.sucessMessage;
        response.Response = $"Token:{payload.UserIdentity}";
        _logger.LogInformation(input.RequestId, "Process Sucessful", input.Ip, methodname);
      }
      catch (TimeoutException ex)
      {
        _logger.LogError(input.RequestId, "Process Faild", input.Ip, methodname, ex);
        response.ResponseCode = GeneralResponse.timeoutCode;
        response.ResponseMessage = GeneralResponse.timeoutMessage;
        response.Response = "Login Failed, please check the login credentials";
      }
      catch (Exception ex)
      {
        _logger.LogError(input.RequestId, "Process Faild", input.Ip, methodname, ex);
        response.ResponseCode = GeneralResponse.failureCode;
        response.ResponseMessage = GeneralResponse.failureMessage;
        response.Response = "Login failed, please check the login credentials";

      }
      return response;
    }

    public RegisterResponseDto RegisterUser(RegisterRequestDto input)
    {
      var methodname = $"{classname}/{nameof(RegisterUser)}";
      var response = new RegisterResponseDto();
      _logger.LogInformation(input.RequestId, "New Process", input.Ip, methodname);
      try
      {
        var payload = input.InputData;
        if (payload.Password != payload.RePassword)
        {
          _logger.logWarning(input.RequestId, "Process Faild: Password and RePassword does not match", input.Ip, methodname);
          response.ResponseCode = GeneralResponse.failureCode;
          response.ResponseMessage = GeneralResponse.failureMessage;
          response.Response = "Could not register user at this time: Passwords do not match";
          return response;
        }
        var userEmail = _db.Users.Where(m => m.EmailAddress.Equals(payload.EmailAddress)).FirstOrDefault();
        var userUsername = _db.Users.Where(m => m.EmailAddress.Equals(payload.EmailAddress)).FirstOrDefault();
        if (userEmail is not null)
        {
          _logger.logWarning(input.RequestId, "Process Faild: Password and RePassword does not match", input.Ip, methodname);
          response.ResponseCode = GeneralResponse.failureCode;
          response.ResponseMessage = GeneralResponse.failureMessage;
          response.Response = "Could not register user at this time: Email already exist";
          return response;
        }

        if (userUsername is not null)
        {
          _logger.logWarning(input.RequestId, "Process Faild: Password and RePassword does not match", input.Ip, methodname);
          response.ResponseCode = GeneralResponse.failureCode;
          response.ResponseMessage = GeneralResponse.failureMessage;
          response.Response = "Could not register user at this time: Username already exist";
          return response;
        }
        Random rnd = new Random();
        int myRandomNo = rnd.Next(100000000, 999999999);
        var emailConfirmationCode = SymentricEncyption.EncryptString(myRandomNo.ToString(), input.AppSettings);
        var inputCode = SymentricEncyption.DecryptString(payload.Password, input.AppSettings);
        var encryptedPassword = _encypt.Encrypt(inputCode);


        //SendMail

        var emailPayload = new EmailRequestDto()
        {
          AppSettings = input.AppSettings,
          Ip = input.Ip,
          RequestId = input.RequestId,
          SourceName = input.AppSettings.SendGridSourceName,
          EmailData = new Domain.ViewModels.EmailViewmodel()
          {
            Subject = "Email Confirmation",
            RecipeientEmailAddress = payload.EmailAddress,
            Body = $"Hello {payload.Username}, Your Email Confirmation Code is {emailConfirmationCode}. Please note that this code expires by {DateTime.Now.AddMinutes(-10).ToShortTimeString}",
          }
        };
        _emailService.SendMailAsync(emailPayload);
        //Create User
        var user = new User()
        {
          EmailAddress = payload.EmailAddress,
          ConfirmationCodeDate = DateTime.Now,
          Password = encryptedPassword,
          IsDeleted = false,
          FirstName = payload.FirstName,
          MiddleName = payload.MiddleName,
          LastName = payload.LastName,
          UserName = payload.Username,
          PhoneNumber = payload.PhoneNumber,
          IsNewsLetter = payload.isNewsLetterEnabled,
          IsEmailConfirmed = false,
          JoinedOn = DateTime.Now,
          LastOnline = DateTime.Now,
          ConfirmationCode = emailConfirmationCode
        };
        _db.Users.Add(user);
        _db.SaveChanges();
        response.ResponseCode = GeneralResponse.sucessCode;
        response.ResponseMessage = GeneralResponse.sucessMessage;
        response.Response = $"Account Created Sucessfully, please check your mail to confirm your email address";
        _logger.LogInformation(input.RequestId, "Process Sucessful", input.Ip, methodname);
      }
      catch (TimeoutException ex)
      {
        _logger.LogError(input.RequestId, "Process Faild", input.Ip, methodname, ex);
        response.ResponseCode = GeneralResponse.timeoutCode;
        response.ResponseMessage = GeneralResponse.timeoutMessage;
        response.Response = "Could not create your account at this time, please try again";
      }
      catch (Exception ex)
      {

        _logger.LogError(input.RequestId, "Process Faild", input.Ip, methodname, ex);
        response.ResponseCode = GeneralResponse.failureCode;
        response.ResponseMessage = GeneralResponse.failureMessage;
        response.Response = "Could not create your account at this time, please try again";

      }
      return response;
    }
  }
}
