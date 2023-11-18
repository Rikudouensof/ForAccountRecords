using ForAccountRecords.Domain.ViewModels.UserManagementViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForAccountRecords.Domain.Dtos.ServiceDtos.UserManagementDtos.Request
{
  

  public class LoginRequestDto : BaseRequestDto
  {
    [Required]
    public LoginViewModel InputData { get; set; }
  }
}
