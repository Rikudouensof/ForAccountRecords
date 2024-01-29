using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForAccountRecords.Domain.ViewModels.InternalViewModels.UserManagementViewModels
{
    public class ConfirmEmailViewModel
    {

        [EmailAddress]
        [Required]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        [Required]
        [Display(Name = "Confirmation Code")]
        public string Code { get; set; }

    }
}
