using System.ComponentModel.DataAnnotations;


namespace ForAccountRecords.Domain.ViewModels.InternalViewModels.UserManagementViewModels
{
    public class ResetPasswordViewModel
    {
        [Required]
        [Display(Name = "Reset Code")]
        public string Code { get; set; }

        [Required]
        [Display(Name = "UserName or Email Address")]
        public string UserIdentity { get; set; }


        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Re-Password")]
        public string RePassword { get; set; }

    }
}
