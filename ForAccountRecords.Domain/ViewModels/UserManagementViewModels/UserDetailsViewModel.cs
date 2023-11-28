using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForAccountRecords.Domain.ViewModels.UserManagementViewModels
{
  public class UserDetailsViewModel : BasicUserDetailsViewModel
  {

    [Required]
    [Display(Name = "User Phone Number")]
    public string PhoneNumber { get; set; }


    [Display(Name = "Joined On")]
    public string JoinedOn { get; set; }


    [Display(Name = "Last Login")]
    public string LastOnlineOn { get; set; }
  }
}
