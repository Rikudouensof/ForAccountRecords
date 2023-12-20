using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForAccountRecords.Domain.ViewModels.UserManagementViewModels
{
  public class LoginViewModel
  {
    [Required]
    [Display(Name = "UserName or Email Address")]
    public string UserIdentity { get; set; }


    [Required]
    [Display(Name = "Password")]
    public string Password { get; set; }

  }
}
