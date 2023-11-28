using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForAccountRecords.Domain.ViewModels.UserManagementViewModels
{
  public class UserByIdViewModel
  {
    [Required]
    [Display(Name = "User Id")]
    public int UserId { get; set; }
  }
}
