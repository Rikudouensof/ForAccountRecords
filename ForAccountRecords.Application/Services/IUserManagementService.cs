using ForAccountRecords.Domain.Dtos.ServiceDtos.UserManagementDtos.Request;
using ForAccountRecords.Domain.Dtos.ServiceDtos.UserManagementDtos.Response;
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

  }
}
