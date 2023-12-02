using ForAccountRecords.Domain.Dtos.ServiceDtos.UserManagementDtos.Request;
using ForAccountRecords.Domain.Dtos.ServiceDtos.UserManagementDtos.Response;
using ForAccountRecords.Domain.Models.GeneralModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForAccountRecords.Application.Services
{
  public interface IUserManagementService
  {


    public RegisterResponseDto RegisterUser(RegisterRequestDto input);
    public LoginResponseDto LoginUser(LoginRequestDto input);
    public ConfirmEmailResponseDto ConfirmEmail(ConfirmEmailRequestDto input);

    public ResetPasswordResponseDto ResetPassword(ResetPasswordRequestDto input);

    public ForgotPasswordResponseDto ForgotPassword(ForgotPasswordRequestDto input);

    public DeleteAccountResponseDto DeleteAccount(DeleteAccountRequestDto input);

    public ConfirmDeleteAccountResponseDto ConfirmDeleteAccount(ConfirmDeleteAccountRequestDto input);

    public GetBasicUserInfoResponseDto GetBasicUserInfo(GetBasicUserInfoRequestDto input);

    public GetUserDetailsResponseDto GetUserDetails(GetUserDetailsRequestDto input);

    public string HashPasswordTest(string password, AppSettings appSettings);
  }
}
