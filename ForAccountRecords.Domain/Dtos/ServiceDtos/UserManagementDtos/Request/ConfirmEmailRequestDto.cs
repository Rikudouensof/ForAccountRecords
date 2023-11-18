using ForAccountRecords.Domain.ViewModels.UserManagementViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForAccountRecords.Domain.Dtos.ServiceDtos.UserManagementDtos.Request
{
  public class ConfirmEmailRequestDto : BaseRequestDto
  {
    [Required]
    public ConfirmEmailViewModel InputData { get; set; }
  }
}
