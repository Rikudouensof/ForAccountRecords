using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForAccountRecords.Domain.ViewModels.InternalViewModels.UserManagementViewModels
{
    public class BasicUserDetailsViewModel
    {
        [Display(Name = "User Id")]
        [Required]
        public string UserId { get; set; }


        [Display(Name = "Username")]
        [Required]
        public string UserName { get; set; }

        [Display(Name = "User Email Address")]
        [Required, EmailAddress]
        public string UserEmail { get; set; }
    }
}
