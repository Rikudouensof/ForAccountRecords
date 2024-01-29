using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForAccountRecords.Domain.ViewModels.InternalViewModels.UserManagementViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "UserName")]
        public string Username { get; set; }

        [EmailAddress]
        [Required]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        [Phone]
        [Display(Name = "Phone Number")]
        public string? PhoneNumber { get; set; }


        [Display(Name = "First Name")]
        public string? FirstName { get; set; }


        [Display(Name = "Middle Name")]
        public string? MiddleName { get; set; }


        [Display(Name = "Last Name")]
        public string? LastName { get; set; }

        [PasswordPropertyText]
        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [PasswordPropertyText]
        [Required]
        [Display(Name = "Confirm Password")]
        public string RePassword { get; set; }

        [Required]
        [Display(Name = "Recieve NewsLetter")]
        public bool isNewsLetterEnabled { get; set; }

    }
}
